
using FileStorageAPI.DAL.Entity;
using System.Collections.Generic;

namespace FileStorageAPI.DAL.Test.Mock
{
    public static class UserTestMock
    {
        public static List<User> GetUsers() =>
            new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Password = "12345",
                    Name = "Test1",
                    IsDeleted = false
                },
                new User()
                {
                    Id = 2,
                    Password = "54321",
                    Name = "Test2",
                    IsDeleted = false
                }
            };

    }
}

