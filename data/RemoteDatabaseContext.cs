using System.Data.Common;
using data.DAO;
using Microsoft.EntityFrameworkCore;

namespace data;

public class RemoteDatabaseContext: DbContext
{
    public DbSet<GroupDao> Groups { get; set; }
    public DbSet<PresenceDao> Presences { get; set; }
    public DbSet<StudentDao> Students { get; set; }
    public DbSet<SubjectDao> Subjects { get; set; }
    public DbSet<TypeAttendanceDao> TypeAttendances { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=123;Database=postgres");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupDao>().HasKey(group => group.Id);
        modelBuilder.Entity<GroupDao>().Property(group => group.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<StudentDao>().HasKey(student => student.Guid);
        modelBuilder.Entity<StudentDao>().Property(student => student.Guid).ValueGeneratedOnAdd();
        modelBuilder.Entity<SubjectDao>().HasKey(subject => subject.Id);
        modelBuilder.Entity<SubjectDao>().Property(subject => subject.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<TypeAttendanceDao>().HasKey(typeAttendance => typeAttendance.Id);
        modelBuilder.Entity<TypeAttendanceDao>().Property(typeAttendance => typeAttendance.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<PresenceDao>().HasKey(presence =>
            new { 
                presence.Date, 
                presence.LessonNumber, 
                presence.StudentGuid,
                presence.SubjectId
            });
    }
}