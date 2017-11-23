using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Models;

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
            text = DeleteLines(text, 2, false);

        // Remove last 2 lines from string (date and overall price)
            text = DeleteLines(text, 6, true);

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
        private DateTime GetDate (string text)
        { // a bit hardcoded part. reverses text from the check and takes 10 symbols of it (date).
            string[] separators = new string[] { "\\r\\n" };
            string[] str = text.Split(separators,StringSplitOptions.None).Reverse().Take(2).ToArray();
            string result;
            result = str[1];
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
            string pattern = " ?\\\\ ?\" ?| *eu *";
            string[] substrings = Regex.Split(Products, pattern);

            for (int i=0; i<(substrings.Length/3); i++)
            {
            items.Add(new ShopItem()
            {
                ShopName = ShopName,
                Type = substrings[i * 3],
                ItemName = substrings[i * 3 + 1],
                Price = float.Parse(substrings[i * 3 + 2]),
                PurchaseTime = DateT
                });
                
            }
            return items;
        }
    public static string DeleteLines(
     string stringToRemoveLinesFrom,
     int numberOfLinesToRemove,
     bool startFromBottom = false)
    {
        string toReturn = "";
        string[] sep = { "\\r", "\\n", "\n" };
        string[] allLines = stringToRemoveLinesFrom.Split(
                separator: sep,
            options: StringSplitOptions.None);
        if (startFromBottom)
            toReturn = String.Join(Environment.NewLine, allLines.Take(allLines.Length - numberOfLinesToRemove));
        else
            toReturn = String.Join(Environment.NewLine, allLines.Skip(numberOfLinesToRemove));
        return toReturn;
    }

    }
