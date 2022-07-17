using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StudentSys
{
    public class StudentContext:DbContext
    {
        public StudentContext() : base("con")
        {
            Database.SetInitializer<DbContext>(null);//不采用默认的初始化方式
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();//关闭一对多
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();//关闭多对多
        }
        //将17张表注册到上下文中
        public DbSet<Student> Students { get; set; }    
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassTeacher> GetTeachers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> employeeTypes { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<StudentDoc> StudentDocs { get; set; }
        public DbSet<StudentGraduateInfo> StudentGraduateInfos { get; set; }
        public DbSet<StudentJob> StudentJobs { get; set; }
        public DbSet<StudentLabComplete> StudentLabs { get; set; }
        public DbSet<StudentRelative> StudentRelatives { get; set; }
        public DbSet<StudentSigned> StudentSIgneds { get; set; }
        public DbSet<StudentTalked> StudentTalkeds { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SysSetting> SysSettings { get; set; }

    }
}
