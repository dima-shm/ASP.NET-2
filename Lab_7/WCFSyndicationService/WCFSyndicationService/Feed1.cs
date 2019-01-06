using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using WCFSyndicationService.WSSDAServiceReference;

namespace WCFSyndicationService
{
    public class Feed1 : IFeed1
    {
        private WSSDAEntities entities;

        public Feed1()
        {
            entities = new WSSDAEntities(new Uri("http://localhost:50620/WcfDataService.svc/"));
        }

        public SyndicationFeedFormatter CreateFeed()
        {
            // Создать новый веб-канал.
            SyndicationFeed feed = new SyndicationFeed(
                title: "Feed Title", 
                description: "A WCF Syndication Feed", 
                feedAlternateLink: new Uri("http://localhost:8733/Design_Time_Addresses/WCFSyndicationService/Feed1/"),
                id: "id",
                lastUpdatedTime: new DateTimeOffset(DateTime.Now),
                items: GetNewsItems());

            // Возвращать канал ATOM или RSS, основываясь на строке запроса
            // RSS-&gt; http://localhost:8733/Design_Time_Addresses/WCFSyndicationService/Feed1/
            // Atom-&gt; http://localhost:8733/Design_Time_Addresses/WCFSyndicationService/Feed1/?format=atom
            string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            SyndicationFeedFormatter formatter = null;
            if (query == "atom")
            {
                formatter = new Atom10FeedFormatter(feed);
            }
            else
            {
                formatter = new Rss20FeedFormatter(feed);
            }

            return formatter;
        }

        private List<SyndicationItem> GetNewsItems()
        {
            List<SyndicationItem> items = new List<SyndicationItem>();
            foreach (var note in entities.Notes.AsEnumerable())
            {
                var student = (from p in entities.Students
                               where p.id == note.studentId
                               select p).First();
                items.Add(new SyndicationItem(
                    title: note.subject + " : " + note.note1,
                    content: student.name.ToString(),
                    itemAlternateLink: new Uri("http://localhost:50620/WcfDataService.svc/Notes(" + note.id + ")"),
                    id: student.id.ToString(),
                    lastUpdatedTime: DateTime.Now));
            }
            return items;
        }
    }
}
