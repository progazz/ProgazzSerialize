using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgazzSerialize
{
    public class CsvSerializer<T>
    {
        public string Serialize(T obj)
        {
            var properties = typeof(T).GetProperties();
            var csvString = string.Join(",", properties.Select(prop => prop.GetValue(obj)));
            return csvString;
        }

        public T Deserialize(string csvString)
        {
            var values = csvString.Split(',');
            var obj = Activator.CreateInstance<T>();
            var properties = typeof(T).GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                var value = Convert.ChangeType(values[i], properties[i].PropertyType);
                properties[i].SetValue(obj, value);
            }

            return obj;
        }
    }
}
