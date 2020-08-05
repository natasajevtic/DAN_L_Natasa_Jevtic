using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class UserViewModel : BaseViewModel
    {
        UserView userView;
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

        private List<vwSong> songList;

        public List<vwSong> SongList
        {
            get
            {
                return songList;
            }
            set
            {
                songList = value;
                OnPropertyChanged("SongList");
            }
        }

        private ICommand addSong;
        public ICommand AddSong
        {
            get
            {
                if (addSong == null)
                {
                    addSong = new RelayCommand(param => AddSongExecute(), param => CanAddSongExecute());
                }
                return addSong;
            }
        }

        private ICommand deleteSong;
        public ICommand DeleteSong
        {
            get
            {
                if (deleteSong == null)
                {
                    deleteSong = new RelayCommand(param => DeleteSongExecute(), param => CanDeleteSongExecute());
                }
                return deleteSong;
            }
        }

        private ICommand durationAsc;
        public ICommand DurationAsc
        {
            get
            {
                if (durationAsc == null)
                {
                    durationAsc = new RelayCommand(param => DurationAscExecute(), param => CanDurationAscExecute());
                }
                return durationAsc;
            }
        }

        private ICommand durationDesc;
        public ICommand DurationDesc
        {
            get
            {
                if (durationDesc == null)
                {
                    durationDesc = new RelayCommand(param => DurationDescExecute(), param => CanDurationDescExecute());
                }
                return durationDesc;
            }
        }

        private ICommand nameAsc;
        public ICommand NameAsc
        {
            get
            {
                if (nameAsc == null)
                {
                    nameAsc = new RelayCommand(param => NameAscExecute(), param => CanNameAscExecute());
                }
                return nameAsc;
            }
        }

        private ICommand nameDesc;
        public ICommand NameDesc
        {
            get
            {
                if (nameDesc == null)
                {
                    nameDesc = new RelayCommand(param => NameDescExecute(), param => CanNameDescExecute());
                }
                return nameDesc;
            }
        }

        public UserViewModel(UserView userView, vwUser user)
        {
            this.userView = userView;
            User = user;
            SongList = songs.GetUserSongs(User);
        }

        public bool CanDeleteSongExecute()
        {
            if (Song != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteSongExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the song?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool isDeleted = songs.DeleteSong(Song);
                    if (isDeleted)
                    {
                        MessageBox.Show("Song is deleted", "Notification");
                        SongList = songs.GetUserSongs(User);
                    }
                    else
                    {
                        MessageBox.Show("Song cannot be deleted", "Notification");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanAddSongExecute()
        {
            return true;
        }

        public void AddSongExecute()
        {
            try
            {
                AddSongView form = new AddSongView(User);
                form.ShowDialog();
                SongList = songs.GetUserSongs(User);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanNameAscExecute()
        {
            return true;
        }

        public void NameAscExecute()
        {
            SongList = songs.SortNameAsc(User);
        }

        public bool CanNameDescExecute()
        {
            return true;
        }

        public void NameDescExecute()
        {
            SongList = songs.SortNameDesc(User);
        }

        public bool CanDurationDescExecute()
        {
            return true;
        }

        public void DurationDescExecute()
        {
            SongList = songs.SortDurationDesc(User);
        }

        public bool CanDurationAscExecute()
        {
            return true;
        }

        public void DurationAscExecute()
        {
            SongList = songs.SortDurationAsc(User);
        }
    }
}