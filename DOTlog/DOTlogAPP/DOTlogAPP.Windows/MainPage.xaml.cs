using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DOTlogAPP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            populateList();
        }

        private async void populateList()
        {
            eventList eventsStored = new eventList();
            eventsStored = await XmlReadWriteUniversal.XmlIO.ReadObjectFromXmlFileAsync<eventList>("eventList.xml");
            displayEvents.ItemsSource = eventsStored.EVENTS;
        }

        private async void syncButton_Click(object sender, RoutedEventArgs e)
        {
            //MemoryStream stream = new MemoryStream();
            //DataContractJsonSerializer serialer = new DataContractJsonSerializer(typeof(eventList));
            eventList eventsStored = new eventList();
            eventsStored = await XmlReadWriteUniversal.XmlIO.ReadObjectFromXmlFileAsync<eventList>("eventList.xml");
           /* serialer.WriteObject(stream, eventsStored);
            byte[] jsonArray = stream.ToArray();
            string jsonEventList = Encoding.UTF8.GetString(jsonArray, 0, jsonArray.Length);                      
            jsonString.Text = jsonEventList;
            */
            //var jsonEventList = new JavaScriptSerializer().Serialize(eventsStored);
            //jsonString.Text += jsonEventList;
            string jsonEventList;
            using(MemoryStream stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(eventList));
                serializer.WriteObject(stream, eventsStored);
                stream.Position = 0;
                using(StreamReader reader = new StreamReader(stream))
                {
                    jsonEventList = reader.ReadToEnd();
                }
            }
            //jsonString.Text = jsonEventList;
            var credential = new NetworkCredential("user1", "DOTlog1", "Http://dotlog.uafcsc.com/");
            var myCache = new CredentialCache();
            myCache.Add(new Uri("Http://dotlog.uafcsc.com/"), "NTLM", credential);
            var handler = new HttpClientHandler();
            handler.Credentials = myCache;
            try
            {
                var client = new HttpClient(handler);
                var eventsURI = new Uri("Http://dotlog.uafcsc.com/" + "dotlog/api/index.cfm/api/events");
                var httpContent = new StringContent(jsonEventList, Encoding.UTF8, "application/json");
                var message = await client.PutAsync(eventsURI, httpContent);
                //jsonString.Text += message.ToString();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        private void addEventButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(addEvent));
        }

        private void eventTabButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void accountSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(accountSettings));
        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            eventList eventsStored = new eventList();
            eventsStored = await XmlReadWriteUniversal.XmlIO.ReadObjectFromXmlFileAsync<eventList>("eventList.xml");
            eventsStored.EVENTS.RemoveAt(0);
            await XmlReadWriteUniversal.XmlIO.SaveObjectToXml(eventsStored, "eventList.xml");
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
