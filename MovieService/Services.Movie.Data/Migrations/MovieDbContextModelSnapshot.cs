using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Services.Movie.Data.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);
            modelBuilder.Entity("Services.Movie.Model.MovieModel", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<Guid>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("uuid");

                b.Property<DateTime>("CreateDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime?>("UpdateDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Name")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Movies");
            });

            #region Notes
            modelBuilder.Entity("Services.Movie.Model.MovieNoteModel", b =>
            {
                b.Property<Guid>("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnType("uuid");

                b.Property<Guid>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("uuid");

                b.Property<DateTime>("CreateDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime?>("UpdateDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Note")
                    .HasColumnType("text");

                b.Property<int>("UserId")
                    .HasColumnType("integer");

                b.HasKey("Id");

                b.HasIndex("MovieId");

                b.ToTable("MovieNotes");
            });

            modelBuilder.Entity("Services.Movie.Model.MovieNoteModel", b =>
            {
                b.HasOne("Services.Movie.Model.Movie", "Movie")
                    .WithMany("MovieNotes")
                    .HasForeignKey("MovieId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Movie");
            });

            modelBuilder.Entity("Services.Movie.Model.Movie", b =>
            {
                b.Navigation("MovieNotes");
            });
            #endregion Notes

            modelBuilder.Entity("Services.Movie.Model.MovieModel", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<Guid>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("uuid");

                b.Property<DateTime>("CreateDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime?>("UpdateDate")
                    .HasColumnType("timestamp with time zone");

                b.HasKey("Id");

                b.ToTable("Movies");
            });

            #region Ranks
            modelBuilder.Entity("Services.Movie.Model.MovieRankModel", b =>
            {
                b.Property<Guid>("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnType("uuid");

                b.Property<Guid>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("uuid");

                b.Property<DateTime>("CreateDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime?>("UpdateDate")
                    .HasColumnType("timestamp with time zone");

                b.Property<short>("Rank")
                    .HasColumnType("smallint");

                b.Property<int>("UserId")
                    .HasColumnType("integer");

                b.HasKey("Id");

                b.HasIndex("MovieId");

                b.ToTable("MovieRanks");
            });

            modelBuilder.Entity("Services.Movie.Model.MovieRankModel", b =>
            {
                b.HasOne("Services.Movie.Model.Movie", "Movie")
                    .WithMany("MovieRanks")
                    .HasForeignKey("MovieId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Movie");
            });

            modelBuilder.Entity("Services.Movie.Model.Movie", b =>
            {
                b.Navigation("MovieRanks");
            });
            #endregion Ranks
        }
    }
}
