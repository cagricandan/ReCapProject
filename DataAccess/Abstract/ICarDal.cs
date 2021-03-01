using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.InMemory.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails();
    }
}
