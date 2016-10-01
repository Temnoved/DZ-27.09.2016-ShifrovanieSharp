using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZShifrovanieSharp
{
    class XORFactory: CryptFactory//фабрика производящая объекты classXOR
    {
        public override CryptBase Create(String strT, String strK)
        {
            return new classXOR(strT, strK);
        }
    }
}
