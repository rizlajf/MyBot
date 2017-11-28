using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using MultiDialogsBot.Dialogs;
using System.Collections.Generic;
using System.Threading;
//using Microsoft.Bot.Builder.FormFlow;

namespace MarkiBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private const string FlightsOption = "Flights";

        private const string HotelsOption = "Hotels";
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            //await context.PostAsync("Sorry I could not understand your request, By the way I can help you out to search any products from Marki Microwave");
            PromptDialog.Choice(context, this.NextQuestionAsync, new List<string>() { "Products", "Videos", "Application Notes", "Contact Info" }, "Please Select what you want to search from these .");           
        }

        public async Task NextQuestionAsync(IDialogContext context, IAwaitable<string> result)
        {
            string optionSelected = await result;
            try
            {
                if (optionSelected.ToString() == "Products")
                {
                    await context.Forward(new ProductDialog(), this.ResumeAfterProductDialog, null, CancellationToken.None);
                }
                else if (optionSelected.ToString() == "Videos")
                {
                    var message = context.MakeMessage();
                    var attachment = GetVideoCard();
                    message.Attachments.Add(attachment);
                    await context.PostAsync(message);
                }
                else if (optionSelected.ToString() == "Application Notes")
                {                   
                    context.Done(true);
                }
                else if (optionSelected.ToString() == "Contact Info")
                {
                    context.Done(true);
                }
            }
            catch (Exception e)
            {

            }
        }

        private static Attachment GetVideoCard()
        {
            var videoCard = new VideoCard
            {
                Title = "Mixer Basics Video",
                //Subtitle = "by the Blender Institute",
                Text = "In this video Doug Jorgesen explains the motivations, basic operations, and some applications of IQ, image reject, and single sideband mixers.",
                Image = new ThumbnailUrl
                {
                    Url = ""
                },
                Media = new List<MediaUrl>
                {
                    new MediaUrl()
                    {
                        Url = "https://www.youtube.com/embed/_DQ24Sj0ArA?rel=0"
                    }
                }
                //,
                //Buttons = new List<CardAction>
                //{
                //    new CardAction()
                //    {
                //        Title = "Learn More",
                //        Type = ActionTypes.OpenUrl,
                //        Value = "https://peach.blender.org/"
                //    }
                //}
            };

            return videoCard.ToAttachment();
        }

        public async Task ResumeAfterProductDialog(IDialogContext context, IAwaitable<int> result)
        {
            context.Wait(this.MessageReceivedAsync);
        }      

        #region Exisitng Sample code
        //private void ShowOptions(IDialogContext context)
        //{
        //    PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() { FlightsOption, HotelsOption }, "Are you looking for a flight or a hotel?", "Not a valid option", 3);
        //}

        //private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        //{
        //    try
        //    {
        //        string optionSelected = await result;

        //        switch (optionSelected)
        //        {
        //            case FlightsOption:
        //                context.Call(new FlightsDialog(), this.ResumeAfterOptionDialog);
        //                break;

        //            case HotelsOption:
        //                context.Call(new HotelsDialog(), this.ResumeAfterOptionDialog);
        //                break;
        //        }
        //    }
        //    catch (TooManyAttemptsException ex)
        //    {
        //        await context.PostAsync($"Ooops! Too many attemps :(. But don't worry, I'm handling that exception and you can try again!");

        //        context.Wait(this.MessageReceivedAsync);
        //    }
        //}

        private async Task ResumeAfterSupportDialog(IDialogContext context, IAwaitable<int> result)
        {
            var ticketNumber = await result;

            await context.PostAsync($"Thanks for contacting our support team. Your ticket number is {ticketNumber}.");
            context.Wait(this.MessageReceivedAsync);
        }

        private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var message = await result;
            }
            catch (Exception ex)
            {
                await context.PostAsync($"Failed with message: {ex.Message}");
            }
            finally
            {
                context.Wait(this.MessageReceivedAsync);
            }
        }
        #endregion
        
    }
}