﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_headingsttusadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HeadinStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "HeadinStatus");
        }
    }
}
