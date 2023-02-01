using Microsoft.AspNetCore.Mvc;
using ApiLoggin.Model;
using ApiLoggin.Class;

namespace ApiLoggin.Controllers
{
    [Route("apiuser/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IDependences _dependences;

        public UsuarioController(IDependences dependences)
        {
            _dependences = dependences;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public ResultGeneric<object> RegisterUser([FromForm]  UsuarioModel usuarioModel)
        {
            ResultGeneric<object> result = new ResultGeneric<object>();
            try
            {
                result = _dependences.IUsuarioRepository.RegisterUser(usuarioModel);
            }
            catch (Exception ex)
            {
                ApiLoggin.Class.LogsError.WriteLogAplication(ex.Message, "UsuarioCOntroller RegisterUser");                
            }
            return result;
        }

        [HttpPost]
        [Route("LogginUser")]
        public ResultGeneric<object> LogginUser([FromForm] UsuarioModel usuarioModel)
        {
            ResultGeneric<object> result = new ResultGeneric<object>();
            try
            {
                result = _dependences.IUsuarioRepository.LogginUser(usuarioModel);
            }
            catch (Exception ex)
            {
                ApiLoggin.Class.LogsError.WriteLogAplication(ex.Message, "UsuarioCOntroller LogginUser");
            }
            return result;
        }
    }
}
