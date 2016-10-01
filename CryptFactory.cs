using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZShifrovanieSharp
{
    abstract class CryptFactory//основна абстрактной фабрики
    {
        public abstract CryptBase Create(String strT, String strK);
    }
}
