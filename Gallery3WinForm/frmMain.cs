using System;
using System.Windows.Forms;
using Gallery3WinForm.ServiceReference1;
using System.Linq;


namespace Gallery3WinForm
{
    sealed public partial class frmMain : Form
    {
        private frmMain()
        {
            InitializeComponent();
        }

        //public static clsArtistList _ArtistList = new clsArtistList();

        public delegate void Notify(string prGalleryName);
        public event Notify GalleryNameChanged;

        private static readonly frmMain _Instance = new frmMain();

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        } 

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Gallery - " + prGalleryName;
        }

        public void updateDisplay()
        {
            //lstArtists.DataSource = null;
            //string[] lcDisplayList = new string[_ArtistList.Count];
            //_ArtistList.Keys.CopyTo(lcDisplayList, 0);
            //lstArtists.DataSource = lcDisplayList;
            //lblValue.Text = Convert.ToString(_ArtistList.GetTotalValue());
            lstArtists.DataSource = null;
            lstArtists.DataSource = Program.SvcClient.GetArtistNames();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //frmArtist.Run(new clsArtist(_ArtistList));
                frmArtist.Run(null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new artist");
            }
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
                try
                {
                    //frmArtist.Run(_ArtistList[lcKey]);
                    frmArtist.Run(lstArtists.SelectedItem as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    _ArtistList.Save();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "File Save Error");
            //}
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting artist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    //_ArtistList.Remove(lcKey);
                    clsArtist lcArtist = new clsArtist() { Name = lcKey };
                    Program.SvcClient.DeleteArtist(lcArtist);
                    lstArtists.ClearSelected();
                    updateDisplay();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error deleing artist");
                }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    //ArtistListInstance = clsArtistList.RetrieveArtistList();
            //    _ArtistList = clsArtistList.RetrieveArtistList();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "File retrieve error");
            //}
            updateDisplay();
            //GalleryNameChanged += new Notify(updateTitle);
            //GalleryNameChanged(_ArtistList.GalleryName); //event raising
        }

        private void btnChangeGalleryName_Click(object sender, EventArgs e)
        {
            //string lcReply = new InputBox(clsArtistList.FACTORY_PROMPT).Answer;
            //if (!string.IsNullOrEmpty(lcReply))
            //{
            //    _ArtistList.GalleryName = lcReply;
            //    GalleryNameChanged(_ArtistList.GalleryName);
            //    updateDisplay();
            //}
        }
    }
}