using System;

namespace DestinoCertoMVC.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}