using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.Entities
{
    public class Indirizzo
    {
        public int IndirizzoId { get; set; }

        public string Tipo { get; set; }
        public string Via { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }
       
        public int CAP { get; set; }

        //Fk verso docente
        public int ContattoId { get; set; }

       
        public override string ToString()
        {
            return $"Indirizzo: {IndirizzoId}\tVia:{Via}\tCAP: {CAP}\tCittà: {Citta}\tProvincia: {Provincia}\tNazione: {Nazione}";
        }
    }
}
