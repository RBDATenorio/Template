using API.DTO.Request;
using API.DTO.Response;
using API.Utils.Caching;
using AutoMapper;
using Domain.Entities;
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
        private readonly IRedisCache _cache;

        public ClasseExemploController(IMapper mapper,
                                       IClasseExemploService classeExemploService,
                                       INotificacao notificacao, IRedisCache cache)
        {
            _classeExemploService = classeExemploService;
            _notificacao = notificacao;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> ObterPaginado([FromQuery] int skip, [FromQuery] int take)
        {
            var classeExemplosPaginada = await _classeExemploService.ObterPaginado(skip, take);

            var classeResponse = _mapper.Map<ClasseExemploResponseDTO<ClasseExemploResponse>>(classeExemplosPaginada);
            return Ok(classeResponse);

        }

        [HttpPost]
        public async Task<IActionResult> CadastrarNovoItem([FromBody] ClasseExemploRequestDTO request)
        {
            if(_notificacao.TemNotificacoes())
            {
                return BadRequest(_notificacao.ObterNotificacoes());
            }

            await _classeExemploService.CriarEntidade(_mapper.Map<ClasseExemplo>(request));

            await _classeExemploService.SalvarAlteracoes();

            var replica = new ClasseExemploReplica(127, 3, "primeiro teste com redis");

            await _cache.SalvarNoRedis(replica);

            return Created($"api/ClasseExemplo/{request}", request);
        }
    }
}
