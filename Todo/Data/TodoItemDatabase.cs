using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite;
using Todo.Models;

namespace Todo.Data
{
    public class TodoItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<TodoItemDatabase> Instance = new AsyncLazy<TodoItemDatabase>(async () =>
        {
            var instance = new TodoItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Encryptdata>();
            return instance;
        });

        public TodoItemDatabase()
        {
             Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            //var options = new SQLiteConnectionString(Constants.DatabasePath, true, "password", postKeyAction: c => {
            //    Console.WriteLine("DB Created--------------------", c);
            //    c.Execute("PRAGMA cipher_compatibility = 3"); });
            //Database = new SQLiteAsyncConnection(options);
        }

        public  Task<List<Encryptdata>> GetItemsAsync()
        {
            return Database.Table<Encryptdata>().ToListAsync();
          

        }



        public Task<int> SaveItemAsync(Encryptdata item)
        {
            Task<int> result = null;
           // Encryptdata listitem = new Encryptdata();

            try
            {
                if (item.ID != 0)

                {
                  
                    
                    result = Database.UpdateAsync(item);
                }
                else
                {
                  
                    result = Database.InsertAsync(item);
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;

        }

        public Task<int> DeleteItemAsync(int id)
        {
            Encryptdata encryptdata = new Encryptdata();
            encryptdata.ID = id;
            return Database.DeleteAsync<Encryptdata>(encryptdata.ID);
        }
    }
}

