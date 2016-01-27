using System.Collections.ObjectModel;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Servicios;
using RedContactos.Util;
using RedContactos.ViewModel.Contactos;
using RedContactos.ViewModel.Mensajes;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class PincipalViewModel:GeneralViewModel
    {
        public ICommand CmdContactos { get; set; }
        public ICommand CmdMensajes { get; set; }

        public PincipalViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            CmdContactos=new Command(RunContactos);
            CmdMensajes=new Command(RunMensajes);
        }

        private async void RunMensajes()
        {
            IsBusy = true;
            var yo = Cadenas.Session["usuario"] as UsuarioModel;
            var data = await _servicio.GetMensajes(yo.id);
            await _navigator.PushAsync<MisMensajesViewModel>(viewmodel =>
                    {
                        viewmodel.Mensajes = new ObservableCollection<MensajeModel>(data); 
                        
                    });
        }

        private async void RunContactos()
        {
            IsBusy = true;
            var yo = Cadenas.Session["usuario"] as UsuarioModel;
            var amigos = await _servicio.GetContactos(true,yo.id);
            var noamigos = await _servicio.GetContactos(false, yo.id);
            await _navigator.PushAsync<ContactosViewModel>(viewmodel =>
            {
                viewmodel.Amigos = new ObservableCollection<ContactoModel>(amigos);
                viewmodel.NoAmigos=new ObservableCollection<ContactoModel>(noamigos);

            });
        }
    }
}