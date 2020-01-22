namespace ToDoManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todotask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentListId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ToDoLists", t => t.ParentListId, cascadeDelete: false)
                .Index(t => t.ParentListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoTasks", "ParentListId", "dbo.ToDoLists");
            DropIndex("dbo.ToDoTasks", new[] { "ParentListId" });
            DropTable("dbo.ToDoTasks");
        }
    }
}
