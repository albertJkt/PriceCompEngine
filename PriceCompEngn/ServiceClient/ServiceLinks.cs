using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient
{
    public static class ServiceLinks
    {
        public const string ServiceBaseUrl = "http://pricecompengineapi.azurewebsites.net";
        public const string TextManagerUrl = "/api/TextManager?";
        public const string PriceComparatorUrl = "/api/PriceComparator?";
        public const string TopItemsUrl = "/api/TopItems?";
        public const string CheapestItemsUrl = "/api/CheapestItems?";
        public const string ShoppingCartUrl = "/api/ShoppingCart?";
        public const string ShopItemsUrl = "/api/ShopItems?";
        public const string OCRUrl = "/api/OCR";

        public static string GetResourceUrl(Resources resource)
        {
            switch (resource)
            {
                case Resources.TextManager:
                    return TextManagerUrl;

                case Resources.PriceComparator:
                    return PriceComparatorUrl;

                case Resources.TopItems:
                    return TopItemsUrl;

                case Resources.CheapestItems:
                    return CheapestItemsUrl;

                case Resources.ShoppingCart:
                    return ShoppingCartUrl;

                case Resources.ShopItems:
                    return ShopItemsUrl;

                case Resources.OCR:
                    return OCRUrl;

                default:
                    return null;
            }
        }
    }
}

[Flags]
public enum Resources
{
    TextManager,
    CheapestItems,
    TopItems,
    ShoppingCart,
    PriceComparator,
    ShopItems,
    OCR
};