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

        public static async Task<bool> Confirm(IDialogService DialogService,string Title,string prompt,string yes,string cancel)
        {            
            var result = await DialogService.ShowMessageBox(Title,prompt,yesText: yes, cancelText: cancel);
            if (result !=null && result==true)
            {
                return true;
            }            
            return false;
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

        public static async Task<bool?> InputDialog(IDialogService DialogService, string Title, string prompt, string ok)
        {
            bool license_accepted = false;
            var options = new DialogOptions { DisableBackdropClick = false, CloseOnEscapeKey = true, CloseButton = true };
            var parameters = new DialogParameters();
            var result = await DialogService.Show<Shared.DialogInput>(Title, parameters, options).Result;
            if (!result.Cancelled)
            {
                license_accepted = (bool)(result.Data ?? false);
            }
            return license_accepted;
        }

        public static async Task<bool?> OptionsDialog(IDialogService DialogService, string Title, string prompt, string ok)
        {
            bool license_accepted = false;
            var options = new DialogOptions { DisableBackdropClick = false, CloseOnEscapeKey = true, CloseButton = true };
            var parameters = new DialogParameters();
            var result = await DialogService.Show<Shared.OptionsDialog>(Title, parameters, options).Result;
            if (!result.Cancelled)
            {
                license_accepted = (bool)(result.Data ?? false);
            }
            return license_accepted;
        }

        public static async Task<bool?> MessageScroll(IDialogService DialogService, string Title, string prompt, string ok)
        {
            bool license_accepted = false;
            var options = new DialogOptions { DisableBackdropClick = false, CloseOnEscapeKey = true, CloseButton = true };
            var parameters = new DialogParameters();
           
           
           
            var result = await DialogService.Show<Shared.DialogMessage>(Title,parameters,options).Result;

            if (!result.Cancelled)
            {
                license_accepted = (bool)(result.Data ?? false);
            }
            return license_accepted;
        }

        public static async Task<bool?> ConfirmDelete(IDialogService DialogService)
        {
            var options = new DialogOptions { DisableBackdropClick = false,CloseOnEscapeKey=true, CloseButton = true };
            return await ConfirmWithOptions(DialogService, "Attenzione!","Vuoi Eliminare questo record?","Si,Elimina!", "Annulla", options);
        }

        public static async Task<bool?> ConfirmDelete2(IDialogService DialogService)
        {
            
            var options = new DialogOptions { DisableBackdropClick = false, CloseOnEscapeKey = true, CloseButton = true };         
            bool ret = false;
           var a= DialogService.Show<Shared.DialogDelete>("", options);
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
