using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Runtime.Serialization.Json;
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
    public sealed partial class accountSettings : Page
    {
        public accountSettings()
        {
            this.InitializeComponent();
        }

        private void eventTabButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void accountSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(accountSettings));
        }

        private void syncButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                syncCategories();
                syncAirports();
            }
            catch (HttpRequestException exception)
            {
                popupMessage.Text = exception.ToString();
                if (!standardPopup.IsOpen)
                {
                    standardPopup.IsOpen = true;
                }
            }
        }

        private async void syncCategories()
        {
            var credential = new NetworkCredential(usernameField.Text, passwordField.Text, urlField.Text);
            var myCache = new CredentialCache();
            myCache.Add(new Uri(urlField.Text), "NTLM", credential);
            var handler = new HttpClientHandler();
            handler.Credentials = myCache;
            var client = new HttpClient(handler);
            var categoryURI = new Uri(urlField.Text + "dotlog/api/index.cfm/api/categories");
            HttpResponseMessage response = await client.GetAsync(categoryURI);
            try
            {                
                Stream respStream = await client.GetStreamAsync(categoryURI);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(categoryList));
                categoryList syncedCategories = (categoryList)ser.ReadObject(respStream);
                await XmlReadWriteUniversal.XmlIO.SaveObjectToXml(syncedCategories, "userCategories.xml");
            }
            catch (HttpRequestException e)
            {
 
                popupMessage.Text = response.StatusCode.ToString();
                if (!standardPopup.IsOpen)
                {
                    standardPopup.IsOpen = true;
                }
            }
        }

        private async void syncAirports()
        {
            var credential = new NetworkCredential(usernameField.Text, passwordField.Text, urlField.Text);
            var myCache = new CredentialCache();
            myCache.Add(new Uri(urlField.Text), "NTLM", credential);
            var handler = new HttpClientHandler();
            handler.Credentials = myCache;
            var client = new HttpClient(handler);
            var airportURI = new Uri(urlField.Text + "dotlog/api/index.cfm/api/airports");
            HttpResponseMessage response = await client.GetAsync(airportURI);
            try
            {                
                Stream respStream = await client.GetStreamAsync(airportURI);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(airportList));
                airportList syncedAirports = (airportList)ser.ReadObject(respStream);
                await XmlReadWriteUniversal.XmlIO.SaveObjectToXml(syncedAirports, "userAirports.xml");
            }
            catch (HttpRequestException e)
            {

                popupMessage.Text = response.StatusCode.ToString();
                if (!standardPopup.IsOpen)
                {
                    standardPopup.IsOpen = true;
                }
               
            }
        }

        private void closePoput_Button(object sender, RoutedEventArgs e)
        {
            if (standardPopup.IsOpen) 
            { 
                standardPopup.IsOpen = false; 
            }
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            logoutPopupMessage.Text = "Logout? \n (Stored Events, Airports, \n Categories and login \n info will be deleted)";
            if (!logoutPopup.IsOpen)
            {
                logoutPopup.IsOpen = true;
            }
        }

        private void cancelLogoutPopup_Click(object sender, RoutedEventArgs e)
        {
            if (logoutPopup.IsOpen)
            {
                logoutPopup.IsOpen = false;
            }
        }

        private async void confirmLogoutPopup_Click(object sender, RoutedEventArgs e)
        {
            airportList syncedAirports = new airportList();
            categoryList syncedCategories = new categoryList();
            await XmlReadWriteUniversal.XmlIO.SaveObjectToXml(syncedAirports, "userAirports.xml");
            await XmlReadWriteUniversal.XmlIO.SaveObjectToXml(syncedCategories, "userCategories.xml");
            usernameField.Text = "";
            passwordField.Text = "";
            if (logoutPopup.IsOpen)
            {
                logoutPopup.IsOpen = false;
            }
        }


    }
}
