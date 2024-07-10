using System;
using System.ComponentModel.DataAnnotations;

namespace DestinoCertoMVC
{
    public class LoginModel
{
    [Required]
    public string Login { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
}
}