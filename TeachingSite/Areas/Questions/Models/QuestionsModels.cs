using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TeachingSite.Areas.Questions.Models
{

     class QuestionsContext : DbContext
    {
		public QuestionsContext() : base("DBConnection") { }

		public DbSet<Question> Questions { get; set; }
		public DbSet<GrammaQuestion> GrammaQuestions { get; set; }
        public DbSet<LexicQuestion> LexicQuestions { get; set; }
        public DbSet<LexicType> LexicTypes { get; set; }
        public DbSet<GrammaCategory> GrammaCategories { get; set; }
        public DbSet<EslLevel> EslLevels { get; set; }
        public DbSet<Theme> Themes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theme>().HasMany(c => c.Questions)
                .WithMany(s => s.Themes)
                .Map(t => t.MapLeftKey("ThemeId")
                .MapRightKey("QuestionId")
                .ToTable("ThemeQuestion"));
        }
    }

    public class Question
    {
        public int Id { get; set; }
        [DisplayName("Question")]
        public string Body { get; set; }
        [DisplayName("Answer")]
        public string Answer { get; set; }
        [DisplayName("Question type")]
        public virtual string Type { get; set; }
        [DisplayName("Creation date")]
        public DateTime ModifiedAt { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
        public Question()
        {
            Themes = new List<Theme>();
        }
    }
    [DisplayName("Grammatical")]
    public class GrammaQuestion : Question
    {
        public override string Type { get { return "Grammatical"; } }
        public int? EslLevelId { get; set; }
        [DisplayName("Esl Level")]
        public string EslLevel { get; set; }
        public int? GrammaCategoryId { get; set; }
        [DisplayName("Gramma category")]
        public string GrammaCategory { get; set; }
    }

	public class LexicQuestion : Question
    {
        public override string Type { get { return "Lexical"; } }
        [DisplayName("Topic")]
        public string Topic { get; set; }
        public int? LexicTypeId { get; set; }
        [DisplayName("Lexic type")]
        public LexicType LexicType { get; set; }
    }

    public class QuestionProperty
    {
        public int Id { get; set; }
        [DisplayName("Property type")]
        public virtual string Type { get; set; }
    }

	public class LexicType : QuestionProperty
    {
        public override string Type { get { return "LexicType"; } }
		[DisplayName("Lexic type")]
		public string LexicTypeName { get; set; }
	}

	public class EslLevel : QuestionProperty
    {
        public override string Type { get { return "EslLevel"; } }
		[DisplayName("Esl Level")]
		public string EslLevelName { get; set; }
	}

	public class GrammaCategory : QuestionProperty
    {
        public override string Type { get { return "GrammaCategory"; } }
		[DisplayName("Gramma category")]
		public string GrammaCategoryName { get; set; }
	}

    public class ThemeSet
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Theme set title")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Theme set Description")]
        public string Description { get; set; }
        public List<Theme> Themes { get; set; }

    }
    public class Theme
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Theme title")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Theme Description")]
        public string Description { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public Theme()
        {
            Questions = new List<Question>();
        }
    }

}


