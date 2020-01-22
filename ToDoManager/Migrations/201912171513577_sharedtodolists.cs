namespace ToDoManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sharedtodolists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SharedToDoLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SharedListId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ToDoLists", t => t.SharedListId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.SharedListId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SharedToDoLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.SharedToDoLists", "SharedListId", "dbo.ToDoLists");
            DropIndex("dbo.SharedToDoLists", new[] { "UserId" });
            DropIndex("dbo.SharedToDoLists", new[] { "SharedListId" });
            DropTable("dbo.SharedToDoLists");
        }
    }
}
