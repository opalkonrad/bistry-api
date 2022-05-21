using BistryApi.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace BistryApi.Authorization;

public class AdminHandler : AuthorizationHandler<AdminRequirement>
{
    private readonly BistryContext _bistryContext;

    public AdminHandler(BistryContext bistryContext)
    {
        _bistryContext = bistryContext;
    }

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        AdminRequirement requirement)
    {
        var email = context.User.FindFirst(x => x.Type == JwtRegisteredClaimNames.Email);

        if (email != null)
        {
            var isAdmin = _bistryContext.Admins.AsEnumerable().Any(x => x.Email == email?.Value);

            if (isAdmin)
            {
                context.Succeed(requirement);
            }
        }

        return Task.CompletedTask;
    }
}
