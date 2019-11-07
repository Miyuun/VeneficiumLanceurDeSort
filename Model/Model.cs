using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    public static class Model
    {
        static string html = string.Empty;
        static string url = @"http://www.veneficium.org";
        static string option = @"/memberlist?mode=lastvisit&order=DESC&submit=Ok&username=";
        static WebClient client = new WebClient();
        private static HttpClient httpClient = new HttpClient();
        static IEnumerable<Cookie> responseCookies = null;
        private static Hashtable Critic = null;
        private static Hashtable BadCritic = null;
        private static float critpercent = 0;
        private static float total = 0;

        public static async Task<CharacterSheet> requestAsync(string name)
        {
            string Name = name.Replace(" ", "+");
            string totalUrl = join(Name);

            if (responseCookies == null)
                await connectAsync();

            // Search user
            string html = HttpGet(totalUrl);

            // Get user sheet
            var document = new HtmlDocument();
            document.LoadHtml(html);


            if (document.GetElementbyId("i_icon_mini_login") != null)
            {
                await connectAsync();
                CharacterSheet sheet = await requestAsync(name);
                return sheet;
            }

            if (document.GetElementbyId("LMBER") == null)
            {
                return new CharacterSheet("Pas de fiche trouvée", 0, 0);
            }

            string link = url + document.GetElementbyId("LMBER").FirstChild.Elements("div").ToArray()[0].FirstChild.GetAttributeValue("href", "default");
            Console.WriteLine(link);
            html = HttpGet(link);
            document = new HtmlDocument();
            document.LoadHtml(html);

            string characterName = document.DocumentNode.SelectSingleNode("//div[contains(@class, 'namePFIL')]/span/strong").InnerHtml;

            if (document.DocumentNode.SelectSingleNode("//div[contains(@class, 'rpg_fields')]") != null)
            {
                string magic = document.DocumentNode.SelectSingleNode("//div[contains(@class, 'rpg_fields')]/span[contains(@class, 'gensmall')]").InnerHtml;
                magic = magic.Substring(magic.IndexOf("(") + 1, magic.IndexOf("/") - 1);
                string volonte = document.DocumentNode.SelectNodes("//div[contains(@class, 'rpg_fields')]/span[contains(@class, 'gensmall')]")[1].InnerHtml;
                volonte = volonte.Substring(volonte.IndexOf("(") + 1, volonte.IndexOf("/") - 1);
                return new CharacterSheet(characterName, Int32.Parse(magic), Int32.Parse(volonte));
            }
            else
            {
                return new CharacterSheet("Pas de fiche trouvée", 0, 0);
            }
        }

        public static bool isCrit(int roll, int willPower)
        {
            if(willPower >=10)
                willPower = Model.round(willPower);
            if (Critic == null)
            {
                Critic = new Hashtable();
                Critic.Add(5, 5);
                Critic.Add(10, 6);
                Critic.Add(20, 8);
                Critic.Add(30, 10);
                Critic.Add(40, 12);
                Critic.Add(50, 14);
                Critic.Add(60, 16);
                Critic.Add(70, 18);
                Critic.Add(80, 20);
                Critic.Add(90, 22);
                Critic.Add(100, 24);
                Critic.Add(110, 26);
                Critic.Add(120, 28);
                Critic.Add(130, 30);
                Critic.Add(140, 32);
                Critic.Add(150, 33);
            }
            int willPowerMax = 0;
            int criticPercent = 0;

            foreach(DictionaryEntry de in Critic)
            {
                if (willPower >= (int)de.Key && (int)de.Key >= willPowerMax)
                {
                    willPowerMax = (int)de.Key;
                    criticPercent = (int)de.Value;
                }
            }

            int criticLevel = 100 - criticPercent;
            total++;
            if (roll >= criticLevel)
            {
                critpercent++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isBadCrit(int roll, int willPower)
        {
            if (willPower >= 10)
                willPower = Model.round(willPower);
            if (BadCritic == null)
            {
                BadCritic = new Hashtable();
                BadCritic.Add(5, 5);
                BadCritic.Add(10, 5);
                BadCritic.Add(20, 5);
                BadCritic.Add(30, 5);
                BadCritic.Add(40, 5);
                BadCritic.Add(50, 5);
                BadCritic.Add(60, 4);
                BadCritic.Add(70, 4);
                BadCritic.Add(80, 3);
                BadCritic.Add(90, 3);
                BadCritic.Add(100, 2);
                BadCritic.Add(110, 2);
                BadCritic.Add(120, 1);
                BadCritic.Add(130, 0);
                BadCritic.Add(140, 0);
                BadCritic.Add(150, 0);
            }

            int willPowerMax = 0;
            int criticPercent = 0;

            foreach (DictionaryEntry de in BadCritic)
            {
                if (willPower >= (int)de.Key && (int)de.Key >= willPowerMax)
                {
                    willPowerMax = (int)de.Key;
                    criticPercent = (int)de.Value;
                }
            }

            if (roll <= criticPercent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string join(string s)
        {
            return url + option + s;
        }

        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static int round(int toRound)
        {
            double temp = toRound / 10;
            temp = Math.Round(temp);
            toRound = ((int)temp * 10);
            return toRound;
        }

        public static async Task connectAsync()
        {
            var values = new Dictionary<string, string>
            {
               { "username", "Program" },
               { "password", "programvenef2018" },
               { "autologin", "on" },
               { "redirect", "" },
               { "query", "" },
               { "login", "Connexion" }
            };

            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            var content = new FormUrlEncodedContent(values);

            httpClient = new HttpClient(handler);
            HttpResponseMessage response = await httpClient.PostAsync("http://www.veneficium.org/login", content);

            var responseString = await response.Content.ReadAsStringAsync();
            Uri uri = new Uri("http://www.veneficium.org/");
            responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
            
        }

        public static string HttpGet(string URI)
        {

            // Add a user agent header in case the 
            // requested URI contains a query.

            client = new WebClient();

            string cookieString = "";
            foreach (Cookie cookie in responseCookies)
                cookieString += cookie.Name + "=" + cookie.Value + ";";

            client.Headers.Add("user-agent", "{'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36'}");
            client.Headers.Add(HttpRequestHeader.Cookie, cookieString);

            Stream data = client.OpenRead(URI);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
        }

    }

    public class GifImage
    {
        private Image gifImage;
        private FrameDimension dimension;
        private int frameCount;
        private int currentFrame = -1;
        private bool reverse;
        private int step = 1;

        public GifImage(string path)
        {
            gifImage = Image.FromFile(path); //initialize
            dimension = new FrameDimension(gifImage.FrameDimensionsList[0]); //gets the GUID
            frameCount = gifImage.GetFrameCount(dimension); //total frames in the animation
        }

        public bool ReverseAtEnd //whether the gif should play backwards when it reaches the end
        {
            get { return reverse; }
            set { reverse = value; }
        }

        public Image GetNextFrame()
        {

            currentFrame += step;

            //if the animation reaches a boundary...
            if (currentFrame >= frameCount || currentFrame < 1)
            {
                if (reverse)
                {
                    step *= -1; //...reverse the count
                    currentFrame += step; //apply it
                }
                else
                    currentFrame = 0; //...or start over
            }
            return GetFrame(currentFrame);
        }

        public Image GetFrame(int index)
        {
            gifImage.SelectActiveFrame(dimension, index); //find the frame
            return (Image)gifImage.Clone(); //return a copy of it
        }
    }

}
