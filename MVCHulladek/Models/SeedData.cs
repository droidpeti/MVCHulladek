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

                var szolgaltatasList = context.Szolgaltatas.ToList();

                var random = new Random();
                var naptarList = new List<Naptar>();
                var lakigList = new List<Lakig>();

                for (int i = 1; i <= 100; i++)
                {
                    var szolgaltatasId = szolgaltatasList[random.Next(szolgaltatasList.Count)].SzolgaltatasId;
                    naptarList.Add(new Naptar
                    {
                        Datum = DateTime.Now.AddDays(random.Next(-1000, 1000)),
                        SzolgaltatasId = szolgaltatasId
                    });

                    lakigList.Add(new Lakig
                    {
                        Igeny = DateTime.Now.AddDays(random.Next(-1000, 1000)),
                        SzolgaltatasId = szolgaltatasId,
                        Mennyiseg = random.Next(1, 21)
                    });
                }
                naptarList.Add(new Naptar
                {
                    Datum = DateTime.Parse("2024-12-03+12:00"),
                    SzolgaltatasId = 4
                });
                naptarList.Add(new Naptar
                {
                    Datum = DateTime.Parse("2024-12-03+12:00"),
                    SzolgaltatasId = 3
                });
                lakigList.Add(new Lakig
                {
                    Igeny = DateTime.Parse("2024-01-01+12:00"),
                    SzolgaltatasId = 4,
                    Mennyiseg = random.Next(1, 21)
                });

                context.Naptar.AddRange(naptarList);
                context.Lakig.AddRange(lakigList);
                
                context.SaveChanges();
            }
        }
    }
}
