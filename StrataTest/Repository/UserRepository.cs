using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using StrataTest.Interfaces;
using StrataTest.Models;

namespace StrataTest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _dataSource;
        public UserRepository(string dataSource)
        {
            _dataSource = dataSource;
        }

        public User GetUserByName(string userName)
        {
            var users = ProcessJson();
            return users.FirstOrDefault(x => x.Name == userName);
        }

        public User GetUserByEmail(string emailAddress)
        {
            var users = ProcessJson();
            return users.FirstOrDefault(x => x.EmailAddress == emailAddress);
        }

        public void AddUser(User user)
        {
            if (GetUserByEmail(user.EmailAddress) == null)
            {
                //Needs refactor!
                using (var fileStream = new FileStream(_dataSource, FileMode.Open, FileAccess.ReadWrite))
                {
                    fileStream.SetLength(fileStream.Length - 1);
                }
                using (StreamWriter sw = File.AppendText(_dataSource))
                {

                    sw.WriteLine("," + JsonConvert.SerializeObject(user) + "]");
                }
            }
        }

        public bool Authenticate(string emailAddress, string password)
        {
            var user = GetUserByEmail(emailAddress);
            if (user == null)
            {
                return false;
            }
            return user.Password == password;
        }

        private IEnumerable<User> ProcessJson()
        {
            return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(_dataSource));
        }
        //TODO make into generic extension method
        //public IEnumerable<object> ProcessJson(Type t)
        //{
        //    return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(_dataSource));
        //}

    }
}