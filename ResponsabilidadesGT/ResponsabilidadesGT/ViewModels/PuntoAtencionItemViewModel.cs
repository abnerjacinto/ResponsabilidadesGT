
namespace ResponsabilidadesGT.ViewModels
{
    
    using System.Windows.Input;
    using Xamarin.Forms;

    class PuntoAtencionItemViewModel:Models.PuntodeAtencion
    {
        public ICommand UrlCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri($"http://{url}"));
        });
    }
}
