using ApiLoggin.IRepositorio;
using ApiLoggin.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace ApiLoggin.Class
{
    public class Dependences : IDependences
    {
        private readonly IConfiguration _configuration; 

        public Dependences(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApiLogginContext GetContext()
        {
            try
            {
                DbContextOptionsBuilder<ApiLogginContext> option = new DbContextOptionsBuilder<ApiLogginContext>();
                option.UseSqlServer(_configuration.GetValue<string>("ConnectionString"));
                var conn = new ApiLogginContext(option.Options);
                conn.Database.SetCommandTimeout(300);
                return conn;
            }catch(Exception ex)
            {
                LogsError.WriteLogAplication(ex.ToString(), "Dependences GetContext");
                return null;
            }
        }

        public IUsuarioRepository IUsuarioRepository => new UsuarioRepository(GetContext());
       
    }
}
