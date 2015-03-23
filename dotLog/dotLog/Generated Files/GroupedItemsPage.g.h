﻿

#pragma once
//------------------------------------------------------------------------------
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//------------------------------------------------------------------------------

namespace Windows {
    namespace UI {
        namespace Xaml {
            namespace Data {
                ref class CollectionViewSource;
            }
        }
    }
}
namespace Windows {
    namespace UI {
        namespace Xaml {
            namespace Controls {
                ref class GridView;
                ref class Button;
                ref class TextBlock;
            }
        }
    }
}

namespace dotLog
{
    partial ref class GroupedItemsPage : public ::Windows::UI::Xaml::Controls::Page, 
        public ::Windows::UI::Xaml::Markup::IComponentConnector
    {
    public:
        void InitializeComponent();
        virtual void Connect(int connectionId, ::Platform::Object^ target);
    
    private:
        bool _contentLoaded;
    
        private: ::Windows::UI::Xaml::Data::CollectionViewSource^ groupedItemsViewSource;
        private: ::Windows::UI::Xaml::Controls::GridView^ itemGridView;
        private: ::Windows::UI::Xaml::Controls::Button^ backButton;
        private: ::Windows::UI::Xaml::Controls::TextBlock^ pageTitle;
    };
}

