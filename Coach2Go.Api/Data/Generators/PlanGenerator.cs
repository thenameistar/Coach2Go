using Coach2Go.Api.Models;

namespace Coach2Go.Api.Data.Generators
{
    public static class PlanGenerator
    {
        private static int sessionCounter = 1;
        private static int exerciseCounter = 1;

        public static WorkoutPlan GeneratePlan(string goal, string type, string experience)
        {
            var plan = new WorkoutPlan
            {
                Goal = goal,
                Type = type,
                Experience = experience,
                Duration = type == "Bodyweight" ? 30 : 40,
                Intensity = experience switch
                {
                    "Beginner" => "Low",
                    "Intermediate" => "Medium",
                    "Advanced" => "High",
                    _ => "Medium"
                },
                Sessions = new List<WorkoutSession>()
            };

            if (!SessionTemplates.TryGetValue(goal, out var sessionTemplate))
                sessionTemplate = FallbackSessionTemplate();

            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int index = 0;
            foreach (var (title, imagePath, duration, category) in sessionTemplate)
            {
                var session = new WorkoutSession
                {
                    Title = title,
                    Week = 1,
                    Day = daysOfWeek[index++],
                    Category = category,
                    ImagePath = imagePath,
                    Duration = duration,
                    Exercises = new List<Exercise>(),

                    TargetMuscles = GetTargetMusclesByCategory(category),
                    Level = experience,
                    Equipment = type,

                };

                if (ExerciseTemplates.TryGetValue(category, out var exerciseList))
                {
                    foreach (var (name, details, image) in exerciseList.Take(5))
                    {
                        session.Exercises.Add(new Exercise
                        {
                            Name = name,
                            Details = details,
                            ImagePath = image
                        });
                    }
                }

                session.WorkoutPlan = plan; 
                plan.Sessions.Add(session);
            }

            return plan;
        }

        private static string GetTargetMusclesByCategory(string category)
        {
            return category switch
            {
                "Explosive Power" => "Chest, Glutes, Core",
                "Strength - Push" => "Chest, Shoulders, Triceps",
                "Strength - Pull" => "Back, Biceps",
                "Strength - Lower" => "Legs, Glutes",
                "Core Stability" => "Abs, Obliques",
                "Mobility / Recovery" => "Full Body",
                "General" => "Full Body",
                _ => "Full Body"
            };
        }

        private static List<(string Title, string ImagePath, int Duration, string Category)> FallbackSessionTemplate()
        {
            return new()
            {
                ("General Day 1", "images/default1.jpg", 30, "General"),
                ("General Day 2", "images/default2.jpg", 30, "General"),
                ("General Day 3", "images/default3.jpg", 30, "General"),
                ("General Day 4", "images/default4.jpg", 30, "General"),
                ("General Day 5", "images/default5.jpg", 30, "General"),
                ("General Day 6", "images/default6.jpg", 30, "General"),
                ("General Day 7", "images/default7.jpg", 30, "General")
            };
        }

        private static readonly Dictionary<string, List<(string Title, string ImagePath, int Duration, string Category)>> SessionTemplates = new()
        {
            ["Lose Weight"] = new()
            {
                ("Full Body", "images/workout1.jpg", 30, "Explosive Power"),
                ("Cardio & Core", "images/cardiocore.jpg", 30, "Core Stability"),
                ("Active Recovery", "images/activerecovery1.jpg", 20, "Mobility / Recovery"),
                ("Lower Body", "images/lowerbody.jpg", 25, "Strength - Lower"),
                ("HIIT", "images/hiit.jpg", 30, "Explosive Power"),
                ("Yoga", "images/yoga.jpg", 20, "Mobility / Recovery"),
                ("Full-Body Blast", "images/fullbodyblast.jpg", 25, "Explosive Power")
            },
            ["Build Muscle"] = new()
            {
                ("Push Day", "images/pushday.jpg", 40, "Strength - Push"),
                ("Pull Day", "images/pullday.jpg", 40, "Strength - Pull"),
                ("Leg Day", "images/legday.jpg", 40, "Strength - Lower"),
                ("Upper Body Hypertrophy", "images/upper_hypertrophy.jpg", 45, "Strength - Push"),
                ("Lower Body Hypertrophy", "images/lower_hypertrophy.jpg", 45, "Strength - Lower"),
                ("Core & Conditioning", "images/core_conditioning.jpg", 30, "Core Stability"),
                ("Mobility & Stretch", "images/mobility_stretch.jpg", 30, "Mobility / Recovery")
            },
            ["General Fitness"] = new()
            {
                ("Full Body Fundamentals", "images/general_fullbody.jpg", 30, "General"),
                ("Core Stability", "images/core_stability.jpg", 25, "Core Stability"),
                ("Balance & Mobility", "images/balance_mobility.jpg", 20, "Mobility / Recovery"),
                ("Bodyweight Flow", "images/bodyweight_flow.jpg", 30, "General"),
                ("Core Burnout", "images/core_burnout.jpg", 25, "Core Stability"),
                ("Stretch & Recovery", "images/stretch_recovery.jpg", 20, "Mobility / Recovery"),
                ("Active Walk", "images/active_recovery.jpg", 20, "Mobility / Recovery")
            },
            ["Strength"] = new()
            {
                ("Upper Strength", "images/upperstrength.jpg", 40, "Strength - Push"),
                ("Lower Strength", "images/lowerstrength.jpg", 40, "Strength - Lower"),
                ("Cardio Intervals", "images/cardio_intervals.jpg", 30, "Explosive Power"),
                ("Push Day", "images/pushday.jpg", 45, "Strength - Push"),
                ("Pull Day", "images/pullday.jpg", 45, "Strength - Pull"),
                ("Mobility & Core", "images/mobility_core.jpg", 25, "Core Stability"),
                ("Active Recovery", "images/stretching.jpg", 20, "Mobility / Recovery")
            }
        };

