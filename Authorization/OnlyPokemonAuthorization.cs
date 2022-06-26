using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAppCourse2022.Authorization
{
    public class OnlyPokemonAuthorization : AuthorizationHandler<OnlyPokemonAuthorization>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyPokemonAuthorization requirement)
        {
            if (context.User.IsInRole("Pokemon"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}
