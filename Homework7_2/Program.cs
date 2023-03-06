using System;
using System.Reflection;

namespace Homework7_2
{
    class Program
    {

        [Obsolete("Warning")] //у формі, що просто виводить попередження
        //[Obsolete("Error", true)] - у формі, що перешкоджає компіляції
        [My()]  //Продемонструйте роботу атрибута з прикладу виклику даних методів
        public class MyClass
        {
            [Obsolete("Warning")]
            public static void Method()
            {
                Console.WriteLine("MyClass.Method()\n");
            }
        }



        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            /*Створіть клас і застосуйте до його методів атрибут Obsolete
             * спочатку у формі, що просто виводить попередження, а потім у
             * формі, що перешкоджає компіляції. Продемонструйте роботу
             * атрибута з прикладу виклику даних методів.*/

            MyClass my = new MyClass();
            //MyClass.Method();


            Type type = typeof(MyClass);

            

            object[] attributes = type.GetCustomAttributes(typeof(MyAttribute), true);

            foreach (MyAttribute attribute in attributes)
            {
                attribute.Method();
                attribute.Method2();
            }

            Console.ReadKey();
        }
    }
}
