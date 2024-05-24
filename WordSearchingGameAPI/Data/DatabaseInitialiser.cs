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
                new Topic { TopicName = "Places" },
                new Topic { TopicName = "Nature" }
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
                 new Word { TopicId = 1, DifficultyId = 1, Word1 = "chicken"},
                 new Word { TopicId = 1, DifficultyId = 1, Word1 = "horse"},
                 new Word { TopicId = 1, DifficultyId = 1, Word1 = "pig"},
                 new Word { TopicId = 1, DifficultyId = 1, Word1 = "elephant"},
                 new Word { TopicId = 1, DifficultyId = 1, Word1 = "mouse"},

                 //10
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "giraffe"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "lion"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "dolphin"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "shark"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "jaguar"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "owl"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "goose"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "gecko"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "squirrel"},
                 new Word { TopicId = 1, DifficultyId = 2, Word1 = "otter"},
                 //8
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "narwhal"},
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "wildebeest"},
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "falcon"},
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "cougar"},
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "skunk"},
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "mongoose"},
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "rhinoceros"},
                 new Word { TopicId = 1, DifficultyId = 3, Word1 = "pelican"},

                 //10
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "cake"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "rice"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "pho"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "noodles"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "egg"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "milk"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "pasta"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "fish"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "meat"},
                 new Word { TopicId = 2, DifficultyId = 1, Word1 = "vegetables"},
                 //11
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "pizza"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "hamburger"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "sushi"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "salad"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "fried"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "chicken"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "spaghetti"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "bread"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "yogurt"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "fruit"},
                 new Word { TopicId = 2, DifficultyId = 2, Word1 = "seafood"},
                 //7
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "tiramisu"},
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "lasagna"},
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "sashimi"},
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "ratatouille"},
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "macarons"},
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "steak"},
                 new Word { TopicId = 2, DifficultyId = 3, Word1 = "lobster"},

                 //9
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Hanoi"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Saigon"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Tokyo"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Paris"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "London"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Rome"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Seoul"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Beijing"},
                 new Word { TopicId = 3, DifficultyId = 1, Word1 = "Bangkok"},

                 //10
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Sydney"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Moscow"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Dubai"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Istanbul"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Rio"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Cairo"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Toronto"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Madrid"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Amsterdam"},
                 new Word { TopicId = 3, DifficultyId = 2, Word1 = "Venice"},

                 //9
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Reykjavik"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Johannesburg"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Montevideo"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Casablanca"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Ulaanbaatar"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Ljubljana"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Bratislava"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Vilnius"},
                 new Word { TopicId = 3, DifficultyId = 3, Word1 = "Yangon"},

                 //10
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "mountain"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "river"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "sea"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "forest"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "lake"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "desert"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "rain"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "snow"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "tree"},
                 new Word { TopicId = 4, DifficultyId = 1, Word1 = "grass"},

                 //10
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "swamp"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "waterfall"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "beach"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "bay"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "plain"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "peninsula"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "rainforest"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "volcano"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "ocean"},
                 new Word { TopicId = 4, DifficultyId = 2, Word1 = "hill"},

                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "biodiversity"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "photosynthesis"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "ecosystem"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "symbiosis"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "conservation"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "deforestation"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "habitat"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "sustainability"},
                 new Word { TopicId = 4, DifficultyId = 3, Word1 = "bioluminescence"},

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
