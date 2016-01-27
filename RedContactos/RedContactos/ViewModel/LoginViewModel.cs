using System;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Servicios;
using RedContactos.ViewModel.Contactos;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        private UsuarioModel _usuario;
        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public ICommand CmdLogin { get; set; }
        public ICommand CmdAlta { get; set; }

        public LoginViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            _usuario=new UsuarioModel();
            CmdLogin=new Command(RunLogin);
            CmdAlta=new Command(RunAlta);
        }

        private async void RunLogin()
        {
            try
            {
                IsBusy = true;
                var us=await _servicio.ValidarUsuario(Usuario);
                if (us != null)
                {
                    //mirar!!!!!!!
                    await _navigator.PushAsync<ContactosViewModel>(viewModel =>
                    {
                        Titulo = "Tus contactos";

                    });
                }
                else
                {
                    //TODo:Informar
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void RunAlta()
        {
            await _navigator.PushAsync<AltaViewModel>(viewModel =>
            {
                Titulo = "Nuevo usuario"; 
                
            });
        }

    }
}