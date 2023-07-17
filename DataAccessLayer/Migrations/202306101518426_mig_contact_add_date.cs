﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contact_add_date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContacDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContacDate");
        }
    }
}
