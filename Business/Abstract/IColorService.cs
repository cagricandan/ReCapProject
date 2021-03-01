﻿using Core.Utilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IDataResult<Color> GetById(int colorId);

        IDataResult<List<Color>>  GetAll();

    }
}
