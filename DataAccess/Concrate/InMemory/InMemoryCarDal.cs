using DataAccess.InMemory.Abstract;
using Entities.Concrate;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            
                new Car{Id=1,BrandId = 1 , ColorId = 1,DailyPrice= 10000 , ModelYear = new DateTime(1900,12,1),Description = "arac hakkında acıklama" },
                new Car{Id=2,BrandId = 1 , ColorId = 2,DailyPrice= 15000 , ModelYear = new DateTime(1999,12,1),Description = "arac hakkında acıklama" },
                new Car{Id=3,BrandId = 2 , ColorId = 1,DailyPrice= 16000 , ModelYear = new DateTime(1980,12,1),Description = "arac hakkında acıklama" },
                new Car{Id=4,BrandId = 3 , ColorId = 5,DailyPrice= 20000 , ModelYear = new DateTime(2000,12,1),Description = "arac hakkında acıklama" },

            };
        }

        public List<CarDetailsDto> GetCarDetails() 
        {

            return null;
        
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            _cars.Remove(_cars.SingleOrDefault(c => c.Id == car.Id));
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public void Update(Car car)
        {
             Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
                        
        }
    }
}
