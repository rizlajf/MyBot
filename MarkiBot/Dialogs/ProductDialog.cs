namespace MultiDialogsBot.Dialogs
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    using System.Collections.Generic;
    using System.Web;

    [Serializable]
    public class ProductDialog : IDialog<int>
    {
        public async Task StartAsync(IDialogContext context)
        {            
            context.Wait(this.MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() { "Amplifiers", "Balun", "Bias Tees", "Couplers", "Equalizers" }, "Which Product category are you looking to buy?", "Not a valid option", 3);
        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var resultMessage = context.MakeMessage();
                resultMessage.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                resultMessage.Attachments = new List<Attachment>();

                string optionSelected = await result;
                HeroCard heroCard = null;

                switch (optionSelected)
                {
                    case "Amplifiers":
                         heroCard = new HeroCard()
                            {
                                Title = "Amplifiers",                             
                                Buttons = new List<CardAction>()
                                {
                                    new CardAction()
                                    {
                                        Title = "More details",
                                        Type = ActionTypes.OpenUrl,
                                        Value = "http://dev.markimicrowave.com/amplifiers/amplifiers-products.aspx"
                                    }
                                }
                            };  
                        break;

                    case "Balun":
                         heroCard = new HeroCard()
                        {
                            Title = "Balun",
                            Buttons = new List<CardAction>()
                                {
                                    new CardAction()
                                    {
                                        Title = "More details",
                                        Type = ActionTypes.OpenUrl,
                                        Value = "http://dev.markimicrowave.com/baluns/baluns-products.aspx"
                                    }
                                }
                        };
                        break;
                    case "Bias Tees":
                        heroCard = new HeroCard()
                        {
                            Title = "Bias Tees",
                            Buttons = new List<CardAction>()
                                {
                                    new CardAction()
                                    {
                                        Title = "More details",
                                        Type = ActionTypes.OpenUrl,
                                        Value = "http://dev.markimicrowave.com/bias-tees/bias-tees-products.aspx"
                                    }
                                }
                        };
                        break;
                    case "Couplers":
                        heroCard = new HeroCard()
                        {
                            Title = "Couplers",
                            Buttons = new List<CardAction>()
                                {
                                    new CardAction()
                                    {
                                        Title = "More details",
                                        Type = ActionTypes.OpenUrl,
                                        Value = "http://dev.markimicrowave.com/couplers/couplers-products.aspx"
                                    }
                                }
                        };
                        break;
                    case "Equalizers":
                        heroCard = new HeroCard()
                        {
                            Title = "Equalizers",
                            Buttons = new List<CardAction>()
                                {
                                    new CardAction()
                                    {
                                        Title = "More details",
                                        Type = ActionTypes.OpenUrl,
                                        Value = "http://dev.markimicrowave.com/equalizers/equalizers-products.aspx"
                                    }
                                }
                        };
                        break;
                }
                resultMessage.Attachments.Add(heroCard.ToAttachment());
                await context.PostAsync(resultMessage);
            }
            catch (TooManyAttemptsException ex)
            {
                await context.PostAsync($"Ooops! Too many attemps :(. But don't worry, I'm handling that exception and you can try again!");

                context.Wait(this.MessageReceivedAsync);
            }
            finally
            {
                PromptDialog.Choice(context, this.MoreQuestionAsync, new List<string>() { "Yes", "No" }, "Is anything else I can help you out?");                
                //context.Wait(this.MessageReceivedAsync);                
            }
        }

        public async Task MoreQuestionAsync(IDialogContext context, IAwaitable<string> result)
        {
            string selectedOption = await result;
            try
            {
                if (selectedOption.ToString() == "Yes")
                {
                    await context.PostAsync("What can I do for you?");
                }
                else
                {
                    await context.PostAsync("Thank you. Please feel free to seek any help from me if you need. Have a nice day!!");
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                context.Done<string>(null);
            }
        }
    }
}