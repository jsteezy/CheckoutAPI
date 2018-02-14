using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using StrataTest.Commands;
using StrataTest.Domain;
using StrataTest.Interfaces;

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
            return users.FirstOrDefault(x => x.UserName == userName);
        }

        public UserModel GetUserByEmail(string emailAddress)
        {
            var users = ProcessJson();
            return users.FirstOrDefault(x => x.Email == emailAddress);
        }

        private IEnumerable<UserModel> ProcessJson()
        {
            return JsonConvert.DeserializeObject<List<UserModel>>(File.ReadAllText(_dataSource));
        }
        //TODO make into generic extension method
        //public IEnumerable<object> ProcessJson(Type t)
        //{
        //    return JsonConvert.DeserializeObject<List<UserCommand>>(File.ReadAllText(_dataSource));
        //}

    }
}