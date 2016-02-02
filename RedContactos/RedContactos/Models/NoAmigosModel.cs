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


        private async void RunComandoAdd()
        {
            var vm = ComponentContext.Resolve<AddContactoViewModel>();
            var d=await vm._servicio.AddContacto(ContactoModel);
            if (d!=null)
            {
                //vm.Amigos.Add(ContactoModel);

                MessagingCenter.Send(ContactoModel,"AddContacto");//envio al contacto model a quien quiera recibirlo es decir a quien este subscrito

                vm.NoAmigos.Remove(this);
                await vm._Page.MostrarAlerta("Exito", "Contacto añadido como Amigo", "Ok");
            }
            else
            {
                await vm._Page.MostrarAlerta("Error", "Contacto no añadido como amigo", "Ok");
            }
        }
    }
}