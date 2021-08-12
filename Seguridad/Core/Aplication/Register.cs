﻿using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Seguridad.Core.JwtLogic;
using Seguridad.Dto;
using Seguridad.Entities;
using Seguridad.Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Seguridad.Aplication
{
    // Las clases en la carpeta de Aplicación implementan el patrón CQRS
    public class Register
    {
        public class UsuarioRegisterCommand : IRequest<UsuarioDto>
        {
            public string Nombre { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public int CondominioId { get; set; }
            public int ViviendaId { get; set; }
            public string Password { get; set; }
        }

        public class UsuarioRegisterValidation : AbstractValidator<UsuarioRegisterCommand>
        {
            public UsuarioRegisterValidation()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.CondominioId).NotEmpty();
                RuleFor(x => x.ViviendaId).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }

        }

        public class UsuarioRegisterHandler : IRequestHandler<UsuarioRegisterCommand, UsuarioDto>
        {
            private readonly SeguridadContexto _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IMapper _mapper;
            private readonly IJwtGenerator _jwtGenerator;

            public UsuarioRegisterHandler(SeguridadContexto context, UserManager<Usuario> userManager, IMapper mapper, IJwtGenerator jwtGenerator)
            {
                _context = context;
                _userManager = userManager;
                _mapper = mapper;
                _jwtGenerator = jwtGenerator;
            }
            public async Task<UsuarioDto> Handle(UsuarioRegisterCommand request, CancellationToken cancellationToken)
            {
                var existe = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();
                if (existe)
                {
                    throw new Exception("El correo del usuario ya existe en la base de datos");
                }

                existe = await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync();
                if (existe)
                {
                    throw new Exception("El usuario ya existe en la base de datos");
                }

                var usuario = new Usuario
                {
                    Nombre = request.Nombre,
                    Email = request.Email,
                    UserName = request.UserName,
                    CondominioId = request.CondominioId,
                    ViviendaId = request.ViviendaId
                };

                var resultado = await _userManager.CreateAsync(usuario, request.Password);
                if (resultado.Succeeded)
                {
                    var usuarioDTO = _mapper.Map<Usuario, UsuarioDto>(usuario);
                    usuarioDTO.Token = _jwtGenerator.CreateToken(usuario);
                    return usuarioDTO;
                }

                throw new Exception("No se pudo registrar el usuario");
            }
        }
    }
}
