using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaxLength
{
    class Program
    {
        static int FindLengthMaxWord(string text)
        {
            int max = 0;
            int currentLength = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if(text[i] != '\r' && text[i] != '\n')
                {
                    currentLength++;
                }
                else
                {
                    if (max < currentLength)
                        max = currentLength;
                    currentLength = 0;
                }
            }

            if(max == 0 && currentLength != 0) //Сработает, если файл состоит из одного слова
                max = currentLength;

            if (max == 0 && currentLength == 0) //Сработает, если файл содержит одни пробелы или переносы
                return -1;

            return max;
        }
        static void Main()
        {
            try
            {
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    string text = sr.ReadToEnd();

                    int res = FindLengthMaxWord(text);

                    if (text.Length == 0 || res == -1)
                    {
                        Console.WriteLine("Файл не содержит слов");
                    }
                    else
                    {
                        Console.WriteLine("Длина максимального слова {0}", res);
                    } 
                }
            }

            catch (Exception err)
            {
                Console.WriteLine("Ошибка при чтении файла:");
                Console.WriteLine(err.Message);
            }

            Console.ReadLine();
        }
    }
}
