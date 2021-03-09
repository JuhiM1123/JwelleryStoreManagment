using JwelleryStore.Common.Model;
using JwelleryStore.DAL;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using JwelleryStore.DAL.Entities;

namespace JwelleryStore.Business.Repository.UserInformationRepoitory
{
    public class UserInformationRepository : IUserInformationRepository
    {
        private readonly JwelleryStoreDBContext _storeDBContext;

        public UserInformationRepository (JwelleryStoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext;
        }

        public UserDetail GetUserDetail(string userName, string password)
        {
            return _storeDBContext.UserDetails.Where(x => x.UserName == userName && x.Password == password).Include(item=>item.Role).FirstOrDefault();
        }
    }
}
