﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppsTracker.Models.ChartModels;
using AppsTracker.MVVM;
using AppsTracker.DAL.Service;

namespace AppsTracker.Pages.ViewModels
{
    internal sealed class Statistics_dailyAppUsageViewModel : ViewModelBase, ICommunicator
    {
        #region Fields

        private AsyncProperty<IEnumerable<DailyUsedAppsSeries>> _dailyUsedAppsList;

        private IChartService _service;

        #endregion

        #region Properties

        public override string Title
        {
            get
            {
                return "DAILY APP USAGE";
            }
        }

        public object SelectedItem
        {
            get;
            set;
        }

        public AsyncProperty<IEnumerable<DailyUsedAppsSeries>> DailyUsedAppsList
        {
            get
            {
                return _dailyUsedAppsList;
            }
        }


        public IMediator Mediator
        {
            get { return MVVM.Mediator.Instance; }
        }

        #endregion

        public Statistics_dailyAppUsageViewModel()
        {
            _service = ServiceFactory.Get<IChartService>();

            _dailyUsedAppsList = new AsyncProperty<IEnumerable<DailyUsedAppsSeries>>(GetContent, this);

            Mediator.Register(MediatorMessages.RefreshLogs, new Action(_dailyUsedAppsList.Reload));
        }

        private IEnumerable<DailyUsedAppsSeries> GetContent()
        {
            return _service.GetAppsUsageSeries(Globals.SelectedUserID, Globals.Date1, Globals.Date2);
        }        
    }
}