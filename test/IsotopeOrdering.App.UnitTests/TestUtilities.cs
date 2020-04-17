﻿using AutoMapper;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Security;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using Moq;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.UnitTests {
    public static class TestUtilities {
        public static IUserService GetUserService(string? userName = null) {
            Mock<IUser> mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.UserName).Returns(userName ?? Guid.NewGuid().ToString());

            Mock<IUserService> mock = new Mock<IUserService>();
            mock.SetupGet(x => x.User).Returns(mockUser.Object);

            return mock.Object;
        }

        public static IEventManager GetEventService() {
            Mock<IEventManager> mock = new Mock<IEventManager>();
            mock.Setup(x => x.CreateEvent(It.IsAny<EntityEventType>(), It.IsAny<int>(), It.IsAny<string>()))
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


        public static IIsotopeOrderingAuthorizationService GetAuthorizationService(string policy) {
            var mock = new Mock<IIsotopeOrderingAuthorizationService>();
            mock.Setup(x => x.AuthorizeAsync(It.IsAny<ClaimsPrincipal>(), It.Is<string>(x => x == policy)))
                .ReturnsAsync(true);
            mock.Setup(x => x.AuthorizeAsync(It.Is<string>(x => x == policy)))
                .ReturnsAsync(true);
            return mock.Object;
        }
    }
}
