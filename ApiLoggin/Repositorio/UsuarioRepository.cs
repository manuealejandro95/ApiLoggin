using ApiLoggin.Class;
using ApiLoggin.IRepositorio;
using ApiLoggin.Model;
using Snickler.EFCore;
using System.Security.Cryptography;
using System.Text;

namespace ApiLoggin.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiLogginContext _context;
        ResultGeneric<object> resultado = new ResultGeneric<object>();
        
        public UsuarioRepository(ApiLogginContext context)
        {
            _context = context;
        }

        public ResultGeneric<object> RegisterUser(UsuarioModel usuarioModel)
        {
            try
            {
                int numberfilas = ValidaCorreo(usuarioModel).Count();

                if (numberfilas == 0)
                {
                    using (_context)
                    {
                        _context.LoadStoredProc("dbo.CRUDUSUARIO", commandTimeout: 5000)
                        .WithSqlParam("Id", usuarioModel.Id)
                        .WithSqlParam("EMAIL", usuarioModel.CorreoElectronico.ToLower())
                        .WithSqlParam("PASSWORD", GetMD5(usuarioModel.Password))
                        .WithSqlParam("ACCION", "INSERT")
                        .ExecuteStoredProc((handler) => { });
                    }
                    resultado.SetOk("Usuario Registrado");
                }
                else
                {
                    resultado.SetOk("EL Usuario ya esta registrado");
                }                
                
            }
            catch(Exception ex)
            {
                LogsError.WriteLogAplication(ex.Message, "UsuarioRepository RegisterUser");
                resultado.SetError("Error Registrando el usuario" + ex.TargetSite.Name + " " + ex.Message + "", 1, null);
            }
            return resultado;
        }

        public ResultGeneric<object> LogginUser(UsuarioModel usuarioModel)
        {
            List<UsuarioModel> ListUsuarios = new List<UsuarioModel>();
            try
            {
                using (_context)
                {
                    _context.LoadStoredProc("dbo.CRUDUSUARIO", commandTimeout: 5000)
                    .WithSqlParam("Id", usuarioModel.Id)
                    .WithSqlParam("EMAIL", usuarioModel.CorreoElectronico.ToLower())
                    .WithSqlParam("PASSWORD", GetMD5(usuarioModel.Password))
                    .WithSqlParam("ACCION", "LOGGIN")
                    .ExecuteStoredProc((handler) =>
                    {
                        ListUsuarios = handler.ReadToList<UsuarioModel>().ToList();
                    });
                }

                if (ListUsuarios.Count == 1)
                {
                    resultado.SetOk("Inicio de Sesión Exítosa");
                }
                else
                {
                    resultado.SetOk("Correo o COntraseña Incorrecta");
                }
                

            }
            catch (Exception ex)
            {
                LogsError.WriteLogAplication(ex.Message, "UsuarioRepository LogginUser");
                resultado.SetError("Error al momento de iniciar sesion." + ex.TargetSite.Name + " " + ex.Message + "", 1, null);
            }
            return resultado;
        }

        public List<UsuarioModel> ValidaCorreo(UsuarioModel usuarioModel)
        {
            List<UsuarioModel> ListUsuarios = new List<UsuarioModel>();
            try
            {
                
                using (_context)
                {
                    _context.LoadStoredProc("dbo.CRUDUSUARIO", commandTimeout: 5000)
                    .WithSqlParam("Id", usuarioModel.Id)
                    .WithSqlParam("EMAIL", usuarioModel.CorreoElectronico.ToLower())
                    .WithSqlParam("PASSWORD", GetMD5(usuarioModel.Password))
                    .WithSqlParam("ACCION", "SEARCH")
                    .ExecuteStoredProc((handler) => {
                        ListUsuarios = handler.ReadToList<UsuarioModel>().ToList();
                    });
                }

            }
            catch (Exception ex)
            {
                LogsError.WriteLogAplication(ex.Message, "UsuarioRepository ValidaCorreo");                
            }
            return ListUsuarios;
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
