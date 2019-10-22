using System.Windows;

namespace FriendStorage.UI.View.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public MessageDialogResult ShowYesNoDialog(string title, string text,
          MessageDialogResult defaultResult = MessageDialogResult.Yes)
        {
            MessageDialog dlg = new MessageDialog(title, text, defaultResult, MessageDialogResult.Yes, MessageDialogResult.No)
            {
                Owner = Application.Current.MainWindow
            };
            return dlg.ShowDialog();
        }
    }
}
