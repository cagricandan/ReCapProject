using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrate
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(
                  CarImageCount(carImage.CarID),
                  MoveCarImageRename(carImage)

                );

            if (result != null)
            {
                return result;
            }



            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetByCarId(int carid)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarID == carid));
        }

        public IDataResult<List<CarImage>> GetBYCarImage(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarID == carId));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }


        private IResult CarImageCount(int carId)
        {
            if (_carImageDal.GetAll(c => c.CarID == carId).Count >= 5)
            {
                return new ErrorResult(Messages.CarImageCount);
            }
            return new SuccessResult();

        }

        private IResult MoveCarImageRename(CarImage carImage)
        {
            string guid = Guid.NewGuid().ToString();
            string filepath = carImage.ImagePath;
            string PathDir = @"..\CarImages";
            string extension = ".jpg";


            File.Copy(filepath, Path.Combine(PathDir, guid) + extension, false);

            carImage.ImagePath = guid + extension;
            carImage.Date = DateTime.Now;

            return new SuccessResult(Messages.CarImageFolderImageAdded);

        }
    }
}
