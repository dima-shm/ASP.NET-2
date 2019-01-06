using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;

namespace WCFSyndicationService
{
    [ServiceContract]
    [ServiceKnownType(typeof(Atom10FeedFormatter))]
    [ServiceKnownType(typeof(Rss20FeedFormatter))]
    public interface IFeed1
    {

        [OperationContract]
        [WebGet(UriTemplate = "*", BodyStyle = WebMessageBodyStyle.Bare)]
        SyndicationFeedFormatter CreateFeed();

        // TODO: Добавьте здесь операции служб
    }
}