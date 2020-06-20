﻿namespace Innoivce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InnoviceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Innvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Innvoices");
        }
    }
}
