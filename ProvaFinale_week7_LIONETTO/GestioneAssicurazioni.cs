using ProvaFinale_week7_LIONETTO.Models;
using ProvaFinale_week7_LIONETTO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale_week7_LIONETTO
{
    public static class GestioneAssicurazioni
    {
        private static IRepositoryCliente repCliente = new RepositoryEFCliente();
        private static IRepositoryPolizza repPolizza = new RepositoryEFPolizza();

        public static void Menu()
        {
            bool exit = true;

            do
            {
                Console.WriteLine("**** Menu ****" +
                    "\n[1] aggiungi Cliente" +
                    "\n[2] aggiungi Polizza" +

                    "\n[3] visualizza tutte le Polizze inserite a DB" +

                    "\n[4] esci");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        AddCliente();
                        break;
                    case '2':
                        AddPolizza();
                        break;
                    case '3':
                        Console.WriteLine("tutte le polizze");
                        var allPolizze = repPolizza.GetAll();
                        StampaCollection<Polizza>(allPolizze);
                        break;
                    case '4':
                        exit = false;
                        Console.WriteLine("arrivederci");
                        break;
                    default:
                        Console.WriteLine("scelta non valida");
                        break;

                }
            } while (exit);

        }

        private static void StampaCollection<T>(ICollection<T> collection) where T : class
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("lista vuota");
                return;
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static void AddPolizza()
        {
            Console.WriteLine("a quale cliente vuoi aggiungere una polizza ?");
            var clienti = repCliente.GetAll();
            foreach (var item in clienti)
            {
                Console.WriteLine(item);
            }
            var codiceFiscale = Console.ReadLine();
            var clienteEsistente = repCliente.GetByCodiceFiscale(codiceFiscale);
            if (clienteEsistente == null)
            {
                Console.WriteLine("cliente errato o inesistente");
            }
            else
            {
                bool exit2 = true;
                do
                {
                    Console.WriteLine("che tipo di polizza vuoi aggiungere?"+
                         "\n [1] RcAuto" +
                         "\n [2] Furto " +
                         "\n [3] Vita"+
                         "\n [4] esci");
                    char scelta = Console.ReadKey().KeyChar;
                    switch (scelta)
                    {
                        case '1':
                            Console.WriteLine("inserisci data di stipula polizza ");
                            var data=DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("inserisci importo totale assicurazione ");
                            var imp = float.Parse(Console.ReadLine());
                            Console.WriteLine("inserisci importo rata Mensile ");
                            var rata = float.Parse(Console.ReadLine());
                            Console.WriteLine("inserisci targa auto ");
                            var targa = Console.ReadLine();
                            Console.WriteLine("inserisci cilindrata ");
                            var cil = int.Parse(Console.ReadLine());


                            var polizzaAuto = new RcAuto()
                            {
                                DataStipula = data,
                                ImportoAssicurazione = imp,
                                RataMensile = rata,
                                Targa = targa,
                                Cilindrata = cil,

                            };
                            repPolizza.Create(polizzaAuto);
                            

                            break;
                        case '2':
                            Console.WriteLine("inserisci data di stipula polizza ");
                            var data1 = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("inserisci importo totale assicurazione ");
                            var imp1 = float.Parse(Console.ReadLine());
                            Console.WriteLine("inserisci importo rata Mensile ");
                            var rata1 = float.Parse(Console.ReadLine());
                            
                            Console.WriteLine("inserisci percentuale copertura ");
                            var percentualeCopertura = int.Parse(Console.ReadLine());


                            var polizzaFurto = new Furto()
                            {
                                DataStipula = data1,
                                ImportoAssicurazione = imp1,
                                RataMensile = rata1,
                                PercentualeCopertura=percentualeCopertura,

                            };
                            repPolizza.Create(polizzaFurto);

                            break;
                        case '3':
                            Console.WriteLine("inserisci data di stipula polizza ");
                            var data2 = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("inserisci importo totale assicurazione ");
                            var imp2 = float.Parse(Console.ReadLine());
                            Console.WriteLine("inserisci importo rata Mensile ");
                            var rata2 = float.Parse(Console.ReadLine());
                           
                            Console.WriteLine("inserisci età del cliente da assicurare ");
                            var eta = int.Parse(Console.ReadLine());


                            var polizzaVita = new Vita()
                            {
                                DataStipula = data2,
                                ImportoAssicurazione = imp2,
                                RataMensile = rata2,
                                AnniAssicurato=eta,

                            };
                            repPolizza.Create(polizzaVita);
                            break;
                        case '4':
                            exit2 = false;
                            Console.WriteLine("fine");
                            break ;
                        default:
                            Console.WriteLine("scelta non valida");
                            break;

                    }
                }while (exit2);
            }
        }

        private static void AddCliente()
        {
            Console.WriteLine("inserisci codice fiscale");
            var codFisc = Console.ReadLine();
            Console.WriteLine("inserisci nome");
            var nome = Console.ReadLine();
            Console.WriteLine("inserisci cognome");
            var cognome = Console.ReadLine();
            Console.WriteLine("inserisci indirizzo");
            var indirizzo = Console.ReadLine();


            var cliente = new Cliente()
            {
                CodiceFiscale = codFisc,
                Nome = nome,
                Cognome = cognome,
                Indirizzo=indirizzo
            };
            repCliente.Create(cliente);
            
        }
    }
}
