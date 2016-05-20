using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TeachingSite.Areas.Questions.Models
{

    public class QuestionsContext : DbContext
    {
        public QuestionsContext() :base("DefaultConnection"){ }
        public DbSet<GrammaQuestion> GrammaQuestions { get; set; }
        public DbSet<LexicQuestion> LexicQuestions { get; set; }
        public DbSet<LexicType> LexicTypes { get; set; }
        public DbSet<GrammaCategory> GrammaCategories { get; set; }
        public DbSet<QIcon> QIcons { get; set; }
        public DbSet<EslLevel> EslLevels { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string Answer { get; set; }
        public int? TypeId { get; set; }
        public QuestionType Type { get; set; }
        public DateTime Date { get; set; }

    }
    public class QuestionProperty
    {
        public int Id { get; set; }
        public virtual string Type { get; set; }
        public string Name { get; set; }
    }

    public class QuestionType : QuestionProperty
    {
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


    public class GrammaQuestion : Question
    {
        public int? EslLevelId { get; set; }
        public EslLevel EslLevel { get; set; }
        public int? GramaCategoryId { get; set; }
        public GrammaCategory GrammaCategory { get; set; }
    }

    public class LexicQuestion : Question
    {
        public string Topic { get; set; }
        public int? LexicTypeId { get; set; }
        public LexicType LexicType { get; set; }
    }



    public class QIcon
    {
        public int Id { get; set; }
        public string IconUrl { get; set; }
        public virtual List<Tag> Tags { get; set; }

    }

    public class QuestionsList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
    }

}
