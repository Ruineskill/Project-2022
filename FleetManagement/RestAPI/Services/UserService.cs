﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestAPI.Authentication;
using RestAPI.Interfaces;
using Shared.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManger;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly ITokenValidationService _tokenValidationService;

        public UserService(UserManager<IdentityUser> userManger, ITokenService tokenService, IRefreshTokenService refreshTokenService, ITokenValidationService tokenValidatorService)
        {
            _userManger = userManger;
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
            _tokenValidationService = tokenValidatorService;
        }

        public bool Validate(IdentityUser user, string token)
        {

            if (!_tokenValidationService.Validate(token)) return false;
            var refreshToken = GetRefreshToken(user);
            if (refreshToken == null) return false;

            if (refreshToken != token) return false;

            return true;
        }

      

        public async Task<AuthenticationReponse?> Authenticate(SignInRequest login)
        {
            // username
            var user = await _userManger.FindByNameAsync(login.UserName);

            if (user != null)
            {
                // password
                if (await _userManger.CheckPasswordAsync(user, login.Password))
                {

                    var refreshToken = _refreshTokenService.Generate();

                    await SaveRefreshToken(user, refreshToken);

                    return new AuthenticationReponse
                    {
                        IsAuthenticated = true,
                        Token = _tokenService.Generate(user),
                        RefreshToken = refreshToken,
                        UserName = login.UserName,
                    };

                }
            }
            return null;
        }  

        public async Task<AuthenticationReponse?> Refresh(IdentityUser user, string token)
        {
            var refreshToken = _refreshTokenService.Generate();

            await SaveRefreshToken(user, refreshToken);

            return new AuthenticationReponse
            {
                IsAuthenticated = true,
                Token = _tokenService.Generate(user),
                RefreshToken = refreshToken,
                UserName = user.UserName,
            };

        }

        public async Task<IdentityUser?> GetUser(ClaimsPrincipal principal)
        {
            return await _userManger.FindByNameAsync(principal.Identity?.Name); ;
        }

        private async Task SaveRefreshToken(IdentityUser user, string refreshToken)
        {
            await _userManger.SetAuthenticationTokenAsync(user, "JWT", "Refresh", refreshToken);
        }

        private string GetRefreshToken(IdentityUser user)
        {
            return _userManger.GetAuthenticationTokenAsync(user, "JWT", "Refresh").Result;
        }

        public async void RemoveRefreshToken(IdentityUser user)
        {
            await _userManger.RemoveAuthenticationTokenAsync(user, "JWT", "Refresh");
        }
    }
}
