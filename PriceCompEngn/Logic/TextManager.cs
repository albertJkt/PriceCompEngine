using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCREngine;
using System.IO;
using DataBase;
using System.Text.RegularExpressions;

namespace Logic
{
    public class TextManager
    {
        private string Standartise (string text)
        {
            return text.ToLower();
        }
        private string DetectShopName(string text)
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
        private string GetProducts (string text)
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
        private System.DateTime GetDate (string text)
        { // a bit hardcoded part. reverses text from the check and takes 10 symbols of it (date).
            var str = text.Split('\n').Reverse().Take(2);
            string result = string.Join("", str);
            result = result.Substring(0, 10);
            DateTime dt = Convert.ToDateTime(result);
            return dt;
        }
        
        public List<ShopItem> GetListOfProducts(string text)
        {
            text = Standartise(text);
            string ShopName = DetectShopName(text);
            DateTime DateT = GetDate(text);
            List<ShopItem> items = new List<ShopItem>();
            string Products = GetProducts(text);
            string pattern = " ?\" ?| *eu *";
            string[] substrings = Regex.Split(Products, pattern);

            for (int i=0; i<(substrings.Length/3); i++)
            {
                items.Add(new ShopItem() {
                    ShopName = ShopName,
                    Type = substrings[i * 3],
                    ItemName = substrings[i * 3 + 1],
                    Price = float.Parse(substrings[i * 3 + 2]),
                    PurchaseTime = DateT
                });
                
            }
            return items;
        }

    }
}
