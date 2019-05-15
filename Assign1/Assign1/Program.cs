using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The program allows one to add items to a linked list and print them out, 
//Uses an Array to perform the above task,
//And randomly put objects from one array into an new array that can be printed out.
namespace Assign1
{
    class MobileObject
    {
        public string name;
        public string id;
        public float[] position;
        //Constructor
        public MobileObject(string name, string ID)
        {
            this.name = name;
            this.id = ID;
        }
        //Get Set for name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //Get Set for Id
        public string Id
        {
            get { return Id; }
            set { Id = value; }
        }
        //Set for position
        public void setPosition()
        {
            Random random = new Random();

            position = new float[3];
            position[0] = (float)random.NextDouble();
            position[1] = (float)random.NextDouble();
            position[2] = (float)random.NextDouble();
        }
        //Print method that can be overwitten. 
        //Returns are string
        public virtual string Print()
        {
            return name + " " + id ;
        } 
        
    }
    //Inherits from MobileObject
    class NPC : MobileObject
    {
        public int legLength;
        public int torsoHeight;
        public int headHeight;
        //Constructor
        public NPC(string name, string ID, int legLength, int torsoHeight, int headHeight)
            : base (name, ID)
        {
            this.legLength = legLength;
            this.torsoHeight = torsoHeight;
            this.headHeight = headHeight;
            this.setPosition();
        }
        //Get Set for Leg length
        public int LegLength
        {
            get { return legLength; }
            set { if (value > 0) legLength = value; }
        }
        //Get Set for Torso height
        public int TorsoHeight
        {
            get { return torsoHeight; }
            set { if (value > 0) torsoHeight = value; }
        }
        //Get Set for Head height
        public int HeadHeight
        {
            get { return headHeight; }
            set { if (value > 0) headHeight = value; }
        }
        //Calculates total height
        //Returns an integer
        private int totalHeight()
        {
            return legLength + torsoHeight + headHeight;
        }
       
        public override string Print()
        {
            return "Name: " + name + " ID: " + id + " Positions: " + position[0] + " "
                + position[1] + " " + position[2] + " Leg length: " + legLength +
                " Torso Height: " + torsoHeight + " Head Height: " + headHeight  + 
                " Total Height: " + totalHeight();
        }
    }
    //Inherites from MobileObject
    class Vehicle : MobileObject
    {
        int length;
        int height;
        int width;
        //Constructors
        public Vehicle(string name, string ID, int length, int height, int width)
            : base (name, ID)
        {
            this.length = length;
            this.height = height;
            this.width = width;
            this.setPosition();
        }
        //Get Set for Length
        public int Length
        {
            get { return length; }
            set { if (value > 0) length = value; }
        }
        //Get Set for Height
        public int Height
        {
            get { return height; }
            set { if(value > 0) height = value; }
        }
        //Get Set for Width
        public int Width
        {
            get { return width; }
            set { if ( value > 0) width = value; }
        }
        //Calculates the Volume
        //Returns an integer
        private int boundingVolume()
        {
            return length * height * width;
        }
        public override string Print()
        {
            return "Name: " + name
                + " ID: " + id + " Positions: " + position[0] + " " + position[1] + " " + position[2]
                + " Length: " + length + " Height: " + height + " Width: " + width
                + " Volume: " + boundingVolume();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Creates a linked list of moblie objects.
            LinkedList<MobileObject> mobile = new LinkedList<MobileObject>();
            //Creates instance of the class NPC with given parameters
            NPC Gardener = new NPC("Yussef", "01", 22, 12, 5);
            NPC Maid = new NPC("Reyn", "02", 19, 16, 5);
            NPC Butler = new NPC("Chris", "03", 25, 20, 6);
            NPC Sim1 = new NPC("Sara", "04", 20, 19, 6);
            NPC Sim2 = new NPC("Roy", "05", 10, 13, 7);
            //Add to the list from the last.
            mobile.AddLast(Gardener);
            mobile.AddLast(Maid);
            mobile.AddLast(Butler);
            mobile.AddLast(Sim1);
            mobile.AddLast(Sim2);
            //Creates instance of the class NPC with given parameters
            Vehicle vehicle1 = new Vehicle("Car", "06", 50, 30, 23);
            Vehicle vehicle2 = new Vehicle("Bike", "07", 34, 20, 12);
            Vehicle vehicle3 = new Vehicle("Bicycle", "08", 20, 17, 12);
            Vehicle vehicle4 = new Vehicle("Tricycle", "09", 17, 16, 11);
            Vehicle vehicle5 = new Vehicle("Bus", "10", 54, 38, 25);
            mobile.AddLast(vehicle1);
            mobile.AddLast(vehicle2);
            mobile.AddLast(vehicle3);
            mobile.AddLast(vehicle4);
            mobile.AddLast(vehicle5);

            //Print out mobile list of items in moblie
            Console.WriteLine("--- Ordered List ---\n");
            foreach (var member in mobile)
                Console.WriteLine(member.Print());
            Console.WriteLine("\n");


            //Creates an array of objects
            MobileObject[] mobs = new MobileObject[10];
            //Adds the instances to the array
            mobs[0] = Gardener;
            mobs[1] = Maid;
            mobs[2] = Butler;
            mobs[3] = Sim1;
            mobs[4] = Sim2;
            mobs[5] = vehicle1;
            mobs[6] = vehicle2;
            mobs[7] = vehicle3;
            mobs[8] = vehicle4;
            mobs[9] = vehicle5;

            //Print out mobile list of items in mobs
            Console.WriteLine("--- Ordered Array ---\n");
            foreach (var m in mobs)
                Console.WriteLine(m.Print());
            Console.WriteLine("\n");


            //Creates a new array
            MobileObject[] newmobs = new MobileObject[mobs.Length];       
            Random random = new Random();
            int n = mobs.Length;
            //Allows items in mobs[] to be placed in newmobs[] but in random locations
            for (int i = 0; i < n; i++)
            {              
                int j = random.Next(0, n);
                MobileObject t = mobs[i];

                if (newmobs[j]==null)
                {
                    newmobs[j] = t;
                }
                else
                {
                    i--;
                }                
            }

            //Print out mobile list of items in newmobs
            Console.WriteLine("--- Randomly ordered array ---\n");
            foreach (var value in newmobs)
                Console.WriteLine(value.Print());
            Console.WriteLine("\n");

            


            Console.ReadKey();
        }
    }
}
