using Safari.controller;
using Safari.model;
using Safari.view;

namespace Safari
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MiSafari safari = new MiSafari();
            Controller controller = new Controller(safari);
            Console.WriteLine("DADAD");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new VentanaInicio(controller));
        }
    }
}