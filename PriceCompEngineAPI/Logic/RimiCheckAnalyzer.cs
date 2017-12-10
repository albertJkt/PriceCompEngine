using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic
{
    public class RimiCheckAnalyzer : ShopCheckAnalyzer
    {
        private string _receiptText;
        private MatchCollection _priceMatches;

        public override void AnalyzeText(string text)
        {
            _receiptText = text;
            ItemNames = GetItemNames();
            ShopName = "Rimi";
            PurchaseTime = DateTime.UtcNow;
            StandartisePrices();
            CorrectPerWeightPrices();
            CorrectPerUnitPrices();
        }

        private List<string> GetItemNames()
        {
            _receiptText = CutBeginning();
            List<string> prices = GetPrices();
            PayedPrices = prices;
            Prices = new List<string>(prices);
            List<string> items = new List<string>();
            for (int i = 0; i < _priceMatches.Count; i++)
            {
                string item;
                if (i == 0)
                {
                    item = new string(_receiptText.Take(_priceMatches[i].Index).ToArray());
                    item = item.Replace("\n", " ");
                    _receiptText = _receiptText.Remove(0, _priceMatches[i].Index);
                }
                else
                {
                    item = new string(_receiptText.Take(_priceMatches[i].Index - _priceMatches[i - 1].Index - 7).ToArray());
                    item = item.Replace("\n", " ");
                    _receiptText = _receiptText.Remove(0, _priceMatches[i].Index - _priceMatches[i - 1].Index - 7);
                }

                items.Add(item);
                _receiptText = _receiptText.Remove(0, 7);
            }

            CorrectDiscount(items);

            return items;
        }

        private void CorrectPerUnitPrices()
        {
            string pattern1 = @"[0-9]\s*vnt.\s*[Xx]\s*[0-9]+[.,][0-9]{2}\s*EUR";
            string pattern2 = @"[0-9]+[.,][0-9]+";

            CorrectNameAndPrice(pattern1, pattern2);
        }

        private void CorrectPerWeightPrices()
        {
            string pattern1 = @"[1il]\s*kg\s+[0-9]+[.,][0-9]+\s*kg\s*[Xx]\s*[0-9]+[.,][0-9]+\s*EUR/kg";
            string pattern2 = @"[0-9]+[.,][0-9]+";

            CorrectNameAndPrice(pattern1, pattern2);
        }

        private void CorrectNameAndPrice(string pattern1, string pattern2)
        {
            for (int i = 0; i < ItemNames.Count; i++)
            {
                if (Regex.IsMatch(ItemNames[i], pattern1))
                {
                    var match = Regex.Match(ItemNames[i], pattern1);
                    var matchText = match.Value;

                    var newPrice = Regex.Matches(matchText, pattern2)
                                        .Cast<Match>()
                                        .OrderByDescending(m => m.Index)
                                        .First()
                                        .Value;
                    Prices[i] = newPrice;

                    ItemNames[i] = ItemNames[i].Remove(match.Index);
                }
            }
        }

        private void StandartisePrices()
        {
            for (int i = 0; i < Prices.Count; i++)
            {
                Prices[i] = Prices[i].Replace(",", ".")
                                     .Remove(Prices[i].Count() - 2);
            }
        }

        private string CorrectDiscount(List<string> items)
        {
            string discountPattern = @"Nuol.\s+-[0-9]+[.,][0-9]{2}\s+Galut.\s+kaina\s+[0-9]+[.,][0-9]{2}";

            for (int i = 0; i < items.Count; i++)
            {
                if (Regex.IsMatch(items[i], discountPattern))
                {
                    var matchCollection = Regex.Matches(items[i], discountPattern).Cast<Match>();

                    var match = matchCollection.First();

                    var matchText = matchCollection.Select(m => m.Value).First();

                    var newPrice = Regex.Matches(matchText, @"[0-9]+[.,][0-9]{2}")
                                        .Cast<Match>()
                                        .Select(m => m.Value)
                                        .ElementAt(1)
                                        .Replace(",", ".");

                    Prices[i - 1] = newPrice + " A";

                    items[i] = items[i].Remove(match.Index, matchText.Count() + 1);
                }
            }

            return null;
        }

        private string GetPurchaseTime()
        {
            string pattern = @"20[0-9]{2}-[0-1][0-9]-[0-3][0-9]\s*[0-2][0-9]:[0-5][0-9]:[0-5][0-9]";

            string dateTime = Regex.Match(_receiptText, pattern).Value;

            return dateTime;
        }

        private string CutBeginning()
        {
            var pattern1 = @"X+[0-9]{4}";
            var pattern2 = @"LT[0-9]{9}";

            if (Regex.IsMatch(_receiptText, pattern1))
            {
                var match = Regex.Match(_receiptText, pattern1);
                _receiptText = _receiptText.Remove(0, match.Index);
                _receiptText = _receiptText.Replace(match.Value, string.Empty);
            }
            else if (Regex.IsMatch(_receiptText, pattern2))
            {
                var match = Regex.Match(_receiptText, pattern2);
                _receiptText = _receiptText.Remove(0, match.Index);
                _receiptText = _receiptText.Replace(match.Value, string.Empty);
            }
            else return _receiptText;

            _receiptText = _receiptText.Remove(0, 1);

            return _receiptText;
        }

        private List<string> GetPrices()
        {
            string pattern = @"[0-9]*[.,][0-9]{2}\s*[AE][\n.]";

            _priceMatches = Regex.Matches(_receiptText, pattern);

            var matches = _priceMatches
                                .Cast<Match>()
                                .Select(m => m.Value)
                                .ToList();

            for (int i = 0; i < matches.Count(); i++)
            {
                matches[i] = matches[i].Remove(matches[i].Count() - 1);
            }

            return matches;
        }
    }
}
