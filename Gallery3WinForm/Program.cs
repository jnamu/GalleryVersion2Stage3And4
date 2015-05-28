using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gallery3WinForm.ServiceReference1;

namespace Gallery3WinForm
{
    static class Program
    {
        public static ServiceReference1.Service1Client SvcClient = new ServiceReference1.Service1Client();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            clsPainting.LoadPaintingForm = new clsPainting.LoadPaintingFormDelegate(frmPainting.Run);
            clsPhotograph.LoadPhotographForm = new clsPhotograph.LoadPhotographFormDelegate(frmPhotograph.Run);
            clsSculpture.LoadSculptureForm = new clsSculpture.LoadSculptureFormDelegate(frmSculpture.Run);
            Application.Run(frmMain.Instance);
            //Application.Run(new frmMain());
            //Application.Run(ArtistListInstance);

            if (SvcClient != null && SvcClient.State != System.ServiceModel.CommunicationState.Closed)
                SvcClient.Close();
        }
    }
}
