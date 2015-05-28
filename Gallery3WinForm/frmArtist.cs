using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Gallery3WinForm.ServiceReference1;
using System.Linq;


namespace Gallery3WinForm
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        private clsArtist _Artist;
        //private string _Artist;
        //private clsWorksList _WorksList;
        private static Dictionary<string, frmArtist> _ArtistFormList = new Dictionary<string, frmArtist>();
        //private string _ArtistFormList;

        //public static void Run(clsArtist prArtist)
        public static void Run(string prArtistName)
        {
            frmArtist lcArtistForm;
            if (string.IsNullOrEmpty(prArtistName) || 
                !_ArtistFormList.TryGetValue(prArtistName, out lcArtistForm))
            //if (!_ArtistFormList.TryGetValue(prArtist, out lcArtistForm))
            {
                lcArtistForm = new frmArtist();
                if (string.IsNullOrEmpty(prArtistName))
                    lcArtistForm.SetDetails(new clsArtist());
                else
                {
                    _ArtistFormList.Add(prArtistName, lcArtistForm);
                    lcArtistForm.refreshFormFromDB(prArtistName);
                }
                //_ArtistFormList.Add(prArtist, lcArtistForm);
                //lcArtistForm.SetDetails(prArtist);
            }
            else
            {
                lcArtistForm.Show();
                lcArtistForm.Activate();
            }
        }

        private void refreshFormFromDB(string prArtistName)
        {
            SetDetails(Program.SvcClient.GetArtist(prArtistName));
        }

        private void updateDisplay()
        {
            lstWorks.DataSource = null;
            if (_Artist.Works != null)
                lstWorks.DataSource = _Artist.Works.ToList();
            ////if (_WorksList.SortOrder == 0)
            //{
            //    //_WorksList.SortByName();
            //    rbByName.Checked = true;
            //}
            ////else
            //{
            //    //_WorksList.SortByDate();
            //    rbByDate.Checked = true;
            //}

            //lstWorks.DataSource = null;
            ////lstWorks.DataSource = _WorksList;
            ////lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
            //frmMain.Instance.updateDisplay();
        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            txtName.Enabled = string.IsNullOrEmpty(_Artist.Name);
            updateForm();
            updateDisplay();
            Show();
        }

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            //_WorksList = _Artist.WorksList;
            frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Artist.ArtistList.GalleryName);
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.SvcClient.DeleteWork(lstWorks.SelectedItem as clsWork);
                refreshFormFromDB(_Artist.Name);
                frmMain.Instance.updateDisplay();
                //_WorksList.RemoveAt(lcIndex);
                //updateDisplay();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                string lcReply = new InputBox(clsWork.FACTORY_PROMPT).Answer;
                if (!string.IsNullOrEmpty(lcReply))
                {
                    clsWork lcWork = clsWork.NewWork(lcReply[0]);
                    if (lcWork != null)
                    {
                        if (txtName.Enabled)
                        {
                            pushData();
                            Program.SvcClient.InsertArtist(_Artist);
                            txtName.Enabled = false;
                        }
                        lcWork.ArtistName = _Artist.Name;
                        lcWork.EditDetails();
                        if (!string.IsNullOrEmpty(lcWork.Name))
                        {
                            refreshFormFromDB(_Artist.Name);
                            //updateDisplay();
                            frmMain.Instance.updateDisplay();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                //throw;
                MessageBox.Show(ex.Message);
            }
            

        }
        //    catch (Exception ex)
        //    {
        //        throw;
        //        //MessageBox.Show(ex.GetBaseException().Message, "In frmArtist.btnAdd");
        //    }
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
                try
                {
                    pushData();
                    if (txtName.Enabled)
                    {
                        //_Artist.NewArtist();
                        //MessageBox.Show("Artist added!", "Success");
                        Program.SvcClient.InsertArtist(_Artist);
                        frmMain.Instance.updateDisplay();
                        txtName.Enabled = false;
                    }
                    else
                        Program.SvcClient.UpdateArtist(_Artist);
                    Hide();
                }
                catch (Exception ex)
                {
                    throw ex.GetBaseException();
                    //MessageBox.Show(ex.Message);
                }
        }

        private Boolean isValid()
        {
            //if (txtName.Enabled && txtName.Text != "")
            //    //if (_Artist.IsDuplicate(txtName.Text))
            //    {
            //        MessageBox.Show("Artist with that name already exists!", "Error adding artist");
            //        return false;
            //    }
            //    else
                    return true;
            //else
                //return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //_WorksList.EditWork(lstWorks.SelectedIndex);
                (lstWorks.SelectedValue as clsWork).EditDetails();
                updateDisplay();
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
                //MessageBox.Show(ex.Message);
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            //_WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            updateDisplay();
        }

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Artist Details - " + prGalleryName;
        }
    }
}