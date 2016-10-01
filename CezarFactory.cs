using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZShifrovanieSharp
{
    class CezarFactory: CryptFactory//фабрика производящая объекты CezarClass
    {
        public override CryptBase Create(string strT, string strK)
        {
            return new CezarClass(strT, strK);
        }
    }
}
