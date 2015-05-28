using System;
using System.Collections.Generic;

namespace GalleryStage3
{
    [Serializable()]
    public class clsArtist
    {
        private string _Name;
        private string _Speciality;
        private string _Phone;

        //private decimal _TotalValue;

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;

        public clsArtistList ArtistList
        {
            get { return _ArtistList; }
            set { _ArtistList = value; }
        }

        //private static frmArtist _ArtistDialog = new frmArtist();

        public clsArtist() { }

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            //EditDetails();
        }

        public void NewArtist()
        {
            if (!string.IsNullOrEmpty(Name))
                _ArtistList.Add(Name, this);
            else
                throw new Exception("No artist name entered");
        }

        //public void EditDetails()
        //{
        //    _ArtistDialog.SetDetails(this);
        //    _TotalValue = _WorksList.GetTotalValue();
        //}

        public bool IsDuplicate(string prArtistName)
        {
            return _ArtistList.ContainsKey(prArtistName);
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Speciality
        {
            get { return _Speciality; }
            set { _Speciality = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public decimal TotalValue
        {
            //get { return _TotalValue; }
            get { return _WorksList.GetTotalValue(); }
        }

        public clsWorksList WorksList
        {
            get { return _WorksList; }
        }
    }
}
