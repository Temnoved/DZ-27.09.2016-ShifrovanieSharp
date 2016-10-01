using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZShifrovanieSharp
{
    class classXOR:CryptBase
    {
        protected String strKey = "";//для ключа
        protected String strText = "";//для шифруемого текста

        public classXOR(String strIntText = "", String strIntKey = "")
        {
            this.strKey = strIntKey;
            this.strText = strIntText;
            this.algoFlag = Algorithms.XOR;//устанавливаем внутренний флаг маркирующий текущий алгоритм
        }

        public override void Encript()//метод шфрующий текст
        {
            //проверки на пустой текст и пустой ключ
            if (this.strText.Length == 0)
            {
                throw new MyException("Empty text(Encript(XOR))");
            }
            if (this.strKey.Length == 0)
            {
                throw new MyException("Empty key(Encript(XOR))");
            }

            //для работы по индексам со строками переводим их в StringBuilder-ы
            StringBuilder strBuiWork = new StringBuilder(this.strText);
            StringBuilder strBuiKey = new StringBuilder(this.strKey);

            for (int i = 0, j = 0; i < strBuiWork.Length; i++, j++)
            {
                strBuiWork[i] ^= strBuiKey[j];
                if (j == strBuiKey.Length - 1)
                {
                    j = 0;
                }
            }
            this.strText = strBuiWork.ToString();//по окончании обработки переводим StringBuilder обратноо в строку
        }

        public override void Decript()//метод дешифрующий текст
        {
            this.Encript();//в случае XOR дешифрование работает по тому же алгоритму что и шифрование - для дешифровки вызываем метод шифрования
        }

        public override void ShowText()//метод вывода текущего текста на экран
        {
            if (this.strText.Length == 0)//проверка на пустой текст
            {
                throw new MyException("Empty text(ShowText(XOR))");
            }
            Console.WriteLine(this.strText);
        }

    }
}
