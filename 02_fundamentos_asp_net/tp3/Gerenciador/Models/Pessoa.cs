using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gerenciador.Models
{
    public class Pessoa
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DtAniversario { get; set; }


        public Pessoa() {
            Id = TokenId();
        }

        private string TokenId()
        {
            Guid g = Guid.NewGuid();
            string strGuid = Convert.ToBase64String(g.ToByteArray());
            strGuid = strGuid.Replace("=", "");
            strGuid = strGuid.Replace("+", "");
            strGuid = strGuid.Replace("/", "");

            return strGuid;
        }
    }
}