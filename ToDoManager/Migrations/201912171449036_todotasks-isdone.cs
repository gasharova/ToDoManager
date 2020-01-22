namespace ToDoManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todotasksisdone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoTasks", "IsDone", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoTasks", "IsDone");
        }
    }
}
