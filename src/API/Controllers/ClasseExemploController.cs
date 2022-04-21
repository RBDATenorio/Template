using API.DTO.Request;
using API.DTO.Response;
using API.Utils.Caching;
using API.Utils.Caching.Replicas;
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

        [HttpGet("paginado/")]
        public async Task<IActionResult> ObterPaginado([FromQuery] int skip, [FromQuery] int take)
        {
            var classeExemplosPaginada = await _classeExemploService.ObterPaginado(skip, take);

            var classeResponse = _mapper.Map<ClasseExemploResponseDTO<ClasseExemploResponse>>(classeExemplosPaginada);
            return Ok(classeResponse);
        }

        [HttpGet("cargaNoBanco")]
        public async Task<IActionResult> CadastrarNovoItem()
        {
            var tamanhoDacarga = 30000;
            for(int i = 0; i < tamanhoDacarga; i++)
            {
                var classeExemplo = new ClasseExemplo(i, i+1, $"iteracao:{i}");

                await _classeExemploService.CriarEntidade(classeExemplo);

                if(i % 5 == 0) await _classeExemploService.SalvarAlteracoes();
            }


            if (_notificacao.TemNotificacoes())
            {
                return BadRequest(_notificacao.ObterNotificacoes());
            }

            return Ok();
        }

        [HttpGet("obterTodosDoCache")]
        public ActionResult<IEnumerable<ClasseExemploReplica>> ObterTodosDoCache()
        {
            var replicas = _cache.ObterTodosComPattern($"ClasseExemplo");
            return Ok(replicas);
        }

        [HttpGet("obterTodosDoSQLBFF")]
        public async Task<ActionResult<IEnumerable<ClasseExemploReplica>>> ObterTodos()
        {
            var classeExemplos = await _classeExemploService.ObterTodos();
            return Ok(_mapper.Map<IEnumerable<ClasseExemploReplica>>(classeExemplos));
        }
        
        [HttpGet("ArquivadasDoSQL")]
        public async Task<ActionResult<IEnumerable<ClasseExemploReplica>>> ObterArquivadas()
        {
            var arquivadas = await _classeExemploService.ObterPorProp(c => c.ArquivadaEm != null);
            return Ok(arquivadas);
        }

        [HttpGet("ArquivadasDoCache")]
        public async Task<ActionResult<IEnumerable<ClasseExemploReplica>>> ObterArquivadasDoCache()
        {
            var arquivadas = await _classeExemploService.ObterPorProp(c => c.ArquivadaEm != null);
            return Ok(arquivadas);
        }

        [HttpPost("cadastrarNovoItem")]
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
        
        [HttpPost("AtualizarContagemDoCache/")]
        public async Task<IActionResult> AtualizarContagemNoCache()
        {
            var arquivadas = await _classeExemploService.ObterContagem(a => a.ArquivadaEm == null);
            var outroExemplo = await _classeExemploService.ObterContagem(a => a.Propriedade2 > 0);

            _cache.AtualizarContagem("Contagem:ClasseExemplo:arquivadas", arquivadas);
            _cache.AtualizarContagem("Contagem:ClasseExemplo:Propriedade2", outroExemplo);

            return Ok();
        }
        
        [HttpPost("AtualizarReplicasNoCache/")]
        public async Task<IActionResult> AtualizarReplicas()
        {
            var classeExemplos = await _classeExemploService.ObterTodos();
            var replicas = _mapper.Map<IList<ClasseExemploReplica>>(classeExemplos);
            await _cache.SalvarReplicasNoRedis("ClasseExemplo", replicas);
            return Ok();
        }

        //[HttpPost("AtualizarReplicasArquivadasNoCache/")]
        //public async Task<IActionResult> AtualizarReplicasArquivadas()
        //{
        //    var classeExemplos = await _classeExemploService.ObterPorProp(c => c.ArquivadaEm == null);
        //    foreach (var classeExemplo in classeExemplos)
        //    {
        //        var replica = _mapper.Map<ClasseExemploReplica>(classeExemplo);
        //        await _cache.SalvarReplicaNoRedis($"ClasseExemplo:Arquivadas:{replica.Id}", replica);
        //    }
        //    return Ok();
        //}

    }
}
