using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrate
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            char Erisimyetkisi = 'A';
            char Admin = 'A';
            char User = 'U';
            if (Erisimyetkisi==Admin)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.CarSuccessfullAdded);
                
                
            }
            else
            {
                return new ErrorResult(Messages.CarNotSuccessfullAdded);
            }     
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId));
        }
    }
}
