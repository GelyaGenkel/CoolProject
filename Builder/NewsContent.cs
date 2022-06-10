using System;

namespace BuilderGenerator
{
    public class NewsContent
    {
        public string Header { get; protected set; }
        public string Title { get; protected set; }
        public string Date { get { if (date != DateTime.MinValue) return date.ToString(); else return ""; } }
        private DateTime date;


        private NewsContent() { }

        public static NewsBuilder Builder => new NewsBuilder();

        public class NewsBuilder
        {
            private NewsContent content = new NewsContent();
            internal NewsBuilder() { }

            public FinalBuilder GenerateNews(string NewsHeader, string NewsContent)
            {
                content.Header = NewsHeader;
                content.Title = NewsContent;
                return new FinalBuilder(content);
            }


        }

        public class FinalBuilder
        {
       
            private NewsContent content;
            internal FinalBuilder() { }

            public FinalBuilder(NewsContent newContent)
            {
                content = newContent;
            }

            public void AddDate(DateTime Date)
            {
                content.date = Date;
            }

            public NewsContent Build()
            {
                return content;
            }


        }
    }
}
