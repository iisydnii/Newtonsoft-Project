using System.IO;
using System;
using Newtonsoft.Json;

namespace NewtonProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookObj = new Book();

            string jsonSource = Directory.GetParent                             //getting the root directory 
                (Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string path = $"{jsonSource}/response.json";   //getting path


            //Deserialize

            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                Book book2 = (Book)serializer.Deserialize(file, typeof(Book));

                //Proof it works

                Console.WriteLine(book2.kind);
                Console.WriteLine(book2.totalItems);
                foreach (var i in book2.items)
                {
                    Console.WriteLine(i.selfLink + "\n" + i.etag);
                    foreach (var j in i.volumeInfo.authors)
                    {
                        Console.WriteLine(j);
                    }
                }

            }

            //Serialize 
            path = $"{jsonSource}/book.json";
            string jsonString = File.ReadAllText($"{jsonSource}/response.json");
           
            // serialize JSON to a string and then write string to a file
            File.WriteAllText(path, JsonConvert.SerializeObject(jsonString));

            //// serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, jsonString);
            }

            //string json = JsonSerializer.Serialize(jsonString, serializeOptions);

            //Console.WriteLine(json);



        }
    }
}
