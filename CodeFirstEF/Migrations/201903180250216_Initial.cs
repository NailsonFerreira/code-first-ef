namespace CodeFirstEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        AlunoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Email = c.String(),
                        CursoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlunoID)
                .ForeignKey("dbo.Curso", t => t.CursoID, cascadeDelete: true)
                .Index(t => t.CursoID);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        CursoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        FaculdadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursoID)
                .ForeignKey("dbo.Faculdade", t => t.FaculdadeID, cascadeDelete: true)
                .Index(t => t.FaculdadeID);
            
            CreateTable(
                "dbo.Faculdade",
                c => new
                    {
                        FaculdadeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        Uf = c.String(),
                    })
                .PrimaryKey(t => t.FaculdadeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluno", "CursoID", "dbo.Curso");
            DropForeignKey("dbo.Curso", "FaculdadeID", "dbo.Faculdade");
            DropIndex("dbo.Curso", new[] { "FaculdadeID" });
            DropIndex("dbo.Aluno", new[] { "CursoID" });
            DropTable("dbo.Faculdade");
            DropTable("dbo.Curso");
            DropTable("dbo.Aluno");
        }
    }
}
