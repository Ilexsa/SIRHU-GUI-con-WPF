﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FontAwesome;
using FontAwesome.Sharp;
using MaterialDesignThemes.Wpf;

namespace SIRHU.ViewModel
{
    public class ItemMenu
    {
        
        public ItemMenu(string header, List<SubItem> subItems, PackIconKind icon) 
        {
           Header = header;
           SubItems = subItems;
           Icon = icon;
        }


        public string Header { get; private set; }

        public PackIconKind Icon { get; private set; }

        public List<SubItem> SubItems { get; private set; }

        public UserControl Screen { get; private set; }

    }
}
