using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {

            if (_rentalDal.Get(r => r.CarID==rental.CarID).ReturnDate!=null)
            {
                return new ErrorResult(Messages.CarNotSuccessfullAdded);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }
                     
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
