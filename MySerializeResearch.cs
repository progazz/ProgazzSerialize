using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgazzSerialize
{
    public class MySerializeResearch : IResearcher
    {
        public string Name => nameof(MySerializeResearch);

        public void Run(int iteration = 1000)
        {
            // Измерение времени сериализации с использованием своего CSV-сериализатора
            Stopwatch customCsvSerializationWatch = Stopwatch.StartNew();
            var customCsvSerializer = new CsvSerializer<F>();
            for (int i = 0; i < iteration; i++)
            {
                string csvSerializedData = customCsvSerializer.Serialize(F.Get());
                //Console.WriteLine(csvSerializedData);
            }
            customCsvSerializationWatch.Stop();
            Console.WriteLine($"Время на сериализацию (CSV) = {customCsvSerializationWatch.ElapsedMilliseconds} мс");

            // Измерение времени десериализации с использованием своего CSV-сериализатора
            Stopwatch customCsvDeserializationWatch = Stopwatch.StartNew();
            for (int i = 0; i < iteration; i++)
            {
                F csvDeserializedObject = customCsvSerializer.Deserialize("1,2,3,4,5");
                // Можно выполнить дополнительные операции с csvDeserializedObject
            }
            customCsvDeserializationWatch.Stop();
            Console.WriteLine($"Время на десериализацию (CSV) = {customCsvDeserializationWatch.ElapsedMilliseconds} мс");

            // Сериализация с использованием Newtonsoft.Json
            Stopwatch jsonSerializationWatch = Stopwatch.StartNew();
            for (int i = 0; i < iteration; i++)
            {
                string jsonSerializedData = JsonConvert.SerializeObject(F.Get());
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
    }
}
