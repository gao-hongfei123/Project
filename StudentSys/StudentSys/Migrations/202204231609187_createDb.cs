namespace StudentSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        IsGraduation = c.Boolean(nullable: false),
                        GradeId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GradeId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false),
                        PassWord = c.String(),
                        Phone = c.String(),
                        EmployeeTypeId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeTypes", t => t.EmployeeTypeId)
                .Index(t => t.EmployeeTypeId);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClassId = c.Guid(nullable: false),
                        ExamTime = c.DateTime(nullable: false),
                        SubjectId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.ClassId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        GradeId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GradeId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.ClassTeachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                        ClassId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubjectId = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        ExamScore = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Sex = c.String(nullable: false),
                        BornTime = c.DateTime(nullable: false),
                        Phone = c.String(),
                        QQ = c.String(),
                        Email = c.String(),
                        ImagePath = c.String(),
                        ClassId = c.Guid(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.StudentDocs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        Content = c.String(),
                        ImagePath = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentGraduateInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        InTime = c.DateTime(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Position = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentJobs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        studentId = c.Guid(nullable: false),
                        ClassId = c.Guid(nullable: false),
                        Time = c.DateTime(nullable: false),
                        State = c.String(),
                        Achievement = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Students", t => t.studentId)
                .Index(t => t.studentId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.StudentLabCompletes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        studentId = c.Guid(nullable: false),
                        ClassId = c.Guid(nullable: false),
                        Time = c.DateTime(nullable: false),
                        CompletePercent = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Students", t => t.studentId)
                .Index(t => t.studentId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.StudentRelatives",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        TypeName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentSIgneds",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        studentId = c.Guid(nullable: false),
                        ClassId = c.Guid(nullable: false),
                        InTime = c.DateTime(),
                        OutTime = c.DateTime(),
                        SignedType = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Students", t => t.studentId)
                .Index(t => t.studentId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.StudentTalkeds",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        studentId = c.Guid(nullable: false),
                        ClassId = c.Guid(nullable: false),
                        Content = c.String(),
                        IsDone = c.Boolean(nullable: false),
                        Result = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Students", t => t.studentId)
                .Index(t => t.studentId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.SysSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        JobScore = c.Int(nullable: false),
                        CompleteScore = c.Int(nullable: false),
                        ExamScore = c.Int(nullable: false),
                        TrigerScore = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentTalkeds", "studentId", "dbo.Students");
            DropForeignKey("dbo.StudentTalkeds", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.StudentSIgneds", "studentId", "dbo.Students");
            DropForeignKey("dbo.StudentSIgneds", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.StudentRelatives", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentLabCompletes", "studentId", "dbo.Students");
            DropForeignKey("dbo.StudentLabCompletes", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.StudentJobs", "studentId", "dbo.Students");
            DropForeignKey("dbo.StudentJobs", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.StudentGraduateInfoes", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentDocs", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Scores", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Scores", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.ClassTeachers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ClassTeachers", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Exams", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Exams", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Employees", "EmployeeTypeId", "dbo.EmployeeTypes");
            DropForeignKey("dbo.Classes", "GradeId", "dbo.Grades");
            DropIndex("dbo.StudentTalkeds", new[] { "ClassId" });
            DropIndex("dbo.StudentTalkeds", new[] { "studentId" });
            DropIndex("dbo.StudentSIgneds", new[] { "ClassId" });
            DropIndex("dbo.StudentSIgneds", new[] { "studentId" });
            DropIndex("dbo.StudentRelatives", new[] { "StudentId" });
            DropIndex("dbo.StudentLabCompletes", new[] { "ClassId" });
            DropIndex("dbo.StudentLabCompletes", new[] { "studentId" });
            DropIndex("dbo.StudentJobs", new[] { "ClassId" });
            DropIndex("dbo.StudentJobs", new[] { "studentId" });
            DropIndex("dbo.StudentGraduateInfoes", new[] { "StudentId" });
            DropIndex("dbo.StudentDocs", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropIndex("dbo.Scores", new[] { "StudentId" });
            DropIndex("dbo.Scores", new[] { "SubjectId" });
            DropIndex("dbo.ClassTeachers", new[] { "ClassId" });
            DropIndex("dbo.ClassTeachers", new[] { "EmployeeId" });
            DropIndex("dbo.Subjects", new[] { "GradeId" });
            DropIndex("dbo.Exams", new[] { "SubjectId" });
            DropIndex("dbo.Exams", new[] { "ClassId" });
            DropIndex("dbo.Employees", new[] { "EmployeeTypeId" });
            DropIndex("dbo.Classes", new[] { "GradeId" });
            DropTable("dbo.SysSettings");
            DropTable("dbo.StudentTalkeds");
            DropTable("dbo.StudentSIgneds");
            DropTable("dbo.StudentRelatives");
            DropTable("dbo.StudentLabCompletes");
            DropTable("dbo.StudentJobs");
            DropTable("dbo.StudentGraduateInfoes");
            DropTable("dbo.StudentDocs");
            DropTable("dbo.Students");
            DropTable("dbo.Scores");
            DropTable("dbo.ClassTeachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Exams");
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
            DropTable("dbo.Grades");
            DropTable("dbo.Classes");
        }
    }
}
