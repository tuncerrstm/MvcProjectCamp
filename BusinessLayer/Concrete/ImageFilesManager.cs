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
    public class ImageFilesManager : IImageFilesService
    {
        IImageFilesDal _imageFilesDal;

        public ImageFilesManager(IImageFilesDal imageFilesDal)
        {
            _imageFilesDal = imageFilesDal;
        }

        public List<ImageFiles> GetList()
        {
            return _imageFilesDal.List();
        }
    }
}
