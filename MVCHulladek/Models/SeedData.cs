using Microsoft.EntityFrameworkCore;
using MVCHulladek.Data;

namespace MVCHulladek.Models
{
    public class SeedData
    {
        
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            
            MVCHulladekContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<MVCHulladekContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Szolgaltatas.Any())
            {
                foreach (Naptar naptar in context.Naptar)
                    context.Naptar.Remove(naptar);
                foreach (Lakig lakig in context.Lakig)
                    context.Lakig.Remove(lakig);

                context.Szolgaltatas.AddRange(
                    new Szolgaltatas
                    {
                        Tipus = "kom",
                        Jelentes = "Kommunális hulladék"
                    },
                    new Szolgaltatas
                    {
                        Tipus = "zold",
                        Jelentes = "Zöldhulladék"
                    },
                    new Szolgaltatas
                    {
                        Tipus = "mua",
                        Jelentes = "Műanyag hulladék"
                    },
                    new Szolgaltatas
                    {
                        Tipus = "pa",
                        Jelentes = "Papír hulladék"
                    }
                );
                context.SaveChanges();
                context.Naptar.AddRange(
                    new Naptar { Datum = new DateTime(2020, 01, 15), SzolgaltatasId = 1 },
                    new Naptar { Datum = new DateTime(2020, 02, 16), SzolgaltatasId = 2 },
                    new Naptar { Datum = new DateTime(2020, 03, 17), SzolgaltatasId = 3 },
                    new Naptar { Datum = new DateTime(2020, 04, 18), SzolgaltatasId = 4 },
                    new Naptar { Datum = new DateTime(2020, 05, 19), SzolgaltatasId = 5 },
                    new Naptar { Datum = new DateTime(2020, 06, 20), SzolgaltatasId = 6 },
                    new Naptar { Datum = new DateTime(2020, 07, 21), SzolgaltatasId = 7 },
                    new Naptar { Datum = new DateTime(2020, 08, 22), SzolgaltatasId = 8 },
                    new Naptar { Datum = new DateTime(2020, 09, 23), SzolgaltatasId = 9 },
                    new Naptar { Datum = new DateTime(2020, 10, 24), SzolgaltatasId = 10 },
                    new Naptar { Datum = new DateTime(2020, 11, 25), SzolgaltatasId = 11 },
                    new Naptar { Datum = new DateTime(2020, 12, 26), SzolgaltatasId = 12 },
                    new Naptar { Datum = new DateTime(2021, 01, 27), SzolgaltatasId = 13 },
                    new Naptar { Datum = new DateTime(2021, 02, 28), SzolgaltatasId = 14 },
                    new Naptar { Datum = new DateTime(2021, 03, 29), SzolgaltatasId = 15 },
                    new Naptar { Datum = new DateTime(2021, 04, 30), SzolgaltatasId = 16 },
                    new Naptar { Datum = new DateTime(2021, 05, 31), SzolgaltatasId = 17 },
                    new Naptar { Datum = new DateTime(2021, 06, 01), SzolgaltatasId = 18 },
                    new Naptar { Datum = new DateTime(2021, 07, 02), SzolgaltatasId = 19 },
                    new Naptar { Datum = new DateTime(2021, 08, 03), SzolgaltatasId = 20 }
                );
                context.SaveChanges();

                context.Lakig.AddRange(
                    new Lakig { Igeny = new DateTime(2020, 01, 15), SzolgaltatasId = 1, Mennyiseg = 1 },
                    new Lakig { Igeny = new DateTime(2020, 02, 16), SzolgaltatasId = 2, Mennyiseg = 2 },
                    new Lakig { Igeny = new DateTime(2020, 03, 17), SzolgaltatasId = 3, Mennyiseg = 3 },
                    new Lakig { Igeny = new DateTime(2020, 04, 18), SzolgaltatasId = 4, Mennyiseg = 4 },
                    new Lakig { Igeny = new DateTime(2020, 05, 19), SzolgaltatasId = 5, Mennyiseg = 5 },
                    new Lakig { Igeny = new DateTime(2020, 06, 20), SzolgaltatasId = 6, Mennyiseg = 6 },
                    new Lakig { Igeny = new DateTime(2020, 07, 21), SzolgaltatasId = 7, Mennyiseg = 7 },
                    new Lakig { Igeny = new DateTime(2020, 08, 22), SzolgaltatasId = 8, Mennyiseg = 8 },
                    new Lakig { Igeny = new DateTime(2020, 09, 23), SzolgaltatasId = 9, Mennyiseg = 9 },
                    new Lakig { Igeny = new DateTime(2020, 10, 24), SzolgaltatasId = 10, Mennyiseg = 10 },
                    new Lakig { Igeny = new DateTime(2020, 11, 25), SzolgaltatasId = 11, Mennyiseg = 11 },
                    new Lakig { Igeny = new DateTime(2020, 12, 26), SzolgaltatasId = 12, Mennyiseg = 12 },
                    new Lakig { Igeny = new DateTime(2021, 01, 27), SzolgaltatasId = 13, Mennyiseg = 13 },
                    new Lakig { Igeny = new DateTime(2021, 02, 28), SzolgaltatasId = 14, Mennyiseg = 14 },
                    new Lakig { Igeny = new DateTime(2021, 03, 29), SzolgaltatasId = 15, Mennyiseg = 15 },
                    new Lakig { Igeny = new DateTime(2021, 04, 30), SzolgaltatasId = 16, Mennyiseg = 16 },
                    new Lakig { Igeny = new DateTime(2021, 05, 31), SzolgaltatasId = 17, Mennyiseg = 17 },
                    new Lakig { Igeny = new DateTime(2021, 06, 01), SzolgaltatasId = 18, Mennyiseg = 18 },
                    new Lakig { Igeny = new DateTime(2021, 07, 02), SzolgaltatasId = 19, Mennyiseg = 19 },
                    new Lakig { Igeny = new DateTime(2021, 08, 03), SzolgaltatasId = 20, Mennyiseg = 20 }
                );
                context.SaveChanges();
                
            }
            
        }
    }
}
