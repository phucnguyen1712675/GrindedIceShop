using System;
using System.Collections.Generic;

namespace GrindedIceShop.Util
{
    public class ListOfTypes<T> : List<Type>
    {
        public void Add<TU>() where TU : T => Add(typeof(TU));
    }
}
