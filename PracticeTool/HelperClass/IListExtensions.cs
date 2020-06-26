using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeTool.HelperClass {
    public static class IListExtensions {
        public static void Swap<T>(
            this IList<T> list,
            T t1,
            T t2) {
            Contract.Requires(list != null && list.Count >= 2);
            Contract.Requires(list.Contains(t1) && list.Contains(t2));

            if(t1.Equals(t2)) {
                return;
            }

            int index1 = list.IndexOf(t1);
            int index2 = list.IndexOf(t2);

            T temp = t1;
            list[index1] = t2;
            list[index2] = temp;




        }



    }
}
