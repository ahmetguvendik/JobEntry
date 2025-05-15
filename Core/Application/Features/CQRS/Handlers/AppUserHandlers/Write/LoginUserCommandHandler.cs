using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.AppUserCommands;
using JobEntry.Application.Features.CQRS.Results.AppUserResults;
using JobEntry.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobEntry.Application.Features.CQRS.Handlers.AppUserHandlers.Write;

 public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserQueryResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginUserQueryResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByNameAsync(request.UserName);
            if(appUser == null)
            {
                appUser = await _userManager.FindByEmailAsync(request.UserName);
        
            }

            await _userManager.SetTwoFactorEnabledAsync(appUser, true);
            var response = await _signInManager.PasswordSignInAsync(appUser,request.Password,false,false);
            if (response.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(appUser);
                if (role.Contains("Admin"))
                {
                    return new LoginUserQueryResult()
                    {
                        Id = appUser.Id,
                        Username = request.UserName,
                        Role = "Admin",
                        Email = request.Email,
                    };
                }
                else if (role.Contains("Company"))
                {
                    return new LoginUserQueryResult()
                    {
                        Id = appUser.Id,
                        Username = request.UserName,
                        Role = "Company",
                        Email = request.Email,
                    };
                }
                else if (role.Contains("Member"))
                {
                    return new LoginUserQueryResult()
                    {
                        Id = appUser.Id,
                        Username = request.UserName,
                        Email = request.Email,
                        Role = "Member"
                    };
                }
                
            }
            
            return new LoginUserQueryResult()
            {
                Id = appUser.Id,
                Username = request.UserName,
                Email = request.Email,
                Role = ""
            };
            
        }
    }