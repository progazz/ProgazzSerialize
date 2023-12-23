using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using CsvHelper;
using CsvHelper.Configuration;
using ProgazzSerialize;

class Program
{
    static List<IResearcher> _Researchers = new List<IResearcher> 
    { 
        new NewtonsoftResearch(), 
        new MySerializeResearch()
    };

    static void Main()
    {
        const int _iteration = 1000;
        Console.WriteLine($"Количество итераций для исследования = {_iteration}");

       _Researchers.ForEach(re => 
       {
           Console.WriteLine("------------------------------------------------------");
           Console.WriteLine($"Исследование {re.Name}");
           re.Run(_iteration); 
       });

        Console.ReadKey(); 
    }
}
