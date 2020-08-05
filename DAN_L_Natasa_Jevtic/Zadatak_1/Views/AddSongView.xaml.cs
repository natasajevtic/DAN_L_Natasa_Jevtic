using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for AddSongView.xaml
    /// </summary>
    public partial class AddSongView : Window
    {
        public AddSongView(vwUser user)
        {
            InitializeComponent();
            this.DataContext = new AddSongViewModel(this, user);
        }
    }
}