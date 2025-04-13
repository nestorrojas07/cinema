using Domain.Entities;

namespace Infrastructure.Seeds;

public static class TheaterSeed
{
    public static void SeedTheaters(this ApplicationDbContext context)
    {
        if( !context.theaters.Any() )
        {
            var theaters = new List<Theater>()
            {
                new Theater()
                {
                    Name = "Multiplex Portal 80",
                    Address = "Calle 80 # 100-52",
                    Contact = "tel:6011004578 email: cinecol.portal80@cinecolombia.com",
                },
                new Theater()
                {
                    Name = "Cine Colombia Multiplex  CC Santafe",
                    Address = "Calle 185 # 45-03 cc Santafe",
                    Contact = "tel:6011234578 email: cinecol.santafe@cinecolombia.com",
                },
            };
            
            context.theaters.AddRange(theaters);
            context.SaveChanges();

        }
    }
}