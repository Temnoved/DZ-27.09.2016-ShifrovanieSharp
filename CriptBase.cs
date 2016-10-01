using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZShifrovanieSharp
{
    public enum Algorithms { Indefined, XOR, Cezar };
    abstract class CryptBase//основной абстрактный класс для алгоритмов шифрования
    {
        protected Algorithms algoFlag = Algorithms.Indefined;//флаг маркирующий текущий алгоритм шифрования для объекта
        public abstract void Encript();//метод шифрования
        public abstract void Decript();//метод расшифрования
        public abstract void ShowText();//метод вывода на консоль обрабатываемого текста
    }
}
