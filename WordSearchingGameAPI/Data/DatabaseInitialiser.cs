using Microsoft.EntityFrameworkCore;
using WordSearchingGameAPI.Models;

namespace WordSearchingGameAPI.Data
{

    public interface IDatabaseInitialiser
    {
        Task InitialiseAsync();
        Task SeedAsync();
        Task TrySeedAsync();
    }
    public class DatabaseInitialiser : IDatabaseInitialiser
    {
        private readonly WordSearchingGameContext _context;

        public DatabaseInitialiser(WordSearchingGameContext context)
        {
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                // Migration Database - Create database if it does not exist
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task TrySeedAsync()
        {
            if(_context.Difficulties.Any() && _context.Topics.Any() && _context.Users.Any() && _context.Words.Any() && _context.Levels.Any())
            {
                return;
            }
            var difficulties = new List<Difficulty>
            {
                new Difficulty { DifficultyLevel = "Easy" },
                new Difficulty { DifficultyLevel = "Medium" },
                new Difficulty { DifficultyLevel = "Hard" }
            };

            var topics = new List<Topic>
            {
                new Topic { TopicName = "Animals" },
                new Topic { TopicName = "Food" },
                new Topic { TopicName = "Sport" },
                new Topic { TopicName = "Hobbies" },
                new Topic { TopicName = "Work" },
                new Topic { TopicName = "Countries" }
            };

            var users = new List<User>
            {
                new User { Username = "thinhnt1702", PasswordHash = "superpasswordsecure", Email = "thinhnt17@gmail.com"}
            };

            var levels = new List<Level>
            {
                   new Level { TopicId = 1, DifficultyId = 1, LevelNumber = 1 },
                   new Level { TopicId = 1, DifficultyId = 1, LevelNumber = 2 },
                   new Level { TopicId = 1, DifficultyId = 1, LevelNumber = 3 },
                   new Level { TopicId = 1, DifficultyId = 1, LevelNumber = 4 },
                   new Level { TopicId = 1, DifficultyId = 1, LevelNumber = 5 },
                   new Level { TopicId = 1, DifficultyId = 1, LevelNumber = 6 },
                   new Level { TopicId = 1, DifficultyId = 1, LevelNumber = 7 },
                   new Level { TopicId = 1, DifficultyId = 1, LevelNumber = 8 },
                   new Level { TopicId = 1, DifficultyId = 1, LevelNumber = 9 },
                   new Level { TopicId = 1, DifficultyId = 1, LevelNumber = 10 },
                   new Level { TopicId = 1, DifficultyId = 2, LevelNumber = 1 },
                   new Level { TopicId = 1, DifficultyId = 2, LevelNumber = 2 },
                   new Level { TopicId = 1, DifficultyId = 2, LevelNumber = 3 },
                   new Level { TopicId = 1, DifficultyId = 2, LevelNumber = 4 },
                   new Level { TopicId = 1, DifficultyId = 2, LevelNumber = 5 },
                   new Level { TopicId = 1, DifficultyId = 2, LevelNumber = 6 },
                   new Level { TopicId = 1, DifficultyId = 2, LevelNumber = 7 },
                   new Level { TopicId = 1, DifficultyId = 2, LevelNumber = 8 },
                   new Level { TopicId = 1, DifficultyId = 2, LevelNumber = 9 },
                   new Level { TopicId = 1, DifficultyId = 2, LevelNumber = 10 },
                   new Level { TopicId = 1, DifficultyId = 3, LevelNumber = 1 },
                   new Level { TopicId = 1, DifficultyId = 3, LevelNumber = 2 },
                   new Level { TopicId = 1, DifficultyId = 3, LevelNumber = 3 },
                   new Level { TopicId = 1, DifficultyId = 3, LevelNumber = 4 },
                   new Level { TopicId = 1, DifficultyId = 3, LevelNumber = 5 },
                   new Level { TopicId = 1, DifficultyId = 3, LevelNumber = 6 },
                   new Level { TopicId = 1, DifficultyId = 3, LevelNumber = 7 },
                   new Level { TopicId = 1, DifficultyId = 3, LevelNumber = 8 },
                   new Level { TopicId = 1, DifficultyId = 3, LevelNumber = 9 },
                   new Level { TopicId = 1, DifficultyId = 3, LevelNumber = 10 },

                   new Level { TopicId = 2, DifficultyId = 1, LevelNumber = 1 },
                   new Level { TopicId = 2, DifficultyId = 1, LevelNumber = 2 },
                   new Level { TopicId = 2, DifficultyId = 1, LevelNumber = 3 },
                   new Level { TopicId = 2, DifficultyId = 1, LevelNumber = 4 },
                   new Level { TopicId = 2, DifficultyId = 1, LevelNumber = 5 },
                   new Level { TopicId = 2, DifficultyId = 1, LevelNumber = 6 },
                   new Level { TopicId = 2, DifficultyId = 1, LevelNumber = 7 },
                   new Level { TopicId = 2, DifficultyId = 1, LevelNumber = 8 },
                   new Level { TopicId = 2, DifficultyId = 1, LevelNumber = 9 },
                   new Level { TopicId = 2, DifficultyId = 1, LevelNumber = 10 },
                   new Level { TopicId = 2, DifficultyId = 2, LevelNumber = 1 },
                   new Level { TopicId = 2, DifficultyId = 2, LevelNumber = 2 },
                   new Level { TopicId = 2, DifficultyId = 2, LevelNumber = 3 },
                   new Level { TopicId = 2, DifficultyId = 2, LevelNumber = 4 },
                   new Level { TopicId = 2, DifficultyId = 2, LevelNumber = 5 },
                   new Level { TopicId = 2, DifficultyId = 2, LevelNumber = 6 },
                   new Level { TopicId = 2, DifficultyId = 2, LevelNumber = 7 },
                   new Level { TopicId = 2, DifficultyId = 2, LevelNumber = 8 },
                   new Level { TopicId = 2, DifficultyId = 2, LevelNumber = 9 },
                   new Level { TopicId = 2, DifficultyId = 2, LevelNumber = 10 },
                   new Level { TopicId = 2, DifficultyId = 3, LevelNumber = 1 },
                   new Level { TopicId = 2, DifficultyId = 3, LevelNumber = 2 },
                   new Level { TopicId = 2, DifficultyId = 3, LevelNumber = 3 },
                   new Level { TopicId = 2, DifficultyId = 3, LevelNumber = 4 },
                   new Level { TopicId = 2, DifficultyId = 3, LevelNumber = 5 },
                   new Level { TopicId = 2, DifficultyId = 3, LevelNumber = 6 },
                   new Level { TopicId = 2, DifficultyId = 3, LevelNumber = 7 },
                   new Level { TopicId = 2, DifficultyId = 3, LevelNumber = 8 },
                   new Level { TopicId = 2, DifficultyId = 3, LevelNumber = 9 },
                   new Level { TopicId = 2, DifficultyId = 3, LevelNumber = 10 },


                   new Level { TopicId = 3, DifficultyId = 1, LevelNumber = 1 },
                   new Level { TopicId = 3, DifficultyId = 1, LevelNumber = 2 },
                   new Level { TopicId = 3, DifficultyId = 1, LevelNumber = 3 },
                   new Level { TopicId = 3, DifficultyId = 1, LevelNumber = 4 },
                   new Level { TopicId = 3, DifficultyId = 1, LevelNumber = 5 },
                   new Level { TopicId = 3, DifficultyId = 1, LevelNumber = 6 },
                   new Level { TopicId = 3, DifficultyId = 1, LevelNumber = 7 },
                   new Level { TopicId = 3, DifficultyId = 1, LevelNumber = 8 },
                   new Level { TopicId = 3, DifficultyId = 1, LevelNumber = 9 },
                   new Level { TopicId = 3, DifficultyId = 1, LevelNumber = 10 },
                   new Level { TopicId = 3, DifficultyId = 2, LevelNumber = 1 },
                   new Level { TopicId = 3, DifficultyId = 2, LevelNumber = 2 },
                   new Level { TopicId = 3, DifficultyId = 2, LevelNumber = 3 },
                   new Level { TopicId = 3, DifficultyId = 2, LevelNumber = 4 },
                   new Level { TopicId = 3, DifficultyId = 2, LevelNumber = 5 },
                   new Level { TopicId = 3, DifficultyId = 2, LevelNumber = 6 },
                   new Level { TopicId = 3, DifficultyId = 2, LevelNumber = 7 },
                   new Level { TopicId = 3, DifficultyId = 2, LevelNumber = 8 },
                   new Level { TopicId = 3, DifficultyId = 2, LevelNumber = 9 },
                   new Level { TopicId = 3, DifficultyId = 2, LevelNumber = 10 },
                   new Level { TopicId = 3, DifficultyId = 3, LevelNumber = 1 },
                   new Level { TopicId = 3, DifficultyId = 3, LevelNumber = 2 },
                   new Level { TopicId = 3, DifficultyId = 3, LevelNumber = 3 },
                   new Level { TopicId = 3, DifficultyId = 3, LevelNumber = 4 },
                   new Level { TopicId = 3, DifficultyId = 3, LevelNumber = 5 },
                   new Level { TopicId = 3, DifficultyId = 3, LevelNumber = 6 },
                   new Level { TopicId = 3, DifficultyId = 3, LevelNumber = 7 },
                   new Level { TopicId = 3, DifficultyId = 3, LevelNumber = 8 },
                   new Level { TopicId = 3, DifficultyId = 3, LevelNumber = 9 },
                   new Level { TopicId = 3, DifficultyId = 3, LevelNumber = 10 },


                   new Level { TopicId = 4, DifficultyId = 1, LevelNumber = 1 },
                   new Level { TopicId = 4, DifficultyId = 1, LevelNumber = 2 },
                   new Level { TopicId = 4, DifficultyId = 1, LevelNumber = 3 },
                   new Level { TopicId = 4, DifficultyId = 1, LevelNumber = 4 },
                   new Level { TopicId = 4, DifficultyId = 1, LevelNumber = 5 },
                   new Level { TopicId = 4, DifficultyId = 1, LevelNumber = 6 },
                   new Level { TopicId = 4, DifficultyId = 1, LevelNumber = 7 },
                   new Level { TopicId = 4, DifficultyId = 1, LevelNumber = 8 },
                   new Level { TopicId = 4, DifficultyId = 1, LevelNumber = 9 },
                   new Level { TopicId = 4, DifficultyId = 1, LevelNumber = 10 },
                   new Level { TopicId = 4, DifficultyId = 2, LevelNumber = 1 },
                   new Level { TopicId = 4, DifficultyId = 2, LevelNumber = 2 },
                   new Level { TopicId = 4, DifficultyId = 2, LevelNumber = 3 },
                   new Level { TopicId = 4, DifficultyId = 2, LevelNumber = 4 },
                   new Level { TopicId = 4, DifficultyId = 2, LevelNumber = 5 },
                   new Level { TopicId = 4, DifficultyId = 2, LevelNumber = 6 },
                   new Level { TopicId = 4, DifficultyId = 2, LevelNumber = 7 },
                   new Level { TopicId = 4, DifficultyId = 2, LevelNumber = 8 },
                   new Level { TopicId = 4, DifficultyId = 2, LevelNumber = 9 },
                   new Level { TopicId = 4, DifficultyId = 2, LevelNumber = 10 },
                   new Level { TopicId = 4, DifficultyId = 3, LevelNumber = 1 },
                   new Level { TopicId = 4, DifficultyId = 3, LevelNumber = 2 },
                   new Level { TopicId = 4, DifficultyId = 3, LevelNumber = 3 },
                   new Level { TopicId = 4, DifficultyId = 3, LevelNumber = 4 },
                   new Level { TopicId = 4, DifficultyId = 3, LevelNumber = 5 },
                   new Level { TopicId = 4, DifficultyId = 3, LevelNumber = 6 },
                   new Level { TopicId = 4, DifficultyId = 3, LevelNumber = 7 },
                   new Level { TopicId = 4, DifficultyId = 3, LevelNumber = 8 },
                   new Level { TopicId = 4, DifficultyId = 3, LevelNumber = 9 },
                   new Level { TopicId = 4, DifficultyId = 3, LevelNumber = 10 },
            };
            var words = new List<Word>
             {
                 //10
                 new Word { TopicId = 1, DifficultyId = 1, Word1 = "cat"},
                 new Word { TopicId = 1, DifficultyId = 1, Word1 = "dog"},
                 new Word { TopicId = 1, DifficultyId = 1, Word1 = "fish"},
                 new Word { TopicId = 1, DifficultyId = 1, Word1 = "bird"},
                 new Word { TopicId = 1, DifficultyId = 1, Word1 = "cow"},

                 //10
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "giraffe"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "lion"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "dolphin"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "shark"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "jaguar"},
                 //8
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "narwhal"},
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "wildebeest"},
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "falcon"},
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "cougar"},
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "skunk"},

                 //10
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "cake"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "rice"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "pho"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "noodles"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "egg"},

                 //11
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "pizza"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "burger"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "sushi"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "salad"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "pasta"},

                 //7
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "sorbet"},
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "toast"},
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "gyro"},
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "donut"},
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "grapes"},

                 //9
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Ball"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Golf"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Swim"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Dart"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Race"},

                 //10
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Soccer"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Tennis"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Hockey"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Boxing"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Rugby"},

                 //9
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Sprint"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Boxing"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Judo"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Futsal"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Wrestl"},

                 //10
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "Read"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "Draw"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "Swim"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "Cook"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "Hike"},

                 //10
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "Gaming"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "Sewing"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "Craft"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "Dance"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "Sketch"},

                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "Puzzle"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "Archery"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "Coding"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "Guitar"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "Quilts"},

                new Word { TopicId = 5, DifficultyId = 1, Word1 = "Email"},
                new Word { TopicId = 5, DifficultyId = 1, Word1 = "Plan"},
                new Word { TopicId = 5, DifficultyId = 1, Word1 = "Meet"},
                new Word { TopicId = 5, DifficultyId = 1, Word1 = "Task"},
                new Word { TopicId = 5, DifficultyId = 1, Word1 = "File"},

                new Word { TopicId = 5, DifficultyId = 2, Word1 = "Report"},
                new Word { TopicId = 5, DifficultyId = 2, Word1 = "Office"},
                new Word { TopicId = 5, DifficultyId = 2, Word1 = "Client"},
                new Word { TopicId = 5, DifficultyId = 2, Word1 = "Design"},
                new Word { TopicId = 5, DifficultyId = 2, Word1 = "Budget"},

                new Word { TopicId = 5, DifficultyId = 3, Word1 = "Manage"},
                new Word { TopicId = 5, DifficultyId = 3, Word1 = "Direct"},
                new Word { TopicId = 5, DifficultyId = 3, Word1 = "Assess"},
                new Word { TopicId = 5, DifficultyId = 3, Word1 = "Review"},
                new Word { TopicId = 5, DifficultyId = 3, Word1 = "Deploy"},

                new Word { TopicId = 6, DifficultyId = 1, Word1 = "Italy"},
                new Word { TopicId = 6, DifficultyId = 1, Word1 = "Japan"},
                new Word { TopicId = 6, DifficultyId = 1, Word1 = "India"},
                new Word { TopicId = 6, DifficultyId = 1, Word1 = "Chile"},
                new Word { TopicId = 6, DifficultyId = 1, Word1 = "Egypt"},

                new Word { TopicId = 6, DifficultyId = 2, Word1 = "France"},
                new Word { TopicId = 6, DifficultyId = 2, Word1 = "Canada"},
                new Word { TopicId = 6, DifficultyId = 2, Word1 = "Brazil"},
                new Word { TopicId = 6, DifficultyId = 2, Word1 = "Sweden"},
                new Word { TopicId = 6, DifficultyId = 2, Word1 = "Mexico"},

                new Word { TopicId = 6, DifficultyId = 3, Word1 = "Turkey"},
                new Word { TopicId = 6, DifficultyId = 3, Word1 = "Norway"},
                new Word { TopicId = 6, DifficultyId = 3, Word1 = "Cyprus"},
                new Word { TopicId = 6, DifficultyId = 3, Word1 = "Jordan"},
                new Word { TopicId = 6, DifficultyId = 3, Word1 = "Poland"}


            };











            //Add difficulties and topics to database
            await _context.Difficulties.AddRangeAsync(difficulties);
            await _context.Topics.AddRangeAsync(topics);
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();
            await _context.Levels.AddRangeAsync(levels);
            await _context.Words.AddRangeAsync(words);


            //Save changes
            await _context.SaveChangesAsync();
        }


    }
    public static class DatabaseInitialiserExtension
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            // Create IServiceScope to resolve service scope
            using var scope = app.Services.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitialiser>();

            await initializer.InitialiseAsync();

            // Try to seeding data
            await initializer.SeedAsync();
        }
    }
}
