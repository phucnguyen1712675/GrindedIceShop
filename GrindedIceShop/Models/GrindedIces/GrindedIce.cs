using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.SizeManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace GrindedIceShop.Models.GrindedIces
{
    [AddINotifyPropertyChangedInterface]
    class GrindedIce: MainMenuItem
    {
        public override decimal GetUpSizePrice()
        {
            return GrindedIceSizeManager.Instance.GetUpSizePrice(Size);
        }
    }
}
