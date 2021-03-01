using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IDataResult<Car> GetById(int carId);
        IDataResult<List <Car>> GetAll();

        IDataResult<List<Car>> GetCarsByBrandId(int id);

        IDataResult<List<Car>> GetCarsByColorId(int id);

        IResult Delete(Car car);

        IDataResult<List<CarDetailsDto>> GetCarDetail();

        IResult Update();

    }
}
