using JwelleryStore.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwelleryStore.Business.Services
{
    public interface IUserService
    {
        UserDetailDTO Authenticate(string username, string password);
    }
}
