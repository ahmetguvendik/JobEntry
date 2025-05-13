using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.AppUserCommands;
using JobEntry.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobEntry.Application.Features.CQRS.Handlers.AppUserHandlers.Write;

 public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            {
                var appUser = new AppUser();
                appUser.UserName = request.Username;    
                appUser.Email = request.Email;
                    var response = await _userManager.CreateAsync(appUser, request.Password);
                    if (response.Succeeded)
                    {
                        var role = await _roleManager.FindByNameAsync("Member");
                        if (role == null)
                        {
                            var appRole = new AppRole()
                            {
                                Name = "Member"
                            };
                            await _roleManager.CreateAsync(appRole);
                        }

                        await _userManager.AddToRoleAsync(appUser, "Member");
                    }
                
            }
        }
    }