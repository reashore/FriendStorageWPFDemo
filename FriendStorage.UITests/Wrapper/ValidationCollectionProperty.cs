﻿using FriendStorage.Model;
using FriendStorage.UI.Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FriendStorage.UITests.Wrapper
{
    [TestClass]
    public class ValidationCollectionProperty
    {
        private Friend _friend;

        [TestInitialize]
        public void Initialize()
        {
            _friend = new Friend
            {
                FirstName = "Thomas",
                Address = new Address { City = "Müllheim" },
                Emails = new List<FriendEmail>
        {
          new FriendEmail { Email="thomas@thomasclaudiushuber.com" },
          new FriendEmail {Email="julia@juhu-design.com" }
        }
            };
        }

        [TestMethod]
        public void ShouldSetIsValidOfRoot()
        {
            FriendWrapper wrapper = new FriendWrapper(_friend);
            Assert.IsTrue(wrapper.IsValid);

            wrapper.Emails.First().Email = "";
            Assert.IsFalse(wrapper.IsValid);

            wrapper.Emails.First().Email = "thomas@thomasclaudiushuber.com";
            Assert.IsTrue(wrapper.IsValid);
        }

        [TestMethod]
        public void ShouldSetIsValidOfRootWhenInitializing()
        {
            _friend.Emails.First().Email = "";
            FriendWrapper wrapper = new FriendWrapper(_friend);
            Assert.IsFalse(wrapper.IsValid);
            Assert.IsFalse(wrapper.HasErrors);
            Assert.IsTrue(wrapper.Emails.First().HasErrors);
        }

        [TestMethod]
        public void ShouldSetIsValidOfRootWhenRemovingInvalidItem()
        {
            FriendWrapper wrapper = new FriendWrapper(_friend);
            Assert.IsTrue(wrapper.IsValid);

            wrapper.Emails.First().Email = "";
            Assert.IsFalse(wrapper.IsValid);

            wrapper.Emails.Remove(wrapper.Emails.First());
            Assert.IsTrue(wrapper.IsValid);
        }

        [TestMethod]
        public void ShouldSetIsValidOfRootWhenAddingInvalidItem()
        {
            FriendEmailWrapper emailToAdd = new FriendEmailWrapper(new FriendEmail());
            FriendWrapper wrapper = new FriendWrapper(_friend);
            Assert.IsTrue(wrapper.IsValid); 
            wrapper.Emails.Add(emailToAdd);
            Assert.IsFalse(wrapper.IsValid);
            emailToAdd.Email = "thomas@thomasclaudiushuber.com";
            Assert.IsTrue(wrapper.IsValid);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsValidOfRoot()
        {
            bool fired = false;
            FriendWrapper wrapper = new FriendWrapper(_friend);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "IsValid")
                {
                    fired = true;
                }
            };
            wrapper.Emails.First().Email = "";
            Assert.IsTrue(fired);

            fired = false;
            wrapper.Emails.First().Email = "thomas@thomasclaudiushuber.com";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsValidOfRootWhenRemovingInvalidItem()
        {
            bool fired = false;
            FriendWrapper wrapper = new FriendWrapper(_friend);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "IsValid")
                {
                    fired = true;
                }
            };
            wrapper.Emails.First().Email = "";
            Assert.IsTrue(fired);

            fired = false;
            wrapper.Emails.Remove(wrapper.Emails.First());
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsValidOfRootWhenAddingInvalidItem()
        {
            bool fired = false;
            FriendWrapper wrapper = new FriendWrapper(_friend);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "IsValid")
                {
                    fired = true;
                }
            };

            FriendEmailWrapper emailToAdd = new FriendEmailWrapper(new FriendEmail());
            wrapper.Emails.Add(emailToAdd);
            Assert.IsTrue(fired);

            fired = false;
            emailToAdd.Email = "thomas@thomasclaudiushuber.com";
            Assert.IsTrue(fired);
        }
    }
}
