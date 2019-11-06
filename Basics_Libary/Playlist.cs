using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using Basics.Downloaders;
using Basics.Files;
using TagLib;

namespace Basics
{
    namespace Files
    {
        public  class Playlist
        {
            public event VideoFileDoneDelegate PlayListVideoFileDone;

            public string playlist_title;

            public List<Video_file> video_Files = new List<Video_file>();

            public List<string> video_ids = new List<string>();

            public void Tag_playlist()
            {
                try
                {
                    foreach (Video_file f in video_Files)
                    {
                        f.Tagger();
                    }
                }
                catch (UnsupportedFormatException e)
                {
                    throw e;
                }

            }



            private string GetFront_page(string list, HtmlDownloader downloader)
            {
                return downloader.DownloadHtml("https://www.youtube.com/playlist?list=" + list);
            }

            private string GetContinuation(string continuation, HtmlDownloader downloader)
            {
                return downloader.DownloadHtml("https://www.youtube.com" + continuation);
            }

            /*public List<Video_file> Get_VideoFile(List<string> video_ids, string path)
            {
                List<Video_file> video_Files = new List<Video_file>();
                Console.WriteLine("Getting videofiles");
                Dictionary<string, Task> video_file_tasks = new Dictionary<string, Task>();

                foreach (string id in video_ids)
                {


                    Video_file video_File = new Video_file(path,null);
                    video_Files.Add(video_File);
                    video_File.video_info.info.positsion = video_ids.FindIndex(x => x == id) + 1;
                    var file = Task.Run(() => video_File.video_info.Video_infoAsync(id));
                    video_file_tasks.Add(id, file);

                }
                try
                {
                    Console.WriteLine("waiting...");

                    Task.WaitAll(video_file_tasks.Values.ToArray());
                }
                catch (AggregateException)
                {

                    Dictionary<string, Task> faulted = video_file_tasks.Where(x => x.Value.Exception != null).ToDictionary(x => x.Key, x => x.Value);
                    foreach (var c in faulted)
                    {
                        Console.WriteLine(c.Key);
                        if (c.Value.Exception.InnerException.Message == "Metadata Gathering failed")
                        {
                            int index = video_Files.FindIndex(x => x.video_info.info.id == c.Key);
                            video_Files.RemoveAt(index);
                        }
                        else
                        {

                        }
                    }

                }
                return video_Files;

            }*/

            public async Task<List<Video_file>> Get_VideoFileAsync(List<string> video_ids, string path)
            {
                
                List<Video_file> video_Files = new List<Video_file>();
                Console.WriteLine("Getting videofiles");
                Dictionary<string, Task<Video_file>> video_file_tasks = new Dictionary<string, Task<Video_file>>();
                await Task.Run(() =>
                {
                    foreach (string id in video_ids)
                    {

      
                            Video_file video_File = new Video_file(path, null);
                            video_Files.Add(video_File);
                            video_File.video_info.info.positsion = video_ids.FindIndex(x => x == id) + 1;
                            var file = Task.Run(async () =>
                            {
                                await video_File.video_info.Video_infoAsync(id);
                                return video_File;
                            });
                            video_file_tasks.Add(id, file);
          
   


                    }
                });
                while (video_file_tasks.Any())
                {
                    Task<Video_file> completedTask = await Task.WhenAny(video_file_tasks.Values.ToArray());
                    try
                    {
                        PlayListVideoFileDone(completedTask.Result);
                        video_file_tasks.Remove(video_file_tasks.Where(x => x.Value == completedTask).First().Key);
                    }
                    catch (AggregateException)
                    {
                        string faultedKey = video_file_tasks.Where(x => x.Value == completedTask).First().Key;
                        video_file_tasks.Remove(faultedKey);
                        Video_file faulted = video_Files.Find(x => x.video_info.info.id == faultedKey);
                        faulted.video_info.info.title = "Unavailable video";
                        PlayListVideoFileDone(faulted);

                    }

                }
                return video_Files;

            }

            public async Task<List<Video_file>> Get_VideoFile2(List<string> video_ids, string path, string format)
            {
                List<Video_file> video_Files = new List<Video_file>();
                Console.WriteLine("Getting videofiles");
                Dictionary<string, Task> video_file_tasks = new Dictionary<string, Task>();
                return await Task.Run(() =>
                {
                    Parallel.ForEach(video_ids, (id) =>
                    {

                        try
                        {
                            Video_file video_File = new Video_file(id, path, format);
                            video_File.video_info.info.positsion = video_ids.FindIndex(x => x == id) + 1;
                            video_Files.Add(video_File);

                        }
                        catch (MetadataException)
                        {

                        }
                    });
                    return video_Files;
                });
            }
      
            private List<Match> Match_Videos(string html, string pattern, List<Match> VideoList)
            {
                //"pl-video yt-uix-tile.+?(?=.u003e)"
                //"tr class=\"pl-video yt-uix-tile.+?(?=>)"
                MatchCollection VideoMatchCollection = Regex.Matches(html, pattern);
                Match[] VideoMatchArray = new Match[VideoMatchCollection.Count];
                VideoMatchCollection.CopyTo(VideoMatchArray, 0);
                List<Match> VideoMatchList = VideoMatchArray.ToList();
                VideoList.AddRange(VideoMatchList);
                return VideoList;


            }

