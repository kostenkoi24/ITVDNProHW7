using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7_2
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class MyAttribute : System.Attribute
    {
        public void Method()
        {
            Console.WriteLine("Метод класу Атрибуту");
        }

        public void Method2()
        {
            Console.WriteLine("Метод2 класу Атрибуту");
        }
    }
}
