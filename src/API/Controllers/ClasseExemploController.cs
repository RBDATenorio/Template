using API.DTO.Request;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClasseExemploController : ControllerBase
    {
        private readonly INotificacao _notificacao;
        private readonly IClasseExemploService _classeExemploService;
        private readonly IMapper _mapper;

        public ClasseExemploController(IMapper mapper, 
                                       IClasseExemploService classeExemploService,
                                       INotificacao notificacao)
        {
            _classeExemploService = classeExemploService;
            _notificacao = notificacao;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterPaginado([FromQuery] int skip, [FromQuery] int take)
        {
            var classeExemplosPaginada = await _classeExemploService.ObterPaginado(skip, take);
            return Ok(classeExemplosPaginada);
        }

        [HttpPost]
        public IActionResult CadastrarNovoItem([FromBody] ClasseExemploRequestDTO request)
        {
            if(_notificacao.TemNotificacoes())
            {
                return BadRequest(_notificacao.ObterNotificacoes());
            }

            return Created($"api/ClasseExemplo/{request}", request);
        }
    }
}
