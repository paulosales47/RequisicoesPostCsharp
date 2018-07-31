using System;

namespace ConsomeAPI.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }

        public string Nome { get; set; }

        public byte Idade { get; set; }

        public DateTime DtNascimento { get; set; }

        public bool Ativo { get; set; }
    }
}