        private static readonly Dictionary<string, List<(string Name, string Details, string ImagePath)>> ExerciseTemplates = new()
        {
            ["Explosive Power"] = new()
            {
                ("Squat Jumps", "3 x 10", "images/squat_jumps.png"),
                ("Medicine Ball Slam", "3 x 12", "images/ball_slam.png"),
                ("Broad Jumps", "3 x 8", "images/broad_jumps.png"),
                ("Plyo Push Ups", "3 x 10", "images/plyo_pushups.png"),
                ("Overhead Throw", "3 x 10", "images/overhead_throw.png")
            },
            ["Ballistic"] = new()
            {
                ("Back Squat Jumps", "3 x 8", "images/squat_jump_barbell.png"),
                ("Bench Press Throw", "3 x 8", "images/bench_press_throw.png"),
                ("Rotational Throw", "3 x 10", "images/rotational_throw.png"),
                ("Jump Lunges", "3 x 10", "images/jump_lunges.png"),
                ("Explosive Step Ups", "3 x 8", "images/explosive_stepups.png")
            },
            ["Strength - Push"] = new()
            {
                ("Push Ups", "3 x 12", "images/pushup.png"),
                ("Bench Press", "3 x 10", "images/bench_press.png"),
                ("Overhead Press", "3 x 10", "images/overhead_press.png"),
                ("Incline Push Ups", "3 x 15", "images/incline_pushups.png"),
                ("Dumbbell Shoulder Press", "3 x 10", "images/shoulder_press.png")
            },
            ["Strength - Pull"] = new()
            {
                ("Dumbbell Row", "3 x 10", "images/dumbbell_row.png"),
                ("Band Rows", "3 x 12", "images/band_rows.png"),
                ("Inverted Rows", "3 x 8", "images/inverted_rows.png"),
                ("Lat Pulldown", "3 x 10", "images/lat_pulldown.png"),
                ("Bicep Curl", "3 x 12", "images/bicep_curl.png")
            },
            ["Strength - Lower"] = new()
            {
                ("Squats", "3 x 12", "images/squat.png"),
                ("Deadlifts", "3 x 8", "images/deadlift.png"),
                ("Lunges", "3 x 10", "images/lunges.png"),
                ("Leg Press", "3 x 10", "images/leg_press.png"),
                ("Glute Bridges", "3 x 15", "images/glutebridges.png")
            },
            ["Core Stability"] = new()
            {
                ("Plank", "3 x 1 min", "images/plank.png"),
                ("Russian Twists", "3 x 20", "images/russian_twists.png"),
                ("Leg Raises", "3 x 15", "images/leg_raises.png"),
                ("Bicycle Crunches", "3 x 20", "images/bicycle_crunches.png"),
                ("Side Plank", "3 x 30 sec each", "images/side_plank.png")
            },
            ["Mobility / Recovery"] = new()
            {
                ("Cat-Cow", "5 rounds", "images/cat_cow.png"),
                ("Downward Dog", "1 min", "images/downward_dog.png"),
                ("Hip Circles", "3 x 10", "images/hip_circles.png"),
                ("Spinal Twists", "3 x 30 secs", "images/spinal_twist.png"),
                ("Breathing", "3 mins", "images/breathing.png")
            },
            ["General"] = new()
            {
                ("Bodyweight Squats", "3 x 15", "images/bodyweight_squats.png"),
                ("Jumping Jacks", "3 x 30 secs", "images/jumping_jacks.png"),
                ("Push Ups", "3 x 12", "images/pushup.png"),
                ("Glute Bridges", "3 x 15", "images/glutebridges.png"),
                ("Superman Hold", "3 x 30 secs", "images/superman.png")
            }
        };
    }
}