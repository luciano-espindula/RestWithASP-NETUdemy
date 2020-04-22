using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using Microsoft.AspNetCore.Authorization;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Controllers
{
    /* Mapeia as requisições de http://localhost:{porta}/api/person/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Person]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : Controller
    {
        //Declaração do serviço usado
        private ILoginBusiness _LoginBusiness;

        /* Injeção de uma instancia de ILoginService ao criar
        uma instancia de LoginController */
        public LoginController(ILoginBusiness loginBusiness)
        {
            _LoginBusiness = loginBusiness;
        }
                
        //Mapeia as requisições POST para http://localhost:{porta}/api/person/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [AllowAnonymous]
        [HttpPost]        
        public object Post([FromBody]UserVO user)
        {
            if (user == null) return BadRequest();
            return _LoginBusiness.FindByLogin(user);
        }
    }
}
