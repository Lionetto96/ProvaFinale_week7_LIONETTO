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

            bool exit2 = true;
            do
            {
                Console.WriteLine("che tipo di polizza vuoi aggiungere?" +
                     "\n [1] RcAuto" +
                     "\n [2] Furto " +
                     "\n [3] Vita" +
                     "\n [4] esci");
                char scelta = Console.ReadKey().KeyChar;
                switch (scelta)
                {
                    case '1':
                        Console.WriteLine("inserisci codice fiscale del cliente a cui vuoi aggiungere una polizza ?");
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
                            DateTime data;
                            do
                            {
                                Console.WriteLine("inserisci data di stipula polizza ");
                                
                            } while (!DateTime.TryParse(Console.ReadLine(), out data));
                            float imp;
                            do
                            {
                                Console.WriteLine("inserisci importo totale assicurazione ");
                                
                            }while(!float.TryParse(Console.ReadLine(), out imp));
                            float rata;
                            do
                            {
                                Console.WriteLine("inserisci importo rata Mensile ");
                                
                            }while (!float.TryParse(Console.ReadLine(),out rata));
                            string targa;
                            do
                            {
                                Console.WriteLine("inserisci targa auto DI MAX 5 caratteri ");
                                targa = Console.ReadLine();
                            } while (!(!string.IsNullOrWhiteSpace(targa) && targa.Length==5));

                            int cil;
                            do
                            {
                                Console.WriteLine("inserisci cilindrata ");

                            } while(!int.TryParse(Console.ReadLine(),out cil));
                            
                            


                            var polizzaAuto = new RcAuto()
                            {
                                DataStipula = data,
                                ImportoAssicurazione = imp,
                                RataMensile = rata,
                                Targa = targa,
                                Cilindrata = cil,
                                CodiceFiscale = codiceFiscale,

                            };
                            repPolizza.Create(polizzaAuto);
                        }



                        break;
                    case '2':
                        Console.WriteLine("inserisci codice fiscale del cliente a cui vuoi aggiungere una polizza ?");
                        var clienti2 = repCliente.GetAll();
                        foreach (var item in clienti2)
                        {
                            Console.WriteLine(item);
                        }
                        var codiceFiscale2 = Console.ReadLine();
                        
                        var clienteEsistente2 = repCliente.GetByCodiceFiscale(codiceFiscale2);
                        if (clienteEsistente2 == null)
                        {
                            Console.WriteLine("cliente errato o inesistente");
                        }
                        else
                        {
                            DateTime data1;
                            do
                            {
                                Console.WriteLine("inserisci data di stipula polizza ");
                            }while(!DateTime.TryParse(Console.ReadLine(), out data1));

                            float imp1;
                            do
                            {
                                Console.WriteLine("inserisci importo totale assicurazione ");
                            }while(!float.TryParse(Console.ReadLine(), out imp1));

                            float rata1;
                            do
                            {
                                Console.WriteLine("inserisci importo rata Mensile ");
                            }while(!float.TryParse(Console.ReadLine(),out rata1));


                            int percentualeCopertura;
                            do
                            {
                                Console.WriteLine("inserisci percentuale copertura ");
                            }while(!int.TryParse(Console.ReadLine(),out percentualeCopertura));
                            
                           


                            var polizzaFurto = new Furto()
                            {
                                DataStipula = data1,
                                ImportoAssicurazione = imp1,
                                RataMensile = rata1,
                                PercentualeCopertura = percentualeCopertura,
                                CodiceFiscale = codiceFiscale2,

                            };
                            repPolizza.Create(polizzaFurto);
                        }
                        

                        break;
                    case '3':
                        Console.WriteLine("Inserisci codice fiscale del cliente a cui vuoi aggiungere una polizza ?");
                        var clienti3 = repCliente.GetAll();
                        foreach (var item in clienti3)
                        {
                            Console.WriteLine(item);
                        }
                        var codiceFiscale3 = Console.ReadLine();
                        
                        var clienteEsistente3 = repCliente.GetByCodiceFiscale(codiceFiscale3);
                        if (clienteEsistente3 == null)
                        {
                            Console.WriteLine("cliente errato o inesistente");
                        }
                        else
                        {
                            DateTime data2;
                            do
                            {
                                Console.WriteLine("inserisci data di stipula polizza ");
                                
                            }while(!DateTime.TryParse(Console.ReadLine(), out data2));
                            float imp2;
                            do
                            {
                                Console.WriteLine("inserisci importo totale assicurazione ");
                                
                            }while(!float.TryParse(Console.ReadLine(), out imp2));
                            float rata2;
                            do
                            {
                                Console.WriteLine("inserisci importo rata Mensile ");
                                
                            }while(!float.TryParse(Console.ReadLine(),out rata2));
                          
                            int eta;
                            do
                            {
                                Console.WriteLine("inserisci età del cliente da assicurare ");
                                
                            }while(!int.TryParse(Console.ReadLine(),out eta));
                            


                            var polizzaVita = new Vita()
                            {
                                DataStipula = data2,
                                ImportoAssicurazione = imp2,
                                RataMensile = rata2,
                                AnniAssicurato = eta,
                                CodiceFiscale = codiceFiscale3

                            };
                            repPolizza.Create(polizzaVita);
                        }
                        
                        break;
                    case '4':
                        exit2 = false;
                        Console.WriteLine("fine");
                        break;
                    default:
                        Console.WriteLine("scelta non valida");
                        break;

                }
            } while (exit2);
        }
        private static void AddCliente()
        {
            string codFisc;
            do
            {
                Console.WriteLine("inserisci codice fiscale");
                codFisc = Console.ReadLine();
            } while(!(!string.IsNullOrWhiteSpace(codFisc) && codFisc.Length==16));

            string nome;
            do
            {
                Console.WriteLine("inserisci nome");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));
            string cognome;
            do
            {
                Console.WriteLine("inserisci cognome");
                cognome = Console.ReadLine();
            }while(string.IsNullOrWhiteSpace(cognome));
            string indirizzo;
            do
            {
                Console.WriteLine("inserisci indirizzo");
                indirizzo = Console.ReadLine();
            }while(string.IsNullOrEmpty(indirizzo));
            


            var cliente = new Cliente()
            {
                CodiceFiscale = codFisc,
                Nome = nome,
                Cognome = cognome,
                Indirizzo = indirizzo
            };
            repCliente.Create(cliente);

        }
    }

    
}

