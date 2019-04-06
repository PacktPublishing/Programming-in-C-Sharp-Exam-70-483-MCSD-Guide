using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_2
{
    public interface ICar
    {
        void ImplementBrake();
        void ImplementAccelerator();
        void ImplementBrand();
        void ImplementColor();
    }

    class Program
    {
        static void Main(string[] args)
        {
            dynamic typeVariable = 100;
            Console.WriteLine(typeVariable + typeVariable.GetType().ToString());
            typeVariable = "Hello";
            Console.WriteLine(typeVariable + typeVariable.GetType().ToString());
            typeVariable = true;
            Console.WriteLine(typeVariable + typeVariable.GetType().ToString());
            Console.ReadLine();

            CoordinatePoint classCoordinate = new CoordinatePoint(.82F, .34F);
            CoordinatePointStruct structCoordinate = new CoordinatePointStruct(.82F, .34F);
            Console.WriteLine("Initial Coordinates for Class are :" + classCoordinate.xCoordinate.ToString() + " " + classCoordinate.yCoordinate.ToString());
            Console.WriteLine("Initial Coordinates for Struct are :" + structCoordinate.xCoordinate.ToString() + " " + structCoordinate.yCoordinate.ToString());
            ChangeValuesClass(classCoordinate);
            ChangeValuesStruct(structCoordinate);
            Console.WriteLine("Initial Coordinates for Class are :" + classCoordinate.xCoordinate.ToString() + " " + classCoordinate.yCoordinate.ToString());
            Console.WriteLine("Initial Coordinates for Struct are :" + structCoordinate.xCoordinate.ToString() + " " + structCoordinate.yCoordinate.ToString());
            Console.ReadLine();

            CarA carA = new CarA();
            carA.ImplementAccelerator();
            carA.ImplementBrake();
            carA.FoldableSeat();

            CarB carB = new CarB();
            carB.ImplementAccelerator();
            carB.ImplementBrake();
            carB.RoofTopExtendable();
            Console.ReadLine();

        }

        static void ChangeValuesClass(CoordinatePoint obj)
        {
            obj.xCoordinate = .5F;
            obj.yCoordinate = .5F;
        }

        static void ChangeValuesStruct(CoordinatePointStruct obj)
        {
            obj.xCoordinate = .5F;
            obj.yCoordinate = .5F;
        }
    }

    class CoordinatePoint
    {
        public float xCoordinate;
        public float yCoordinate;

        public CoordinatePoint()
        {

        }

        public CoordinatePoint(float x, float y)
        {
            this.xCoordinate = x;
            this.yCoordinate = y;
        }
    }

    struct CoordinatePointStruct
    {
        public float xCoordinate;
        public float yCoordinate;

        public CoordinatePointStruct(float x, float y)
        {
            this.xCoordinate = x;
            this.yCoordinate = y;
        }
    }

    public class Car
    {
        public DateTime manufacturingDate;
        public string bodyType;
        public float fuelCapacity;
        public void ImplementBrake()
        {
            Console.WriteLine("Inside Base Class Implement Brake");
        }
        public void ImplementAccelerator()
        {
            Console.WriteLine("Inside Base Class Implement Accelerator");
        }
    }

    public class CarA : Car
    {
        public CarA()
        {
            this.bodyType = string.Empty;
            this.manufacturingDate = DateTime.MinValue;
            this.fuelCapacity = 0.0F;
        }
        public CarA(DateTime manufacturingDate, string bodyType, float fuelCapacity)
        {
            this.bodyType = bodyType;
            this.manufacturingDate = manufacturingDate;
            this.fuelCapacity = fuelCapacity;
            Console.WriteLine("Inside Car A Constructor");
        }
        public void FoldableSeat()
        {
            Console.WriteLine("Inside Car A Foldable Seat");
        }
    }

    class CarB : Car
    {
        public CarB()
        {
            this.bodyType = string.Empty;
            this.manufacturingDate = DateTime.MinValue;
            this.fuelCapacity = 0.0F;
        }
        public CarB(DateTime manufacturingDate, string bodyType, float fuelCapacity)
        {
            this.bodyType = bodyType;
            this.manufacturingDate = manufacturingDate;
            this.fuelCapacity = fuelCapacity;
            Console.WriteLine("Inside Car B Constructor");
        }
        public void RoofTopExtendable()
        {
            Console.WriteLine("Inside Car B Foldable Seat");
        }
    }

    public class Product
    {
        public void ImplementBrand()
        {
            Console.WriteLine("Inside Base Class Implement Brake");
        }
        public void ImplementColor()
        {
            Console.WriteLine("Inside Base Class Implement Accelerator");
        }
    }
}
