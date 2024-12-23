using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<AuthorData> AuthorDatas { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=Lesson11;Username=postgres;Password=1");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new AuthorConf());
        modelBuilder.ApplyConfiguration(new AuthorDataConf());
        modelBuilder.ApplyConfiguration(new BookConf());
        modelBuilder.ApplyConfiguration(new GenreConf());
    }
}