using ChatStudents.Classes;
using ChatStudents.Models;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ChatStudents.Pages
{
    public partial class Login : Page
    {
        public string srcUserImage = "";
        public UsersContext usersContext = new UsersContext();

        public Login()
        {
            InitializeComponent();
        }

        private void SelectPhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите фотографию.";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                imgUser.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                srcUserImage = openFileDialog.FileName;
            }
        }

        public bool CheckEmpty(string Pattern, string Input)
        {
            if (string.IsNullOrEmpty(Input))
                return false;
            Match m = Regex.Match(Input, Pattern);
            return m.Success;
        }

        private async void Continue(object sender, RoutedEventArgs e)
        {
            // Проверяем что пользователь указал фамилию
            if (!CheckEmpty("^[А-ЯЁ][а-яА-ЯЁ]*$", LastName.Text))
            {
                MessageBox.Show("Укажите фамилию.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверяем что пользователь указал имя
            if (!CheckEmpty("^[А-ЯЁ][а-яА-ЯЁ]*$", FirstName.Text))
            {
                MessageBox.Show("Укажите имя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверяем что пользователь указал отчество (необязательно)
            if (!string.IsNullOrEmpty(Surname.Text))
            {
                if (!CheckEmpty("^[А-ЯЁ][а-яА-ЯЁ]*$", Surname.Text))
                {
                    MessageBox.Show("Отчество должно начинаться с заглавной буквы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            // Проверяем что пользователь указал изображение
            if (string.IsNullOrEmpty(srcUserImage))
            {
                MessageBox.Show("Выберите изображение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                byte[] photoBytes = File.ReadAllBytes(srcUserImage);
                var surnameValue = string.IsNullOrWhiteSpace(Surname.Text) ? null : Surname.Text;

                // Ищем пользователя
                var existingUser = usersContext.Users.FirstOrDefault(x =>
                    x.Firstname == FirstName.Text &&
                    x.Lastname == LastName.Text &&
                    x.Surname == surnameValue);

                if (existingUser != null)
                {
                    existingUser.Photo = photoBytes;
                    await usersContext.SaveChangesAsync();
                    MainWindow.Instance.LoginUser = existingUser;
                    MessageBox.Show($"Добро пожаловать, {existingUser.ToFIO()}!", "Успешный вход", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    var newUser = new Users(LastName.Text, FirstName.Text, surnameValue, photoBytes);
                    usersContext.Users.Add(newUser);
                    await usersContext.SaveChangesAsync();
                    MainWindow.Instance.LoginUser = newUser;
                    MessageBox.Show($"Пользователь {newUser.ToFIO()} успешно зарегистрирован!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                // Открываем главную страницу
                MainWindow.Instance.OpenPages(new MainPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}