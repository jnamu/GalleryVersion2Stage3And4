using System;
using System.Collections.Generic;

namespace GalleryStage3
{
    [Serializable()]
    sealed class clsNameComparer : IComparer<clsWork>
    {
        private clsNameComparer(){}
        public static readonly clsNameComparer Instance = new clsNameComparer();

        public int Compare(clsWork x, clsWork y)
        {
            string lcNameX = x.Name;
            string lcNameY = y.Name;

            return lcNameX.CompareTo(lcNameY);
        }
    }
}



