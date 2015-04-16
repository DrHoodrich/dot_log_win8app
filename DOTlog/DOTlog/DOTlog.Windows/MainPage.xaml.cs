using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using Windows.Globalization;
using Windows.Globalization.DateTimeFormatting;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DOTlog
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MemoryStream memoryStream = new MemoryStream();
        DataContractJsonSerializer serialer = new DataContractJsonSerializer(typeof(jsonClass));
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EditEvents));
        }

        private void SyncButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SyncEvents));
        }

        private string dateTime()
        {
            string dateAndTimeOfEvent;

            DateTimeFormatter dateFormatter = new DateTimeFormatter("shortdate");
            DateTimeFormatter timeFormatter = new DateTimeFormatter("shorttime");

            // We use a calendar to determine daylight savings time transition days
            Calendar calendar = new Calendar();
            calendar.ChangeClock("24HourClock");

            // The value of the selected time in a TimePicker is stored as a TimeSpan, so it is possible to add it directly to the value of the selected date
            DateTimeOffset selectedDate = this.dateField.Date;
            DateTimeOffset combinedValue = new DateTimeOffset(new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day) + this.timeField.Time);

            calendar.SetDateTime(combinedValue);

            dateAndTimeOfEvent = dateFormatter.Format(combinedValue) + " " + timeFormatter.Format(combinedValue);

            return dateAndTimeOfEvent;
        }

        private async void jsonButton_Click(object sender, RoutedEventArgs e)
        {
            memoryStream = new MemoryStream();
            jsonClass eventObj = await XmlReadWriteUniversal.XmlIO.ReadObjectFromXmlFileAsync<jsonClass>("events.xml");
            serialer.WriteObject(memoryStream, eventObj);
            byte[] jsonArray = memoryStream.ToArray();
            memoryStream.Dispose();
            jsonResult.Text = Encoding.UTF8.GetString(jsonArray, 0, jsonArray.Length);
        }

        

        private async void submitButton_Click(object sender, RoutedEventArgs e)
        {
            jsonClass eventObj = new jsonClass((string)airportField.SelectedItem, (string)categoryField.SelectedItem, dateTime(), eventDescriptionField.Text, (bool)includeInReportField.IsChecked);
            await XmlReadWriteUniversal.XmlIO.SaveObjectToXml(eventObj, "events.xml");
        }
    }
}
