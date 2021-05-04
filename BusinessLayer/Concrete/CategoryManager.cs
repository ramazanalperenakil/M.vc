using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category p)
        {
            _categoryDal.Insert(p);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        //public void CategoryAddBL (Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryStatus == false || p.CategoryName.Length <= 2)
        //    {
        //        //hatamesajı
        //    }
        //    else
        //    {
        //        _categoryDal.Insert(p);

        //    }
        //}
    }
}
 