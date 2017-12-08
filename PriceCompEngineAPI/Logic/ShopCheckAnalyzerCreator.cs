using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Logic
{
    public class ShopCheckAnalyzerCreator
    {
        public ShopCheckAnalyzer Create(string text)
        {
            if (Regex.IsMatch(text, @"[Rr][Ii][Mm][Ii]"))
            {
                ShopCheckAnalyzer analyzer = new RimiCheckAnalyzer();
                analyzer.AnalyzeText(text);
                return analyzer;
            }
            else throw new ArgumentException("Text doesn't match any shop signature");
        } 
    }
}
