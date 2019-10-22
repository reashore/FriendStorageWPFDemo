using System;
using System.Collections.Generic;
using FriendStorage.Model;
using FriendStorage.UI.Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FriendStorage.UITests.Wrapper
{
    [TestClass]
    public class BasicTests
    {
        private Friend _friend;

        [TestInitialize]
        public void Initialize()
        {
            _friend = new Friend
            {
                FirstName = "Thomas",
                Address = new Address(),
                Emails = new List<FriendEmail>()
            };
        }

        [TestMethod]
        public void ShouldContainModelInModelProperty()
        {
            FriendWrapper wrapper = new FriendWrapper(_friend);
            Assert.AreEqual(_friend, wrapper.Model);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentNullExceptionIfModelIsNull()
        {
            try
            {
                // ReSharper disable once UnusedVariable
                FriendWrapper wrapper = new FriendWrapper(null);
            }
            catch (ArgumentNullException argumentNullException)
            {
                Assert.AreEqual("model", argumentNullException.ParamName);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionIfAddressIsNull()
        {
            try
            {
                _friend.Address = null;
                // ReSharper disable once UnusedVariable
                FriendWrapper wrapper = new FriendWrapper(_friend);
            }
            catch (ArgumentException argumentException)
            {
                Assert.AreEqual("Address cannot be null", argumentException.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionIfEmailsCollectionIsNull()
        {
            try
            {
                _friend.Emails = null;
                // ReSharper disable once UnusedVariable
                FriendWrapper wrapper = new FriendWrapper(_friend);
            }
            catch (ArgumentException argumentException)
            {
                Assert.AreEqual("Emails cannot be null", argumentException.Message);
                throw;
            }
        }

        [TestMethod]
        public void ShouldGetValueOfUnderlyingModelProperty()
        {
            FriendWrapper wrapper = new FriendWrapper(_friend);
            Assert.AreEqual(_friend.FirstName, wrapper.FirstName);
        }

        [TestMethod]
        public void ShouldSetValueOfUnderlyingModelProperty()
        {
            FriendWrapper wrapper = new FriendWrapper(_friend);
            wrapper.FirstName = "Julia";
            Assert.AreEqual("Julia", _friend.FirstName);
        }
    }
}