using System.ComponentModel;
using Xamarin.Forms;
using AppMobileOrders.ViewModels;

namespace AppMobileOrders.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}