namespace AthosTestePriscilaMatos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AthosTestePriscilaMatos.Models.AthosTestePriscilaMatosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AthosTestePriscilaMatos.Models.AthosTestePriscilaMatosContext context)
        {
            context.Administradoras.AddOrUpdate(x => x.Id,
           new Models.Administradora() { Id = 1, Nome = "SIGMA" }
            );

            context.Usuarios.AddOrUpdate(x => x.Id,
           new Models.Usuario() { Id = 1, Nome = "Priscila de Matos", Email = "pridematos@gmail.com", Condominio = "Bethaville", Tp_Usuario = "Morador" },
           new Models.Usuario() { Id = 1, Nome = "Giovanni de Matos", Email = "gidematos@gmail.com", Condominio = "Bethaville", Tp_Usuario = "Administradora" },
           new Models.Usuario() { Id = 1, Nome = "José de Matos", Email = "zedematos@gmail.com", Condominio = "Bethaville", Tp_Usuario = "Zelador" }
           );

            
            context.Condominios.AddOrUpdate(x => x.Id,
           new Models.Condominio() { Id = 1, Nome_Condominio = "Bethaville",  Administradora = "SIGMA", Tp_Usuario = "Sindico"}

           );

 
        }
    }
}
