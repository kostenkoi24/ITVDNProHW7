using System;
using System.Text;

namespace Homework7_5
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class AccessLevelAttribute : System.Attribute
    {
        private int level;
        public AccessLevelAttribute(int level)
        {
            this.level = level;
        }

        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }

    }

    class Connector
    {
        public virtual void ConnectToDB()
        {
            Console.WriteLine("connecting...");
        }
    }

    
    [AccessLevel(0)]
    class Programmer : Connector
    {
        public override void ConnectToDB()
        {
            base.ConnectToDB();
            ////object[] attributes = typeof(); //.GetCustomAttributes(false);
            //Type t = this.GetType();
            //object[] attributes =  t.GetCustomAttributes(false);

            //Console.WriteLine($"Class type = {t.Name}"); 

            //foreach (Attribute attribute in attributes)
            //{
            //    Console.WriteLine("Attribute: {0}", attribute.GetType().Name, attribute.Name);
            //}
        }
    }

    [AccessLevel(1)]
    class Director : Connector
    {

    }

    [AccessLevel(2)]
    class Manager : Connector
    {

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Programmer programmer = new Programmer();
            Director director = new Director();
            Manager manager = new Manager();

            programmer.ConnectToDB();
            GetAttribute(typeof(Programmer));

            director.ConnectToDB();
            GetAttribute(typeof(Director));

            Console.ReadKey();
        }


        public static void GetAttribute(Type t)
        {
            AccessLevelAttribute MyAttribute =
                (AccessLevelAttribute)Attribute.GetCustomAttribute(t, typeof(AccessLevelAttribute));

            if (MyAttribute == null)
            {
                Console.WriteLine("The attribute was not found.");
            }
            else
            {
                Console.WriteLine("Attribute value:{0}", MyAttribute.Level);
            }
        }
    }
}
