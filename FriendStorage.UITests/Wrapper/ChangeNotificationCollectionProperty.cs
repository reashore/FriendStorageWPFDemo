using FriendStorage.Model;
using FriendStorage.UI.Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FriendStorage.UITests.Wrapper
{
    [TestClass]
    public class ChangeNotificationCollectionProperty
    {
        private Friend _friend;
        private FriendEmail _friendEmail;

        [TestInitialize]
        public void Initialize()
        {
            _friendEmail = new FriendEmail { Email = "thomas@thomasclaudiushuber.com" };
            _friend = new Friend
            {
                FirstName = "Thomas",
                Address = new Address(),
                Emails = new List<FriendEmail>
        {
          new FriendEmail {Email="julia@juhu-design.com" },
          _friendEmail,
        }
            };
        }

        [TestMethod]
        public void ShouldInitializeEmailsProperty()
        {
            FriendWrapper wrapper = new FriendWrapper(_friend);
            Assert.IsNotNull(wrapper.Emails);
            CheckIfModelEmailsCollectionIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterRemovingEmail()
        {
            FriendWrapper wrapper = new FriendWrapper(_friend);
            FriendEmailWrapper emailToRemove = wrapper.Emails.Single(ew => ew.Model == _friendEmail);
            wrapper.Emails.Remove(emailToRemove);
            CheckIfModelEmailsCollectionIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterAddingEmail()
        {
            _friend.Emails.Remove(_friendEmail);
            FriendWrapper wrapper = new FriendWrapper(_friend);
            wrapper.Emails.Add(new FriendEmailWrapper(_friendEmail));
            CheckIfModelEmailsCollectionIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterClearingEmails()
        {
            FriendWrapper wrapper = new FriendWrapper(_friend);
            wrapper.Emails.Clear();
            CheckIfModelEmailsCollectionIsInSync(wrapper);
        }

        private void CheckIfModelEmailsCollectionIsInSync(FriendWrapper wrapper)
        {
            Assert.AreEqual(_friend.Emails.Count, wrapper.Emails.Count);
            Assert.IsTrue(_friend.Emails.All(e =>
                        wrapper.Emails.Any(we => we.Model == e)));
        }
    }
}
