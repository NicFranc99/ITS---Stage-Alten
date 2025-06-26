using FluentAssertions;
using Supermercato_DB.Repos;
using Supermercato_DB.Services;
using Xunit;
namespace Supermercato_DB.Tests
{


    public class UserRepositoryTests
    {
        private readonly UserRepository _userRepository;

        public UserRepositoryTests()
        {
            _userRepository = new UserRepository();
        }

        [Fact]
        public void UserRepository_GetUser_Cenzino()
        {
            
            var user = new User()
            {
                Username = "Cenzino",
                Password = "ChatGPT."             
            };



            var result = _userRepository.GetUser(user);
            

            result.Should().BeTrue();
             
        }


        [Fact]
        public void UserRepository_GetUser_Unknown()
        {
           
            var user = new User()
            {
                Username = "Vito",
                Password = "Rossi"
            };



            var result = _userRepository.GetUser(user);


            result.Should().BeFalse();

        }


        [Fact]
        public void UserRepository_GetUser_Empty()
        {
           

            var user = new User()
            {
                Username = null,
                Password = null

            };

            var result = _userRepository.GetUser(user);

            result.Should().BeFalse();

        }


    }
}