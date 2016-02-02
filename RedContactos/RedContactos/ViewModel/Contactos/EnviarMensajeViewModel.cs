using System;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Servicios;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel.Contactos
{
    public class EnviarMensajeViewModel:GeneralViewModel
    {
        private ContactoModel _contacto;
        private MensajeModel _mensaje;

        public ContactoModel Contacto
        {
            get { return _contacto; }
            set { SetProperty(ref _contacto, value); }
        }

        public MensajeModel Mensaje
        {
            get { return _mensaje; }
            set {SetProperty(ref _mensaje,value); }
        }

        public ICommand CmdEnviar { get; set; }

        public EnviarMensajeViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            CmdEnviar=new Command(RunEnviarMensaje);
        }

        private async void RunEnviarMensaje()
        {
            MessagingCenter.Send("Estoy en mensajes","Hola");
            try
            {
                IsBusy = true;
                Mensaje.idOrigen = Contacto.idOrigen;
                Mensaje.fecha=DateTime.Now;
                Mensaje.IdDestino = Contacto.idDestino;
                Mensaje.leido = false;//se podira omitir, porque cualquier boolean por defecto es false
                var r=await _servicio.AddMensaje(Mensaje);
                if (r != null)
                {
                    await _Page.MostrarAlerta("Exito", "Mensaje enviado", "Aceptar");
                }
                else
                {
                    await _Page.MostrarAlerta("Error", "No se pudo enviar", "Aceptar");
                }
            }
            finally
            {
                IsBusy = false;
            }


        }

       
    }
}