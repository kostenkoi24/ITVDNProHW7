using System;
using System.Reflection;

namespace Homework7_3
{


    [My("1/31/2008", Number = 1)]
    public class MyClass
    {
        [MyAttribute("2/31/2007", Number = 2)]
        public static void Method()
        {
            Console.WriteLine("MyClass.Method()\n");
        }

        static void PrivateMethod()
        {
            Console.WriteLine("MyClass.PrivateMethod()\n");
        }

        int Prop1 { get; set; }
        int Prop2 { get; set; }

    }


    class Program
    {
            /*Розширте можливості програми-рефлектора з попереднього уроку таким чином:
            1. Додайте можливість вибирати, які саме члени типу мають бути показані користувачеві. 
            При цьому має бути можливість вибирати відразу кілька членів типу, наприклад, методи та властивості.
            2. Додайте можливість виводу інформації про атрибути для типів та всіх членів типу,
            які можуть бути декоровані атрибутами.
            */
        static string Text;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            MyClass my = new MyClass();
            MyClass.Method();

            // Аналіз атрибутів.
            Type type = typeof(MyClass);

            PropertyInfo[] properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine("Properties:");
            foreach (var p in properties)
            {
                Console.WriteLine($"Properties:{p.Name}");
            }

            Console.WriteLine("Methods:");
            MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
                var customAttributeData = method.CustomAttributes;
                foreach (var a in customAttributeData)
                {
                    Console.WriteLine($"\t Atributes: {a.AttributeType}");
                }

            }

                
                Console.ReadKey();



        }
    }
}
