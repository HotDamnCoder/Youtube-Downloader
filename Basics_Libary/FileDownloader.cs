using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace Basics
{
    namespace Downloaders
    {
        public class FileDownloader
        {
            FileStream File;

            public string request_url;

            public string File_name;

            public string path;

            event Download DownloadStarted;

            event Download DownloadCompleted;

            event Download DownloadProgressChanged;

            private void DownloadStartedHandler(Stopwatch Timer)
            {
                Console.WriteLine("Starting to download \"" + File_name + "\"");
                Timer.Start();
            }

            private void DownloadCompletedHandler(Stopwatch Timer)
            {
                Console.WriteLine("\nDownload completed : \"" + File_name + "\"");
                Timer.Reset();
                File = null;
            }

            private void DownloadProgressChangedHandler(Stopwatch Timer)
            {
                Timer.Stop();
                double s = Timer.Elapsed.TotalSeconds;
                float dl = (float)(1048576 / s) / 1048576;
                Console.Write("\rDownloading at " + dl.ToString("F3") + " MB/S");
                Timer.Restart();
            }

            long TestRequest()
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(request_url);
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                long size = Response.ContentLength;
                Response.Close();
                return size;

            }

            HttpWebRequest GetRequest(long downloaded)
            {
                HttpWebRequest Request = WebRequest.CreateHttp(request_url);
                Request.AddRange(downloaded, downloaded + 1048576);
                return Request;
            }

            byte[] GetResponse(HttpWebRequest request)
            {

                HttpWebResponse Response = (HttpWebResponse)request.GetResponse();
                BinaryReader Reader = new BinaryReader(Response.GetResponseStream());
                byte[]chunk = Reader.ReadBytes(1048576);
                Reader.Close();
                Response.Close();
                return chunk;

            }

            void WriteFIle(byte[] chunk)
            {
                File.Write(chunk, 0, chunk.Length);
            }

            public async Task DownloadFIle()
            {
                long size;
                try
                {
                    size = TestRequest();
                }
                catch (WebException e)
                {
                    File.Close();
                    System.IO.File.Delete(path);
                    throw new ForbiddenUrlException("Forbidden url:" + e.Message);
                }
                long downloaded = 0;
                Stopwatch Timer = new Stopwatch();
                await Task.Run(() =>
                {
                    DownloadStarted(Timer);

                    while (downloaded < size)
                    {
                        WriteFIle(GetResponse(GetRequest(downloaded)));
                        downloaded += 1048576;
                        DownloadProgressChanged(Timer);
                    }
                    File.Close();
                    DownloadCompleted(Timer);

                });
            }

            public FileDownloader(string request_url, string File_name, string path, string extension)
            {
                this.path = path + File_name + extension;
                this.File_name = File_name;
                this.request_url = request_url;
                DownloadStarted += new Download(DownloadStartedHandler);
                DownloadProgressChanged += new Download(DownloadProgressChangedHandler);
                DownloadCompleted += new Download(DownloadCompletedHandler);
                try
                {
                    File = System.IO.File.Create(this.path);
                }
                catch (IOException)
                {

                    Console.WriteLine("Please close your files");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadKey();
                    File = System.IO.File.Create(this.path);
                }
            }
        }
    }

}
