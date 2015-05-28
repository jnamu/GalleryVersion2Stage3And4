using System;

namespace GalleryStage3
{
    [Serializable()]
    public class clsSculpture : clsWork
    {
        public delegate void LoadSculptureFormDelegate(clsSculpture prSculpture);
        public static GalleryStage3.clsSculpture.LoadSculptureFormDelegate LoadSculptureForm;

        private float _Weight;
        private string _Material;

        //[NonSerialized()]
        //private frmSculpture _SculptureDialog;

        public override void EditDetails()
        {
            LoadSculptureForm(this);
            //if (_SculptureDialog == null)
            //    _SculptureDialog = frmSculpture.Instance;
            //_SculptureDialog.SetDetails(this);
        }

        public float Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }

        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }
    }
}
