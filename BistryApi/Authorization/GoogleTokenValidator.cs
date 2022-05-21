using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BistryApi.Authorization;

public class GoogleTokenValidator : ISecurityTokenValidator
{
    private readonly string _clientId;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public GoogleTokenValidator(string clientId)
    {
        _clientId = clientId;
        _tokenHandler = new JwtSecurityTokenHandler();
    }

    public bool CanValidateToken => true;

    public int MaximumTokenSizeInBytes { get; set; } =
        TokenValidationParameters.DefaultMaximumTokenSizeInBytes;

    public bool CanReadToken(string securityToken)
    {
        return _tokenHandler.CanReadToken(securityToken);
    }

    public ClaimsPrincipal ValidateToken(
        string securityToken,
        TokenValidationParameters validationParameters,
        out SecurityToken validatedToken)
    {
        var payload = GoogleJsonWebSignature.ValidateAsync(
            securityToken,
            new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new[] { _clientId }
            }).Result;

        validatedToken = _tokenHandler.ReadJwtToken(securityToken);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, payload.Name),
            new Claim(JwtRegisteredClaimNames.FamilyName, payload.FamilyName),
            new Claim(JwtRegisteredClaimNames.GivenName, payload.GivenName),
            new Claim(JwtRegisteredClaimNames.Email, payload.Email)
        };

        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

        var principle = new ClaimsPrincipal();
        principle.AddIdentity(claimsIdentity);

        return principle;
    }
}
