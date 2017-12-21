namespace TourMe.Model.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TMEntities : DbContext
    {
        public TMEntities()
            : base("name=TMEntities")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleKind> ArticleKinds { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventKind> EventKinds { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ImageKind> ImageKinds { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<PlaceKind> PlaceKinds { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TripBook> TripBooks { get; set; }
        public virtual DbSet<TripBookHasPlace> TripBookHasPlaces { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleKind>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.ArticleKind)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.UserGroupId)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.RoleId)
                .IsUnicode(false);

            modelBuilder.Entity<PlaceKind>()
                .HasMany(e => e.Places)
                .WithRequired(e => e.PlaceKind)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.GroupId)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Places)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();
        }
    }
}
