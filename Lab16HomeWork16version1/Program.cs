using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace Lab16HomeWork16version1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Фролов Юрий/source/repos/Lab16HomeWork16version1/Lab16HomeWork16version1/bin/Debug/Product/Product.json"; // Путь
            if (!File.Exists(path)) // Содаем файл
            {File.Create(path);}
            else
            {
                using (StreamWriter sw = new StreamWriter(path))   // Записываем в файл
                {
                    try
                    {
                        string[] arrayJsonString = new string[5];// НЕ ЗАБЫТЬ исправить на 5
                        for (int i = 0; i < 5; i++) // НЕ ЗАБЫТЬ исправить на 5
                        {
                            #region Ввод переменных
                            Console.Write("Введите код товара: ");
                            int code = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите название товара: ");
                            string name = Convert.ToString(Console.ReadLine());
                            Console.Write("Введите стоимость товара: ");
                            double prise = Convert.ToDouble(Console.ReadLine());
                            #endregion

                            Product product = new Product() //Обращение к классу
                            {
                                Code = code,
                                Name = name,
                                Price = prise,
                            };//Обращение к классу
                            JsonSerializerOptions options = new JsonSerializerOptions() //Опции. Добавляем Кирилицу и пробелы
                            {
                                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                                //WriteIndented = true  
                            };//Опции. Добавляем Кирилицу и пробелы
                            arrayJsonString[i] = JsonSerializer.Serialize(product, options); //Сериализация 
                            sw.WriteLine(arrayJsonString[i]);
                            Console.WriteLine();
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                }
                //sw.Close();
                Console.WriteLine("Запись в файл Product.json произведена.");
                Console.ReadKey();
            }
        }
    }
    class Product
    {
        [JsonPropertyName("Код товара")]
        public int Code { get; set; }
        [JsonPropertyName("Название товара")]
        public string Name { get; set; }
        [JsonPropertyName("Цена товара")]
        public double Price { get; set; }
    }
}
