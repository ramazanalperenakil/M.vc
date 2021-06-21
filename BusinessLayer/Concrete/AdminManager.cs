﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetByAdmin(string k, string p)
        {
            return _adminDal.GetByAdmin(k, p);
        }

        public Admin GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }

        public string[] GetRolesForAdmin(string username)
        {
            return _adminDal.GetRolesForAdmin(username);
        }
    }
}
