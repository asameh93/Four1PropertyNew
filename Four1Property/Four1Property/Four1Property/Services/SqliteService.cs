using SQLite;
using System;
using System.Collections.Generic;

namespace Four1Property.Services
{
    public static class SqliteService
    {

        private static string dbPath = FileManagerService.GetFilePath("Four1Property.db3");
        private static object locker = new object();
        private static SQLiteConnection db;
        public static bool Insert<T>(ref T data) where T : class, new()
        {
            try
            {
                using (db = new SQLiteConnection(dbPath))
                {
                    db.CreateTable<T>();
                    if (db.Insert(data) != 0)
                        return true;
                }
                return false;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        public static bool InsertList<T>(ref List<T> data) where T : class, new()
        {
            try
            {
                using (db = new SQLite.SQLiteConnection(dbPath))
                {
                    db.CreateTable<T>(CreateFlags.AutoIncPK);
                    foreach (var item in data)
                    {
                        if (db.Insert(item) == 0)
                            return false;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        public static List<T> GetList<T>() where T : class, new()
        {
            try
            {
                using (db = new SQLite.SQLiteConnection(dbPath))
                {
                    List<T> CashedData = new List<T>();
                    CashedData = db.Table<T>().ToList();
                    return CashedData;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }
        public static T GetOneObject<T>() where T : class, new()
        {
            try
            {
                using (db = new SQLite.SQLiteConnection(dbPath))
                {
                    T CashedObject = new T();
                    CashedObject = db.Table<T>().FirstOrDefault();
                    return CashedObject;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }
        public static void DropTable<T>()
        {
            try
            {
                using (db = new SQLite.SQLiteConnection(dbPath))
                {
                    db.DropTable<T>();
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return;
            }
        }
        public static bool IsExists(string tableName)
        {
            try
            {
                using (db = new SQLite.SQLiteConnection(dbPath))
                {
                    var info = db.GetTableInfo(tableName);
                    if (info.Count == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
        public static List<T> GetListByFild<T>(string tableName, string whare) where T : class, new()
        {
            try
            {
                using (db = new SQLite.SQLiteConnection(dbPath))
                {
                    List<T> CashedData = new List<T>();
                    string q = "SELECT * FROM " + tableName + " where " + whare + " ;";
                    CashedData = db.Query<T>(q);
                    return CashedData;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }
        public static T GetDataByFild<T>(string tableName, string whare) where T : class, new()
        {
            try
            {
                using (db = new SQLite.SQLiteConnection(dbPath))
                {
                    T CashedData = new T();
                    string q = "SELECT * FROM " + tableName + " where " + whare + " ;";
                    CashedData = db.FindWithQuery<T>(q);
                    return CashedData;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }
        public static void Delete<T>(ref T data) where T : class, new()
        {
            try
            {
                using (db = new SQLite.SQLiteConnection(dbPath))
                {
                    db.Delete(data);
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return;
            }
        }
        public static void update<T>(ref T data) where T : class, new()
        {
            try
            {
                using (db = new SQLite.SQLiteConnection(dbPath))
                {
                    db.Update(data);
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return;
            }
        }
    }
}
