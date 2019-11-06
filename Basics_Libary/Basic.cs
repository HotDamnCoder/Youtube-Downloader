using System;
using System.Diagnostics;

using Basics.Formats;
using Basics.Files;

namespace Basics
{
    public delegate void VideoInfoChanged();
    public class PrivacyException : Exception
    {
        public PrivacyException()
        {
        }

        public PrivacyException(string message)
            : base(message)
        {
        }

        public PrivacyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public delegate void VideoFileDoneDelegate (Video_file a);

    public delegate void Download(Stopwatch timer);

    public class UnavailableFormatException : Exception
    {
        public UnavailableFormatException()
        {
        }

        public UnavailableFormatException(string message)
            : base(message)
        {
        }

        public UnavailableFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }

    public class MetadataException : Exception
    {
        public MetadataException()
        {
        }

        public MetadataException(string message)
            : base(message)
        {
        }

        public MetadataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ForbiddenUrlException : Exception
    {
        public ForbiddenUrlException()
        {
        }

        public ForbiddenUrlException(string message)
            : base(message)
        {
        }

        public ForbiddenUrlException(string message, Exception inner)
            : base(message, inner)
        {
        }
        
    }

    public struct VideoInfo_Struct
    {
        public int positsion;

        public Player_Info player;

        public string image_url;



        public string id;

        public string title;

        public string name;

        public string[] artists;

        public string channel;

        public string file_name;
    }

    public struct Stream_info
    {
        public string label;
        public string s;
        public bool mixed;
        public int itag;
        public string type;
        public string file;
        public string codec;
        public int size_bytes/*(clen)*/;
        public int bitrate;
        public string url;
        public int fps;
        public string quality_label;
        public string size_pixels;
        public int audio_sample_rate;
        public string quality;
    }
}

