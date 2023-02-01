using ApiLoggin.Class;
using ApiLoggin.Model;

namespace ApiLoggin.IRepositorio
{
    public interface IUsuarioRepository
    {
        ResultGeneric<object> RegisterUser(UsuarioModel usuarioModel);
        ResultGeneric<object> LogginUser(UsuarioModel usuarioModel);
    }
}
