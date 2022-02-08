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

        public static async Task<bool?> ConfirmWithOptions(IDialogService DialogService, string Title, string prompt, string yes, string cancel, DialogOptions options)
        {

            return await DialogService.ShowMessageBox(Title,
            prompt,
             yes, null, cancel, options);
        }

        public static async Task<bool?> Message(IDialogService DialogService, string Title, string prompt,string ok)
        {

            return await DialogService.ShowMessageBox(Title,
            prompt,
             ok, null, null, null);
        }

        public static async Task<bool?> ConfirmDelete(IDialogService DialogService)
        {
            var options = new DialogOptions { DisableBackdropClick = false,CloseOnEscapeKey=true, CloseButton = true };
            return await ConfirmWithOptions(DialogService, "Attenzione!","Vuoi Eliminare questo record?","Si,Elimina!", "Annulla", options);
        }

        public static async Task<bool?> ConfirmDelete2(IDialogService DialogService)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you really want to delete these records? This process cannot be undone.");
            parameters.Add("ButtonText", "Delete");
            parameters.Add("Color", Color.Error);
            var options = new DialogOptions { DisableBackdropClick = false, CloseOnEscapeKey = true, CloseButton = true };
            var result =  ConfirmWithParameters(DialogService,"Elimina", parameters, options);
            if (result!=null )
            {
                return true;
            }
            return false;
        }

        public static async Task<bool> ConfirmWithParameters(IDialogService DialogService, string Title,  DialogParameters parameters, DialogOptions options)
        {
            bool ret = false;
           var a= DialogService.Show<Shared.DialogDelete>(Title, options);
            var result = await a.GetReturnValueAsync<object>();
            if (result != null)
            {
                if ((bool)result==true)
                {
                    ret = true;
                }
            }
           
            return ret;
        }


    }
}
