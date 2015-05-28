using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery3WinForm.ServiceReference1
{
    class DTO_Extension
    {
    }

    public abstract partial class clsWork
    {
        public override string ToString()
        {
            return Name + "\t" + Date.ToShortDateString();
                //Date.ToString();
            //
        }

        public abstract void EditDetails();

        public static readonly string FACTORY_PROMPT = "Enter P for Painting, S for Sculpture and H for Photograph";

        public static clsWork NewWork(char prChoice)
        {
            switch (char.ToUpper(prChoice))
            {
                case 'P': return new clsPainting();
                case 'S': return new clsSculpture();
                case 'H': return new clsPhotograph();
                default: return null;
            }
        }
    }

    public partial class clsPainting
    {
        public delegate void LoadPaintingFormDelegate(clsPainting prPainting);
        public static LoadPaintingFormDelegate LoadPaintingForm;

        public override void EditDetails()
        {
            LoadPaintingForm(this);
        }
    }

    public partial class clsPhotograph
    {
        public delegate void LoadPhotographFormDelegate(clsPhotograph prPhotograph);
        public static LoadPhotographFormDelegate LoadPhotographForm;

        public override void EditDetails()
        {
            LoadPhotographForm(this);
        }
    }

    public partial class clsSculpture
    {
        public delegate void LoadSculptureFormDelegate(clsSculpture prSculpture);
        public static LoadSculptureFormDelegate LoadSculptureForm;

        public override void EditDetails()
        {
            LoadSculptureForm(this);
        }
    }
}
