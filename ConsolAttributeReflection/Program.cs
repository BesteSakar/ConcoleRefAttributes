using System;

namespace ConsolAttributeReflection
{
    internal class Program
    {


        /*
         Attributeslar ve reflection genelde beraber kullanılırlar.
        Run time esnasında class enum,method gibi yapılarla bilgi veren
        ve kontrol etmemizi sağlayan yapılardır..
        -------------------------------------------------------------

        Aşağıdaki örneğimizde person ismindeki sınıfımıza tanımladığımız prop.lerin
        hepsine bir değer girilmesini,oluşturduğumuz attributes satesinde zorunlu hale getirdik.
        Control sınıfımızdaki check metodumuzlada bu kontrol işlemini sağladık..
        Foreach ve iflerle doluluk durumuna bakıp,bool bir değer döndürdük...
      

        */





        static void Main(string[] args)
        {
            person p1 = new person()
            {
                Name = "Mehmet",
                Age = 34

            };

            Console.WriteLine(Control.Check(p1));
            Console.ReadLine();
           
        }

        public class person
        {
            [zorunlu]
            public string Name;
            [zorunlu]
            public string ID;
            [zorunlu]
            public int Age;
        }


        public class zorunluAttribute : Attribute
        {

        }

        public static class Control
        {
            public static bool Check(person ins)
            {
                Type type = ins.GetType();
                foreach(var item in type.GetFields())
                {
                    object[] attributes = item.GetCustomAttributes(typeof(zorunluAttribute), true);
                    if(attributes.Length != 0)
                    {
                        object value = item.GetValue(ins);

                        if(value == null)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }





    }
}
