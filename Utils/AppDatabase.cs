using GameTournament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameTournament.Utils
{
    public class AppDatabase
    {
        private static AppDatabase appDatabase;
        public static AppDatabase getInstence()
        {
            if (appDatabase == null)
                appDatabase = new AppDatabase();
            return appDatabase;
        }
        public DatabaseContext getDatabase()
        {
            var db = new DatabaseContext();
            return db;
        }
    }
}