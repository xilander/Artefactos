﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Seguridad.Aplication;
using Seguridad.Core.Aplication;
using Seguridad.Dto;
using System.Threading.Tasks;

// MediatR librería para implementar el patrón CQRS

namespace Seguridad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioDto>> Registrar(Register.UsuarioRegisterCommand parametros)
        {
            return await _mediator.Send(parametros);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> Login(Login.UsuarioLoginCommand parametros)
        {
            return await _mediator.Send(parametros);
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioDto>> Get()
        {
            return await _mediator.Send(new UsuarioActual.UsuarioActualCommand());
        }

    }
}
