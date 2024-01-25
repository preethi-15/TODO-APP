using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Todo.Data;
using Todo.Models;
using Xamarin.Forms;
using static SQLite.SQLite3;

namespace Todo.Views
{
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
        }

        List<TodoItem> FinalList = new List<TodoItem>();
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            TodoItemDatabase database = await TodoItemDatabase.Instance;
            var encryptlist = await database.GetItemsAsync();
            foreach (var item in encryptlist)
            {
                string decryptData = EncryptAndDecrypt.DecryptString("b14ca5898a4e4133bbce2ea2315a1916", item.Info);
                TodoItem TodoData = JsonConvert.DeserializeObject<TodoItem>(decryptData);
                TodoData.ID = item.ID;
                FinalList.Add(TodoData);
            }
            // listView.ItemsSource = await database.GetItemsAsync();
            listView.ItemsSource= FinalList;
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }
}
