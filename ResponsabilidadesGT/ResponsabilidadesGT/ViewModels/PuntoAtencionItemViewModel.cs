
namespace ResponsabilidadesGT.ViewModels
{
    using ResponsabilidadesGT.Models;
    using System.Windows.Input;
    using Xamarin.Forms;

    class PuntoAtencionItemViewModel:PuntodeAtencion
    {
        public ICommand UrlCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri($"http://{url}"));
        });
    }
}
