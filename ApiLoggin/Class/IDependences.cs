using ApiLoggin.IRepositorio;

namespace ApiLoggin.Class
{
    public interface IDependences
    {
        IUsuarioRepository IUsuarioRepository { get; }
    }
}
