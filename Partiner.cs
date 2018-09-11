using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaSolid
{
    public class Partiner
    {
        public Partiner(string nome, string email)
        {
            if (this.Validate())
            {
                Nome = nome;
                Email = email;
            }
        }

        public Partiner(int partinerId, string nome, string email)
        {
            PartinerId = partinerId;
            Nome = nome;
            Email = email;
        }

        public int PartinerId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public bool Validate()
        {

            if (!this.Email.Contains("@"))
            {
                Console.WriteLine("E-mail inválido na inscrição");
                return false;
            }

            if (string.IsNullOrEmpty(this.Nome))
            {
                Console.WriteLine("Nome não informado na inscrição");
                return false;
            }
            return false;
        }
    }
}
