using System;

namespace GalleryStage3
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        public delegate void LoadPhotographFormDelegate(clsPhotograph prPhotograph);
        public static LoadPhotographFormDelegate LoadPhotographForm;

        private float _Width;
        private float _Height;
        private string _Type;

        //[NonSerialized()]
        //private frmPhotograph _PhotoDialog;

        public override void EditDetails()
        {
            LoadPhotographForm(this);
            //if (_PhotoDialog == null)
            //    _PhotoDialog = frmPhotograph.Instance;
            //_PhotoDialog.SetDetails(this);
        }

        public Single Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        public Single Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
    }
}
