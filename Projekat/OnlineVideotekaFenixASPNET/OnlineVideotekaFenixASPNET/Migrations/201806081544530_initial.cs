namespace OnlineVideotekaFenixASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Korisnik", "DatumRodjenja", c => c.String());
            AlterColumn("dbo.Korisnik", "DatumRegistracije", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Korisnik", "DatumRegistracije", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Korisnik", "DatumRodjenja", c => c.DateTime(nullable: false));
        }
    }
}
