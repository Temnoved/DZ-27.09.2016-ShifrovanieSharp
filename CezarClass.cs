using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZShifrovanieSharp
{
    class CezarClass:CryptBase
    {
        protected readonly String strAlf = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        protected String strText = "";
        protected String bKey = "";

        public CezarClass(String strT = "", String strKey = "")
        {
            this.strText = strT;
            this.bKey = strKey;
            this.algoFlag = Algorithms.Cezar;//устанавливаем внутренний флаг маркирующий текущий алгоритм
        }

        public override void Encript()//метод шфрующий текст
        {
            //проверки на пустой текст
            if (this.strText.Length == 0)
            {
                throw new MyException("Empty text(Encript(Cezar))");
            }

            String strTemp = "";

            for (int i = 0; i < this.strText.Length; i++)
            {
                try
                {
                    for (int j = 0; j < this.strAlf.Length; j++)
                    {
                        if (this.strText[i] == this.strAlf[j])
                        {
                            int iTemp = j + Convert.ToInt32(this.bKey);
                            while (iTemp >= this.strAlf.Length)
                            {
                                iTemp -= this.strAlf.Length;
                            }
                            strTemp += this.strAlf[iTemp];
                            throw new Exception();
                        }
                    }
                }
                catch(Exception)
                {
                    continue;
                }
                strTemp += this.strText[i];
            }
            this.strText = strTemp;
        }

        public override void Decript()//метод дешифрующий текст
        {
            //проверки на пустой текст
            if (this.strText.Length == 0)
            {
                throw new MyException("Empty text(Decript(Cezar))");
            }

            //StringBuilder strBuiTemp = new StringBuilder(this.strText);
            String strTemp = "";

            for (int i = 0; i < this.strText.Length; i++)
            {
                try
                {
                    for (int j = 0; j < this.strAlf.Length; j++)
                    {
                        if (this.strText[i] == this.strAlf[j])
                        {
                            int iTemp = j - Convert.ToInt32(this.bKey);//корректор индекса
                            while (iTemp < 0)//корректировка индекса (while на случай если величина ключа многократно превосходит длинну алфавита)
                            {
                                iTemp += this.strAlf.Length;
                            }
                            while (iTemp >= this.strAlf.Length)//если корректор вышел за пределы алфавита
                            {
                                iTemp -= this.strAlf.Length;
                            }

                            strTemp += this.strAlf[iTemp];
                            throw new Exception();
                        }
                    }
                }
                catch(Exception)
                {
                    continue;
                }
                strTemp += this.strText[i];
            }
            this.strText = strTemp;                
        }

        public override void ShowText()//метод вывода текущего текста на экран
        {
            //проверки на пустой текст
            if (this.strText.Length == 0)
            {
                throw new MyException("Empty text(ShowText(Cezar))");
            }

            Console.WriteLine(this.strText);
        }
    }
}
