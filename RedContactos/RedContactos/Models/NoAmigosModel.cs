using System.Windows.Input;
using Autofac;
using ContactosModel.Model;
using RedContactos.ViewModel.Contactos;
using Xamarin.Forms;

namespace RedContactos.Models
{
    public class NoAmigosModel // define un objeto de tipo contacto model, un comand para cada una.
    {
        public ICommand CmdAdd { get; set; }
        public ContactoModel ContactoModel { get; set; }
        public IComponentContext ComponentContext { get; set; }

        public NoAmigosModel()
        {
            CmdAdd=new Command(RunComandoAdd);
        }


        private void RunComandoAdd()
        {
            var vm = ComponentContext.Resolve<AddContactoViewModel>();
            vm.Amigos.Add(ContactoModel);
            vm.NoAmigos.Remove(this);
        }
    }
}