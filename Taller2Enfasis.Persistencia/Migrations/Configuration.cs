namespace Taller2Enfasis.Persistencia.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Taller2Enfasis.Persistencia.Taller2EnfasisContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Taller2Enfasis.Persistencia.Taller2EnfasisContexto";
        }

        protected override void Seed(Taller2Enfasis.Persistencia.Taller2EnfasisContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Usuarios.AddOrUpdate(
             new Usuario
             {
                 Nombres = "jorge luis",
                 Apellidos = "menco",
                 FechaNacimiento = DateTime.Now,
                 Sexo = "Masculino",
                 Correo = "jorge@gmail.com",
                 Username = "luis95",
                 Password = "luis1995",
                 ConfirmacionPassword = "luis1995",
                 TipoUsuario = TipoUsuario.Administrador

             });

        }
    }
}
