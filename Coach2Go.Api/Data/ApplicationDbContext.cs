using Microsoft.EntityFrameworkCore;
using Coach2Go.Api.Models;
using Microsoft.AspNetCore.Components.Web;

namespace Coach2Go.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GymEquipment> GymEquipment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkoutPlan>()
                .HasOne(p => p.User)
                .WithMany(u => u.Plans)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        
            
            modelBuilder.Entity<GymEquipment>().HasData(
                new GymEquipment { Id = 1, GymName = "PureGym", EquipmentName = "Treadmill", ImageUrl = "images/treadmill.png" },
                new GymEquipment { Id = 2, GymName = "PureGym", EquipmentName = "Cross Trainer", ImageUrl = "images/cross_trainer.png" },
                new GymEquipment { Id = 3, GymName = "PureGym", EquipmentName = "Stair Climber", ImageUrl = "images/stair_climber.png" },
                new GymEquipment { Id = 4, GymName = "PureGym", EquipmentName = "Stepper", ImageUrl = "images/stepper.png" },
                new GymEquipment { Id = 5, GymName = "PureGym", EquipmentName = "Exercise Bike", ImageUrl = "images/exercise_bike.png" },
                new GymEquipment { Id = 6, GymName = "PureGym", EquipmentName = "Rowing Machine", ImageUrl = "images/rowing_machine.png" },

                new GymEquipment { Id = 7, GymName = "PureGym", EquipmentName = "Dumbbells", ImageUrl = "images/dumbbells.png" },
                new GymEquipment { Id = 8, GymName = "PureGym", EquipmentName = "Weight Bench", ImageUrl = "images/weight_bench.png" },
                new GymEquipment { Id = 9, GymName = "PureGym", EquipmentName = "Squat Rack", ImageUrl = "images/squat_rack.png" },
                new GymEquipment { Id = 10, GymName = "PureGym", EquipmentName = "Plate-Loaded Machine", ImageUrl = "images/plate_loaded.png" },

                new GymEquipment { Id = 11, GymName = "PureGym", EquipmentName = "Chest Press", ImageUrl = "images/chest_press.png" },
                new GymEquipment { Id = 12, GymName = "PureGym", EquipmentName = "Shoulder Press", ImageUrl = "images/shoulder_press.png" },
                new GymEquipment { Id = 13, GymName = "PureGym", EquipmentName = "Bicep Curl Machine", ImageUrl = "images/bicep_curl.png" },
                new GymEquipment { Id = 14, GymName = "PureGym", EquipmentName = "Lateral Pulldown Machine", ImageUrl = "images/lat_pulldown.png" },
                new GymEquipment { Id = 15, GymName = "PureGym", EquipmentName = "Leg Press", ImageUrl = "images/leg_press.png" },
                new GymEquipment { Id = 16, GymName = "PureGym", EquipmentName = "Ab Machine", ImageUrl = "images/ab_machine.png" },
                new GymEquipment { Id = 17, GymName = "PureGym", EquipmentName = "Multi-Gym Station", ImageUrl = "images/multigym.png" },
                new GymEquipment { Id = 18, GymName = "PureGym", EquipmentName = "Hip Abductor", ImageUrl = "images/hip_abductor.png" },

                new GymEquipment { Id = 19, GymName = "PureGym", EquipmentName = "Kettlebell", ImageUrl = "images/kettlebell.png" },
                new GymEquipment { Id = 20, GymName = "PureGym", EquipmentName = "Medicine Ball", ImageUrl = "images/medicine_ball.png" },
                new GymEquipment { Id = 21, GymName = "PureGym", EquipmentName = "Battle Ropes", ImageUrl = "images/battle_ropes.png" },
                new GymEquipment { Id = 22, GymName = "PureGym", EquipmentName = "TRX", ImageUrl = "images/trx.png" }
            );
            
        }
    }
}