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

            var classeResponse = _mapper.Map<ClasseExemploResponseDTO<ClasseExemploResponse>>(classeExemplosPaginada);
            return Ok(classeResponse);

        }

        [HttpGet("contagem")]
        public async Task<IActionResult> ObterContagem()
        {
            // TO-DO: Implementar a busca de contagem;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarNovoItem([FromBody] ClasseExemploRequestDTO request)
        {

            var classeExemplo = _mapper.Map<ClasseExemplo>(request);

            await _classeExemploService.CriarEntidade(classeExemplo);

            var replica = new ClasseExemploReplica(classeExemplo.Propriedade1, classeExemplo.Propriedade2, 
                                                    classeExemplo.Propriedade3, classeExemplo.ArquivadaEm);
            
            /* Essa rota é exclusiva para criar entidades, portanto o valor do contador nesse caso deve ser 1 */
            await _classeExemploService.SalvarAlteracoes(replica, 
                                                        new KeyValuePair<string, int>($"{nameof(classeExemplo)}", 1),
                                                        $"{nameof(classeExemplo)}:{classeExemplo.Id}");
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
    }
}
