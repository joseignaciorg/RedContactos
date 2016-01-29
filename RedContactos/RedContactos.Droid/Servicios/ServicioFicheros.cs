﻿using System;
using System.IO;
using RedContactos.Droid.Servicios;
using RedContactos.Servicios;
using Xamarin.Forms;

[assembly:Dependency(typeof(ServicioFicheros))] //habilita la inyeccion de la dependencia de dispositivo es decir para que sepa
//si es andorid, ios o winphone
namespace RedContactos.Droid.Servicios
{
    public class ServicioFicheros:IServicioFicheros
    {
        public void GuardarTexto(string texto, string fichero)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var rutafinal = Path.Combine(path, fichero);
            File.WriteAllText(rutafinal,texto);
        }

        public string RecuperarTexto(string fichero)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var rutafinal = Path.Combine(path, fichero);
            try
            {
                return File.ReadAllText(rutafinal);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}