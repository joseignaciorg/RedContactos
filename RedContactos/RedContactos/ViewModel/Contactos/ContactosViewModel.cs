using System.Collections.ObjectModel;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Models;
using RedContactos.Servicios;
using RedContactos.View.Contactos;
using Xamarin.Forms;

namespace RedContactos.ViewModel.Contactos
{
    public class ContactosViewModel:GeneralViewModel
    {
        private ObservableCollection<ContactoModel> _amigos;
        private ObservableCollection<NoAmigosModel> _noAmigos;
        private ContactoModel _contactoSeleccionado;

        public ObservableCollection<ContactoModel> Amigos
        {
            get { return _amigos; }
            set { SetProperty(ref _amigos, value); }
        }

        public ObservableCollection<NoAmigosModel> NoAmigos
        {
            get { return _noAmigos; }
            set { SetProperty(ref _noAmigos, value); }
        }

        public ContactoModel ContactoSeleccionado
        {
            get { return _contactoSeleccionado; }
            set
            {
                SetProperty(ref _contactoSeleccionado, value);
                if (value != null)
                {
                    RunAddMensaje();
                }
            }
        }

        public ICommand CmdNuevo { get; set; }//para añadir contactos

        public ContactosViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            CmdNuevo = new Command(RunNuevoContacto);
            
            //Sistema de mensajeria
            //Me estoy subscribiendo a los mensajes llamados hola con el .subscribe
            //<string>me estoy subscribiendo a mensajes de tipo string (tb le podria pasar un viewmodel)
            //this quien se subscribe a los mensajes(el objeto que se esta subscribiendo)
            //hola es le nombre del mensaje a enviar
            MessagingCenter.Subscribe<string>(this,"Hola", (sender) =>
            {
                var a = "";
            });

            

            //aqui el que envie un mensaje va a ser de tipo contactomodel
            MessagingCenter.Subscribe<ContactoModel>(this,"AddContacto", (sender) =>
            {
                Amigos.Add(sender);
            });

            //MessagingCenter.Unsubscribe<string>(this,"Hola");quito la subscripción
        }


        private async void RunNuevoContacto()
        {    
            //mensaje que se quiere enviar y hola es el nombre del mensaje.
            MessagingCenter.Send("Hola ¿como estas?","Hola");//envio el mensaje hola

            await _navigator.PushAsync<AddContactoViewModel>(viewModel =>
             {
                 viewModel.Amigos = Amigos;
                 viewModel.NoAmigos = NoAmigos;
             });
        }

        private async void RunAddMensaje()
        {
            await _navigator.PushAsync<EnviarMensajeViewModel>(viewModel =>
            {
                viewModel.Contacto = ContactoSeleccionado;
                viewModel.Mensaje = new MensajeModel();
            });
            ContactoSeleccionado = null;
        }
    }
}