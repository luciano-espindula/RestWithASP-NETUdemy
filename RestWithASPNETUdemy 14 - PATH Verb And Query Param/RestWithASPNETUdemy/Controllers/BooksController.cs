using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace RestWithASPNETUdemy.Controllers
{
    /* Mapeia as requisições de http://localhost:{porta}/api/person/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Person]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : Controller
    {
        //Declaração do serviço usado
        private IBookBusiness _bookBusiness;

        /* Injeção de uma instancia de IPersonService ao criar
        uma instancia de PersonController */
        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/person/
        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<BookVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return new OkObjectResult(_bookBusiness.FindAll());
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/person/{id}
        //recebendo um ID como no Path da requisição
        //Get com parâmetros para o FindById --> Busca Por ID
        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(BookVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return new OkObjectResult(book);
        }

        //Mapeia as requisições POST para http://localhost:{porta}/api/person/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [HttpPost]
        [SwaggerResponse((201), Type = typeof(BookVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            return new OkObjectResult(_bookBusiness.Create(book));
        }

        //Mapeia as requisições PUT para http://localhost:{porta}/api/person/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [HttpPut]
        [SwaggerResponse((202), Type = typeof(BookVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            var updatedBook = _bookBusiness.Update(book);
            if (updatedBook == null) return BadRequest();
            return new OkObjectResult(updatedBook);
        }


        //Mapeia as requisições DELETE para http://localhost:{porta}/api/person/{id}
        //recebendo um ID como no Path da requisição
        [HttpDelete("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
