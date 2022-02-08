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

        public static async Task<bool?> Confirm(IDialogService DialogService)
        {
           
            return  await DialogService.ShowMessageBox("Warning",
            "Deleting can not be undone!",
            yesText: "Delete!", cancelText: "Cancel");

            
        }
    }
}
