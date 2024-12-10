
using lms.Domain;
using Microsoft.EntityFrameworkCore;

namespace lms.Data;

public class LmsDbContext : DbContext
{
    public LmsDbContext(DbContextOptions<LmsDbContext> options) : base(options) { }

    public DbSet<AssignmentModel> Assignments { get; set; }
    public DbSet<QuestionModel> Questions { get; set; }
    public DbSet<OptionModel> Options { get; set; }

    public DbSet<AssignmentAttemptModel> AssignmentAttempts { get; set; }
    public DbSet<QuestionAnswerModel> QuestionAnswers { get; set; }

    public DbSet<GradingModel> Grades { get; set; }

    public DbSet<TeacherModel> Teachers { get; set; }
    public DbSet<StudentModel> Students { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<StudentCourseModel> StudentCourses { get; set; }

    public DbSet<CourseModel> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignmentModel>()
            .HasMany(a => a.Questions)
            .WithOne()
            .HasForeignKey(q => q.AssignmentId);

        modelBuilder.Entity<QuestionModel>()
            .HasMany(q => q.Options)
            .WithOne()
            .HasForeignKey(o => o.QuestionId);

        modelBuilder.Entity<AssignmentModel>()
            .HasMany(a => a.AssignmentAttempts)
            .WithOne(a => a.Assignment)
            .HasForeignKey(a => a.AssignmentId);

        modelBuilder.Entity<AssignmentAttemptModel>()
            .HasMany(a => a.QuestionAnswers)
            .WithOne()
            .HasForeignKey(q => q.AssignmentAttemptId);

        modelBuilder.Entity<QuestionAnswerModel>();

        modelBuilder.Entity<StudentCourseModel>(entity =>
        {
            // Configuração da chave primária
            entity.HasKey(e => e.Id);

            // Configuração das propriedades
            entity.Property(e => e.EnrollmentDate)
                .IsRequired();

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.FinalGrade)
                .HasPrecision(5, 2); // Exemplo de precisão para notas

            entity.Property(e => e.CurrentScore)
                .HasPrecision(5, 2); // Exemplo de precisão para pontuação

            // Configuração de relacionamentos
            entity.HasOne<StudentModel>()
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne<CourseModel>()
                .WithMany()
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CourseModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            //entity.Property(e => e.Details).HasColumnType("text");
            //entity.Property(e => e.CreationDate).IsRequired().HasDefaultValueSql("GETDATE()");
            //entity.ToTable("Courses");
        });

        modelBuilder.Entity<StudentModel>()
            .HasOne(s => s.User)
            .WithOne(u => u.Student)
            .HasForeignKey<StudentModel>(s => s.Id)
            .OnDelete(DeleteBehavior.Cascade);


        //modelBuilder.Entity<StudentModel>(entity =>
        //{
        //    entity.HasKey(s => s.Id);
        //    entity.Property(s => s.EnrollmentDate)
        //          .IsRequired();

        //    entity.HasOne(s => s.User)
        //          .WithOne()
        //          .HasForeignKey<StudentModel>(s => s.Id)
        //          .IsRequired();
        //});

        modelBuilder.Entity<TeacherModel>(entity =>
        {
            entity.HasKey(s => s.Id);

            entity.HasOne(s => s.User)
                  .WithOne()
                  .HasForeignKey<TeacherModel>(s => s.Id)
                  .IsRequired();
        });

        // Configuração de UserModel
        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.FullName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(u => u.Email)
                  .IsRequired()
                  .HasMaxLength(150);
        });
    }
}
