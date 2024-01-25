using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using Todo.Data;
using Todo.Models;
using Xamarin.Forms;

namespace Todo.Views
{
    public partial class TodoItemPage : ContentPage
    {
        public TodoItemPage()
        {
            InitializeComponent();
            list = new ObservableCollection<TodoItem>();
           
        }

        public ObservableCollection<TodoItem> list { get; set; }
        Encryptdata listitem = new Encryptdata();
        async void OnSaveClicked(object sender, EventArgs e)
        {
           
            var todoItem = (TodoItem)BindingContext;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            listitem.ID=todoItem.ID;
            listitem.Info = EncryptAndDecrypt.EncryptString("b14ca5898a4e4133bbce2ea2315a1916", JsonConvert.SerializeObject(todoItem));
            await database.SaveItemAsync(listitem);
            await Navigation.PopAsync();
          
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.DeleteItemAsync(todoItem.ID);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
