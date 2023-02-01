using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApiLogginContext : DbContext
{
    public ApiLogginContext (DbContextOptions<ApiLogginContext> options): base(options)
    {

    }

    public DbSet<ApiLoggin.Model.UsuarioModel> UsuarioModels { get; set; }
}
