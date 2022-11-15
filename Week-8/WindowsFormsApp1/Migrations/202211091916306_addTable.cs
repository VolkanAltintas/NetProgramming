namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urunlers", "kategori_KategoriID", c => c.Int());
            CreateIndex("dbo.Urunlers", "kategori_KategoriID");
            AddForeignKey("dbo.Urunlers", "kategori_KategoriID", "dbo.Kategoris", "KategoriID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Urunlers", "kategori_KategoriID", "dbo.Kategoris");
            DropIndex("dbo.Urunlers", new[] { "kategori_KategoriID" });
            DropColumn("dbo.Urunlers", "kategori_KategoriID");
        }
    }
}
