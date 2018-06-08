namespace OnlineVideotekaFenixASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisnik", "ListaFilmova", c => c.String());
        }
        
        public override void Down()
        {
           DropColumn("dbo.Korisnik", "ListaFilmova");
          
        }
    }
}
