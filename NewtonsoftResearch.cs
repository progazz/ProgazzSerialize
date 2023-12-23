using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgazzSerialize
{
    public class NewtonsoftResearch: IResearcher
    {
        public string Name => nameof(NewtonsoftResearch);

        public void Run(int iteration = 1000) 
        {
            // Измерение времени сериализации
            Stopwatch serializationWatch = Stopwatch.StartNew();
            for (int i = 0; i < iteration; i++)
            {
                string serializedData = SerializeObject(F.Get());
                // Вывести в консоль полученную строку
                //Console.WriteLine(serializedData);
            }
            serializationWatch.Stop();
            Console.WriteLine($"Время на сериализацию = {serializationWatch.ElapsedMilliseconds} мс");

            // Измерение времени на вывод в консоль
            Stopwatch consoleOutputWatch = Stopwatch.StartNew();
            for (int i = 0; i < iteration; i++)
            {
                //Console.WriteLine("Пример вывода в консоль");
            }
            consoleOutputWatch.Stop();
            Console.WriteLine($"Время на вывод в консоль = {consoleOutputWatch.ElapsedMilliseconds} мс");

            // Измерение времени десериализации
            Stopwatch deserializationWatch = Stopwatch.StartNew();
            for (int i = 0; i < iteration; i++)
            {
                F deserializedObject = DeserializeObject<F>("{ \"i1\": 1, \"i2\": 2, \"i3\": 3, \"i4\": 4, \"i5\": 5 }");
                // Можно выполнить дополнительные операции с deserializedObject
            }
            deserializationWatch.Stop();
            Console.WriteLine($"Время на десериализацию = {deserializationWatch.ElapsedMilliseconds} мс");

            // Сериализация с использованием Newtonsoft.Json
            Stopwatch jsonSerializationWatch = Stopwatch.StartNew();
            for (int i = 0; i < iteration; i++)
            {
                string jsonSerializedData = JsonConvert.SerializeObject(F.Get());
                // Вывести в консоль полученную строку
               // Console.WriteLine(jsonSerializedData);
            }
            jsonSerializationWatch.Stop();
            Console.WriteLine($"Время на сериализацию (Newtonsoft.Json) = {jsonSerializationWatch.ElapsedMilliseconds} мс");

            // Десериализация с использованием Newtonsoft.Json
            Stopwatch jsonDeserializationWatch = Stopwatch.StartNew();
            for (int i = 0; i < iteration; i++)
            {
                F jsonDeserializedObject = JsonConvert.DeserializeObject<F>("{ \"i1\": 1, \"i2\": 2, \"i3\": 3, \"i4\": 4, \"i5\": 5 }");
                // Можно выполнить дополнительные операции с jsonDeserializedObject
            }
            jsonDeserializationWatch.Stop();
            Console.WriteLine($"Время на десериализацию (Newtonsoft.Json) = {jsonDeserializationWatch.ElapsedMilliseconds} мс");
        }

        // Функция сериализации объекта в строку JSON
        private static string SerializeObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        // Функция десериализации строки JSON в объект
        private static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
