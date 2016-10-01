using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DZShifrovanieSharp
{
    [Serializable]
    class MyException:ApplicationException//собственный класс исключений
    {
        public MyException():base() { }//конструктор по умолчанию
        public MyException(String strS) : base(strS) { }//конструктор принимающий текст сообщения о исключении
        public MyException(String strS, Exception ex):base(strS, ex) { }//конструктор для внутренних исключений
        protected MyException(SerializationInfo serInf, StreamingContext cont):base(serInf, cont) { }//защищенный конструктор для сериализации
    }
}
