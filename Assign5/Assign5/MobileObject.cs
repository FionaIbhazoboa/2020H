using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign5
{
    //abstract method
    abstract class MobileObject : IComparable<MobileObject>
    {
        public abstract int CompareTo(MobileObject obj);
        public abstract int distancefromOrigin();
    }
    //Inherits from MobileObject
    class NPC : MobileObject
    {
        private static Random random = new Random();
        public static int GetRandom()
        {
            return random.Next(0, 40);
        }
        public string id;
        public int[] position = new int[3];

        //Constructor
        public NPC(string ID)
        {
            this.id = ID;
            this.setPosition();
            this.distancefromOrigin();
        }

        //Get Set for Id
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        //Set for position
        public void setPosition()
        {
            // position = new int[3];
            position[0] = GetRandom();
            position[1] = GetRandom();
            position[2] = GetRandom();
        }

        //Overrides the abstract method in Mobile objects
        public override int distancefromOrigin()
        {
            int x = position[0],
                y = position[1],
                z = position[2];
            return (int)Math.Sqrt((x * x) + (y * y) + (z * z));
        }
        //Overrides abstract method in Mobile objects. 
        //Also sorts object
        //this should sort it in decending order. 
        public override int CompareTo(MobileObject obj)
        {
            if (this.distancefromOrigin() > obj.distancefromOrigin())
                return -1;
            if (this.distancefromOrigin() == obj.distancefromOrigin())
                return 0;
            else
                return 1;
        }
        //Returns are string
        public string Print()
        {
            return "\nID: " + id + " -- " + "Distance from Origin: " + distancefromOrigin();
        }
        public override string ToString()
        {
            return Print();
        }
    }
    //Inherites from MobileObject
    class Vehicle : MobileObject
    {
        private static Random random = new Random();
        public static int GetRandom()
        {
            return random.Next(40, 80);
        }
        public string id;
        public int[] position = new int[3];
        //Constructor
        public Vehicle(string ID)
        {
            this.id = ID;
            this.setPosition();
            this.distancefromOrigin();
        }

        //Get Set for Id"
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        //Set for position
        public void setPosition()
        {
            position = new int[3];

            position[0] = GetRandom();
            position[1] = GetRandom();
            position[2] = GetRandom();
        }
        //Overrides the abstract method in Mobile objects
        public override int distancefromOrigin()
        {
            int x = position[0],
                y = position[1],
                z = position[2];
            return (int)Math.Sqrt((x * x) + (y * y) + (z * z));
        }
        //Overrides abstract method in Mobile objects. 
        //Also sorts objects
        public override int CompareTo(MobileObject obj)
        {
            if (this.distancefromOrigin() > obj.distancefromOrigin())
                return -1;
            if (this.distancefromOrigin() == obj.distancefromOrigin())
                return 0;
            else
                return 1;

        }
        //Returns are string
        public string Print()
        {
            return "\nID: " + id + " -- " + "Distance from Origin: " + distancefromOrigin();
        }
        public override string ToString()
        {
            return Print();
        }

    }
    
}
