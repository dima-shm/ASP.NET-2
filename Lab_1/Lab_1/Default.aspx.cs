using System;
using System.Text;
using System.IO;
using System.Net;
using System.Web.UI;

namespace Lab_1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://172.16.0.174:40751/Lab_1/.sda");
            rq.Method = "GET";
            HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();
            StreamReader rdk = new StreamReader(rs.GetResponseStream());
            Response.Write(rdk.ReadToEnd());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://172.16.0.174:40751/Lab_1/.sda");
            rq.Method = "POST";
            rq.ContentType = "application/x-www-form-urlencoded";
            string data = "result=" + TextBox1.Text.ToString();
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
            rq.ContentLength = dataStream.Length;
            Stream stream = rq.GetRequestStream();
            stream.Write(dataStream, 0, dataStream.Length);
            HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();
            StreamReader rdk = new StreamReader(rs.GetResponseStream());
            Response.Write(rdk.ReadToEnd());
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://172.16.0.174:40751/Lab_1/.sda");
            rq.Method = "PUT";
            rq.ContentType = "application/x-www-form-urlencoded";
            string data = "add=" + TextBox2.Text.ToString();
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
            rq.ContentLength = dataStream.Length;
            Stream stream = rq.GetRequestStream();
            stream.Write(dataStream, 0, dataStream.Length);
            HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();
            StreamReader rdk = new StreamReader(rs.GetResponseStream());
            Response.Write(rdk.ReadToEnd());
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://172.16.0.174:40751/Lab_1/.sda");
            rq.Method = "DELETE";
            HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();
            StreamReader rdk = new StreamReader(rs.GetResponseStream());
            Response.Write(rdk.ReadToEnd());
        }
    }
}