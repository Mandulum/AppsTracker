﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppsTracker.Widgets
{
    public class SortableGridViewColumn : GridViewColumn
    {
        public string SortPropertyName
        {
            get { return (string)GetValue(SortPropertyNameProperty); }
            set { SetValue(SortPropertyNameProperty, value); }
        }

        public static readonly DependencyProperty SortPropertyNameProperty =
            DependencyProperty.Register("SortPropertyName", typeof(string), typeof(SortableGridViewColumn), new UIPropertyMetadata(""));

        public bool IsDefaultSortColumn
        {
            get { return (bool)GetValue(IsDefaultSortColumnProperty); }
            set { SetValue(IsDefaultSortColumnProperty, value); }
        }

        public static readonly DependencyProperty IsDefaultSortColumnProperty =
            DependencyProperty.Register("IsDefaultSortColumn", typeof(bool), typeof(SortableGridViewColumn), new UIPropertyMetadata(false));      
        
    }
}
