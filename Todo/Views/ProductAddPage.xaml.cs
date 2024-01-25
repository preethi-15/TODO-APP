using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductAddPage : ContentPage
    {
        public int rate { get; set; }
        Productlist item = new Productlist();

        public static List<Productlist> productlst {get;set;}
        public ProductAddPage()
        {
            InitializeComponent();
            productlst = new List<Productlist>();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
           
                
            
        }

        public void Ontextchanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Price.Text))
            {
                rate = Convert.ToInt32(Quantity.Text) * Convert.ToInt32(Price.Text);
                Amount.Text = rate.ToString();
            }
            else
            {
                Amount.Text = string.Empty;
            }

        }
        public async void Addclicked(object sender,EventArgs e)
        {

            var product = new Productlist()
            {
                product = Product.Text,
                id = Id.Text,
                unit = "kg",
                quantity = Quantity.Text,
                price = Price.Text,
                amount = Amount.Text


            };
            productlst.Add(product);
            await Navigation.PushAsync(new ProductlistPage());
        }
        public void Clearclicked(object sender,EventArgs e)
        {
            Product.Text = string.Empty;
            Id.Text = string.Empty;
            Quantity.Text =null;
            Price.Text = null;
            Amount.Text = string.Empty;
        }
    }
}
