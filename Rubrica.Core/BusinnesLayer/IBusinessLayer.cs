using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.BusinnesLayer
{
    public interface IBusinessLayer
    {
        List<Contatto> GetAllContatti();
        
        Esito InserisciNuovoContatto(Contatto nuovoContatto);
        Esito EliminaContatto(int codice);
        Esito InserisciNuovoIndirizzo(Indirizzo nuovoindirizzo);
    }
}
