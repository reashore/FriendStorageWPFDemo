﻿using FriendStorage.Model;
using FriendStorage.UI.Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FriendStorage.UITests.Wrapper
{
    [TestClass]
    public class ChangeNotificationComplexProperty
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
        public void ShouldInitializeAddressProperty()
        {
            FriendWrapper wrapper = new FriendWrapper(_friend);
            Assert.IsNotNull(wrapper.Address);
            Assert.AreEqual(_friend.Address, wrapper.Address.Model);
        }
    }
}
