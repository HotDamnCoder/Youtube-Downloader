using System.IO;
using System.Net;

namespace Basics
{
    namespace Downloaders
    {
        public class HtmlDownloader {
        
            private HttpWebRequest GetRequest(string request_url)
            {
                HttpWebRequest Request = WebRequest.CreateHttp(request_url);
                Request.ContentType = "text/html; charset=utf-8";
                return Request;
            }

            private string GetResponseInString(HttpWebRequest Request)
            {
                try
                {
                    
                    HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                    StreamReader Reader = new StreamReader(Response.GetResponseStream());
                    string html = Reader.ReadToEnd(); //timeout
                    Response.Close();
                    return html;
                }
                catch (WebException e)
                {
                    throw e;
                }
            }

            public string DownloadHtml(string request_url)
            {
                return GetResponseInString(GetRequest(request_url));
            }

            public HtmlDownloader(string request_url)
            {
                DownloadHtml(request_url);
            }
            public HtmlDownloader()
            {

            }
        }
    }

}
