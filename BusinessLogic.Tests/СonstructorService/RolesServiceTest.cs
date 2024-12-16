using BusinessLogic.Services;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Wrapper;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Xunit.Sdk;

namespace BusinessLogic.Tests.СonstructorService
{
    public class RoleServiceTest
    {
        private readonly RolesService service;
        private readonly Mock<IRolesRepository> RoleRepositoryMoq;

        public static IEnumerable<object[]> CreateIncorrectRole()
        {
            return new List<object[]>
            {
                new object[] { new Role() { Role1=""} },
                new object[] { new Role() { Role1= Convert.ToString(new DateTime(123,1232,12323))} },
            };
        }

        public static IEnumerable<object[]> CreateCorrectRole()
        {
            return new List<object[]>
            {
                new object[] { new Role() { Role1="sd213122323!!!s"} },
                new object[] { new Role() { Role1 = "sdsds" } },
            };
        }

        public static IEnumerable<object[]> GetIncorrectRole()
        {
            return new List<object[]>
            {
                new object[] { new Role() { Role1=""} },
                new object[] { new Role() { Role1= Convert.ToString(new DateTime(123,1232,12323))} },
            };
        }

        public static IEnumerable<object[]> GetCorrectRole()
        {
            return new List<object[]>
            {
                new object[] { new Role() { Role1="sd213122323!!!s"} },
                new object[] { new Role() { Role1 = "sdsds" } },
            };
        }


        public RoleServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            RoleRepositoryMoq = new Mock<IRolesRepository>();

            repositoryWrapperMoq.Setup(x => x.Roles).Returns(RoleRepositoryMoq.Object);

            service = new RolesService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task GetALL()
        {
            await service.GetAll();
            RoleRepositoryMoq.Verify(x => x.FindALL());
        }


        [Theory]
        [MemberData(nameof(GetCorrectRole))]
        public async Task GetById_correct(Role Role)
        {
            RoleRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Role, bool>>>())).ReturnsAsync(new List<Role> { Role });

            // Act
            var result = await service.GetById(Role.Id);

            // Assert
            Assert.Equal(Role.Id, result.Id);
            RoleRepositoryMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<Role, bool>>>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectRole))]
        public async Task GetByid_incorrect(Role Role)
        {
            RoleRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Role, bool>>>())).ReturnsAsync(new List<Role> { Role });

            // Act
            var result = await service.GetById(Role.Id);

            // Assert
            Assert.Equal(Role.Id, result.Id);
            RoleRepositoryMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<Role, bool>>>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(CreateCorrectRole))]

        public async Task CreateAsyncNewRoleShouldNotCreateNewRole_correct(Role Role)
        {
            var newRole = Role;

            await service.Create(newRole);
            RoleRepositoryMoq.Verify(x => x.Create(It.IsAny<Role>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(CreateIncorrectRole))]

        public async Task CreateAsyncNewRoleShouldNotCreateNewRole_incorrect(Role Role)
        {
            var newRole = Role;

            await service.Create(newRole);
            RoleRepositoryMoq.Verify(x => x.Create(It.IsAny<Role>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetCorrectRole))]

        public async Task UpdateAsyncOldRole_correct(Role Role)
        {
            var newRole = Role;

            await service.Update(newRole);
            RoleRepositoryMoq.Verify(x => x.Update(It.IsAny<Role>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectRole))]

        public async Task UpdateAsyncOldRole_incorrect(Role Role)
        {
            var newRole = Role;

            await service.Update(newRole);
            RoleRepositoryMoq.Verify(x => x.Update(It.IsAny<Role>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetCorrectRole))]

        public async Task DeleteAsyncOldRole_correct(Role Role)
        {
            RoleRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Role, bool>>>())).ReturnsAsync(new List<Role> { Role });

            await service.Delete(Role.Id);

            RoleRepositoryMoq.Verify(x => x.Delete(It.IsAny<Role>()), Times.Once);
            var result = await service.GetById(Role.Id);
            Assert.Equal(Role.Role1, result.Role1);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectRole))]

        public async Task DeleteAsyncOldRole_incorrect(Role Role)
        {
            RoleRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Role, bool>>>())).ReturnsAsync(new List<Role> { Role });

            await service.Delete(Role.Id);

            RoleRepositoryMoq.Verify(x => x.Delete(It.IsAny<Role>()), Times.Once);
            var result = await service.GetById(Role.Id);
            Assert.Equal(Role.Role1, result.Role1);
        }

    }
}