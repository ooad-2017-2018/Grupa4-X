namespace OnlineVideotekaFenixASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrator",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Username = c.String(),
                        Lozinka = c.String(),
                        Videoteka_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Videoteka", t => t.Videoteka_Id)
                .Index(t => t.Videoteka_Id);
            
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazivFilma = c.String(),
                        GodinaFilma = c.Int(nullable: false),
                        ZanrFilma = c.String(),
                        Reziser = c.String(),
                        Glumci = c.String(),
                        VrijemeTrajanja = c.Int(nullable: false),
                        Cijena = c.Double(nullable: false),
                        Poster = c.Binary(),
                        Sinopsis = c.String(),
                        Direktor = c.String(),
                        BrojOcjena = c.Int(nullable: false),
                        ProsjekOcjena = c.Double(nullable: false),
                        Videoteka_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Videoteka", t => t.Videoteka_Id)
                .Index(t => t.Videoteka_Id);
            
            CreateTable(
                "dbo.Korisnik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImePrezime = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        DatumRegistracije = c.DateTime(nullable: false),
                        Username = c.String(),
                        Lozinka = c.String(),
                        Videoteka_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Videoteka", t => t.Videoteka_Id)
                .Index(t => t.Videoteka_Id);
            
            CreateTable(
                "dbo.Videoteka",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Korisnik", "Videoteka_Id", "dbo.Videoteka");
            DropForeignKey("dbo.Film", "Videoteka_Id", "dbo.Videoteka");
            DropForeignKey("dbo.Administrator", "Videoteka_Id", "dbo.Videoteka");
            DropIndex("dbo.Korisnik", new[] { "Videoteka_Id" });
            DropIndex("dbo.Film", new[] { "Videoteka_Id" });
            DropIndex("dbo.Administrator", new[] { "Videoteka_Id" });
            DropTable("dbo.Videoteka");
            DropTable("dbo.Korisnik");
            DropTable("dbo.Film");
            DropTable("dbo.Administrator");
        }
    }
}
