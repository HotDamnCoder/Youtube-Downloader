using Basics.Formats;
using Basics.Files;
using System;
using Basics;

namespace ConsoleApp1
{
    class Main_Method
    {

        static void Main(string[] args)
        {
 
            Video_file a = new Video_file("C:\\Users\\Marcus-PC\\Desktop\\",  null);
            a.Video_fileAsync("Cq6F5tc2-Io").Wait();
            a.Tagger();
        
        }
    }
}
