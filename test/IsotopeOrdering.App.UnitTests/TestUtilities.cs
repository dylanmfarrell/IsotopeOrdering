using AutoMapper;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using MIR.Core.Domain;
using Moq;
using System;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.UnitTests {
    public static class TestUtilities {
        public static IUserService GetUserService(string userName = null) {
            Mock<IUser> mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.UserName).Returns(userName ?? Guid.NewGuid().ToString());

            Mock<IUserService> mock = new Mock<IUserService>();
            mock.SetupGet(x => x.User).Returns(mockUser.Object);

            return mock.Object;
        }

        public static IEventService GetEventService() {
            Mock<IEventService> mock = new Mock<IEventService>();
            mock.Setup(x => x.CreateEvent(It.IsAny<EntityEventType>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<object[]>()))
                .Returns(Task.CompletedTask);
            return mock.Object;
        }

        public static IRoleService GetRoleService(params string[] roles) {
            Mock<IRoleService> mock = new Mock<IRoleService>();
            mock.Setup(x => x.UserRoles).Returns(roles);
            return mock.Object;
        }

        public static IMapper GetMapper(params Profile[] profiles) {
            var config = new MapperConfiguration(c =>
                c.AddProfiles(profiles)
            );
            return new Mapper(config);
        }
    }
}
