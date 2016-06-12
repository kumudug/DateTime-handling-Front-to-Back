namespace DateTimeFrontToBack.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataPocs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoredDateTimeUTC = c.DateTime(nullable: false),
                        StoredDateTimeOffset = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DataPocs");
        }
    }
}
