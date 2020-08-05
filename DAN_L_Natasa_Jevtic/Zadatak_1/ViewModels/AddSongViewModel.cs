using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AddSongViewModel : BaseViewModel
    {
        AddSongView songView;
        Songs songs = new Songs();

        private vwUser user;

        public vwUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private vwSong song;

        public vwSong Song
        {
            get
            {
                return song;
            }
            set
            {
                song = value;
                OnPropertyChanged("Song");
            }
        }

        private bool btnSaveIsEnabled;
        public bool BtnSaveIsEnabled
        {
            get
            {
                return btnSaveIsEnabled;
            }
            set
            {
                btnSaveIsEnabled = value;
                base.OnPropertyChanged("BtnSaveIsEnabled");
            }
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }

        public AddSongViewModel(AddSongView songView, vwUser user)
        {
            this.songView = songView;
            User = user;
            Song = new vwSong();
        }

        public void SaveExecute()
        {
            if (String.IsNullOrEmpty(Song.Name) || String.IsNullOrEmpty(Song.Author) || String.IsNullOrEmpty(Song.Duration.ToString())
                || Song.Duration.ToString() == "00:00:00")
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to save the song?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isCreated = songs.CreateSong(User, Song);
                        if (isCreated == true)
                        {
                            MessageBox.Show("Song is created.", "Notification", MessageBoxButton.OK);
                            songView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Song cannot be created.", "Notification", MessageBoxButton.OK);
                            songView.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public bool CanSaveExecute()
        {
            return true;
        }

        public void CancelExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the song?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    songView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelExecute()
        {
            return true;
        }
    }
}