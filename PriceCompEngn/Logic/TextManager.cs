using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCREngine;
using System.IO;

namespace Logic
{
    public class TextManager
    {
        //private static string ImagePath = @"C:\Users\Albert\Desktop\a.png"; // string to the test file
        public string ShopName { get; set; }
        public string Item { get; set; }
        public string ItemName { get; set; }
        public float ItemPrice { get; set; }

        public string Standartise (string text)
        {
            return text.ToLower();
        }
        public string DetectShopName(string text)
        {
            // kadangi realus cekiai labai skiriasi lengviausia tiesiog ieskot parduotuves pavadinimo. 
            if (text.Contains("maxima"))
            {
                return "maxima";
            }
            else if (text.Contains("rimi"))
            {
                return "rimi";
            }
            else if (text.Contains("iki"))
            {
                return "iki";
            }
            else if (text.Contains("lidl"))
            {
                return "lidl";
            }
            else if (text.Contains("norfa"))
            {
                return "norfa";
            }
            else
            {
                return "unrecognized";
            }
        }
        public string GetProducts (string text)
        {
            string result = "";
            // Delete everything till products
            text = text.Substring(text.IndexOf('\n') + 1);

            // Remove last 2 lines from string (date and overall price)
            text = RemoveLast2Lines(text);

            // Remove all endlines from string
            result = RemoveEndlines(text);
            return result;
        }
        private string RemoveEndlines(string text)
        {
            string result="";
            using (StringReader reader = new StringReader(text))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        result = result + line + " ";
                    }
                } while (line != null);
            }
            return result;
        }
        private string RemoveLast2Lines(string text)
        {
            text = text.Remove(text.TrimEnd().LastIndexOf(Environment.NewLine));
            text = text.Remove(text.TrimEnd().LastIndexOf(Environment.NewLine));

            return text;
        }
        public string GetDate (string text)
        {
            var str = text.Split('\n').Reverse().Take(2);
            string result = string.Join("", str);
            return result;
        }

    }
}
