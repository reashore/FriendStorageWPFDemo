﻿using FriendStorage.Model;
using FriendStorage.UI.Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FriendStorage.UITests.Wrapper
{
    [TestClass]
    public class ValidationComplexProperty
    {
        private Friend _friend;

        [TestInitialize]
        public void Initialize()
        {
            _friend = new Friend
            {
                FirstName = "Thomas",
                Address = new Address { City = "Müllheim" },
                Emails = new List<FriendEmail>()
            };
        }

        [TestMethod]
        public void ShouldSetIsValidOfRoot()
        {
            FriendWrapper wrapper = new FriendWrapper(_friend);
            Assert.IsTrue(wrapper.IsValid);

            wrapper.Address.City = "";
            Assert.IsFalse(wrapper.IsValid);

            wrapper.Address.City = "Salt Lake City";
            Assert.IsTrue(wrapper.IsValid);
        }

        [TestMethod]
        public void ShouldSetIsValidOfRootAfterInitialization()
        {
            _friend.Address.City = "";
            FriendWrapper wrapper = new FriendWrapper(_friend);
            Assert.IsFalse(wrapper.IsValid);

            wrapper.Address.City = "Salt Lake City";
            Assert.IsTrue(wrapper.IsValid);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsValidOfRoot()
        {
            bool fired = false;
            FriendWrapper wrapper = new FriendWrapper(_friend);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(wrapper.IsValid))
                {
                    fired = true;
                }
            };
            wrapper.Address.City = "";
            Assert.IsTrue(fired);

            fired = false;
            wrapper.Address.City = "Salt Lake City";
            Assert.IsTrue(fired);
        }
    }
}
