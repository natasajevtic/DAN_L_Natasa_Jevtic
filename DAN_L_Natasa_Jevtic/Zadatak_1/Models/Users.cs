using System;
using System.Diagnostics;
using System.Linq;

namespace Zadatak_1.Models
{
    class Users
    {
        /// <summary>
        /// This methods finds user based on forwarded username and password.
        /// </summary>
        /// <param name="username">User username.</param>
        /// <param name="password">User password.</param>
        /// <returns>User.</returns>
        public vwUser FindUser(string username, string password)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return context.vwUsers.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method checks if forwarded username unique.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <returns>True if unique, false if not.</returns>
        public bool IsUsernameUnique(string username)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    var list = context.vwUsers.Where(x => x.Username == username).ToList();
                    //if exists user with forwarded username, return false
                    if (list.Count() > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// This method checks if password is in correct format.
        /// </summary>
        /// <param name="password">Password.</param>
        /// <returns>True if correct, false if not.</returns>
        public bool IsPasswordCorrect(string password)
        {
            if (password.Length >= 6)
            {
                var list = password.Where(Char.IsUpper).ToList();
                if (list.Count >= 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// This methods add user to DbSet and save changes to database.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>True if user is created, false if not.</returns>
        public bool CreateUser(string username, string password)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    tblUser user = new tblUser
                    {
                        Password = password,
                        Username = username
                    };
                    context.tblUsers.Add(user);
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