using AutoMapper;
using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Application.Interfaces;
using MasterNet.Persistence.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Accounts.Register
{
    public class RegisterCommand
    {
        public record RegisterCommandRequest(RegisterRequest registerRequest)
            : IRequest<Result<Profile>>, ICommandBase;

        internal class RegisterCommandHandler :
            IRequestHandler<RegisterCommandRequest, Result<Profile>>
        {
            private readonly UserManager<AppUser> _userManager;

            private readonly ITokenService _tokenService;

            public RegisterCommandHandler(
                UserManager<AppUser> userManager,
                ITokenService tokenService)
            {
                _userManager = userManager;
                _tokenService = tokenService;
            }

            public async Task<Result<Profile>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
            {

                var user = await _userManager.Users.
                    AnyAsync(x => x.Email!.Equals(request.registerRequest.Email) || x.UserName!.Equals(request.registerRequest.UserName));

                if (user)
                {
                    Result<Profile>.Failure("El email ó el nombre de usuario, ya fue registrado por otro usuario");
                }

                var appUser = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    NombreCompleto = request.registerRequest.NombreCompleto,
                    Carrera = request.registerRequest.Carrera,
                    Email = request.registerRequest.Email,
                    UserName = request.registerRequest.UserName,
                };

                var resultado = _userManager.CreateAsync(appUser, request.registerRequest.Password!);

                if (resultado.IsCompletedSuccessfully)
                {

                    await _userManager.AddToRoleAsync(appUser, "Client");
                    var profile = new Profile
                    {
                        Email = appUser.Email,
                        NombreCompleto = appUser.NombreCompleto,
                        Token = await _tokenService.CreateToken(appUser),
                        UserName = appUser.UserName,
                    };

                    return Result<Profile>.Success(profile);
                }

                return Result<Profile>.Failure("Errores en el registro del usuario");
            }
        }

        public class RegisterCommandRequestValidator : AbstractValidator<RegisterCommandRequest>
        {

            public RegisterCommandRequestValidator()
            {
                RuleFor(x => x.registerRequest).SetValidator(new RegisterValidator());
            }
        }

    }
}
