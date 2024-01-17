using AutoMapper;
using AutoMapperProjectVideo.Dto;
using AutoMapperProjectVideo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperProjectVideo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {


        public List<LivroModel> livros = new List<LivroModel>
        {
            new LivroModel { 
                Id = 1,
                Titulo = "Suicidas",
                Autor = "Raphael Montes",
                ISBN = "SRM123456",
                DataCadastro = new DateTime(2024, 01, 17)
            },
            new LivroModel {
                Id = 2,
                Titulo = "Jantar Secreto",
                Autor = "Raphael Montes",
                ISBN = "JSRM123456",
                DataCadastro = new DateTime(2023, 12, 17)
            },
            new LivroModel {
                Id = 3,
                Titulo = "Verity",
                Autor = "Colleen Hoover",
                ISBN = "VCH123456",
                DataCadastro = new DateTime(2023, 08, 17)
            },
            new LivroModel {
                Id = 4,
                Titulo = "Dias Perfeitos",
                Autor = "Raphael Montes",
                ISBN = "DPRM123456",
                DataCadastro = new DateTime(2024, 01, 17)
            }
        };

        private readonly IMapper _mapper;
        public LivroController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet("BuscaLivrosSemAutoMapper")]
        public ActionResult<List<LivroModel>> BuscaLivrosSemMapper()
        {
            return Ok(livros);
        }

        [HttpGet("BuscaLivrosComAutoMapper")]
        public ActionResult<List<LivroModel>> BuscaLivrosComMapper()
        {

            var livrosDto = _mapper.Map<List<LivroVisualizacaoDto>>(livros);

            return Ok(livrosDto);
        }


        [HttpPost("CriarLivros")]
        public ActionResult<List<LivroModel>> CriarLivros(LivroCriacaoDto livro)
        {

            var livroModel = _mapper.Map<LivroModel>(livro);

            livroModel.Id = livros.Last().Id + 1;

            livros.Add(livroModel);

            return Ok(livros);
        }



    }
}
