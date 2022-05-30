using FileStorageAPI.DAL.Entity;
using System;
using System.Collections;

namespace FileStorageAPI.DAL.Test.TestCaseSources
{
    internal class UserRepositoryUpdateUserTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            User user =
                new User()
                {
                    Id = 2,
                    Password = "54321",
                    Name = "Test3Updated",
                    IsDeleted = false
                };
            int id = 2;

            yield return new Object[] { user, user, id };
        }
    }
}
