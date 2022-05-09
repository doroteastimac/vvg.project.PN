using Microsoft.EntityFrameworkCore.ChangeTracking;
using Console.PN.Database;
using Model.PN.model;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Console.PN
{
   class DataQueries
    {

        static void Main(string[] args)
        {
             PNDbContext pnDbContext = new PNDbContext();

            /*Dodavanje mjesta*/
            EntityEntry<MjestoPutovanja> novoMjestoPutovanja = pnDbContext.MjestoPutovanja.Add(new MjestoPutovanja 
            {
                Id = 4,
                NazivMjesta = "Varazdin"
            });
            pnDbContext.SaveChanges();

            /*Update naziva mjesta*/

            MjestoPutovanja izmjenaNaziva = pnDbContext.MjestoPutovanja.Find(novoMjestoPutovanja.Entity.NazivMjesta);
            izmjenaNaziva.NazivMjesta = "Virovitica";

            novoMjestoPutovanja = pnDbContext.MjestoPutovanja.Update(izmjenaNaziva);
            pnDbContext.SaveChanges();

            /*brisanje mjesta*/

            pnDbContext.MjestoPutovanja.Remove(novoMjestoPutovanja.Entity);
            pnDbContext.SaveChanges();

            /*Dodavanje Putnog troska*/
            EntityEntry<PutniTroskovi> noviPutniTroskovi = pnDbContext.PutniTroskovi.Add(new PutniTroskovi
            {
                Id = 4,
                IznosTroska = 276.25,
                VrstaTroska = 1
                
            }); 
            pnDbContext.SaveChanges();

            /*Dodavanje Radnog mjesta*/
            EntityEntry<RadnoMjesto> novoRadnoMjesto = pnDbContext.RadnoMjesto.Add(new RadnoMjesto
            {
                Id = 4,
                Naziv = "Tehnicar"

            });
            pnDbContext.SaveChanges();

            /*Dodavanje vozila*/
            EntityEntry<Vozilo> novoVozilo = pnDbContext.Vozilo.Add(new Vozilo
            {
                Id = 4,
                Marka = "Audi",
                Registracija ="ZG4658FF"

            });
            pnDbContext.SaveChanges();

            /*Dodavanje vrste troska*/
            EntityEntry<VrstaTroska> novaVrstaTroska = pnDbContext.VrstaTroska.Add(new VrstaTroska
            {
                Id = 4,
                Naziv ="Ostali troskovi"

            });
            pnDbContext.SaveChanges();

            /*Dodavanje zaposlenika*/
            EntityEntry<Zaposlenik> noviZaposlenik = pnDbContext.Zaposlenik.Add(new Zaposlenik
            {
                Id = 4,
                Ime ="Marko",
                Prezime = "Markic",
                UkupniIznosTroska = 12365.57,
                RadnoMjesto = 1,
                PutniTroskovi =1

            });
            pnDbContext.SaveChanges();

        }

        public IList<PutniNalog> getPutniNalog()
        {
            PNDbContext pnDbContext = new PNDbContext();

            List<Zaposlenik> putniTroskoviList = new List<Zaposlenik>();
            Double UkupniTrosak = 0;

            pnDbContext.Zaposlenik.OrderBy(d => d.Ime)
                .Join(pnDbContext.PutniTroskovi,
                r => r.PutniTroskovi,
                t => t.Id, (r, t) => new {
                    Id = t.Id,
                    Troskovi=t.IznosTroska,
                                       
                }).ToList().ForEach(t => {
                    UkupniTrosak = ((double)(t.Troskovi*5));

                    putniTroskoviList
                    .Add(new Zaposlenik
                    {
                        Ime = "Pero",
                        Prezime ="Peric",
                        UkupniIznosTroska=UkupniTrosak,
                        RadnoMjesto=1,
                        PutniTroskovi=1
                       
                    });
                });

            return (IList<PutniNalog>)putniTroskoviList.ToList();
        }
    }
}
