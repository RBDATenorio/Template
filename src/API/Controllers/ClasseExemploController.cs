using API.DTO.Request;
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
        //private readonly INotificacao _notificador;
        private readonly IClasseExemploService _classeExemploService;
        private readonly IMapper _mapper;

        private IList<ClasseExemplo> Repositorio = new List<ClasseExemplo>();
        public ClasseExemploController(IMapper mapper, IClasseExemploService classeExemploService)
        {
            //_notificador = notificador;
            _classeExemploService = classeExemploService;
            _mapper = mapper;
            Repositorio.Add( new ClasseExemplo(2, 3, "propriedade 3"));
        }

        [HttpGet]
        public IActionResult ObterPaginado()
        {
            return Ok(_mapper.Map<IList<ClasseExemploRequestDTO>>(Repositorio));
        }

        [HttpPost]
        public IActionResult CadastrarNovoItem([FromBody] ClasseExemploRequestDTO request)
        {
            /* Como temos validações das requisições, não é necessário 
             * usar o ModelState */
            _classeExemploService.ObterTodos(_mapper.Map<ClasseExemplo>(request));

            return Created($"api/ClasseExemplo/{request}", request);
        }
    }
}
