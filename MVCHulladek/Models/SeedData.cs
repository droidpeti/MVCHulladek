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
                    new Naptar
                    {
                        Datum = new DateTime(2020, 06, 20, 21, 4, 11),
                        SzolgaltatasId = 1
                    },
                    new Naptar 
                    {
                        Datum = new DateTime(2021, 07, 21, 22, 5, 12),
                        SzolgaltatasId = 2
                    },
                    new Naptar
                    {
                        Datum = new DateTime(2022, 08, 22, 23, 6, 13),
                        SzolgaltatasId = 3
                    },
                    new Naptar
                    {
                        Datum = new DateTime(2023, 09, 23, 01, 7, 14),
                        SzolgaltatasId = 4
                    }
                    
                );
                context.SaveChanges();
                context.Lakig.AddRange(
                    new Lakig 
                    {
                        Igeny = new DateTime(2020, 06, 20, 22, 4, 11),
                        SzolgaltatasId = 1,
                        Mennyiseg = 1
                    },
                    new Lakig
                    {
                        Igeny = new DateTime(2021, 07, 21, 23, 5, 12),
                        SzolgaltatasId = 2,
                        Mennyiseg = 2
                    },
                    new Lakig
                    {
                        Igeny = new DateTime(2022, 08, 22, 01, 6, 13),
                        SzolgaltatasId = 3,
                        Mennyiseg = 3
                    },
                    new Lakig
                    {
                        Igeny = new DateTime(2023, 09, 23, 02, 7, 14),
                        SzolgaltatasId = 4,
                        Mennyiseg = 5
                    }
                );
                context.SaveChanges();
                
            }
            
        }
    }
}
