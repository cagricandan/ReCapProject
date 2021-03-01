using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;
using DataAccess.InMemory.Abstract;
using Entities.Concrate;
using Entities.DTO;
using System;
using System.Linq;

namespace UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ColorTest();

            //BrandTest();

            //RentalCar();


        }

        private static void RentalCar()
        {
            Customer customer = new Customer
            {
                UserID=1,
                CompanyName = "deneme"
            };

            User user = new User
            {

                Email = "test@mail.com",
                FirstName = "çağrı",
                LastName = "candan",
                Password = "123456"
            };

            Rental rental = new Rental
            {
                CarID = 1,
                CustomerID = 3,
                RentDate = new DateTime(1999, 2, 2),

            };


            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            
            userManager.Add(user);

            customerManager.Add(customer);
            //var result=rentalManager.Add(rental);

            //Console.WriteLine(result.Message);

            foreach (var rental1 in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental1.CarID);
            }
        }

        private static void BrandTest()
        {
            Brand brand = new Brand
            {
                Id = 5,
                Name = "Bmw"

            };

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //var result = brandManager.Add(brand);
            //var result = brandManager.Delete(brand);
            //var result = brandManager.Update(brand);
            var result = brandManager.GetById(2);
            //brand = result.Data;
            Console.WriteLine(result.Data.Name);
            foreach (var _brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(_brand.Name);
            }
        }

        private static void ColorTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            ColorManager colorManager = new ColorManager(new EfColorDal());

            Color color = new Color
            {
                Name = "Mor"
            };

            var result = colorManager.Add(color);

            if (result.Success != true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            foreach (var _color in colorManager.GetAll().Data)
            {
                Console.WriteLine(_color.Name);
            }
        }

        private static void Denemeler()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car { BrandId = 2, ColorId = 3, DailyPrice = 50000, Description = "added data", CarName = "F1b", ModelYear = new DateTime(2015, 12, 1) };


            //carManager.Add(car);
            //carManager.Delete(car);
            //carManager.Update(car);

            //foreach (var car1 in carManager.GetAll())
            //{
            //    Console.WriteLine(car1.Id + " " + car1.ColorId + " " + car1.DailyPrice + " " + car1.Description);
            //}

            //foreach (var car2 in carManager.GetAll())
            //{
            //    Console.WriteLine(car2.Id + " " + car2.ColorId + " " + car2.DailyPrice + " " + car2.Description + " " + car2.ModelYear.Year);
            //}

            carManager.Add(car);
        }
    }
}
