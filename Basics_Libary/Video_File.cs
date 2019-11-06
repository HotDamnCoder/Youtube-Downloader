using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Basics.Downloaders;
using Basics.Formats;
using TagLib;
using FFMpegSharp;
using System.IO;



namespace Basics
{
    namespace Files
    {
        public class Video_file
        {
            public event VideoFileDoneDelegate VideoFileDone;

            public Video_info video_info;

            public string path;

            public string File_name;

            public string extension;

            public  void Tagger()
            {
                Console.WriteLine("[Tagging file]");
                try
                {
                    TagLib.File tag_file = TagLib.File.Create(path + File_name + extension);
                    



                    tag_file.Tag.Title = video_info.info.name;
                    tag_file.Tag.Performers = video_info.info.artists;
                    tag_file.Tag.Album = video_info.info.name;

                    IPicture[] pictures = { Download_thumbnail() };
                    tag_file.Tag.Pictures = pictures;
                    System.IO.File.Delete(path + "thumbnail.jpg");
                    tag_file.Save();
                }
                catch (UnsupportedFormatException e )
                {
                    throw e;
                }
               
                

            }

            public Picture Download_thumbnail()
            {
                FileDownloader downloader = new FileDownloader(video_info.info.image_url, "thumbnail", path, ".jpg");
                downloader.DownloadFIle().Wait();
                return new Picture(downloader.path);
            }

            public Format_Stream Select_stream(string format, string quality_word, string type)
            {
                Format_Stream selected_stream;
                switch (quality_word)
                {
                    case "best":

                        if(video_info.streams.Any(x=> x.info.file == format && x.info.type == type))
                        {
                            selected_stream = video_info.streams.Where(x => x.info.file == format && x.info.type == type).Last();
                        }
                        else
                        {
                            throw new UnavailableFormatException("Chosen format: " + format);
                        }
                        break;
                    case "worst":
                        if (video_info.streams.Any(x => x.info.file == format && x.info.type == type))
                        {
                            selected_stream = video_info.streams.Where(x => x.info.file == format && x.info.type == type).First();
                        }
                        else
                        {
                            throw new UnavailableFormatException("Chosen format: " + format);
                        }
                        break;
                    default:
                        if (video_info.streams.Any(x => x.info.file == format && x.info.type == type))
                        {
                            selected_stream = video_info.streams.Where(x => x.info.file == format && x.info.type == type).Last();
                        }
                        else
                        {
                            throw new UnavailableFormatException("Chosen format: " + format);
                        }
                        break;

                }
                return selected_stream;



            }

            

            public async Task Download_file(Format_Stream stream)
            {

                string request_url = stream.info.url;
                File_name = video_info.info.file_name;
                extension = stream.info.file;
                FileDownloader downloader = new FileDownloader(request_url, File_name, path, extension);
                try
                {
                    await downloader.DownloadFIle();

                }
                catch (WebException e)
                {
                    throw e;
                }



            }

            public async Task Video_fileAsync(string video_id)
            {
                await video_info.Video_infoAsync(video_id);
                File_name = video_info.info.file_name;
                VideoFileDone?.Invoke(this);

            }

            public Video_file(string video_id, string path, string format)
            {
                try
                {
                    this.path = path;
                    extension = format;
                    video_info = new Video_info(video_id);
                    File_name = video_info.info.file_name;
                    
                }
                catch (MetadataException e)
                {
                    throw e;
                }

            }

            public Video_file(string path, VideoFileDoneDelegate Handler)
            {
                this.path = path;
                video_info = new Video_info();
                VideoFileDone += Handler;
            }



        }
    }
}
