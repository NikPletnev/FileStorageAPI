using FileStorageAPI.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FileStorageAPI.DAL.Test.TestCaseSources
{
    internal class UserRepositoryTestCaseSourceAddUser : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            List<User> expectedUsers = new List<User>()
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
                },
                new User()
                {
                    Id = 3,
                    Password = "54321",
                    Name = "Test3",
                    IsDeleted = false
                }

            };

            User user =
                new User()
                {
                    Id = 3,
                    Password = "54321",
                    Name = "Test3",
                    IsDeleted = false
                };

            yield return new Object[] { expectedUsers, user };
        }
    }
}
