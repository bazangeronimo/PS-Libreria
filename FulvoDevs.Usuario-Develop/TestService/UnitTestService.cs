using PS.Template.Aplication.Utils;
using PS.Template.Aplication.Utils.Authentication;
using PS.Template.Aplication.Interface;
using PS.Template.Aplication.Services;
using PS.Template.Domain.DtoModels;
using PS.Template.Domain.Models;
using NUnit.Framework;
using Moq;

 namespace TestService
{
    public class Tests
    {
        Mock<IUserCommands> _userCommands;
        Mock<IUserQuery> _userQuery;
        Mock<IFollowQuery> _followQuery;
        Mock<IFeaturesQueries> _featureQuery;
        Mock<JwtAuthManager> _jwtAuthManager;
        
        [SetUp]
        public void Setup()
        {
            _userCommands = new Mock<IUserCommands>();
            _userQuery = new Mock<IUserQuery>();
            _followQuery = new Mock<IFollowQuery>(); 
            _featureQuery = new Mock<IFeaturesQueries>();
            _jwtAuthManager = new Mock<JwtAuthManager>("qYSfppVPCw0X0MEbWUOtnDneqD22p6j1qUuL0WHMVPI"); 
        }

        //(user),search,work,description,expected
        [TestCase("1", true, true, "Descripcion corta", true)]
        [TestCase("1", false, true, "Descripcion corta", false)]
        [TestCase("1", true, false, "Descripcion corta", false)]
        [TestCase("1", false, false, "Descripcion corta", false)]

        [TestCase("1", false, true, "Descripcion larga aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa", false)]
        [TestCase("1", true, false, "Descripcion larga aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa", false)]
        [TestCase("1", false, false, "Descripcion larga aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa", false)]

        [TestCase("u", false, true, "Descripcion corta", false)]
        [TestCase("u", true, false, "Descripcion corta", false)]
        [TestCase("u", false, false, "Descripcion corta", false)]

        [TestCase("1", false, true, "", false)]
        [TestCase("1", true, false, "", false)]
        [TestCase("1", false, false, "", false)]

        [TestCase("1", true, true, null, false)]
        [TestCase("1", false, true, null, false)]
        [TestCase("1", true, false, null, false)]
        [TestCase("1", false, false, null, false)]

        [TestCase("", true, true, "Descripcion corta", false)]
        [TestCase("", false, true, "Descripcion corta", false)]
        [TestCase("", true, false, "Descripcion corta", false)]
        [TestCase("", false, false, "Descripcion corta", false)]

        [TestCase("", true, true, "", false)]
        [TestCase("", false, true, "", false)]
        [TestCase("", true, false, "", false)]
        [TestCase("", false, false, "", false)]

        [TestCase("", true, true, null, false)]
        [TestCase("", false, true, null, false)]
        [TestCase("", true, false, null, false)]
        [TestCase("", false, false, null, false)]

        [TestCase(null, false, true, "DescripcionNueva", false)]
        [TestCase(null, true, false, "DescripcionNueva", false)]
        [TestCase(null, false, false, "DescripcionNueva", false)]

        [TestCase(null, false, true, "", false)]
        [TestCase(null, true, false, "", false)]
        [TestCase(null, false, false, "", false)]

        [TestCase(null, true, true, null, false)]
        [TestCase(null, false, true, null, false)]
        [TestCase(null, true, false, null, false)]
        [TestCase(null, false, false, null, false)]

        public void TestUpdateDescription(string user, bool userSearch, bool retorno, string Description, bool expected)
        {
            //Arrange

            User? usuario = null;
            if (userSearch)
            {
                usuario = new User()
                { 
                    Nombre ="Gero",
                    Apellido ="Bazan",
                    Email = "bazangeronimo@gmail.com",
                    Description = "Descripcion",
                    EquipoFutbol = "Berazategui",
                    Ubicacion = "Av. siempre viva"
                };
            }
            dtoUpdateDescriptionUser dtoDescrUpdate = null;
            dtoDescrUpdate = new dtoUpdateDescriptionUser()
            {
                description = Description
            };
            var userById = _userQuery.Setup(u => u.SearchUserById(It.IsAny<int>())).Returns(usuario);
            var updateUser = _userCommands.Setup(u => u.UpdateDescription(It.IsAny<User>(), It.IsAny<string>())).Returns(new Response(retorno, ""));
            var service = new UserServices(_userCommands.Object, _userQuery.Object, _jwtAuthManager.Object, _followQuery.Object, _featureQuery.Object);
            
            //Act

            var response = service.UpdateDescription(user, dtoDescrUpdate);

            //Assert

            Assert.AreEqual(expected, response.succes);
        }
    }
}
