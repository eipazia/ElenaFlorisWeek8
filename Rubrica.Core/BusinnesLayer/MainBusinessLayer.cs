using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.BusinnesLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryContatti contattiRepo;
        private readonly IRepositoryIndirizzi indirizziRepo;


        public MainBusinessLayer(IRepositoryContatti contatti, IRepositoryIndirizzi indirizzi)
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;
        }

        

        public Esito EliminaContatto(int codice)
        {
            var contattoRecuperato = contattiRepo.GetByIdC(codice);
            
            if (contattoRecuperato == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessun contatto corrispondente al codice inserito" };
            }
            var sottolista = GetIndirizzoByCodice(codice);
            if (sottolista.Count > 0)
            {
                return new Esito() { IsOk = false, Messaggio = "Il contatto non verrà eliminato" };
            }

            contattiRepo.Delete(contattoRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Contatto eliminato correttamente" };
        }
        public List<Indirizzo> GetIndirizzoByCodice(int codice)
        {
            
            var contatto = contattiRepo.GetByIdC(codice);
            if (contatto == null)
            {
                return null;
            }
            List<Indirizzo> indirizziFiltrati = new List<Indirizzo>();
            foreach (var item in indirizziRepo.GetAll())
            {
                if (item.ContattoId == codice)
                {
                    indirizziFiltrati.Add(item);
                }
            }
            return indirizziFiltrati;

        }

        public List<Contatto> GetAllContatti()
        {
            return contattiRepo.GetAll();
        }
       

        public Esito InserisciNuovoContatto(Contatto nuovoContatto)
        {
            Contatto contattoRecuperato = contattiRepo.GetByIdC(nuovoContatto.ContattoId);
            if (contattoRecuperato == null)
            {
                contattiRepo.Add(nuovoContatto);
                return new Esito() { IsOk = true, Messaggio = "Contatto aggiunto correttamente" };
            }
            return new Esito() { IsOk = false, Messaggio = "Impossibile aggiungere il nuovo contatto" };
        }

        public Esito InserisciNuovoIndirizzo(Indirizzo nuovoindirizzo)
        {
            
            Contatto contattoEsistente = contattiRepo.GetByIdC(nuovoindirizzo.ContattoId);
            if (contattoEsistente == null)
            {
                return new Esito { Messaggio = "Codice contatto errato", IsOk = false };
            }
            indirizziRepo.Add(nuovoindirizzo);
            
            return new Esito { Messaggio = "indirizzo inserito correttamente", IsOk = true };
        }
    }
}
