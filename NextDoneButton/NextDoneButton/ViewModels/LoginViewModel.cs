using AppORCA.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NextDoneButton.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand loginCmd { get; set; }

        public LoginViewModel()
        {
            loginCmd = new Command(async () => await LoginAsync());
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }


        private async Task LoginAsync()
        {
            await App.Current.MainPage.DisplayAlert("Información", "Se llama método en ViewModel desde Entry", "Ok");
        }

    }
}
