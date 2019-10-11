using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SINGIT.Models;
using SQLite;
namespace SINGIT.Data
{
    public class SingItDataBase
    {
        readonly SQLiteAsyncConnection database;
        
        public SingItDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<RegisterModel>().Wait();
            //database.CreateTableAsync<FavoriteSongsModel>().Wait();

        }

        public Task<List<RegisterModel>> GetUserAsync()
        {
            return database.Table<RegisterModel>().ToListAsync();
        }
        public Task<List<RegisterModel>> GetUserNotDoneAsync()
        {
            return database.QueryAsync<RegisterModel>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<RegisterModel> GetUserAsync(string username, string password)
        {
            return database.Table<RegisterModel>().Where(i => i.UserName == username && i.Password== password).FirstOrDefaultAsync();
             
        }
      
        public Task<int> InsertUserAsync(RegisterModel user)
        {
            
                return database.InsertAsync(user);
            
        }

        public Task<int> DeleteItemAsync(RegisterModel item)
        {
            return database.DeleteAsync(item);
        }
        
        
    }
}
