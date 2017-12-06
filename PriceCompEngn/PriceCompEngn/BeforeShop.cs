using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;
using DataBase;
using System.Threading;
using ServiceClient;
using Newtonsoft.Json;

namespace PriceCompEngn
{
    public partial class BeforeShop : Form
    {
       
        public BeforeShop()
        {           
            InitializeComponent();
        }

        private async void BeforeShop_LoadAsync(object sender, EventArgs e)
        {
            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.TopItems);
            int rows = 5;
            Dictionary<string, int> arguments = new Dictionary<string, int>()
            {
                {"rows", rows }
            };
            builder.AppendNumericArgs(arguments);
            RestRequestExecutor executor = new RestRequestExecutor();

            var response = await executor.ExecuteRestGetRequest(builder);

            var result = JsonConvert.DeserializeObject<Dictionary<string, int>>(response);

            label1.Text = @"Top 5 Perkamiausios prekės:";

            int index = 1;

            foreach (var x in result)
            {
                string[] row = { index.ToString(), x.Key, x.Value.ToString() };
                var i = new ListViewItem(row);
                listView1.Items.Add(i);
                index++;
            }

            index = 1;

            builder = new PCEUriBuilder(ServiceClient.Resources.CheapestItems);
            builder.AppendNumericArgs(arguments);
            response = await executor.ExecuteRestGetRequest(builder);
            var typeList = new[]
{
                new
                {
                    ItemName = "",
                    ShopName = "",
                    Type = "",
                    Price = (float)0.00,
                    PurchaseTime = new DateTime(),
                    Id = 1
                }
            }.ToList();

            var result2 = JsonConvert.DeserializeAnonymousType(response, typeList);

    
            label3.Text = @"Top 5 Pigiausios prekės:";

            foreach (var x in result2)
            {
                string[] row = { index.ToString(), x.ItemName, x.Price.ToString() };
                var i = new ListViewItem(row);
                listView2.Items.Add(i);
                index++;
            }

            index = 1;
            int days = 5;
            Dictionary<string, int> arguments2 = new Dictionary<string, int>()
            {
                { "rows", rows },
                { "days", days }
            };

            builder = new PCEUriBuilder(ServiceClient.Resources.TopItems);
            builder.AppendNumericArgs(arguments2);
            response = await executor.ExecuteRestGetRequest(builder);

            result = JsonConvert.DeserializeObject<Dictionary<string, int>>(response);


            label2.Text = @"Top 5 Savaitės perkamiausios prekės:";

            foreach (var x in result)
            {
                string[] row = { index.ToString(), x.Key, x.Value.ToString() };
                var i = new ListViewItem(row);
                listView3.Items.Add(i);
                index++;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AroundMe around = new AroundMe();
            around.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShoppingForm shop = new ShoppingForm();
            shop.Show();
        }
    }
}
