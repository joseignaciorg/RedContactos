using System;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using Newtonsoft.Json;
using RedContactos.Servicios;
using RedContactos.Util;
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
                var us = await _servicio.ValidarUsuario(Usuario);
                if (us != null)
                {
                    var txt = JsonConvert.SerializeObject(us);
                    DependencyService.Get<IServicioFicheros>().GuardarTexto(txt,Cadenas.FicheroSettings); //guardamos el settings de usuairo en el dispositivo
                    Cadenas.Session["usuario"] = us; // guardo en el objeto session el usuario que se ha logado
                    //mirar!!!!!!!
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        Titulo = "Tus contactos";

                    });
                }
            }
            catch (Exception e)
            {
                await _Page.MostrarAlerta("Error", "Error en el login", "Aceptar");
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
                viewModel.Titulo = "Nuevo usuario"; 
                
            });
        }

    }
}