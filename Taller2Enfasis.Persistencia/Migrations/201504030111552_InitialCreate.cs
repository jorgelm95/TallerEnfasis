namespace Taller2Enfasis.Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artistas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(maxLength: 30),
                        UrlFoto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Discoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 40),
                        UrlFoto = c.String(),
                        FechaLanzamiento = c.DateTime(nullable: false),
                        NumeroCanciones = c.Int(nullable: false),
                        Genero = c.String(),
                        Precio = c.Int(nullable: false),
                        artista_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artistas", t => t.artista_Id)
                .Index(t => t.artista_Id);
            
            CreateTable(
                "dbo.Cancions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCacion = c.String(maxLength: 30),
                        Duracion = c.String(),
                        Precio = c.Int(nullable: false),
                        album_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discoes", t => t.album_Id)
                .Index(t => t.album_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(maxLength: 40),
                        Apellidos = c.String(maxLength: 40),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Sexo = c.String(maxLength: 30),
                        Correo = c.String(),
                        Username = c.String(maxLength: 15),
                        Password = c.String(maxLength: 15),
                        TipoUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cancions", "album_Id", "dbo.Discoes");
            DropForeignKey("dbo.Discoes", "artista_Id", "dbo.Artistas");
            DropIndex("dbo.Cancions", new[] { "album_Id" });
            DropIndex("dbo.Discoes", new[] { "artista_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Cancions");
            DropTable("dbo.Discoes");
            DropTable("dbo.Artistas");
        }
    }
}
