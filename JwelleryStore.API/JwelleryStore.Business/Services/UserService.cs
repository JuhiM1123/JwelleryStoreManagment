using JwelleryStore.Business.JWT;
using JwelleryStore.Business.Repository.UserInformationRepoitory;
using JwelleryStore.Common.DTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace JwelleryStore.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserInformationRepository _userInformationRepo;
        private readonly IJWTTokenManager _jwtTokenManager;

        public UserService(IUserInformationRepository userInformationRepository, IJWTTokenManager jwtTokenManager)
        {
            _userInformationRepo = userInformationRepository;
            _jwtTokenManager = jwtTokenManager;
        }

        public UserDetailDTO Authenticate(string username, string password)
        {
            UserDetailDTO userDetail = new UserDetailDTO();

            var user = _userInformationRepo.GetUserDetail(username, password);

            if (user == null)
                return null;
            else
            {
                var claims = new[]
                          {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role, user.Role?.RoleName)
            };
                userDetail.Id = user.UserDetailId;
                userDetail.FirstName = user.FirstName;
                userDetail.LastName = user.LastName;
                userDetail.UserName = user.UserName;
                userDetail.RoleName = user.Role?.RoleName;
                userDetail.DiscountPrice = user.Role?.DiscountPrice;
                userDetail.Token = _jwtTokenManager.GenerateTokens(claims, DateTime.Now);
            }
            return userDetail;
        }
    }
}

