using FileStorageAPI.DAL.Entity;
using FileStorageAPI.DAL.Repositories;
using FileStorageAPI.DAL.Test.Mock;
using FileStorageAPI.DAL.Test.TestCaseSources;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileStorageAPI.DAL.Test
{
    public class UserRepositoryTest
    {
        private FileStorageContext _context;
        private UserRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<FileStorageContext>()
            .UseInMemoryDatabase(databaseName: "FileStorageTests")
            .Options;

            _context = new FileStorageContext(options);

            _context.Database.EnsureCreated();
            _context.Database.EnsureDeleted();

            _repository = new UserRepository(_context);

            var users = UserTestMock.GetUsers();
            _context.Users.AddRange(users);

            _context.SaveChanges();
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task GetUserByIdTest_MustReturnUser(int? id)
        {
            var expected = await _context.Users.FindAsync(id);

            var actual =  await _repository.GetUserById(id);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task GetGetAllUsers_MustReturnUserList()
        {
            var expected = await _context.Users.Where(d => !d.IsDeleted).ToListAsync();

            var actual = await _repository.GetAllUsers();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(UserRepositoryTestCaseSourceAddUser))]
        public async Task AddUser_MustAddNewUserAndReturnId(List<User> expected, User user)
        {
            var actualId = await _repository.AddUser(user);
            var actual = await _context.Users.Where(d => !d.IsDeleted).ToListAsync();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(user.Id, actualId);
        }

        [TestCaseSource(typeof(UserRepositoryUpdateUserTestCaseSource))]
        public async Task UpdateUser_MustUpdateUserData(User expected, User user, int id)
        {
            var oldUserEntity = await _context.Users.FirstOrDefaultAsync(d => d.Id == id);

            await _repository.UpdateUser(user, oldUserEntity);
            var newUser = await _context.Users.FirstOrDefaultAsync(d => d.Id == id);

            Assert.AreEqual(expected, newUser);
        }

        public async Task UpdateUser_MustDeleteUserOrRestoreUser(int id, bool IsDeleted)
        {

        }

    }
}