            private void Match_ids(List<Match> VideoList, string pattern)
            { 
                // "data-video-id=\".+?(?=\")"
                // "data-video-id=.\".+?(?=.\")"
                Parallel.ForEach(VideoList.OfType<Match>(), (match) =>
                {
                    if (match.ToString().Contains("Kustutatud video") || match.ToString().Contains("Deleted video"))
                    {
                        Console.WriteLine("Deleted video");
              

                    }
                    else
                    {
                        string id = Regex.Match(match.ToString(), pattern).ToString();
                        id = Regex.Match(match.ToString(), pattern).ToString().Split('"')[1];

                        video_ids.Add(id);
                        Console.WriteLine("[Playlist_video : " + video_ids.Count + "]");






                    }
                });
                video_ids.OrderBy(a => VideoList.FindIndex(x => Regex.Match(x.ToString(), pattern).ToString().Split('"')[1] == a));
            }
            
            public async Task PlayListAsync(string list, string path, int start, int end)
            {
                HtmlDownloader downloader = new HtmlDownloader();
                Console.WriteLine("[Getting playlist info]");
                Console.WriteLine("[Playlist_id : \"" + list + "\"]");
                string html = GetFront_page(list, downloader);
                if (Regex.IsMatch(html, "og:title.+?(?=>)"))
                {
                    List<Match> VideoList = await Task.Run(() =>
                    {


                        string title_match = Regex.Match(html, "og:title.+?(?=>)").ToString().Split('=')[1].Remove(0, 1);
                        playlist_title = title_match.Remove(title_match.Length - 1, 1);
                        Console.WriteLine("[Playlist_id : \"" + playlist_title + "\"]");
                        VideoList = new List<Match>();
                        string continuation;
                        VideoList = Match_Videos(html, "tr class=\"pl-video yt-uix-tile.+?(?=>)", VideoList);
                        if (Regex.IsMatch(html, "data-uix-load-more-href=.+?(?=\")"))
                        {
                            continuation = WebUtility.HtmlDecode(Regex.Match(html, "data-uix-load-more-href=.+?(?=\")").ToString()).Split('"')[1];
                            html = GetContinuation(continuation, downloader);

                            VideoList = Match_Videos(html, "pl-video yt-uix-tile.+?(?=.u003e)", VideoList);

                            while (Regex.IsMatch(html, "data-uix-load-more-href=.\".+?(?=.\")"))
                            {
                                continuation = WebUtility.HtmlDecode(Regex.Match(html, "data-uix-load-more-href=.\".+?(?=.\")").ToString()).Split('"')[1].Remove(0, 1);
                                html = GetContinuation(continuation, downloader);



                                VideoList = Match_Videos(html, "pl-video yt-uix-tile.+?(?=.u003e)", VideoList);






                            }

                        }
                        return VideoList;
                    });
                    try
                    {
                        if (end == 0 && start != 0)
                        {
                            VideoList = VideoList.GetRange(start+1 , VideoList.Count - start);
                        }
                        if (end != 0 && start != 0)
                        {
                            VideoList = VideoList.GetRange(start+1, (end - start));
                        }
                        if (end != 0 && start == 0)
                        {
                            VideoList = VideoList.GetRange(0, (end - start));
                        }

                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        throw e;
                    }

                    Match_ids(VideoList.Where(x => x.ToString().Contains("tr class")).ToList(), "data-video-id=\".+?(?=\")");
                    Match_ids(VideoList.Where(x => !x.ToString().Contains("tr class")).ToList(), "data-video-id=.\".+?(?=.\")");
                    video_Files = await Get_VideoFileAsync(video_ids, path);

                }
                else
                {
                    throw new PrivacyException();
                }

            }

            public Playlist(string list, string path, int start, int finish)
            {
                HtmlDownloader downloader = new HtmlDownloader();
                Console.WriteLine("[Getting playlist info]");
                Console.WriteLine("[Playlist_id : \"" + list + "\"]");
                string html = GetFront_page(list, downloader);
                string title_match = Regex.Match(html, "og:title.+?(?=>)").ToString().Split('=')[1].Remove(0, 1);
                playlist_title = title_match.Remove(title_match.Length - 1, 1);
                Console.WriteLine("[Playlist_id : \"" + playlist_title + "\"]");
                List<Match> VideoList = new List<Match>();
                VideoList = Match_Videos(html, "tr class=\"pl-video yt-uix-tile.+?(?=>)", VideoList);
                if (Regex.IsMatch(html, "data-uix-load-more-href=.+?(?=\")"))
                {
                    string continuation = WebUtility.HtmlDecode(Regex.Match(html, "data-uix-load-more-href=.+?(?=\")").ToString()).Split('"')[1];
                    html = GetContinuation(continuation, downloader);
                    VideoList = Match_Videos(html, "pl-video yt-uix-tile.+?(?=.u003e)", VideoList);



                    while (Regex.IsMatch(html, "data-uix-load-more-href=.\".+?(?=.\")"))
                    {
                        continuation = WebUtility.HtmlDecode(Regex.Match(html, "data-uix-load-more-href=.\".+?(?=.\")").ToString()).Split('"')[1].Remove(0, 1);
                        html = GetContinuation(continuation, downloader);
                        VideoList = Match_Videos(html, "pl-video yt-uix-tile.+?(?=.u003e)", VideoList);






                    }
                }
                Match_ids(VideoList.GetRange(0, 100), "data-video-id=\".+?(?=\")");
                Match_ids(VideoList.GetRange(100, VideoList.Count - 100), "data-video-id=.\".+?(?=.\")");

            }

            public Playlist(VideoFileDoneDelegate Handler)
            {

                PlayListVideoFileDone += Handler;
            }

        }
    }

}
