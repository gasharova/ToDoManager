namespace ToDoManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todolists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: false)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoLists", "OwnerId", "dbo.Users");
            DropIndex("dbo.ToDoLists", new[] { "OwnerId" });
            DropTable("dbo.ToDoLists");
        }
    }
}
