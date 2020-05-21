using AutoMapper;
using IsotopeOrdering.App.Mappings;
using Microsoft.EntityFrameworkCore;
using MIR.Core.Domain;
using Moq;
using System;

namespace IsotopeOrdering.Infrastructure.IntegrationTests {
    public static class TestUtilities {
        public static IMapper GetMapper() {
            var config = new MapperConfiguration(c =>
                c.AddMaps(typeof(CustomerProfile).Assembly)
            );
            return new Mapper(config);
        }

        public static IUserService GetUserService(string userName) {
            Mock<IUser> mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.UserName).Returns(userName);
            mockUser.SetupGet(x => x.EducationId).Returns(userName);

            Mock<IUserService> mock = new Mock<IUserService>();
            mock.SetupGet(x => x.User).Returns(mockUser.Object);

            return mock.Object;
        }

        public static IRoleService GetRoleService(params string[] roles) {
            Mock<IRoleService> mock = new Mock<IRoleService>();
            mock.Setup(x => x.UserRoles).Returns(roles);
            return mock.Object;
        }

        public static DbContextOptions<IsotopeOrderingDbContext> GetInMemoryOptions(string instanceName) {
            return new DbContextOptionsBuilder<IsotopeOrderingDbContext>()
                .UseInMemoryDatabase(instanceName)
                .Options;
        }

        public static IsotopeOrderingDbContext GetDbContext(string? instanceName = null, string? instanceUser = null, string[]? roles = null) {
            string defaultInstanceIdentifier = Guid.NewGuid().ToString();
            var options = GetInMemoryOptions(instanceName ?? defaultInstanceIdentifier);
            IUserService userService = GetUserService(instanceUser ?? defaultInstanceIdentifier);
            IRoleService roleService = GetRoleService(roles ?? new string[0]);
            return new IsotopeOrderingDbContext(userService, roleService, options);
        }
    }
}
