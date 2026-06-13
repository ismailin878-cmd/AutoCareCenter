using System;
using System.Windows.Forms;

namespace AutoCare.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // تشغيل شاشة العملاء الأساسية فقط كبداية شرعية للمشروع
            Application.Run(new Form1());
        }
    }
}