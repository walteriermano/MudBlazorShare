using MudBlazor;

namespace MudServer.Helpers
{
    public class Mudary
    {
        public Mudary(IDialogService DialogService)
        {
            this.DialogService = DialogService;
        }

        public IDialogService DialogService { get; }

        public static async Task<bool?> Confirm(IDialogService DialogService,string Title,string prompt,string yes,string cancel)
        {           
            return  await DialogService.ShowMessageBox(Title,
            prompt,
            yesText: yes, cancelText: cancel);            
        }

        public static async Task<bool?> ConfirmDelete(IDialogService DialogService)
        {
            return await Confirm(DialogService, "Attenzione!","Vuoi Eliminare questo record?","Si,Elimina!", "Annulla");
        }
    }
}
