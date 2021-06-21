namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class odev3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Capabilities",
                c => new
                    {
                        CapabilityID = c.Int(nullable: false, identity: true),
                        CapabilityName = c.String(maxLength: 100),
                        CapabilityLevel = c.Int(nullable: false),
                        CapabilityStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CapabilityID);
            
            AddColumn("dbo.Mesajs", "MessageReadStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Mesajs", "MessageDraftsStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mesajs", "MessageDraftsStatus");
            DropColumn("dbo.Mesajs", "MessageReadStatus");
            DropTable("dbo.Capabilities");
        }
    }
}
