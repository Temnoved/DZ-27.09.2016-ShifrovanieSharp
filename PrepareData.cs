using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZShifrovanieSharp
{
    class PrepareData//класс предворительной обработки вошедших данных
    {
        protected String[] strWork = null;//для сохрания прешедшего массива
        protected String strK = "";//для ключа
        protected String strT = "";//для текста
        protected Algorithms alFlags = Algorithms.Indefined;//флаг типа алгоритма шифрования

        public PrepareData(String[] strIn)//конструктор принимает массив стрингов и разбирает его на ключ и обрабатвыаемый текст
        {
            this.strK = strIn[strIn.Length - 1];//получаем из входящей строки ключ (последнее слово в строке)

            //определение типа используемого алгоритма
            //если ключ удачно конвертируется в число использовать алгоритм Цезаря
            //если ключ не удалось конвертировать - использовать XOR
            int iKey;
            if(int.TryParse(this.strK,out iKey) == true)
            {
                this.alFlags = Algorithms.Cezar;
            }
            else
            {
                this.alFlags = Algorithms.XOR;
            }

            String strWorkMessage = "";//для обрабатываемого сообщения
            for (int i = 0; i < strIn.Length - 1; i++)//формируем из введенных строк одну строку
            {
                strWorkMessage = strWorkMessage + strIn[i] + " ";
            }
            this.strT = strWorkMessage.Trim();//убераем последний пробел
        }

        public String Key//возвращает ключ текущего объекта
        {
            get { return this.strK; }
        }

        public String Text//возвращает обрабатываемый текст текущего объекта
        {
            get { return this.strT; }
        }

        public Algorithms AlgorithmFlag
        {
            get { return this.alFlags; }
        }
    }
}
