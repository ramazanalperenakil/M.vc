﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminUserNAme = c.String(maxLength: 50),
                        MyPasword = c.String(maxLength: 50),
                        AdminRole = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
