using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1a
{
    class Cat
    {
        public string name;
        public int age;
        public float mass;
        public double[] position;

        public Cat(string givenname, int givenage, int givenmass)
        {
            name = givenname;
            age = givenage;
            mass = givenmass;

        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public float Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        public void setPosition()
        {
            Random random = new Random();

            position = new double[3];
            position[0] = random.NextDouble();
            position[1] = random.NextDouble();
            position[2] = random.NextDouble();
        }
            public int Birthday()
            {
            return age++;

            }
        public float Eat()
        {
            return mass++;
        }
        public double Move()
        {
            return 0.0;
        }
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Cat> cats = new LinkedList<Cat>();
            Cat Cat1 = new Cat("Jawaharlal", 3, 9);
            Cat1.setPosition();
            Cat Cat2 = new Cat("Willow", 16, 5);
            Cat2.setPosition();
            Cat Cat3 = new Cat("Indra", 3, 4);
            Cat3.setPosition();
            Cat Cat4 = new Cat("Tiger", 19,6);
            Cat4.setPosition();

            cats.AddLast(Cat1);
            cats.AddLast(Cat2);
            cats.AddLast(Cat3);
            cats.AddLast(Cat4);


            foreach (var member in cats)
               Console.WriteLine(member.name + " " + member.age + " " + member.mass +"kg" + " " + member.position[0]+ " " + member.position[1]+ " " + member.position[2]);
           

            Console.ReadLine();

        }
    }
}
