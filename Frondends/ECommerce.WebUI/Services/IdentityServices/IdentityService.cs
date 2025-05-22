using Duende.IdentityModel.Client;
using ECommerce.WebUI.DTOs.IdentityDtos;
using ECommerce.WebUI.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;

namespace ECommerce.WebUI.Services.IdentityServices
{
    public class IdentityService(IHttpContextAccessor _contextAccessor,
                                 HttpClient _client,
                                 IOptions<ServiceApiSettings> serviceApiSettings,
                                 IOptions<ClientSettings> clientSettings) : IIdentityService
    {
        private readonly ServiceApiSettings _serviceApiSettings = serviceApiSettings.Value;
        private readonly ClientSettings _clientSettings = clientSettings.Value;





        public async Task<bool> GetRefreshToken()
        {
            var discoveryEndpoint = await _client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl
            });

            var refreshToken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);


            RefreshTokenRequest refreshTokenRequest = new()
            {
                Address = discoveryEndpoint.TokenEndpoint,
                ClientId = _clientSettings.AdminClient.ClientId,
                ClientSecret = _clientSettings.AdminClient.ClientSecret,
                RefreshToken = refreshToken
            };


            var tokenResponse = await _client.RequestRefreshTokenAsync(refreshTokenRequest);

            var authenticationToken = new List<AuthenticationToken>()
            {
                new AuthenticationToken()
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = tokenResponse.AccessToken
                },
                new AuthenticationToken()
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = tokenResponse.RefreshToken
                },
                new AuthenticationToken()
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn).ToString()
                }
            };
            var result = await _contextAccessor.HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result.Succeeded)
            {
                var properties = result.Properties;
                properties.StoreTokens(authenticationToken);
                await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties);
                return true;
            }
            return false;
        }





        public async Task<bool> SignInAsync(SignInDto signInDto)
        {
            var discoveryEndpoint = await _client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl
            });

            var passwordTokenRequest = new PasswordTokenRequest()
            {

                ClientId = _clientSettings.AdminClient.ClientId,
                ClientSecret = _clientSettings.AdminClient.ClientSecret,
                UserName = signInDto.UserName,
                Password = signInDto.Password,
                Address = discoveryEndpoint.TokenEndpoint
            };

            var tokenResponse = await _client.RequestPasswordTokenAsync(passwordTokenRequest);
            if (tokenResponse is null)
            {
                return false;
            }
            var userInfoRequest = new UserInfoRequest
            {
                Address = discoveryEndpoint.UserInfoEndpoint,
                Token = tokenResponse.AccessToken
            };


            var userValues = await _client.GetUserInfoAsync(userInfoRequest);


            ClaimsIdentity claimsIdentity = new(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            var authProperties = new AuthenticationProperties();

            authProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken()
                {
                    Name= OpenIdConnectParameterNames.AccessToken,
                    Value= tokenResponse.AccessToken
                },
                new AuthenticationToken()
                {
                    Name= OpenIdConnectParameterNames.RefreshToken,
                    Value= tokenResponse.RefreshToken
                },
                new AuthenticationToken()
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn).ToString()
                }

                });

            authProperties.IsPersistent = false;

            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

            return true;
        }
    }
}
