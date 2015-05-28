using System;

namespace GalleryStage3
{
    [Serializable()]
    public class clsPainting : clsWork
    {
        public delegate void LoadPaintingFormDelegate(clsPainting prPainting);
        public static GalleryStage3.clsPainting.LoadPaintingFormDelegate LoadPaintingForm;

        private float _Width;
        private float _Height;
        private string _Type;

        //[NonSerialized()]
        //private frmPainting _PaintDialog;

        public override void EditDetails()
        {
            LoadPaintingForm(this);
            //if (_PaintDialog == null)
            //    _PaintDialog = frmPainting.Instance;
            //_PaintDialog.SetDetails(this);
        }

        public float Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        public float Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        //public delegate void LoadPaintingFormDelegate(GalleryStage2.clsPainting prPainting, GalleryStage2.clsPainting prPainting);

    }
}
