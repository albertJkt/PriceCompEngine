using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient
{
    public static class ServiceLinks
    {
        public const string ServiceBaseUrl = "https://pricecompengineapi.azurewebsites.net";
        public const string TextManagerUrl = "/api/TextManager";
        public const string PriceComparatorUrl = "/api/PriceComparator?";
        public const string TopItemsUrl = "/api/TopItems?";
        public const string CheapestItemsUrl = "/api/CheapestItems?";
        public const string ShoppingCartUrl = "/api/ShoppingCart?";
        public const string ShopItemsUrl = "/api/ShopItems?";
        public const string OCRUrl = "/api/OCR";
        public const string UserUrl = "/api/User?";
        public const string ItemsUrl = "/api/Items?";
        public const string PurchasesUrl = "/api/Purchases?";
        public const string TopShopsUrl = "/api/TopShops?";
        public const string MoreItemsUrl = "/api/MoreItems?";

        public static string GetResourceUrl(Resources resource)
        {
            switch (resource)
            {
                case Resources.TextManager:
                    return TextManagerUrl;

                case Resources.TopItems:
                    return TopItemsUrl;

                case Resources.CheapestItems:
                    return CheapestItemsUrl;

                case Resources.ShoppingCart:
                    return ShoppingCartUrl;

                case Resources.OCR:
                    return OCRUrl;

                case Resources.User:
                    return UserUrl;

                case Resources.Items:
                    return ItemsUrl;

                case Resources.Purchases:
                    return PurchasesUrl;

                case Resources.TopShops:
                    return TopShopsUrl;

                case Resources.MoreItems:
                    return MoreItemsUrl;

                default:
                    return null;
            }
        }
    }
}

