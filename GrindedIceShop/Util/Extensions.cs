using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GrindedIceShop.Util
{
    public static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> col) => new ObservableCollection<T>(col);
    }
}
