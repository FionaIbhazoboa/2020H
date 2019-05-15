using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Cat
    {
        public string name;
        public double[] position;
        public void setName(string givenname)
        {
            name = givenname;
        }
        public void setPosition()
        {
            Random random = new Random();
            position = new double [3];
            position[0] = random.NextDouble();
            position[1] = random.NextDouble();
            position[2]= random.NextDouble();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat();
            cat1.setName("Tiger");
            cat1.setPosition();
            Console.WriteLine("cat1" + cat1.name + " " + cat1.position[0] + cat1.position[1] + cat1.position[2]);
            Console.ReadLine();
        }
    }
}
