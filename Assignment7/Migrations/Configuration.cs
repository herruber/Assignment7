namespace Assignment7.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Assignment7.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment7.DataAccess.PersonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assignment7.DataAccess.PersonContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Persons.AddOrUpdate(p => p.ID,
                new Person { ID = 1, City = "Skellefteå", Name = "Robert Nyqvist", Occupation="Studerande"},
                new Person { ID = 2, City = "Stockholm", Name = "Arne Weise", Occupation="Barista"},
                new Person { ID = 3, City = "Umeå", Name = "Anders Saucig", Occupation="Arbetslös"},
                new Person { ID = 4, City = "Ursviken", Name = "Urban Ur", Occupation="Urmakare"},
                new Person { ID = 5, City = "Järfälla", Name = "Pia Petersson", Occupation = "Formel 1 förare" },
                new Person { ID = 6, City = "Kalix", Name = "Jan Banan", Occupation = "Bilmekaniker" },
                new Person { ID = 7, City = "Bergsbyn", Name = "Leif Larsson", Occupation = "Kakmonster" }
                );
        }
    }
}
