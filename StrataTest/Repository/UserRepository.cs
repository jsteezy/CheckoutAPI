using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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

        public UserModel GetUserByName(string userName)
        {
            var users = ProcessJson();
            return users.FirstOrDefault(x => x.Name == userName);
        }

        public UserModel GetUserByEmail(string emailAddress)
        {
            var users = ProcessJson();
            return users.FirstOrDefault(x => x.EmailAddress == emailAddress);
        }

        public void AddUser(UserModel userModel)
        {
            if (GetUserByEmail(userModel.EmailAddress) == null)
            {
                //Needs refactor!
                using (var fileStream = new FileStream(_dataSource, FileMode.Open, FileAccess.ReadWrite))
                {
                    fileStream.SetLength(fileStream.Length - 1);
                }
                using (StreamWriter sw = File.AppendText(_dataSource))
                {

                    sw.WriteLine("," + JsonConvert.SerializeObject(userModel) + "]");
                }
            }
        }

        private IEnumerable<UserModel> ProcessJson()
        {
            return JsonConvert.DeserializeObject<List<UserModel>>(File.ReadAllText(_dataSource));
        }
        //TODO make into generic extension method
        //public IEnumerable<object> ProcessJson(Type t)
        //{
        //    return JsonConvert.DeserializeObject<List<UserModel>>(File.ReadAllText(_dataSource));
        //}

    }
}