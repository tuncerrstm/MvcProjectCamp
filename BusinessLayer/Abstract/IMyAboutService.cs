﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMyAboutService
    {
        List<MyAbout> GetAll();
        MyAbout GetById(int id);
        void Add(MyAbout myAbout);
        void Update(MyAbout myAbout);
        void Delete(MyAbout myAbout);
    }
}
