using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceCompEngn
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// testing testing - Saras
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OCREngineForm());
        }
    }
}
