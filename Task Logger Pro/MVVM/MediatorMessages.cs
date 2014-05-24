﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_Logger_Pro.MVVM
{
    public static class MediatorMessages
    {
        public const string FilterClearedMessage = "Clear Filter";
        public const string ApplicationAdded = "New Application added";
        public const string KeystrokeAdded = "New log with keystrokes added";
        public const string ScreenshotAdded = "New Screenshot added";
        public const string RefreshLogs = "Refresh logs";
        public const string AppsToBlockChanged = "Changing AppsToBlock";
        public const string FilterDatesChanged = "Filter dates";
    }
}