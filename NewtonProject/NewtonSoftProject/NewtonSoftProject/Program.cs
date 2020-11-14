////////////////////////////////////////////////////////////////////////////////////////////////////////////////// //
// Project: SystemTextJson
// File Name: Program.cs
// Description: Driver
// Course: CSCI-2910-940
// Author: Sydni Ward
// Created: 11/14/2020
// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.IO;
using System;
using Newtonsoft.Json;

namespace NewtonSoftProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonSource = Directory.GetParent                             //getting the root directory 
                (Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string path = $"{jsonSource}/response.json";                        //Set path

            //Deserialize
            using (StreamReader file = File.OpenText(path))                     //Open Text using stream
            {
                JsonSerializer serializer = new JsonSerializer();
                Book book2 = (Book)serializer.Deserialize(file, typeof(Book));  //Deserialize

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
            path = $"{jsonSource}/book.json";                                   //set new path
            string jsonString = File.ReadAllText($"{jsonSource}/response.json");//Read the text with in a file
           
            // serialize JSON to a string and then write string to a file
            File.WriteAllText(path, JsonConvert.SerializeObject(jsonString));

            //// serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();               //intialize JsonSerializer
                serializer.Serialize(file, jsonString);                         //Serialize and put into file
            }
        }
    }
}
