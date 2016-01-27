using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Servicios;

namespace RedContactos.ViewModel.Mensajes
{
    public class DetalleMensajeViewModel:GeneralViewModel //cuando el usuario entre a ver un mensaje se lo mostramos
    {
        private MensajeModel _mensaje; //mostramos todos los campos del modelo mensaje por eso es de tipo MensajeModel
        public MensajeModel Mensaje
        {
            get {return _mensaje;}

            set {SetProperty (ref _mensaje , value);}
        }
        public DetalleMensajeViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
        }

        
    }
}