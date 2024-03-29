﻿using System.Windows;
using System.Windows.Controls;

namespace FriendStorage.UI.View.Services
{
    public partial class MessageDialog : Window
    {
        private MessageDialogResult _result;

        public MessageDialog(string title, string text, MessageDialogResult defaultResult, params MessageDialogResult[] buttons)
        {
            InitializeComponent();
            Title = title;
            textBlock.Text = text;
            InitializeButtons(buttons);
            _result = defaultResult;
        }

        private void InitializeButtons(MessageDialogResult[] buttons)
        {
            if (buttons == null || buttons.Length == 0)
            {
                buttons = new[] { MessageDialogResult.Ok };
            }
            foreach (MessageDialogResult button in buttons)
            {
                Button btn = new Button { Content = button, Tag = button };
                ButtonsPanel.Children.Add(btn);
                btn.Click += ButtonClick;
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                _result = (MessageDialogResult)button.Tag;
                Close();
            }
        }

        public new MessageDialogResult ShowDialog()
        {
            base.ShowDialog();
            return _result;
        }
    }
}
