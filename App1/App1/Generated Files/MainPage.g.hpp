﻿

//------------------------------------------------------------------------------
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//------------------------------------------------------------------------------
#include "pch.h"
#include "MainPage.xaml.h"




void ::App1::MainPage::InitializeComponent()
{
    if (_contentLoaded)
        return;

    _contentLoaded = true;

    // Call LoadComponent on ms-appx:///MainPage.xaml
    ::Windows::UI::Xaml::Application::LoadComponent(this, ref new ::Windows::Foundation::Uri(L"ms-appx:///MainPage.xaml"), ::Windows::UI::Xaml::Controls::Primitives::ComponentResourceLocation::Application);

    // Get the AppBarButton named 'EditEvents'
    EditEvents = safe_cast<::Windows::UI::Xaml::Controls::AppBarButton^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"EditEvents"));
    // Get the AppBarButton named 'SyncPage'
    SyncPage = safe_cast<::Windows::UI::Xaml::Controls::AppBarButton^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"SyncPage"));
    // Get the TextBlock named 'categoryLabel'
    categoryLabel = safe_cast<::Windows::UI::Xaml::Controls::TextBlock^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"categoryLabel"));
    // Get the TextBlock named 'airportLabel'
    airportLabel = safe_cast<::Windows::UI::Xaml::Controls::TextBlock^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"airportLabel"));
    // Get the ComboBox named 'categoryBox'
    categoryBox = safe_cast<::Windows::UI::Xaml::Controls::ComboBox^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"categoryBox"));
    // Get the ComboBox named 'airportBox'
    airportBox = safe_cast<::Windows::UI::Xaml::Controls::ComboBox^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"airportBox"));
    // Get the TextBlock named 'importantLabel'
    importantLabel = safe_cast<::Windows::UI::Xaml::Controls::TextBlock^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"importantLabel"));
    // Get the CheckBox named 'reportBox'
    reportBox = safe_cast<::Windows::UI::Xaml::Controls::CheckBox^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"reportBox"));
    // Get the TimePicker named 'timeBox'
    timeBox = safe_cast<::Windows::UI::Xaml::Controls::TimePicker^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"timeBox"));
    // Get the DatePicker named 'dateBox'
    dateBox = safe_cast<::Windows::UI::Xaml::Controls::DatePicker^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"dateBox"));
    // Get the TextBlock named 'timeLabel'
    timeLabel = safe_cast<::Windows::UI::Xaml::Controls::TextBlock^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"timeLabel"));
    // Get the TextBox named 'descriptionBox'
    descriptionBox = safe_cast<::Windows::UI::Xaml::Controls::TextBox^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"descriptionBox"));
    // Get the Button named 'submitButton'
    submitButton = safe_cast<::Windows::UI::Xaml::Controls::Button^>(static_cast<Windows::UI::Xaml::IFrameworkElement^>(this)->FindName(L"submitButton"));
}

void ::App1::MainPage::Connect(int connectionId, Platform::Object^ target)
{
    switch (connectionId)
    {
    case 1:
        (safe_cast<::Windows::UI::Xaml::Controls::Primitives::ButtonBase^>(target))->Click +=
            ref new ::Windows::UI::Xaml::RoutedEventHandler(this, (void (::App1::MainPage::*)(Platform::Object^, Windows::UI::Xaml::RoutedEventArgs^))&MainPage::EditEventsButton_Click);
        break;
    case 2:
        (safe_cast<::Windows::UI::Xaml::Controls::Primitives::ButtonBase^>(target))->Click +=
            ref new ::Windows::UI::Xaml::RoutedEventHandler(this, (void (::App1::MainPage::*)(Platform::Object^, Windows::UI::Xaml::RoutedEventArgs^))&MainPage::SyncPageButton_Click);
        break;
    }
    (void)connectionId; // Unused parameter
    (void)target; // Unused parameter
    _contentLoaded = true;
}

