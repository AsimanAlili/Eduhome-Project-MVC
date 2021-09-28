using Eduhome.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTag> CourseTags { get; set; }
        public DbSet<CourseReview> CourseReviews { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventTag> EventTags { get; set; }
        public DbSet<EventTeacher> EventTeachers { get; set; }
        public DbSet<EventReview> EventReviews { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactReview> ContactReviews { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
