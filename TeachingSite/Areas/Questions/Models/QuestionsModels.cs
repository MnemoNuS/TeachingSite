using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TeachingSite.Areas.Questions.Models
{

    public class QuestionsContext : DbContext
    {
        public QuestionsContext() : base("DefaultConnection") { }
        public DbSet<GrammaQuestion> GrammaQuestions { get; set; }
        public DbSet<LexicQuestion> LexicQuestions { get; set; }
        public DbSet<LexicType> LexicTypes { get; set; }
        public DbSet<GrammaCategory> GrammaCategories { get; set; }
        public DbSet<EslLevel> EslLevels { get; set; }
    }

    public class Question
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Question")]
        public string Body { get; set; }
        [DisplayName("Answer")]
        public string Answer { get; set; }
        public int? TypeId { get; set; }
        [DisplayName("Question type")]
        public virtual string Type { get; set; }
        [DisplayName("Creation date")]
        public DateTime Date { get; set; }
    }

    public class GrammaQuestion : Question
    {
        public override string Type { get { return "GrammaQuestion"; } }
        public int? EslLevelId { get; set; }
        [DisplayName("Esl Level")]
        public EslLevel EslLevel { get; set; }
        public int? GramaCategoryId { get; set; }
        [DisplayName("Gramma category")]
        public GrammaCategory GrammaCategory { get; set; }
    }

    public class LexicQuestion : Question
    {
        public override string Type { get { return "LexicQuestion"; } }
        [DisplayName("Topic")]
        public string Topic { get; set; }
        public int? LexicTypeId { get; set; }
        [DisplayName("Lexic type")]
        public LexicType LexicType { get; set; }
    }

    public class QuestionProperty
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Question type")]
        public virtual string Type { get; set; }
    }

    public class LexicType : QuestionProperty
    {
        public override string Type { get { return "LexicType"; } }
    }

    public class EslLevel : QuestionProperty
    {
        public override string Type { get { return "EslLevel"; } }
    }

    public class GrammaCategory : QuestionProperty
    {
        public override string Type { get { return "GrammaCategory"; } }
    }

}


