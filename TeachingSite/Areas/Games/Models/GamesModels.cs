using System.Data.Entity;
using TeachingSite.Areas.Questions.Models;

namespace TeachingSite.Areas.Games.Models
{


    public class GamesContext : DbContext
    {
        public GamesContext() :base("DefaultConnection"){ }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public GameType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? QuestionsId { get; set; }
        public QuestionsList Questions { get; set;  }
    }

    public class GameType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}