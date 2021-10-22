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

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = "C:/Users/Фролов Юрий/source/repos/Lab16HomeWork16version1/Lab16HomeWork16version1/bin/Debug/Product/Product.json";
            using (StreamReader sr = new StreamReader(path))
            {
                string[] arrayJsonString = new string[5];
                double priceMax = 0;
                string priceMaxName = "";
                for (int i = 0; i < 5; i++)
                {
                    arrayJsonString[i] = sr.ReadLine();
                    Product product1 = JsonSerializer.Deserialize<Product>(arrayJsonString[i]); //Десериализация 
                    Console.WriteLine("Код товара: {0}    Название товара: {1,8}    Цена товара: {2,5:f2}", product1.Code, product1.Name,product1.Price);
                    if (priceMax< product1.Price)
                    {
                        priceMaxName = product1.Name;

                    }
                }
                Console.WriteLine();
                Console.WriteLine("Самый дорогой товар: {0,8}", priceMaxName);
            }
            Console.ReadKey();
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
