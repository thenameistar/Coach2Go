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
            foreach (var (title, imagePath, duration, category, requiredEquipment) in sessionTemplate)
            {
                if (type == "Bodyweight" && requiredEquipment != "Bodyweight")
                    continue;
                var session = new WorkoutSession
                {
                    Title = title,
                    Week = 1,
                    Day = daysOfWeek[index++],
                    Category = category,
                    ImagePath = imagePath,
                    Duration = duration,
                    TargetMuscles = GetTargetMusclesByCategory(category),
                    Level = experience,
                    Equipment = requiredEquipment, 
                    Type = type,
                    Exercises = new List<Exercise>()

                };

                if (ExerciseTemplates.TryGetValue(category, out var exerciseList))
                {
                    foreach (var (name, details, image, _) in exerciseList.Take(5))
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

        private static List<(string Title, string ImagePath, int Duration, string Category, string Equipment)> FallbackSessionTemplate()
        {
            return new()
            {
                ("General Day 1", "images/default1.jpg", 30, "General", "BodyWeight"),
                ("General Day 2", "images/default2.jpg", 30, "General", "Bodyweight"),
                ("General Day 3", "images/default3.jpg", 30, "General", "Bodyweight"),
                ("General Day 4", "images/default4.jpg", 30, "General", "Bodyweight"),
                ("General Day 5", "images/default5.jpg", 30, "General", "Bodyweight"),
                ("General Day 6", "images/default6.jpg", 30, "General"," Bodyweight"),
                ("General Day 7", "images/default7.jpg", 30, "General", "Bodyweight")
            };
        }

        private static readonly Dictionary<string, List<(string Title, string ImagePath, int Duration, string Category, string Equipment)>> SessionTemplates = new()
        {

            ["Lose Weight"] = new()
            {
                ("Full Body", "images/workout1.jpg", 30, "Explosive Power", "Bodyweight"),
                ("Cardio & Core", "images/cardiocore.jpg", 30, "Core Stability", "Bodyweight"),
                ("Active Recovery", "images/activerecovery1.jpg", 20, "Mobility / Recovery", "Bodyweight"),
                ("Lower Body", "images/lowerbody.jpg", 25, "Strength - Lower", "Bodyweight"),
                ("HIIT", "images/hiit.jpg", 30, "Explosive Power", "Bodyweight"),
                ("Yoga", "images/yoga.jpg", 20, "Mobility / Recovery", "Bodyweight"),
                ("Full-Body Blast", "images/fullbodyblast.jpg", 25, "Explosive Power", "Bodyweight")
            },
            ["Build Muscle"] = new()
            {
                ("Push Day", "images/pushday.jpg", 40, "Strength - Push", "Gym"),
                ("Pull Day", "images/pullday.jpg", 40, "Strength - Pull", "Gym"),
                ("Leg Day", "images/legday.jpg", 40, "Strength - Lower", "Gym"),
                ("Upper Body Hypertrophy", "images/upper_hypertrophy.jpg", 45, "Strength - Push", "Gym"),
                ("Lower Body Hypertrophy", "images/lower_hypertrophy.jpg", 45, "Strength - Lower", "Gym"),
                ("Core & Conditioning", "images/core_conditioning.jpg", 30, "Core Stability", "Bodyweight"),
                ("Mobility & Stretch", "images/mobility_stretch.jpg", 30, "Mobility / Recovery", "Bodyweight")
            },
            ["General Fitness"] = new()
            {
                ("Full Body Fundamentals", "images/general_fullbody.jpg", 30, "General", "Bodyweight"),
                ("Core Stability", "images/core_stability.jpg", 25, "Core Stability", "Bodyweight"),
                ("Balance & Mobility", "images/balance_mobility.jpg", 20, "Mobility / Recovery", "Bodyweight"),
                ("Bodyweight Flow", "images/bodyweight_flow.jpg", 30, "General", "Bodyweight"),
                ("Core Burnout", "images/core_burnout.jpg", 25, "Core Stability", "Bodyweight"),
                ("Stretch & Recovery", "images/stretch_recovery.jpg", 20, "Mobility / Recovery", "Bodyweight"),
                ("Active Walk", "images/active_recovery.jpg", 20, "Mobility / Recovery", "Bodyweight")
            },
            ["Strength"] = new()
            {
                ("Upper Strength", "images/upperstrength.jpg", 40, "Strength - Push", "Gym"),
                ("Lower Strength", "images/lowerstrength.jpg", 40, "Strength - Lower", "Gym"),
                ("Cardio Intervals", "images/cardio_intervals.jpg", 30, "Explosive Power", "Bodyweight"),
                ("Push Day", "images/pushday.jpg", 45, "Strength - Push", "Gym"),
                ("Pull Day", "images/pullday.jpg", 45, "Strength - Pull", "Gym"),
                ("Mobility & Core", "images/mobility_core.jpg", 25, "Core Stability", "Bodyweight"),
                ("Active Recovery", "images/stretching.jpg", 20, "Mobility / Recovery", "Bodyweight")
            }
        };

        private static readonly Dictionary<string, List<(string Name, string Details, string ImagePath, string Equipment)>> ExerciseTemplates = new()
        {

            ["Explosive Power"] = new()
            {
                ("Squat Jumps", "3 x 10", "images/squat_jumps.png", "Bodyweight"),
                ("Medicine Ball Slam", "3 x 12", "images/ball_slam.png", "Medicine Ball"),
                ("Broad Jumps", "3 x 8", "images/broad_jumps.png", "Bodyweight"),
                ("Plyo Push Ups", "3 x 10", "images/plyo_pushups.png", "Bodyweight"),
                ("Overhead Throw", "3 x 10", "images/overhead_throw.png", "Medicine Ball")
            },
            ["Ballistic"] = new()
            {
                ("Back Squat Jumps", "3 x 8", "images/squat_jump_barbell.png", "Barbell"),
                ("Bench Press Throw", "3 x 8", "images/bench_press_throw.png", "Barbell"),
                ("Rotational Throw", "3 x 10", "images/rotational_throw.png", "Medicine Ball"),
                ("Jump Lunges", "3 x 10", "images/jump_lunges.png", "Bodyweight"),
                ("Explosive Step Ups", "3 x 8", "images/explosive_stepups.png", "Bodyweight")
            },
            ["Strength - Push"] = new()
            {
                ("Push Ups", "3 x 12", "images/pushup.png", "Bodyweight"),
                ("Bench Press", "3 x 10", "images/bench_press.png", "Barbell"),
                ("Overhead Press", "3 x 10", "images/overhead_press.png", "Barbell"),
                ("Incline Push Ups", "3 x 15", "images/incline_pushups.png", "Bodyweight"),
                ("Dumbbell Shoulder Press", "3 x 10", "images/shoulder_press.png", "Dumbbells")
            },

            ["Strength - Pull"] = new()

            {
                ("Dumbbell Row", "3 x 10", "images/dumbbell_row.png", "Dumbbells"),
                ("Band Rows", "3 x 12", "images/band_rows.png", "Resistance Band"),
                ("Inverted Rows", "3 x 8", "images/inverted_rows.png", "Bodyweight"),
                ("Lat Pulldown", "3 x 10", "images/lat_pulldown.png", "Gym Machine"),
                ("Bicep Curl", "3 x 12", "images/bicep_curl.png", "Dumbbells")
            },
            ["Strength - Lower"] = new()
            {
                ("Squats", "3 x 12", "images/squat.png", "Bodyweight"),
                ("Deadlifts", "3 x 8", "images/deadlift.png", "Barbell"),
                ("Lunges", "3 x 10", "images/lunges.png", "Bodyweight"),
                ("Leg Press", "3 x 10", "images/leg_press.png", "Gym Machine"),
                ("Glute Bridges", "3 x 15", "images/glutebridges.png", "Bodyweight")
            },
            ["Core Stability"] = new()
            {
                ("Plank", "3 x 1 min", "images/plank.png", "Bodyweight"),
                ("Russian Twists", "3 x 20", "images/russian_twists.png", "Bodyweight"),
                ("Leg Raises", "3 x 15", "images/leg_raises.png", "Bodyweight"),
                ("Bicycle Crunches", "3 x 20", "images/bicycle_crunches.png", "Bodyweight"),
                ("Side Plank", "3 x 30 sec each", "images/side_plank.png", "Bodyweight")
            },
            ["Mobility / Recovery"] = new()
            {
                ("Cat-Cow", "5 rounds", "images/cat_cow.png", "Bodyweight"),
                ("Downward Dog", "1 min", "images/downward_dog.png", "Bodyweight"),
                ("Hip Circles", "3 x 10", "images/hip_circles.png", "Bodyweight"),
                ("Spinal Twists", "3 x 30 secs", "images/spinal_twist.png", "Bodyweight"),
                ("Breathing", "3 mins", "images/breathing.png", "Bodyweight")
            },
            ["General"] = new()
            {
                ("Bodyweight Squats", "3 x 15", "images/bodyweight_squats.png", "Bodyweight"),
                ("Jumping Jacks", "3 x 30 secs", "images/jumping_jacks.png", "Bodyweight"),
                ("Push Ups", "3 x 12", "images/pushup.png", "Bodyweight"),
                ("Glute Bridges", "3 x 15", "images/glutebridges.png", "Bodyweight"),
                ("Superman Hold", "3 x 30 secs", "images/superman.png", "Bodyweight")
            }

        };

        public static List<WorkoutSession> GenerateFilteredSessions(string goal, string type, int time, string equipment, string experience)
        {

            if (!SessionTemplates.TryGetValue(goal, out var sessionTemplate))
                sessionTemplate = FallbackSessionTemplate();
            return sessionTemplate
                .Where(s => true)
                .Select((s, index) => new WorkoutSession
                {
                    Title = s.Title,
                    ImagePath = s.ImagePath,
                    Duration = s.Duration,
                    Category = s.Category,
                    TargetMuscles = GetTargetMusclesByCategory(s.Category),
                    Level = experience,
                    Equipment = equipment,
                    Type = type,
                    Goal = goal,
                    Day = $"Day {index + 1}",
                    Week = 1,
                    Exercises = ExerciseTemplates.TryGetValue(s.Category, out var exercises)
                        ? exercises
                            .Where(e => equipment == "Bodyweight" || e.Equipment == equipment)
                            .Take(5)
                            .Select(e => new Exercise
                            {
                                Name = e.Name,
                                Details = e.Details,
                                ImagePath = e.ImagePath
                            }).ToList()
                        : new List<Exercise>()
                })
                .ToList();
        }
                
        


    } 
}