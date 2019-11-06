using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Basics.Downloaders;
using TagLib;
namespace Basics
{
    namespace Formats
    {
        public class Video_info
        {

            public VideoInfo_Struct info;

            public List<Format_Stream> streams = new List<Format_Stream>();

            private void Sort_stream()
            {

                foreach (var stream in streams.Where(x => x.info.mixed == true))
                {
                    switch (stream.info.quality)
                    {
                        case "low":
                            stream.info.bitrate = 1;
                            break;
                        case "medium":
                            stream.info.bitrate = 2;
                            break;
                        case "high":
                            stream.info.bitrate = 3;
                            break;
                    }
                }
                streams = streams.OrderByDescending(x => x.info.bitrate).ToList();
            }

            private string Get_metadata(string video_id, Player_Info session)
            {
                string metadata_url = "https://www.youtube.com/get_video_info?video_id=" + video_id + "&sts=" + session.sts+"&hl=ee" + "&el=";
                HtmlDownloader downloader = new HtmlDownloader();
                string url = metadata_url + "embedded";
                string metadata_string = downloader.DownloadHtml(url);
                if (metadata_string.Contains("status=fail"))
                {
                    url = metadata_url + "detailpage";
                    metadata_string = downloader.DownloadHtml(url);
                    if (metadata_string.Contains("status=fail"))
                    {
                        if (metadata_string.Contains("Vanuse+kinnitamiseks+logige+sisse"))
                        {
                            Console.WriteLine("Metadata Gathering failed");
                            throw new MetadataException("Metadata Gathering failed. Age restricted");
                        }
                        else
                        {
                            Console.WriteLine("Metadata Gathering failed");
                            throw new MetadataException("Metadata Gathering failed");
                        }
                
                    }

                }
                if(metadata_string.Contains("UNPLAYABLE"))
                {
                    Console.WriteLine("Unplayable");
                    metadata_string = downloader.DownloadHtml(metadata_url+"detailpage");
                }
                return metadata_string;
            }



            private void Get_artists()
            {
                string[] parts = Regex.Split(info.title, " - ");
                info.name = parts[parts.Length - 1];
                if (parts.Length > 2)
                {
                    if (parts[1].Contains("&"))
                    {
                        info.artists = parts[1].Split('&');
                    }
                    info.artists = new string[1];
                    info.artists.SetValue(parts[1], 0);
                }
                else
                {

                    if (parts[0].Contains("&"))
                    {
                        info.artists = parts[0].Split('&');
                    }
                    info.artists = new string[1];
                    info.artists.SetValue(parts[0], 0);
                }
            }

            private Dictionary<string, string> Parse_metadata(string metadata_string)
            {
                string[] value_array = metadata_string.Split('&');
                Dictionary<string, string> value_dict = new Dictionary<string, string>();
                foreach (string value in value_array)
                {
                    value_dict.Add(value.Split('=')[0], value.Split('=')[1]);
                }
                Dictionary<string, string> metadata_dict = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> value_pair in value_dict)
                {
                    metadata_dict.Add(Uri.UnescapeDataString(value_pair.Key), Uri.UnescapeDataString(value_pair.Value));
                }
                return metadata_dict;
            }

            private void Get_adaptive_fmts(Dictionary<string,string> metadata_dict, Player_Info dechipher)
            {
                string adaptive_fmts = metadata_dict["adaptive_fmts"] + ",";
                MatchCollection match_formats = Regex.Matches(adaptive_fmts, ".+?(?=,)");
                foreach (Match match in match_formats)
                {
                    Dictionary<string, string> format = new Dictionary<string, string>();
                    string[] format_values = match.ToString().Trim(',').Split('&');
                    foreach (string value in format_values)
                    {
                        format.Add(Uri.UnescapeDataString(Uri.UnescapeDataString(value.Split('=')[0])), Uri.UnescapeDataString(Uri.UnescapeDataString(value.Split('=')[1])));
                    }
                    format.Add("mixed", "false");
                    if (format.ContainsKey("s"))
                    {
   
                            format["url"] += "&sig=" + dechipher.Decipher(format["s"]);
                        
                    }
                    Format_Stream stream = new Format_Stream(format);
                    streams.Add(stream);



                }
             
            }

