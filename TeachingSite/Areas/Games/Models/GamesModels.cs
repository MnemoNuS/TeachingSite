﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using TeachingSite.Areas.Questions.Models;

namespace TeachingSite.Areas.Games.Models
{


    public class GamesContext : DbContext
    {
        public GamesContext() : base("DBConnection") { }

		public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
    }

    public class Game
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Game name")]
        public string Name { get; set; }
        public int? TypeId { get; set; }
        [DisplayName("Game type")]
        public GameType Type { get; set; }
        public string Description { get; set; }
        [DisplayName("List of questions")]
        public List<Question> Questions { get; set; }
    }

    public class GameType
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Game type")]
        public string Type { get; set; }
        public string Description { get; set; }
    }
        public class GameSet
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Game set")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Game set Description")]
        public string Description { get; set; }
        public ThemeSet ThemeSet { get; set; }
    }

}