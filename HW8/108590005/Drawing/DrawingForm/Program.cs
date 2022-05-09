using System;
using System.Windows.Forms;

namespace DrawingForm
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DrawingForm(new FormPresentationModel(new DrawingModel.Model(new GoogleDriveService(DrawingModel.Strings.APPLICATION_NAME, DrawingModel.Strings.CLIENT_SECRET_FILE_NAME)))));
        }
    }
}
