using AutomobileLibrary.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {
        private static List<Car> CarList = new List<Car>()
        {
            new Car{CarID=1, CarName="CRV", Manufacturer="Honda", Price =30000, ReleaseYear =2021},
            new Car{CarID=2, CarName="Ford Focus", Manufacturer="Ford", Price=15000, ReleaseYear=2020}
        };
        private static CarDBContext instance = null;
        private static readonly object instanceLock = new object();
        private CarDBContext() { }
        public static CarDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }
        public List<Car> GetCarList => CarList;
        public Car GetCarID(int carID)
        {
            //using LINQ to object
            Car car = CarList.SingleOrDefault(pro=>pro.CarID == carID);
            return car;
        }

        //Add new a car
        public void AddNew(Car car)
        {
            Car pro = GetCarID(car.CarID);
            if(pro == null)
            {
                CarList.Add(car);
            } 
            else
            {
                throw new Exception("Car is already exists.");
            }
        }

        //Update a car
        public void Update(Car car) { 
            Car c = GetCarID(car.CarID);
            if(c != null)
            {
                var index = CarList.IndexOf(c);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("Car does not already exists.");
            }
        }

        //Remote a car
        public void Remove(Car car)
        {
            Car p = GetCarID(car.CarID);
            if(p != null)
            {
                CarList.Remove(p);
            }
            else
            {
                throw new Exception("Car does not already exists.");
            }
        }

        internal void Remove(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
