using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrindedIceShop.Models.SupportCompareStrings;
using PropertyChanged;

namespace GrindedIceShop.Models.Bases
{
    [AddINotifyPropertyChangedInterface]
    public class MainMenuItem: MenuItem
    {
        public char Size { get; set; }

        public void SetSize(string Size)
        {
            this.Size = new MyCompareString().getSizeChar(Size);
        }

        public virtual decimal GetUpSizePrice() { return 0; }
    }
}
