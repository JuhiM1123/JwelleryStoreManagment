using JwelleryStore.Common.Model;
using JwelleryStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwelleryStore.Business.Repository.UserInformationRepoitory
{
    public interface IUserInformationRepository
    {
        UserDetail GetUserDetail(string userName, string password);
    }
}
