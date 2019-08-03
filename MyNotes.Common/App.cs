using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Common
{
    // new'lenmeden kullanılacak.
    public static class App
    {
        // Bu değişkendin default değeri 'DefaultCommon' classından dönen 'system' user'ı olacak.
        public static ICommon Common = new DefaultCommon();
    }
}
