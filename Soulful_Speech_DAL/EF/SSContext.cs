using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Soulful_Speech_Core.Entities;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_DAL
{
    public class SSContext : IdentityDbContext<User>
    {
        public SSContext(DbContextOptions<SSContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        //public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PersonalMessage> PersonalMessages { get; set; }
        public DbSet<UserRoomRole> UserRoomRoles { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<TagInRoom> TagsInRooms { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<User>().HasRequired(i => new { i.Login, i.Pass, i.Gender, i.Email });
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(iur => new { iur.RoleId, iur.UserId });

            //modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();
           // modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.UserMain)
                .WithMany(u => u.Friends)
                .HasForeignKey(p => p.UserMainId);
            modelBuilder.Entity<Friend>()
                .HasOne(f => f.UserSub)
                .WithMany()
                .HasForeignKey(p => p.UserMainId);

            modelBuilder.Entity<FriendRequest>()
                .HasOne(fr => fr.To)
                .WithMany(u => u.ToFriendRequests)
                .HasForeignKey(p => p.ToId);
            modelBuilder.Entity<FriendRequest>()
                .HasOne(fr => fr.From)
                .WithMany(u => u.FromFriendRequests)
                .HasForeignKey(p => p.FromId);

            modelBuilder.Entity<PersonalMessage>()
                .HasOne(pm => pm.From)
                .WithMany(u => u.FromPersonalMessages)
                .HasForeignKey(p => p.FromId);
            modelBuilder.Entity<PersonalMessage>()
                .HasOne(pm => pm.To)
                .WithMany(u => u.ToPersonalMessages)
                .HasForeignKey(p => p.ToId);


            //modelBuilder.Entity<FriendRequest>()
            //    .HasRequired(i => i.From)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<FriendRequest>()
            //    .HasRequired(i => i.To)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Friend>()
            //    .HasRequired(i => i.UserMain)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Friend>()
            //    .HasRequired(i => i.UserSub)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<PersonalMessage>()
            //    .HasRequired(i => i.From)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<PersonalMessage>()
            //    .HasRequired(i => i.To)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);


            //modelBuilder.Entity<Friend>()
            //    .HasRequired(c => c.UserSub)
            //    .WithMany(u => u.Friends)
            //    .HasForeignKey(c => c.UserSubId);

            //modelBuilder.Entity<PersonalMessage>()
            //   .HasRequired(c => c.To)
            //   .WithMany(u => u.ToPersonalMessages)
            //   .HasForeignKey(c => c.ToId);

            //modelBuilder.Entity<PersonalMessage>()
            //   .HasRequired(c => c.From)
            //   .WithMany(u => u.FromPersonalMessages)
            //   .HasForeignKey(c => c.FromId);

            //modelBuilder.Entity<FriendRequest>()
            //  .HasRequired(c => c.To)
            //  .WithMany(u => u.ToFriendRequests)
            //  .HasForeignKey(c => c.ToId);

            //modelBuilder.Entity<FriendRequest>()
            //   .HasRequired(c => c.From)
            //   .WithMany(u => u.FromFriendRequests)
            //   .HasForeignKey(c => c.FromId);

            //// modelBuilder.Entity<User>().Property(p => p.Login).IsRequired();

            //base.OnModelCreating(modelBuilder);
        }
    }
}
