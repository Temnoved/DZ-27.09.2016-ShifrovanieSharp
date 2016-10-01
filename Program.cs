using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZShifrovanieSharp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                PrepareData pdIn = new PrepareData(args);//подготовка прешедших данных для дальнейшей работы(разделение на ключ и текст, определение алгоритма)
                CryptBase cryObj = null;//объект для обрабатываемого текста
                CryptFactory crFa = null;//объект фабрики

                switch(pdIn.AlgorithmFlag)
                {
                    case Algorithms.XOR:
                        crFa = new XORFactory();//создаём объект генерирующий объекты XOR
                        cryObj = crFa.Create(pdIn.Text, pdIn.Key);//создаём объект класса classXOR с помощю созданного генератора объектов
                        break;
                    case Algorithms.Cezar:
                        crFa = new CezarFactory();//создаём объект генерирующий объекты Cezar
                        cryObj = crFa.Create(pdIn.Text, pdIn.Key);//создаём объект класса CezarClass с помощю созданного генератора объектов
                        break;
                    default://если ключ не удалось определить генерируем исключение
                        throw new MyException("The key is not defined");
                        break;
                }
                
                cryObj.Encript();//шифровка
                cryObj.ShowText();//показываем зашифрованный текст
                cryObj.Decript();//дешифровка
                cryObj.ShowText();//показываем дешифрованный текст

                Console.Read();
            }//конец глобального try
            catch(MyException mEx)
            {
                Console.WriteLine(mEx.Message);
                Console.Read();
            }

        }//конец Main
    }//конец class Program
}//конец namespace DZShifrovanieSharp
