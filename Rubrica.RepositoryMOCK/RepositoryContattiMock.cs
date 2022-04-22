using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepository;

namespace Rubrica.RepositoryMOCK
{
    public class RepositoryContattiMock : IRepositoryContatti
    {
        private static List<Contatto> listacontatti = new List<Contatto>()
        {
            new Contatto{ContattoId=1, Nome= "Elena", Cognome="Floris"},
            new Contatto{ContattoId=2, Nome= "Massimiliano", Cognome="Fadda"},
            new Contatto{ContattoId=3, Nome= "Daniela", Cognome="Diana"}
        };
        public Contatto Add(Contatto item)
        {
            //if (item == null)
            //{
            //    return null;
            //}
            //listacontatti.Add(item);
            //return item;
            if (listacontatti.Count == 0)
            {
                item.ContattoId = 1;
            }
            else 
            {
                int maxId = 1;
                foreach (var s in listacontatti)
                {
                    if (s.ContattoId > maxId)
                    {
                        maxId = s.ContattoId;
                    }
                }
                item.ContattoId = maxId + 1;
            }
            listacontatti.Add(item);
            return item;
        }

        public bool Delete(Contatto item)
        {
            if (item == null)
            {
                return false;
            }
            listacontatti.Remove(item);
            return true;
        }

        public List<Contatto> GetAll()
        {
           return listacontatti;
        }

        public Contatto GetByIdC(int id)
        {
            foreach (var item in listacontatti)
            {
                if (item.ContattoId == id)
                {
                    return item;
                }
            }
            return null;
        }
    }


}