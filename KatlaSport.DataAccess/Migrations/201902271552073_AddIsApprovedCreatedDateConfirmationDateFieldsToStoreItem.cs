namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Add IsApproved, CreatedDate, ConfirmationDate to StoreItem model.
    /// </summary>
    public partial class AddIsApprovedCreatedDateConfirmationDateFieldsToStoreItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product_store_items", "product_store_item_is_approved", c => c.Boolean(nullable: false));
            AddColumn("dbo.product_store_items", "product_store_item_created_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.product_store_items", "product_store_item_confirmation_date", c => c.DateTime(nullable: true));
        }

        public override void Down()
        {
            DropColumn("dbo.product_store_items", "product_store_item_confirmation_date");
            DropColumn("dbo.product_store_items", "product_store_item_created_date");
            DropColumn("dbo.product_store_items", "product_store_item_is_approved");
        }
    }
}
