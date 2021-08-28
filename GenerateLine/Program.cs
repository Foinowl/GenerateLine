using System;

namespace GenerateLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator();


            GetCommand();

            while (true)
            {
                try
                {
                    string command = ReadCommand();
                    ExecuteCommand(generator, command);
                    Console.WriteLine("Команда исполнилась");
                }
                catch (Exception)
                {
                    Console.WriteLine("ООХххх что-то пошло не так.");
                    GetCommand();
                    continue;
                }

                Console.ReadKey();
            }
            Console.ReadKey();
        }

        public static void ExecuteCommand(Generator gen, string command)
        {
            switch (command)
            {
                case "Write":
                    Write(gen);
                    break;
                case "Owerwrite":
                    OwerWrite(gen);
                    break;
                case "Delete":
                    Delete(gen);
                    break;
                case "GetFile":
                    GetFile(gen);
                    break;
                case "GetMask":
                    GetMask(gen);
                    break;
                case "GetData":
                    GetData(gen);
                    break;
                case "Commands":
                    GetCommand();
                    break;
                default:
                    throw new Exception("Команда не найдена");

            }
        }

        public static void Write(Generator gen)
        {
            Console.WriteLine("Полный путь до файла");
            string filename = Console.ReadLine();
            Console.WriteLine("Маска");
            string mask = Console.ReadLine();
            Console.WriteLine("Указать количество строк для генерации строк");
            int repeat = int.Parse(Console.ReadLine());

            gen.WriteFile(filename, mask, repeat);
        }

        public static void OwerWrite(Generator gen)
        {
            Console.WriteLine("Полный путь до файла");
            string filename = Console.ReadLine();
            Console.WriteLine("Маска");
            string mask = Console.ReadLine();
            Console.WriteLine("Указать количество строк для генерации строк");
            int repeat = int.Parse(Console.ReadLine());

            gen.WriteFile(filename, mask, repeat, true);
        }

        public static void Delete(Generator gen)
        {
            Console.WriteLine("Полный путь до файла");
            string filename = Console.ReadLine();

            gen.DeleteFile(filename);
        }

        public static void GetFile(Generator gen)
        {
            Console.WriteLine("Полный путь до файла");
            string filename = Console.ReadLine();

            var s = gen.GetFile(filename);
            Console.WriteLine("Маска:    {0}", s[0]);

            Console.WriteLine("Сгенированные строки по маске");
            for (int i = 1; i < s.Count; i++)
            {
                Console.WriteLine(s[i]);
            }
        }

        public static void GetMask(Generator gen)
        {
            Console.WriteLine("Полный путь до файла");
            string filename = Console.ReadLine();

            var s = gen.GetFile(filename);
            Console.WriteLine("Маска:    {0}", s[0]);
        }

        public static void GetData(Generator gen)
        {
            Console.WriteLine("Полный путь до файла");
            string filename = Console.ReadLine();

            var s = gen.GetFile(filename);

            Console.WriteLine("Сгенированные строки по маске");
            for (int i = 1; i < s.Count; i++)
            {
                Console.WriteLine(s[i]);
            }
        }

        private static string ReadCommand()
        {
            Console.WriteLine("Введите команду:");
            return Console.ReadLine();
        }

        private static void GetCommand()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("Write - это команда принимает в себя путь файла, маску, количество записей. Команда запишет в файл маску и данные по ней.");
            Console.WriteLine("Owerwrite - это команда принимает в себя путь файла, маску, количество записей. Добавить в текущий файл маску при условии идентичности с предыдущей и в конец новые данные");
            Console.WriteLine("Delete - это команда принимает в себя путь файла. Удаляет файл по его полному пути");
            Console.WriteLine("GetFile - выводит всё данные из файла: маску и строки. Указать полный путь файла");
            Console.WriteLine("GetMask - выводит только маску по полному пути файла");
            Console.WriteLine("GetData - выводит данные по полному пути файла");
            Console.WriteLine("Commands - Повторить команды");
        }

    }
}
