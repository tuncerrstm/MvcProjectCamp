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
    public class TitleManager : ITitleService
    {
        ITitleDal _titleDal;

        public TitleManager(ITitleDal titleDal)
        {
            _titleDal = titleDal;
        }

        public Title GetByID(int id)
        {
            return _titleDal.Get(x => x.TitleID == id);
        }

        public List<Title> GetList()
        {
            return _titleDal.List();
        }

        public List<Title> GetListByWriter()
        {
            return _titleDal.List(x => x.WriterID == 4);
        }

        public void TitleAdd(Title title)
        {
            _titleDal.Insert(title);
        }

        public void TitleDelete(Title title)
        {
            
            _titleDal.Update(title);
        }

        public void TitleUpdate(Title title)
        {
            _titleDal.Update(title);
        }
    }
}
