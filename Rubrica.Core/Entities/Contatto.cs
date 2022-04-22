using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.Entities
{
    public class Contatto
    {
        public int ContattoId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public override string ToString()
        {
            return $"Contatto: {ContattoId}\t Nome:{Nome}\t Cognome: {Cognome}";
        }




    }
}
