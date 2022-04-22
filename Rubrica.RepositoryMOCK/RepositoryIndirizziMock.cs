using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryMOCK
{
    public class RepositoryIndirizziMock : IRepositoryIndirizzi
    {
        private static List<Indirizzo> listaindirizzi = new List<Indirizzo>()
        {
            new Indirizzo{IndirizzoId=80,Tipo="Domicilio",Via="Via Sa Tella",CAP=0934,Citta="Cagliari",Provincia="Cagliari",Nazione="Italia",ContattoId=1},
            new Indirizzo{IndirizzoId=81,Tipo="Residenza",Via="Via Delle Rane",CAP=09027,Citta="Ossi",Provincia="Sassari",Nazione="Italia",ContattoId=2}
        };
        public Indirizzo Add(Indirizzo item)
        {
            if (item == null)
            {
                return null;
            }
            listaindirizzi.Add(item);
            return item;
        }

        public bool Delete(Indirizzo item)
        {
            if (item == null)
            {
                return false;
            }
            listaindirizzi.Remove(item);
            return true;
        }

        public List<Indirizzo> GetAll()
        {
            return listaindirizzi;
        }

        public Indirizzo GetByIdI(int id)
        {
            foreach (var item in listaindirizzi)
            {
                if (item.IndirizzoId == id)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
