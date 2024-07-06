using System;
using System.Net.Http;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;


namespace GraphQL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCeUx3Rnxbf1x0ZFdMZFtbR35PIiBoS35RckVkWXlfdHBSRWhdU0Z1");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Oddsmatcher());
        }
    }
}