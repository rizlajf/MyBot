using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using System.Threading;
using MultiDialogsBot.Dialogs;

namespace MarkiBot.Dialogs
{
    [Serializable]
    public class SupportDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Sorry I could not understand your request, By the way I can help you out to search any products from Marki Microwave");
            PromptDialog.Choice(context, this.NextQuestionAsync, new List<string>() { "Yes", "No" }, "Please let me know if you want me to help you out to search any in Marki Microwave.");
        }

        public async Task NextQuestionAsync(IDialogContext context, IAwaitable<string> result)
        {
            string optionSelected = await result;
            try
            {
                if (optionSelected.ToString() == "Yes")
                {
                    await context.Forward(new RootDialog(), this.ResumeAfterRootDialog, null, CancellationToken.None);
                }
                else
                {
                    await context.PostAsync("You Said No");
                    await context.PostAsync("Thank you. Please feel free to seek any help from me if you need. Have a nice day!!");
                    context.Done(true);
                }
            }
            catch (Exception e)
            {

            }
        }

        public async Task ResumeAfterRootDialog(IDialogContext context, IAwaitable<object> result)
        {
            //context.Wait(this.MessageReceivedAsync);
            context.Done(true);
        }
    }
}