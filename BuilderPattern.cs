using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public interface ICarBuilder
    {
        void BuildWheels();
        void BuildChassis();
        void BuildDoors();
        void BuildSportChassis();
        void BuildSportDoors();
        void BuildSportWheels();
        void BuildSeats();
        void BuildSportSeats();
    }

    public class CarBuilder : ICarBuilder
    {
        private Car _car = new Car();
        
        public CarBuilder()
        {
            this.Reset();
        }

        private void Reset()
        {
            this._car = new Car();
        }

        public void BuildWheels()
        {
            this._car.Add("--------> Basic Wheels\n");
        }

        public void BuildChassis()
        {
            this._car.Add("--------> Basic Chassis\n");
        }

        public void BuildDoors()
        {
            this._car.Add("--------> Basic Doors\n");
        }

        public void BuildSportChassis()
        {
            this._car.Add("--------> Sport Chassis\n");
        }

        public void BuildSportDoors()
        {
            this._car.Add("--------> Sport Doors\n");
        }

        public void BuildSportWheels()
        {
            this._car.Add("--------> Sport Wheels\n");
        }

        public void BuildSeats()
        {
            this._car.Add("--------> Basic Seats\n");
        }

        public void BuildSportSeats()
        {
            this._car.Add("--------> Sport Seats\n");
        }

        public Car GetCar()
        {
            Car result = this._car;
            this.Reset();
            return result;
        }
    }

    public class Car
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i];
            }

            str = str.Remove(str.Length - 2);
            return "----> Product parts:\n" + str;
        }
    }

    public class Director
    {
        private ICarBuilder _carBuilder;

        public ICarBuilder Builder
        {
            set => _carBuilder = value;
        }

        public void BuildSportCar()
        {
            this._carBuilder.BuildSportChassis();
            this._carBuilder.BuildSportDoors();
            this._carBuilder.BuildSportWheels();
            this._carBuilder.BuildSportSeats();
        }

        public void BuildBasicCar()
        {
            this._carBuilder.BuildChassis();
            this._carBuilder.BuildDoors();
            this._carBuilder.BuildWheels();
            this._carBuilder.BuildSeats();
        }
    }
    
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var directorCreator = new Director();
            var carBuilder = new CarBuilder();
            
            directorCreator.Builder = carBuilder;
            
            Console.WriteLine("Constructing a Sport car:");
            directorCreator.BuildSportCar();
            Console.WriteLine(carBuilder.GetCar().ListParts());
            
            Console.WriteLine("----------------------------------------");
            
            Console.WriteLine("Constructing a Basic car:");
            directorCreator.BuildBasicCar();
            Console.WriteLine(carBuilder.GetCar().ListParts());
        }
    }
    */
}