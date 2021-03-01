using Core.DataAccess.EntityFramework;
using DataAccess.InMemory.Abstract;
using Entities.Concrate;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {

                var result = from c in context.Cars
                             join co in context.Colors on c.ColorId equals co.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             select new CarDetailsDto { CarName = c.CarName, BrandName = b.Name, ColorName = co.Name, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }
    }
}
