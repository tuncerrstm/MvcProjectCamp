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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public Content GetByID(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public int GetContentCountByTitle(int id)
        {
            return _contentDal.List(x => x.TitleID == id).Count;
        }

        public List<Content> GetList(string p)
        {
            return _contentDal.List(x => x.ContenValue.Contains(p));
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public List<Content> GetListByTitleID(int id)
        {
            return _contentDal.List(x => x.TitleID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }

        public List<Content> GetListByWriter(int id, string p)
        {
            return _contentDal.List(x => x.WriterID == id && x.ContenValue.Contains(p));
        }
    }
}
