using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            XmlReader xmlReader = XmlReader.Create("http://localhost:8733/Design_Time_Addresses/WCFSyndicationService/Feed1/");
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
            foreach (SyndicationItem item in feed.Items)
            {
                richTextBox1.Text += item.Title.Text + "\n";
            }
        }
    }
}