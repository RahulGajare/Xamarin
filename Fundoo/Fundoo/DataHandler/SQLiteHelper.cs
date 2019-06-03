using Fundoo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundoo.DataHandler
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Note>().Wait();
        }
    }
}
