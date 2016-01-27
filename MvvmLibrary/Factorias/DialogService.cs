using System.Threading.Tasks;

namespace MvvmLibrary.Factorias
{
    public class DialogService:IDialogService
    {
        private readonly IPage _page;

        public DialogService(IPage page)
        {
            _page = page;
        }

        public Task MostrarAlerta(string titulo, string msg, string cancelar)
        {
            return _page.MostrarAlerta(titulo, msg, cancelar);
        }

        public async Task<bool> MostrarAlerta(string titulo, string msg, string cancelar, string aceptar)
        {
            return await _page.MostrarAlerta(titulo, msg, cancelar, aceptar);
        }

        public async Task<string> MostrarActionSheet(string titulo, string cancelar, string destruccion, params string[] botones)
        {
            return await _page.MostrarActionSheet(titulo, cancelar, destruccion, botones);
        }
    }
}