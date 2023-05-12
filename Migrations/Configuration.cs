namespace ASTechLogin.Migrations
{
    using ASTechLogin.Data;
    using ASTechLogin.Helpers;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ASTechLogin.Data.TechDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ASTechLogin.Data.TechDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            this.SeedUsers(context);
        }

        private void SeedUsers(TechDbContext context)
        {
            var password = HashManager.HashPassword("Password012");
            if(!context.user.Any(i=>i.IdNumber=="9212214321678"))
            {
                context.user.Add(new Entities.User
                {
                    IdNumber= "9212214321678",
                    Password= password

                });
            }

            if (!context.user.Any(i => i.IdNumber == "9312214321678"))
            {
                context.user.Add(new Entities.User
                {
                    IdNumber = "9312214321678",
                    Password = password

                });
            }

            context.SaveChanges();
        }
    }
}
