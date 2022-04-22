using Rubrica.Core.BusinnesLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryMOCK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Presentation
{
    internal class Menu
    {

        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
        //private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiADO(), new RepositoryStudentiADO());


        internal static void Start()
        {
            bool continua = true;

            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaContatti();
                    break;
                case 2:
                    InserisciNuovoContatto();
                    break;

                case 3:
                    EliminaCorso();
                    break;

                case 4:
                    InserisciNuovoIndirizzo();
                    break;


                case 0:
                    return false;
                default:
                    Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
                    break;
            }
            return true;
        }

        private static void InserisciNuovoIndirizzo()
        {
            //Chiedo le info per creare il nuovo studente
            Console.WriteLine("Inserisci tipo");
            string tipo = Console.ReadLine();
            Console.WriteLine("Inserisci via");
            string via = Console.ReadLine();
            Console.WriteLine("Inserisci cap");
            int cap = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci città");
            string citta = Console.ReadLine();
            Console.WriteLine("Inserisci provincia");
            string provincia = Console.ReadLine();
            Console.WriteLine("Inserisci nazione");
            string nazione = Console.ReadLine();
            
            VisualizzaContatti();
            Console.WriteLine("Inserisci codice contatto per il quale si vuole inserire indirizzo");
            int codice = int.Parse(Console.ReadLine());

           
            Indirizzo nuovoindirizzo = new Indirizzo();
            nuovoindirizzo.Tipo = tipo;
            nuovoindirizzo.Via = via;
            nuovoindirizzo.CAP = cap;
            nuovoindirizzo.Citta = citta;
            nuovoindirizzo.Provincia = provincia;
            nuovoindirizzo.Nazione = nazione;
            nuovoindirizzo.ContattoId = codice;

           
            Esito esito = bl.InserisciNuovoIndirizzo(nuovoindirizzo);
            Console.WriteLine(esito.Messaggio);
        }

        private static void EliminaCorso()
        {
            VisualizzaContatti();
            Console.WriteLine("Quale contatto vuoi eliminare? Inserisci il codice");
            int codice = int.Parse(Console.ReadLine());
            Esito esito = bl.EliminaContatto(codice);
            Console.WriteLine(esito.Messaggio);
        }

        private static void VisualizzaContatti()
        {
            var listacontatti = bl.GetAllContatti();
            if (listacontatti.Count == 0)
            {
                Console.WriteLine("Non ci sono contatti");
            }
            else
            {
                Console.WriteLine("Ecco l'elenco dei contatti:");
                foreach (var item in listacontatti)
                {
                    Console.WriteLine(item);
                }
            }
        }
        private static void InserisciNuovoContatto()
        {
            //Console.WriteLine("Inserisci il codice del contatto");
            //int codice = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il nome del contatto");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome del contatto");
            string cognome = Console.ReadLine();

            Contatto nuovoContatto = new Contatto();
            //nuovoContatto.ContattoId = codice;
            nuovoContatto.Nome = nome;
            nuovoContatto.Cognome = cognome;

            var esito = bl.InserisciNuovoContatto(nuovoContatto);
            Console.WriteLine(esito.Messaggio);
        }
        private static int SchermoMenu()
        {
            Console.WriteLine("******************MENU*****************");
            Console.WriteLine("Funzionalità Contatti");
            Console.WriteLine("1.Visualizza Contatti");
            Console.WriteLine("2.Inserisci nuovo Contatto");
            Console.WriteLine("3.Elimina Contatto");
            Console.WriteLine("4.Inserisci nuovo indirizzo");
            Console.WriteLine("\n0. Exit");

            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while (!(int.TryParse(Console.ReadLine(), out scelta) /*&& scelta >=0 && scelta <= 1*/))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
            }

            return scelta;
        }
    }
}
