using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SINGIT.Models;
using SQLite;

namespace SINGIT.Data
{
    public class SingItDatabase
    {
        readonly SQLiteAsyncConnection database;
        public SingItDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<RegisterModel>().Wait();
        }

        public Task<List<RegisterModel>> GetUserAsync()
        {
            return database.Table<RegisterModel>().ToListAsync();
        }
        public Task<List<RegisterModel>> GetUserNotDoneAsync()
        {
            return database.QueryAsync<RegisterModel>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<RegisterModel> GetUserAsync(int id)
        {
            return database.Table<RegisterModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(RegisterModel item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(RegisterModel item)
        {
            return database.DeleteAsync(item);
        }
    }
}
