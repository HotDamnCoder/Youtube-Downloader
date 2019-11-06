using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Basics
{
    namespace Formats
    {
        public class Format_Stream
        {

            public Stream_info info = new Stream_info();

            private void Populate_mixed_info(Dictionary<string, string> format)
            {
                if (format.ContainsKey("s"))
                {
                    info.s = format["s"];
                }
                info.itag = Int32.Parse(format["itag"]);
                info.type = "mixed";
                info.file = Regex.Match(format["type"], "\\/.+?(?=;)").ToString().Replace('/', '.');
                info.codec = format["type"].Split('=')[1].Replace("\"", "");
                info.quality = format["quality"];
                info.url = format["url"];
                info.mixed = true;
                if (info.size_bytes == 0)
                {
                    info.label ="Mixed " + info.quality.ToUpper() + " " + info.file.ToUpper();
                }
                else
                {
                    info.label  = "Mixed " + info.quality.ToUpper() + " " + info.file.ToUpper() + " " + Math.Round((decimal)info.size_bytes / 1048576, 2) + "MB";

                }
            }

            private void Populate_audio_info(Dictionary<string, string> format)
            {
                if (format.ContainsKey("s"))
                {
                    info.s = format["s"];
                }
                info.itag = Int32.Parse(format["itag"]);
                info.type = "audio";
                info.file = Regex.Match(format["type"], "\\/.+?(?=;)").ToString().Replace('/', '.');
                info.codec = format["type"].Split('=')[1].Replace("\"", "");
                info.size_bytes = Int32.Parse(format["clen"]);
                info.bitrate = Int32.Parse(format["bitrate"]);
                info.url = format["url"];
                info.audio_sample_rate = Int32.Parse(format["audio_sample_rate"]);
                info.mixed = false;
                info.label = "Audio " + info.file.ToUpper() + " " + Math.Round((decimal)info.size_bytes / 1048576, 2) + "MB";
            }

            private void Populate_video_info(Dictionary<string, string> format)
            {
                if (format.ContainsKey("s"))
                {
                    info.s = format["s"];
                }
                
                info.itag = Int32.Parse(format["itag"]);
                info.type = "video";
                info.file = Regex.Match(format["type"], "\\/.+?(?=;)").ToString().Replace('/', '.');
                info.codec = format["type"].Split('=')[1].Replace("\"", "");
                info.size_bytes = Int32.Parse(format["clen"]);
                info.bitrate = Int32.Parse(format["bitrate"]);
                info.url = format["url"];
                info.fps = Int32.Parse(format["fps"]);
                info.quality_label = format["quality_label"];
                info.size_pixels = format["size"];
                info.mixed = false;
                info.label = "Video " + info.quality_label.ToUpper() + " " + info.file.ToUpper() + " " + Math.Round((decimal)info.size_bytes / 1048576, 2) + "MB";
            }

            public Format_Stream(Dictionary<string, string> format)
            {

                if (format["mixed"] == "true")
                {
                    Populate_mixed_info(format);
                }
                else
                {
                    if (format["type"].Contains("audio"))
                    {
                        Populate_audio_info(format);
                    }
                    else
                    {
                        Populate_video_info(format);
                    }
                }


            }
        }
    }

}
