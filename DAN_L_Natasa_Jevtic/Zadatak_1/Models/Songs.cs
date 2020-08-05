using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Zadatak_1.Models
{
    class Songs
    {
        public List<vwSong> GetUserSongs(vwUser user)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwSongs.Where(x => x.UserId == user.UserId).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwSong> SortNameAsc(vwUser user)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwSongs.Where(x => x.UserId == user.UserId).OrderBy(x => x.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwSong> SortNameDesc(vwUser user)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwSongs.Where(x => x.UserId == user.UserId).OrderByDescending(x => x.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwSong> SortDurationAsc(vwUser user)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwSongs.Where(x => x.UserId == user.UserId).OrderBy(x => x.Duration).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwSong> SortDurationDesc(vwUser user)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwSongs.Where(x => x.UserId == user.UserId).OrderByDescending(x => x.Duration).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public bool CreateSong(vwUser user, vwSong song)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    tblSong newSong = new tblSong
                    {
                        Author = song.Author,
                        Duration = song.Duration,
                        Name = song.Name,
                        UserId = user.UserId
                    };
                    context.tblSongs.Add(newSong);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public bool DeleteSong(vwSong song)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    var songToDelete = context.tblSongs.Where(x => x.SongId == song.SongId).FirstOrDefault();
                    context.tblSongs.Remove(songToDelete);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
    }
}