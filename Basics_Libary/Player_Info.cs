using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
    
namespace Basics
{
    namespace Formats
    {
        public class Player_Info
        {
            string ReverseFuncName = "";

            string SpliceFuncName = "";

            string CharSwapFuncName = "";

            public string title;

            public string channel;

            public string sts;

            private List<Dictionary<int, int>> command_order = new List<Dictionary<int, int>>();

            private string Charswap(string sig, int b)
            {
                char c = sig[0];
                char[] sig_array = sig.ToCharArray();
                sig_array[0] = sig_array[b % sig.Length];
                sig_array[b % sig.Length] = c;
                return new string(sig_array);

            }

            private string Reverse(string sig)
            {
                char[] sig_array = sig.ToCharArray();
                Array.Reverse(sig_array);
                return new string(sig_array);
            }

            private string Splice(string sig, int b)
            {
               return sig.Remove(0, b);

            }

            private void Get_sts(string html)
            {

                if (Regex.IsMatch(html, "\"sts\":.+?(?=,)"))
                {
                    sts = Regex.Match(html, "\"sts\":.+?(?=,)").ToString().Split(':')[1];
                    if (!Int32.TryParse(sts, out int result))
                    {
                        sts = Regex.Match(html, "\"sts\":.+?(?=})").ToString().Split(':')[1];
                    }


                }
                else
                {
                    sts = "";
                }
                title = WebUtility.HtmlDecode(Regex.Split(Regex.Match(html, "meta property=\"og:title\".+?(?=>)").ToString(), "content=")[1]);
                title = title.Remove(title.Length - 1, 1);
                title = title.Remove(0, 1);
                channel = Regex.Match(html, "\"name\":.+").ToString().Split(':')[1];
                channel = channel.Remove(channel.Length - 1, 1);
                channel = channel.Remove(0, 2);
            }

            public async Task PlayerAsync(string url)
            {
                await Task.Run(() =>
                {
                    Console.WriteLine("Getting player");
                    Player_info(url);
                });
            }

            private void Player_info(string url)
            {

                Downloaders.HtmlDownloader downloader = new Downloaders.HtmlDownloader();
                string html = downloader.DownloadHtml(url);
                string player = Regex.Match(html, "\\/yts\\/jsbin\\/player.+?(?:base.js)").ToString();
                string player_scripts = downloader.DownloadHtml("https://www.youtube.com" + player);
                string decode_function_name = Regex.Escape(Regex.Match(player_scripts, "encodeURIComponent\\(\\w+?(\\(decodeURIComponent)").ToString().Split('(')[1]);
                string decode_function = Regex.Match(player_scripts, decode_function_name + "=function.+").ToString();
                string[] commands = decode_function.Split('{')[1].Split(';');
                MatchCollection command_definations = Regex.Matches(Regex.Match(player_scripts, "var " + commands[1].Split('.')[0] + "(.+\n)+?(?:(.+?(?=\\};)))").ToString(), "..:function.+?(?=\\})");
                foreach (var command_defination in command_definations)

                {
                    if (command_defination.ToString().Contains("reverse"))
                    {
                        ReverseFuncName = command_defination.ToString().Split(':')[0];
                    }
                    else if (command_defination.ToString().Contains("splice"))
                    {
                        SpliceFuncName = command_defination.ToString().Split(':')[0];
                    }
                    else
                    {
                        CharSwapFuncName = command_defination.ToString().Split(':')[0];
                    }
                }
                foreach (var command in commands)
                {
                    if (!command.Contains("return"))
                    {
                        Dictionary<int, int> command_dict = new Dictionary<int, int>();
                        if (command.Contains(ReverseFuncName))
                        {
                            command_dict.Add(0, Int32.Parse(command.Split(',')[1].Replace(")", "")));
                            command_order.Add(command_dict);
                        }
                        else if (command.Contains(SpliceFuncName))
                        {
                            command_dict.Add(1, Int32.Parse(command.Split(',')[1].Replace(")", "")));
                            command_order.Add(command_dict);
                        }
                        else if (command.Contains(CharSwapFuncName))
                        {
                            command_dict.Add(2, Int32.Parse(command.Split(',')[1].Replace(")", "")));
                            command_order.Add(command_dict);
                        }
                    }
           





                }
                Get_sts(html);




            }

            public string Decipher(string a)
            {
                
                foreach (var command in command_order)
                {
                    foreach (var comman in command)
                    {
                        if (comman.Key == 0)
                        {
                            a = Reverse(a);
                        }
                        if (comman.Key == 1)
                        {
                            a = Splice(a, comman.Value);
                        }
                        if (comman.Key == 2)
                        {
                            a = Charswap(a, comman.Value);
                        }

                    }

                }

                /*charswap(signature, 23);
                splice(signature, 1);
                reverse(signature);
                splice(signature, 2);
                reverse(signature);
                splice(signature, 1);
                reverse(signature);
                charswap(signature, 23);
                splice(signature, 2);*/
                return a;
            }

            public Player_Info() { }

            public Player_Info(string url)
            {
                Console.WriteLine("[Getting player]");
                Player_info(url);
            }


        }
    }
}
