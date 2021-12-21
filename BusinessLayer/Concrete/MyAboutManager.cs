using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    

    public class MyAboutManager : IMyAboutService
    {
        private IMyAboutDal _myAboutDal;

        public MyAboutManager(IMyAboutDal myAboutDal)
        {
            _myAboutDal = myAboutDal;
        }

        public void Add(MyAbout myAbout)
        {
            _myAboutDal.Insert(myAbout);
        }

        public void Delete(MyAbout myAbout)
        {
            _myAboutDal.Delete(myAbout);
        }

        public List<MyAbout> GetAll()
        {
            return _myAboutDal.List();
        }

        public MyAbout GetById(int id)
        {
            return _myAboutDal.Get(x => x.SkillId == id);
        }

        public void Update(MyAbout myAbout)
        {
            _myAboutDal.Update(myAbout);
        }
    }
}
