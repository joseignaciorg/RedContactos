using MvvmLibrary.Factorias;
using MvvmLibrary.ViewModel.Base;
using RedContactos.Servicios;

namespace RedContactos.ViewModel
{
    public class GeneralViewModel:ViewModelBase
    {
        protected INavigator _navigator;
        public IServicioMovil _servicio;
        public IPage _Page;

        public GeneralViewModel(INavigator navigator, IServicioMovil servicio, IPage page)
        {
            _navigator = navigator;
            _servicio = servicio;
            _Page = page;
        }
    }
}