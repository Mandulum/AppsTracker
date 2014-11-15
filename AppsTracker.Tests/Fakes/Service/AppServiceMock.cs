﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppsTracker.DAL.Service;
using AppsTracker.Models.EntityModels;

namespace AppsTracker.Tests.Fakes.Service
{
    public class AppsServiceMock : IAppsService
    {
        public Models.EntityModels.Log CreateNewLog(string windowTitle, int usageID, int userID, Models.Proxy.IAppInfo appInfo, out bool newApp)
        {
            newApp = false;
            return new Models.EntityModels.Log();
        }

        public Models.EntityModels.Uzer InitUzer(string userName)
        {
            return new Models.EntityModels.Uzer() { Name = userName };
        }

        public Models.EntityModels.Usage InitLogin(int userId)
        {
            return new Models.EntityModels.Usage() { UserID = userId };
        }

        public IEnumerable<T> GetFiltered<T>(System.Linq.Expressions.Expression<Func<T, bool>> filter) where T : class
        {
            return new List<T>();
        }

        public IEnumerable<T> GetFiltered<T>(System.Linq.Expressions.Expression<Func<T, bool>> filter, params System.Linq.Expressions.Expression<Func<T, object>>[] navigations) where T : class
        {
            return new List<T>();
        }

        public IQueryable<T> GetQueryable<T>() where T : class
        {
            return new List<T>().AsQueryable();
        }

        public T GetSingle<T>(System.Linq.Expressions.Expression<Func<T, bool>> filter) where T : class
        {
            T item = Activator.CreateInstance<T>();
            return item;
        }

        public T GetSingle<T>(System.Linq.Expressions.Expression<Func<T, bool>> filter, params System.Linq.Expressions.Expression<Func<T, object>>[] navigations) where T : class
        {
            T item = Activator.CreateInstance<T>();
            return item;
        }

        public void Add<T>(T item) where T : class
        {
            //do nothing
        }

        public DateTime GetStartDate(int userID)
        {
            return DateTime.Now.AddDays(-10);
        }

        public IList<AppsToBlock> AddToBlockedList(List<Aplication> apps, string username, int userID)
        {
            return new List<AppsToBlock>();
        }
    }
}