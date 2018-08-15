using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gerenciador.Models
{
    public class Calculator
    {
        public static int DiasRestantesAniversario(DateTime dt)
        {
            int anoAtual = DateTime.Today.Year;

            var dataInicial = DateTime.Today;
            var dataFinal = $"{dt.Day}/{dt.Month}/{anoAtual}";

            return (DateTime.Parse(dataFinal).Subtract(dataInicial)).Days;
        }
    }
}