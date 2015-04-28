using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Windows.Globalization.DateTimeFormatting;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DOTlogAPP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class addEvent : Page
    {
        eventList eventsStored = new eventList();

        public addEvent()
        {
            this.InitializeComponent();
            populateCategory();
            populateAirport();
        }

        private async void populateCategory()
        {
            categoryList syncedCategories = await XmlReadWriteUniversal.XmlIO.ReadObjectFromXmlFileAsync<categoryList>("userCategories.xml");
            foreach(category i in syncedCategories.CATEGORIES)
            {
                categoryField.Items.Add(i.CATEGORY_TITLE);
            }
        }

        private async void populateAirport()
        {
            airportList syncedAirports = await XmlReadWriteUniversal.XmlIO.ReadObjectFromXmlFileAsync<airportList>("userAirports.xml");
            foreach(airport i in syncedAirports.AIRPORTS)
            {
                airportField.Items.Add(i.FAA_CODE);
            }           
        }

        private string dateTime()
        {
            string dateAndTimeOfEvent = "";
            string space = " ";
            string seconds = ":00";
            string date = dateField.Date.ToString(@"yyyy-MM-dd");
            string time =  timeField.Time.ToString();
            //dateAndTimeOfEvent += seconds;
            dateAndTimeOfEvent += date += space += time;
            return dateAndTimeOfEvent;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            eventList eventsStored = new eventList();
            eventType newEvent = new eventType( (string)airportField.SelectedItem,
                                                (string)categoryField.SelectedItem,
                                                (bool)includeField.IsChecked,
                                                (string)dateTime(),
                                                (string)summaryField.Text);
            eventsStored = await XmlReadWriteUniversal.XmlIO.ReadObjectFromXmlFileAsync<eventList>("eventList.xml");
            eventsStored.EVENTS.Add(newEvent);
            await XmlReadWriteUniversal.XmlIO.SaveObjectToXml(eventsStored, "eventList.xml");
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
