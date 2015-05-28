using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Gallery4Phone.Resources;
using Gallery4Phone.ServiceReference1;

namespace Gallery4Phone
{
    public partial class pgArtist : PhoneApplicationPage
    {
        public pgArtist()
        {
            InitializeComponent();  
            pgMain.SvcClient.GetArtistCompleted +=SvcClient_GetArtistCompleted;  
        }

        void SvcClient_GetArtistCompleted(object sender, GetArtistCompletedEventArgs e)
        {
            try 
	        {
	            if (e.Error == null)
		            _Artist = e.Result;
                else
                txbMessage.Text = e.Error.Message;
	        }
	        catch (Exception ex)
	        {
                txbMessage.Text = ex.Message;
	        }
            UpdateDisplay();
        }

       // public static readonly Service1Client SvcClient = new Service1Client();

        private clsArtist _Artist = new clsArtist();

        public void UpdateDisplay()
        {
            txtName.Text = _Artist.Name;
            txtName.IsEnabled = string.IsNullOrEmpty(_Artist.Name);
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            lstWorks.ItemsSource = _Artist.Works;

            //lstWorks.DataSource = null;
            //if (_Artist.Works != null)
            //    lstWorks.DataSource = _Artist.Works.ToList();

            lstWorks.DataContext = null;
            if (_Artist.Works != null)
                lstWorks.DataContext = _Artist.Works.ToList();
        }

        public void PushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string lcArtistName;

            if (NavigationContext.QueryString.TryGetValue("artist", out lcArtistName))
                pgMain.SvcClient.GetArtistAsync(lcArtistName);
            else // no suitable query string -> new artist!
                _Artist = new clsArtist();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PushData();
                if (txtName.IsEnabled)
                {
                    pgMain.SvcClient.InsertArtistAsync(_Artist);
                    txtName.IsEnabled = false;
                }
                else
                    pgMain.SvcClient.UpdateArtistAsync(_Artist);
            }
            catch (Exception ex)
            {
                txbMessage.Text = ex.Message;
            }
        }      

    }
}


//txtName.Text = _Artist.Name;
//            txtSpeciality.Text = _Artist.Speciality;
//            txtPhone.Text = _Artist.Phone;
//            //_WorksList = _Artist.WorksList;
//            frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
//            //updateTitle(_Artist.ArtistList.GalleryName);

// txtName.Enabled = string.IsNullOrEmpty(_Artist.Name);

//lstWorks.DataSource = null;
//            if (_Artist.Works != null)
//                lstWorks.DataSource = _Artist.Works.ToList();