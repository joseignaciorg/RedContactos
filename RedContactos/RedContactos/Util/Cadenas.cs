using System.Collections.Generic;

namespace RedContactos.Util
{
    public static class Cadenas
    {
        //al ser estatico se arranca nada mas inicializar el proyecto
         public static string Url = "http://apicontactosnacho.azurewebsites.net/api"; //Añadimos el "/api" !!!!!!

         public static Dictionary<object,object> Session = new Dictionary<object, object>(); 
    }
}