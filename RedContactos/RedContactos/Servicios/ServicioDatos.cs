using System.Collections.Generic;
using System.Threading.Tasks;
using ContactosModel.Model;
using RedContactos.Util;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace RedContactos.Servicios
{
    public class ServicioDatos : IServicioMovil
    {
        private RestClient client;

        public ServicioDatos()
        {
            client = new RestClient(Cadenas.Url);
        }

        public async Task<UsuarioModel> ValidarUsuario(UsuarioModel usuario)
        {
            var request = new RestRequest("Usuario");//hace referencia al controlador Usuario de la Api
            //Al request se le pueden añadir Headers, y al client se le pueden añadir credentials
            request.Method = Method.GET;
            request.AddQueryParameter("login",usuario.login);
            request.AddQueryParameter("password",usuario.password);

            var reponse = await client.Execute<UsuarioModel>(request);
            if (reponse.IsSuccess)
                return reponse.Data;
            return null;
        }

        public async Task<bool> UsuarioNuevo(string login)
        {
            var request = new RestRequest("Usuario");
            request.Method = Method.GET;
            request.AddQueryParameter("login", login);

            var reponse = await client.Execute<bool>(request);
            if (reponse.IsSuccess)
                return reponse.Data;
            return false;
        }

        public async Task<UsuarioModel> AddUsuario(UsuarioModel usuario)
        {
            var request = new RestRequest("Usuario")
            {
                Method = Method.POST //Esta es otra forma de hacerlo.
            };
            request.AddJsonBody(usuario);
            var reponse = await client.Execute<UsuarioModel>(request);
            
            if (reponse.IsSuccess)
                return reponse.Data;
            return null;
        }

        public async Task<List<ContactoModel>> GetContactos(bool actuales, int id)
        {
            var request = new RestRequest("Contacto"); //contacto hace referencia al controlador de la Api
            request.Method = Method.GET;
            request.AddQueryParameter("id", id);
            request.AddQueryParameter("amigos", actuales);

            var reponse = await client.Execute<List<ContactoModel>>(request);
            if (reponse.IsSuccess)
                return reponse.Data;
            return null;
        }

        public async Task<ContactoModel> AddContacto(ContactoModel contacto)
        {
            var request = new RestRequest("Contacto")//contacto hace referencia al controlador de la Api
            {
                Method = Method.POST //Esta es otra forma de hacerlo.
            };
            request.AddJsonBody(contacto);
            var reponse = await client.Execute<ContactoModel>(request);

            if (reponse.IsSuccess)
                return reponse.Data;
            return null;
        }

        public async Task DelContacto(ContactoModel contacto)
        {
            var request = new RestRequest("Contacto")//contacto hace referencia al controlador de la Api
            {
                Method = Method.DELETE //Esta es otra forma de hacerlo.
            };
            request.AddJsonBody(contacto);
            await client.Execute(request); 
        }

        public async Task<List<MensajeModel>> GetMensajes(int id)
        {
            var request = new RestRequest("Mensaje"); //Mensaje hace referencia al controlador de la Api
            request.Method = Method.GET;
            request.AddQueryParameter("id", id);

            var reponse = await client.Execute<List<MensajeModel>>(request);
            if (reponse.IsSuccess)
                return reponse.Data;
            return null;
        }

        public async Task<MensajeModel> AddMensaje(MensajeModel mensaje)
        {
            var request = new RestRequest("Mensaje")//Mensaje hace referencia al controlador de la Api
            {
                Method = Method.POST //Esta es otra forma de hacerlo.
            };
            request.AddJsonBody(mensaje);
            var reponse = await client.Execute<MensajeModel>(request);

            if (reponse.IsSuccess)
                return reponse.Data;
            return null;
        }

        public async Task UpdateMensaje(MensajeModel mensaje)
        {
            var request = new RestRequest("Mensaje")//Mensaje hace referencia al controlador de la Api
            {
                Method = Method.PUT //Esta es otra forma de hacerlo.
            };
            request.AddJsonBody(mensaje);
            await client.Execute(request);

        }
    }
}