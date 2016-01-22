﻿using Autofac;
using MvvmLibrary.Factorias;
using MvvmLibrary.ModuloBase;
using RedContactos.View;
using RedContactos.ViewModel;
using Xamarin.Forms;

namespace RedContactos.Module
{
    public class StartUp:AutofacBootstrapper
    {
        private readonly App _application;

        public StartUp(App application)
        {
            _application = application;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<ContactosModule>();
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<LoginViewModel, LoginView>();
            viewFactory.Register<AltaViewModel, AltaView>();
            viewFactory.Register<ContactosViewModel, ContactosView>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var main = viewFactory.Resolve<LoginViewModel>();
            var np = new NavigationPage(main);
            _application.MainPage = np;
        }
    }
}
