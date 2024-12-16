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
    public class PhotoUserServiceTest
    {
        private readonly PhotoUsersService service;
        private readonly Mock<IPhotoUsersRepository> PhotoUserRepositoryMoq;

        public static IEnumerable<object[]> CreateIncorrectPhotoUser()
        {
            return new List<object[]>
            {
                new object[] { new PhotoUser() { UserId=0,PhotoLink=""} },
                new object[] { new PhotoUser() { UserId=-1,PhotoLink=""} },
                new object[] { new PhotoUser() { UserId=int.MinValue,PhotoLink=""} },
            };
        }

        public static IEnumerable<object[]> CreateCorrectPhotoUser()
        {
            return new List<object[]>
            {
                new object[] { new PhotoUser() { UserId=1,PhotoLink="sdds"} },
                new object[] { new PhotoUser() { UserId=2,PhotoLink="sdds"} },
                new object[] { new PhotoUser() { UserId=3,PhotoLink="111"} },
            };
        }
        public static IEnumerable<object[]> GetIncorrectPhotoUser()
        {
            return new List<object[]>
            {
                new object[] { new PhotoUser() { PhotoId=0, UserId=0,PhotoLink=""} },
                new object[] { new PhotoUser() { PhotoId=-1, UserId=-1,PhotoLink="dss"} },
                new object[] { new PhotoUser() { PhotoId=-3, UserId=0,PhotoLink="s"} },
            };
        }

        public static IEnumerable<object[]> GetCorrectPhotoUser()
        {
            return new List<object[]>
            {
                new object[] { new PhotoUser() {PhotoId=1, UserId=1,PhotoLink="dsd"} },
                new object[] { new PhotoUser() {PhotoId=2, UserId=3,PhotoLink="sds"} },
                new object[] { new PhotoUser() {PhotoId=3, UserId=2,PhotoLink="sds"} },
            };
        }


        public PhotoUserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            PhotoUserRepositoryMoq = new Mock<IPhotoUsersRepository>();

            repositoryWrapperMoq.Setup(x => x.PhotoUsers).Returns(PhotoUserRepositoryMoq.Object);

            service = new PhotoUsersService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task GetALL()
        {
            await service.GetAll();
            PhotoUserRepositoryMoq.Verify(x => x.FindALL());
        }


        [Theory]
        [MemberData(nameof(GetCorrectPhotoUser))]
        public async Task GetById_correct(PhotoUser PhotoUser)
        {
            PhotoUserRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<PhotoUser, bool>>>())).ReturnsAsync(new List<PhotoUser> { PhotoUser });

            // Act
            var result = await service.GetById(PhotoUser.PhotoId);

            // Assert
            Assert.Equal(PhotoUser.PhotoId, result.PhotoId);
            PhotoUserRepositoryMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<PhotoUser, bool>>>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectPhotoUser))]
        public async Task GetByid_incorrect(PhotoUser PhotoUser)
        {
            PhotoUserRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<PhotoUser, bool>>>())).ReturnsAsync(new List<PhotoUser> { PhotoUser });

            // Act
            var result = await service.GetById(PhotoUser.PhotoId);

            // Assert
            Assert.Equal(PhotoUser.PhotoId, result.PhotoId);
            PhotoUserRepositoryMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<PhotoUser, bool>>>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(CreateCorrectPhotoUser))]

        public async Task CreateAsyncNewPhotoUserShouldNotCreateNewPhotoUser_correct(PhotoUser PhotoUser)
        {
            var newPhotoUser = PhotoUser;

            await service.Create(newPhotoUser);
            PhotoUserRepositoryMoq.Verify(x => x.Create(It.IsAny<PhotoUser>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(CreateIncorrectPhotoUser))]

        public async Task CreateAsyncNewPhotoUserShouldNotCreateNewPhotoUser_incorrect(PhotoUser PhotoUser)
        {
            var newPhotoUser = PhotoUser;

            await service.Create(newPhotoUser);
            PhotoUserRepositoryMoq.Verify(x => x.Create(It.IsAny<PhotoUser>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetCorrectPhotoUser))]

        public async Task UpdateAsyncOldPhotoUser_correct(PhotoUser PhotoUser)
        {
            var newPhotoUser = PhotoUser;

            await service.Update(newPhotoUser);
            PhotoUserRepositoryMoq.Verify(x => x.Update(It.IsAny<PhotoUser>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectPhotoUser))]

        public async Task UpdateAsyncOldPhotoUser_incorrect(PhotoUser PhotoUser)
        {
            var newPhotoUser = PhotoUser;

            await service.Update(newPhotoUser);
            PhotoUserRepositoryMoq.Verify(x => x.Update(It.IsAny<PhotoUser>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetCorrectPhotoUser))]

        public async Task DeleteAsyncOldPhotoUser_correct(PhotoUser PhotoUser)
        {
            PhotoUserRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<PhotoUser, bool>>>())).ReturnsAsync(new List<PhotoUser> { PhotoUser });

            await service.Delete(PhotoUser.PhotoId);

            PhotoUserRepositoryMoq.Verify(x => x.Delete(It.IsAny<PhotoUser>()), Times.Once);
            var result = await service.GetById(PhotoUser.PhotoId);
            Assert.Equal(PhotoUser.PhotoId, result.PhotoId);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectPhotoUser))]

        public async Task DeleteAsyncOldPhotoUser_incorrect(PhotoUser PhotoUser)
        {
            PhotoUserRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<PhotoUser, bool>>>())).ReturnsAsync(new List<PhotoUser> { PhotoUser });

            await service.Delete(PhotoUser.PhotoId);

            PhotoUserRepositoryMoq.Verify(x => x.Delete(It.IsAny<PhotoUser>()), Times.Once);
            var result = await service.GetById(PhotoUser.PhotoId);
            Assert.Equal(PhotoUser.PhotoId, result.PhotoId);
        }

    }
}