            private void Get_encoded_fmts(Dictionary<string, string> metadata_dict, Player_Info dechipher)
            {
                string url_encoded_fmt_stream_map = metadata_dict["url_encoded_fmt_stream_map"] + ",";
                MatchCollection match_formats = Regex.Matches(url_encoded_fmt_stream_map, ".+?(?=,)");
                foreach (Match match in match_formats)
                {
                    Dictionary<string, string> format = new Dictionary<string, string>();
                    string[] format_values = match.ToString().Trim(',').Split('&');
                    foreach (string value in format_values)
                    {
                        format.Add(Uri.UnescapeDataString(Uri.UnescapeDataString(value.Split('=')[0])), Uri.UnescapeDataString(Uri.UnescapeDataString(value.Split('=')[1])));
                    }
                    format.Add("mixed", "true");
                    if (format.ContainsKey("s"))
                    {
                
                            format["url"] += "&sig=" + dechipher.Decipher(format["s"]);
                        
                    }
                    Format_Stream stream = new Format_Stream(format);
                    streams.Add(stream);

                }
           
            }

            private void Get_sources(Dictionary<string, string> metadata_dict, Player_Info dechipher)
            {

                Get_adaptive_fmts(metadata_dict, dechipher);

                Get_encoded_fmts(metadata_dict, dechipher);
           
         

            }

            public Video_info(string video_id)
            {
                Console.WriteLine("[Getting metadata]");
                try
                {
                   
                    info.player = new Player_Info("https://www.youtube.com/watch?v=" + video_id);
                    info.id = video_id;
                    info.title = info.player.title;
                    info.channel = info.player.channel;
                    info.image_url = "https://i.ytimg.com/vi/" + info.id + "/hqdefault.jpg";
                    Console.WriteLine("Getting metadata");
                    string metadata = Get_metadata(video_id, info.player);
                  
                    var metadict = Parse_metadata(metadata);
                    Get_sources(metadict, info.player);
           
                    if (info.title != "")
                    {
                        if (info.title.Contains(" - "))
                        {
                            Get_artists();

                        }
                        else
                        {
                            info.name = info.title;
                            info.artists = new string[1];
                            info.artists.SetValue(info.channel, 0);
                        }

                    }
                    
                }
                catch (MetadataException exception)
                {
                    throw exception;
                }
            }

            public async Task Video_infoAsync(string video_id)
            {
       
                info.player = new Player_Info();
                await info.player.PlayerAsync("https://www.youtube.com/watch?v=" + video_id);
                info.id = video_id;
                info.title = info.player.title;
                info.channel = info.player.channel;
                info.image_url = "https://i.ytimg.com/vi/" + info.id + "/hqdefault.jpg";
                info.file_name = string.Join("", info.title.Split(Path.GetInvalidFileNameChars()));
                try
                {
                    Console.WriteLine("Getting metadata");
                    string metadata = Get_metadata(video_id, info.player);
                    await Task.Run(() =>
                    {
                        var metadict = Parse_metadata(metadata);

                        Get_sources(metadict, info.player);
                        
                            
                        

                 
                        if (info.title != "")
                        {
                            if (info.title.Contains(" - "))
                            {
                                Get_artists();

                            }
                            else
                            {
                                info.name = info.title;
                                info.artists = new string[1];
                                info.artists.SetValue(info.channel, 0);
                            }
                        }
                       
                    });
    
            
                }
                catch (MetadataException e)
                {
                    throw e;
                }
                Sort_stream();


            }

         

            public Video_info() { }

        }
    }
  
}
