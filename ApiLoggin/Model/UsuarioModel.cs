using System.ComponentModel.DataAnnotations;

namespace ApiLoggin.Model
{
    public class UsuarioModel
    {
        public int? Id { get; set; } = null;

        [Required(ErrorMessage = "El campo correo electronico es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electronico es incorrecto.")]
        public string CorreoElectronico { get; set; }

        [DataType(DataType.Password)]
        [MinLength(10, ErrorMessage = "La longitud mínima de la contraseña es de 10 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z])(?=.*[\~\`\!\@\#\$\%\^\&\*\(\)_\-\+\=\{\[\}\]\|\\\:\;\”\’\<\,\>\.\?\/]).{8,}$", ErrorMessage = @"El campo contraseña debe contener mayúscula, minúscula, número y al menos un caracter especial ")] //
        [Required(ErrorMessage = "El campo contraseña es requerido")]
        public string Password { get; set; }
    }
}
