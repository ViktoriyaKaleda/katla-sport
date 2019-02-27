namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Adds deletion time and is deleted fields to store item table.
    /// </summary>
    public partial class AddIsDeletedDeletionDateFieldsToStoreItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product_store_items", "product_store_item_is_deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.product_store_items", "product_store_item_deletion_date", c => c.DateTime());
        }

        public override void Down()
        {
            DropColumn("dbo.product_store_items", "product_store_item_deletion_date");
            DropColumn("dbo.product_store_items", "product_store_item_is_deleted");
        }
    }
}
