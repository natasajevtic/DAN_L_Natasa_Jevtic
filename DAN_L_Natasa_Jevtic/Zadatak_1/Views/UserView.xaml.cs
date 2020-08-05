using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView(vwUser user)
        {
            InitializeComponent();
            this.DataContext = new UserViewModel(this, user);
        }
    }
}