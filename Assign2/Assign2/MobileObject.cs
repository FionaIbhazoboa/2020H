using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign2
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
            return name + " " + id;
        }
        public override string ToString()
        {
            return Print();
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
            : base(name, ID)
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
            return "\nName: " + name + " ID: " + id + " \nPositions: " + position[0] + " "
                + position[1] + " " + position[2] + " \nLeg length: " + legLength +
                " Torso Height: " + torsoHeight + " Head Height: " + headHeight +
                " \nTotal Height: " + totalHeight();
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
            : base(name, ID)
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
            set { if (value > 0) height = value; }
        }
        //Get Set for Width
        public int Width
        {
            get { return width; }
            set { if (value > 0) width = value; }
        }
        //Calculates the Volume
        //Returns an integer
        private int boundingVolume()
        {
            return length * height * width;
        }
        public override string Print()
        {
            return "\nName: " + name
                + " ID: " + id + " \nPositions: " + position[0] + " " + position[1] + " " + position[2]
                + " \nLength: " + length + " Height: " + height + " Width: " + width
                + " \nVolume: " + boundingVolume();
        }

    }
}

