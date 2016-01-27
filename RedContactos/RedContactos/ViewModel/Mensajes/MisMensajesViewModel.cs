using System.Collections.ObjectModel;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Servicios;

namespace RedContactos.ViewModel.Mensajes
{
    public class MisMensajesViewModel:GeneralViewModel//Aqui mantendre todos mis mensajes mediante una colección
    {
        private ObservableCollection<MensajeModel> _mensajes;

        public ObservableCollection<MensajeModel> Mensajes
        {
            get {return _mensajes;}

            set {SetProperty(ref _mensajes,value);}
        }

        public MensajeModel MensajeSeleccionado
        {
            get {return _mensajeSeleccionado;}

            set
            {
                if(value!=null)
                    VerDetalleMensaje();

                SetProperty(ref _mensajeSeleccionado,value);
            }
        }

        private MensajeModel _mensajeSeleccionado; //con esto manejo el mensaje que ha tocado el usuario para que yo se lo  muestre
         
        public MisMensajesViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
        }

        private async void VerDetalleMensaje()
        {
            if (_mensajeSeleccionado !=null)
            {
                if (!_mensajeSeleccionado.leido)
                {
                    _mensajeSeleccionado.leido = true;
                    await _servicio.UpdateMensaje(_mensajeSeleccionado);
                }
                await _navigator.PushAsync<DetalleMensajeViewModel>(viewModel =>
                {
                    viewModel.Mensaje = _mensajeSeleccionado;
                    viewModel.Titulo = _mensajeSeleccionado.asunto;
                });
                MensajeSeleccionado = null;
            }

        }
        
    }
}