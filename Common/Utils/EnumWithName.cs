using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class EnumWithName<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }

        public static EnumWithName<T>[] ParseEnum()
        {
            List<EnumWithName<T>> list = new List<EnumWithName<T>>();

            foreach (object o in Enum.GetValues(typeof(T)))
            {
                list.Add(new EnumWithName<T>
                {
                    Name = Enum.GetName(typeof(T), o),
                    Value = (T)o
                });
            }

            return list.ToArray();
        }
    }
}
