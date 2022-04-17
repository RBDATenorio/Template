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
                                       INotificacao notificacao,
                                       IRedisCache cache)
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

            var classeExemplo = _mapper.Map<ClasseExemplo>(request);

            await _classeExemploService.CriarEntidade(classeExemplo);
            
            await _classeExemploService.SalvarAlteracoes();

            if (_notificacao.TemNotificacoes())
            {
                return BadRequest(_notificacao.ObterNotificacoes());
            }

            return Created($"api/ClasseExemplo/{classeExemplo.Id}", request);
        }

        [HttpPut]
        public async Task<IActionResult> ArquivarItem(ClasseExemploRequestDTO request)
        {
            // Implementar o arquivamento
            return Ok();
        }

        [HttpPost("AtualizarContagemDoCache/")]
        public async Task<IActionResult> AtualizarContagemNoCache()
        {
            var arquivadas = await _classeExemploService.ObterContagem(a => a.ArquivadaEm != null);
            var outroExemplo = await _classeExemploService.ObterContagem(a => a.Propriedade2 > 0);

            _cache.AtualizarContagem("ClasseExemplo:total", arquivadas);
            _cache.AtualizarContagem("ClasseExemplo:Propriedade2", outroExemplo);

            return Ok();
        }

        [HttpPost("AtualizarReplicasNoCache/")]
        public async Task<IActionResult> AtualizarReplicas()
        {

            //await _cache.SalvarReplicaNoRedis("", replica);
            return Ok();
        }

    }
}
