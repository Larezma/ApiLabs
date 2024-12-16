﻿using BusinessLogic.Services;
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
    public class GroupMemberServiceTest
    {
        private readonly GroupMembersService service;
        private readonly Mock<IGroupMembersRepository> GroupMemberRepositoryMoq;

        public static IEnumerable<object[]> CreateIncorrectGroupMember()
        {
            return new List<object[]>
            {
                new object[] { new GroupMember() {GroupsId=0,UserId = 0 } },
                new object[] { new GroupMember() {GroupsId=-1,UserId =0 } },
                new object[] { new GroupMember() {GroupsId=3,UserId = -1 } },
            };
        }

        public static IEnumerable<object[]> CreateCorrectGroupMember()
        {
            return new List<object[]>
            {
                new object[] { new GroupMember() {GroupsId=1,UserId =1 } },
                new object[] { new GroupMember() {GroupsId=2,UserId =2 } },
                new object[] { new GroupMember() {GroupsId=3,UserId =3 } },
            };
        }
        public static IEnumerable<object[]> GetIncorrectGroupMember()
        {
            return new List<object[]>
            {
                new object[] { new GroupMember() {GroupsId=0,UserId =1 } },
                new object[] { new GroupMember() {GroupsId=-1,UserId =0 } },
                new object[] { new GroupMember() {GroupsId=3,UserId =-1 } },
            };
        }

        public static IEnumerable<object[]> GetCorrectGroupMember()
        {
            return new List<object[]>
            {
                new object[] { new GroupMember() {GroupsId=1,UserId =1 } },
                new object[] { new GroupMember() {GroupsId=2,UserId =2 } },
                new object[] { new GroupMember() {GroupsId=3,UserId =3 } },
            };
        }


        public GroupMemberServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            GroupMemberRepositoryMoq = new Mock<IGroupMembersRepository>();

            repositoryWrapperMoq.Setup(x => x.GroupMembers).Returns(GroupMemberRepositoryMoq.Object);

            service = new GroupMembersService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task GetALL()
        {
            await service.GetAll();
            GroupMemberRepositoryMoq.Verify(x => x.FindALL());
        }


        [Theory]
        [MemberData(nameof(GetCorrectGroupMember))]
        public async Task GetById_correct(GroupMember GroupMember)
        {
            GroupMemberRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<GroupMember, bool>>>())).ReturnsAsync(new List<GroupMember> { GroupMember });

            // Act
            var result = await service.GetById(GroupMember.GroupsId);

            // Assert
            Assert.Equal(GroupMember.GroupsId, result.GroupsId);
            GroupMemberRepositoryMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<GroupMember, bool>>>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectGroupMember))]
        public async Task GetByid_incorrect(GroupMember GroupMember)
        {
            GroupMemberRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<GroupMember, bool>>>())).ReturnsAsync(new List<GroupMember> { GroupMember });

            // Act
            var result = await service.GetById(GroupMember.GroupsId);

            // Assert
            Assert.Equal(GroupMember.GroupsId, result.GroupsId);
            GroupMemberRepositoryMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<GroupMember, bool>>>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(CreateCorrectGroupMember))]

        public async Task CreateAsyncNewGroupMemberShouldNotCreateNewGroupMember_correct(GroupMember GroupMember)
        {
            var newGroupMember = GroupMember;

            await service.Create(newGroupMember);
            GroupMemberRepositoryMoq.Verify(x => x.Create(It.IsAny<GroupMember>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(CreateIncorrectGroupMember))]

        public async Task CreateAsyncNewGroupMemberShouldNotCreateNewGroupMember_incorrect(GroupMember GroupMember)
        {
            var newGroupMember = GroupMember;

            await service.Create(newGroupMember);
            GroupMemberRepositoryMoq.Verify(x => x.Create(It.IsAny<GroupMember>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetCorrectGroupMember))]

        public async Task UpdateAsyncOldGroupMember_correct(GroupMember GroupMember)
        {
            var newGroupMember = GroupMember;

            await service.Update(newGroupMember);
            GroupMemberRepositoryMoq.Verify(x => x.Update(It.IsAny<GroupMember>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectGroupMember))]

        public async Task UpdateAsyncOldGroupMember_incorrect(GroupMember GroupMember)
        {
            var newGroupMember = GroupMember;

            await service.Update(newGroupMember);
            GroupMemberRepositoryMoq.Verify(x => x.Update(It.IsAny<GroupMember>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetCorrectGroupMember))]

        public async Task DeleteAsyncOldGroupMember_correct(GroupMember GroupMember)
        {
            GroupMemberRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<GroupMember, bool>>>())).ReturnsAsync(new List<GroupMember> { GroupMember });

            await service.Delete(GroupMember.GroupsId);

            GroupMemberRepositoryMoq.Verify(x => x.Delete(It.IsAny<GroupMember>()), Times.Once);
            var result = await service.GetById(GroupMember.GroupsId);
            Assert.Equal(GroupMember.GroupsId, result.GroupsId);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectGroupMember))]

        public async Task DeleteAsyncOldGroupMember_incorrect(GroupMember GroupMember)
        {
            GroupMemberRepositoryMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<GroupMember, bool>>>())).ReturnsAsync(new List<GroupMember> { GroupMember });

            await service.Delete(GroupMember.GroupsId);

            GroupMemberRepositoryMoq.Verify(x => x.Delete(It.IsAny<GroupMember>()), Times.Once);
            var result = await service.GetById(GroupMember.GroupsId);
            Assert.Equal(GroupMember.GroupsId, result.GroupsId);
        }

    }
}