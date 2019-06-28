using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication5
{
    class Program
    {
        static void PrintMenu()
            {
            Console.Write("Выберите пункт\n1 Вставить текст в начало файла\n2 Вставить текст в конец файла\n3 Прочесть файл\n");
            }
        static void Main(string[] args)
        {
            int choose;

            do
            {
                PrintMenu();
                choose = Convert.ToInt32(Console.ReadLine());
                string filename,tekst;
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Введите имя файла\n");
                        filename=Convert.ToString(Console.ReadLine());
                        Console.Clear();
                        Console.Write("Введите текст\n");
                        tekst = Convert.ToString(Console.ReadLine());
                        if (!File.Exists(filename))
                        {
                            File.WriteAllText(filename, tekst);   
                        }
                        else
                        {
                            File.WriteAllText(filename, string.Format("{0} {1}", tekst, File.ReadAllText(filename)));
                        }
                        
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Введите имя файла\n");
                        filename = Convert.ToString(Console.ReadLine());
                        Console.Clear();
                        Console.Write("Введите текст\n");
                        tekst = Convert.ToString(Console.ReadLine());
                        if (!File.Exists(filename))
                        {                            
                            File.WriteAllText(filename, tekst);
                        }
                        else
                        {
                            File.AppendAllText(filename, tekst);
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Введите имя файла\n");
                        filename = Convert.ToString(Console.ReadLine());
                        Console.Clear();
                        if (File.Exists(filename))
                        {
                            FileStream stream = new FileStream(filename, FileMode.Open);
                            StreamReader reader = new StreamReader(stream);
                            tekst = reader.ReadToEnd();
                            stream.Close();
                            Console.WriteLine(tekst);
                            Console.Write("\nНажмите Enter для продолжения...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Указанный файл не найден\nНажмите Enter для продолжения...");
                            Console.ReadLine();
                        }
                        break;
                }
                Console.Clear();
            }
                while (choose!=0) ;
        }
    }
}
