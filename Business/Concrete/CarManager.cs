using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.InMemory.Abstract;
using Entities.Concrate;
using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [TransactionScopeAspect] //bi hata olursa bütün işlemi geri alma
        [SecuredOperation("car.add,admin")] //yetkilerine veya yetkisisne sahip mi
        [ValidationAspect(typeof(CarValidator))] //doğrulama
        [CacheRemoveAspect("ICarServices.Get")] // bellekteki carservices içindeki get içeren tüm datayı yok et
        [PerformanceAspect(20)]  // 20 saniyeyi geçerse çalışma süresi uyar
        public IResult Add(Car car)
        {

            ValidationTool.Validate(new CarValidator(), car);
             _carDal.Add(car);
            return new SuccessResult(Messages.CarSuccessfullAdded);
     
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [CacheAspect] //veriyi belleğe kaydet
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Update()
        {
            return new SuccessResult();
        }
    }
}
