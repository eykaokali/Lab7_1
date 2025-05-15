using System;

namespace Lab7_1
{

    internal class Program
    {
        static List<TV> TVs;
        static void printTVs()
        {
            foreach (TV tv in TVs)
                Console.WriteLine(tv.info());
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            TVs = new List<TV>();
            FileStream FS = new FileStream("TV.tv", FileMode.Open);
            BinaryReader br = new BinaryReader(FS);
            try
            {
                TV tv;
                Console.WriteLine("Читаємо дані з файлу");
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    tv = new TV();
                    for (int i = 1; i <= 8; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                tv.Model = br.ReadString();
                                break;
                            case 2:
                                tv.Brand = br.ReadString();
                                break;
                            case 3:
                                tv.ScreenSize = br.ReadInt32();
                                break;
                            case 4:
                                tv.Resolution = br.ReadString();
                                break;
                            case 5:
                                tv.IsSmart = br.ReadBoolean();
                                break;
                            case 6:
                                tv.Color = br.ReadString();
                                break;
                            case 7:
                                tv.Price = br.ReadDouble();
                                break;
                        }
                    }
                    TVs.Add(tv);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталась помилка: {0}", ex.Message);
            }
            finally
            {
                br.Close();
            }
            Console.WriteLine("Несортований перелік телевізорів {0}", TVs.Count);
            printTVs();
            TVs.Sort();
            Console.WriteLine("Сортований перелік телевізорів {0}", TVs.Count);
            printTVs();
            Console.WriteLine("Додаємо новий запис LG");
            TV tvLG = new TV("A55", "LG", 55, "1380x2250", false, "Чорний", 30000);
            TVs.Add(tvLG);
            TVs.Sort();
            Console.WriteLine("Перелік телевізорів: {0}", TVs.Count);
            printTVs();
            Console.WriteLine("Видаляємо останій телевізор", TVs.Count);
            TVs.RemoveAt(TVs.Count - 1);
            Console.WriteLine("Перелік телевізорів: {0}", TVs.Count);
            printTVs();

        }
    }
}