using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HollyPlayer
{
    class Lrc
    {
        public static bool isLrcCanParse;
        public static List<string> ParseLrc(string lrcFile)
        {
            List<string> lrcList = new List<string>();
            StringBuilder lrcStrBuilder1 = new StringBuilder();
            StreamReader streamReader = new StreamReader(lrcFile);
            int lrcIndex = 0;
            string input;
            while ((input = streamReader.ReadLine()) != null)
            {
                try
                {
                    foreach (Match match in new Regex("\\[([0-9.:]*)\\]", RegexOptions.Compiled).Matches(input))
                    {
                        lrcIndex += match.Value.Length;
                        string str = match.Value.Replace("[","").Replace("]","");
                        str.Remove(str.Length-1, 1);
                        string[] timeArray = str.Split(':');
                        double min = double.Parse(timeArray[0]);
                        double sec = double.Parse(timeArray[1].Split('.')[0]);
                        double ms_100 = double.Parse(timeArray[1].Split('.')[1].Remove(timeArray[1].Split('.')[1].Length-1));
                        double time = min * 600 + sec*10+ms_100;
                        lrcStrBuilder1.Append(time.ToString() + "|");
                    }
                    StringBuilder lrcStrBuilder2 = new StringBuilder();
                    lrcStrBuilder2.Append(input.Substring(lrcIndex));
                    lrcIndex = 0;
                    lrcStrBuilder1.Append("【" + lrcStrBuilder2 + "】");
                    lrcList.Add(lrcStrBuilder1.ToString());
                    lrcStrBuilder1.Clear();
                    Lrc.isLrcCanParse = true;
                }
                catch (Exception)
                {
                    Lrc.isLrcCanParse = false;
                }
            }
            return lrcList;
        }

        public static string ShowLrc(double playTime, List<string> lrcList)
        {
            foreach (string lrc in lrcList)
            {
                string str = lrc.Replace("|", "");
                int num1 = lrc.Length - str.Length;
                string[] strArray = lrc.Split('|');
                for (int index = 0; index < num1; ++index)
                {
                    if (strArray[index] == (double.Parse(playTime.ToString("0.0"))*10).ToString())
                    {
                        int num2 = lrc.IndexOf("【");
                        int num3 = lrc.LastIndexOf("】");
                        return lrc.Substring(num2 + 1, num3 - num2 - 1);
                    }
                }
            }
            return "lrccannotfind";
        }
    }
}
