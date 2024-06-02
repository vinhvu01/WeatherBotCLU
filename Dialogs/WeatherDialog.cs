using System.Net.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.BotBuilderSamples;
using Microsoft.Bot.Schema;
using Microsoft.BotBuilderSamples.Dialogs;
using System;
using Microsoft.Extensions.Configuration;
using WeatherBotCLU.Service;

namespace WeatherBotCLU.Dialogs
{
    public class WeatherDialog : CancelAndHelpDialog
    {
        private const string DestinationStepMsgText = "Where would you like to get the weather?";

        public const string UrlTimeLine = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline";

        public static string WeatherApiKey = "";

        public WeatherDialog(IConfiguration configuration)
            : base(nameof(WeatherDialog))
        {
            WeatherApiKey = configuration["WeatherAPIKey"];

            var waterfallSteps = new WaterfallStep[]
            {
                PromptForLocationStepAsync,
                FetchWeatherStepAsync
            };

            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));

            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> PromptForLocationStepAsync(WaterfallStepContext stepContext,
            CancellationToken cancellationToken)
        {
            var bookingDetails = (BookingDetails)stepContext.Options;
            if (bookingDetails.Destination == null)
            {
                if (bookingDetails.Origin == null)
                {
                    var promptMessage = MessageFactory.Text(DestinationStepMsgText, DestinationStepMsgText,
                        InputHints.ExpectingInput);
                    return await stepContext.PromptAsync(nameof(TextPrompt),
                        new PromptOptions { Prompt = promptMessage }, cancellationToken);
                }
                else
                {
                    return await stepContext.NextAsync(bookingDetails.Origin, cancellationToken);
                }
            }

            return await stepContext.NextAsync(bookingDetails.Destination, cancellationToken);
        }

        private async Task<DialogTurnResult> FetchWeatherStepAsync(WaterfallStepContext stepContext,
            CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty((string)stepContext.Result))
            {
                var bookingDetails = (BookingDetails)stepContext.Options;

                var location = stepContext.Result;

                var weather = GetWeather(location.ToString());
                await stepContext.Context.SendActivityAsync(MessageFactory.Text($"The weather in {location} is: {weather}"),
                    cancellationToken);
            }
           
            return await stepContext.EndDialogAsync(null, cancellationToken);
        }

        private string GetWeather(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                return "Sorry, I didn't get that. Please try asking in a different way";
            }

            var restService = new RestService();
            var datetime = DateTime.Now;
            var url = $"{UrlTimeLine}/{location}/{datetime:yyyy-MM-ddTHH:mm:ss}?key={WeatherApiKey}";
            var results = restService.GetWeatherData(url);

            if (results != null)
            {
                var description = results.Days[0].Description;
                var temperature = results.Days[0].Temp;

                return $"{description}. The temperature of {temperature}°F";
            }

            return "Sorry, I didn't get that. Please try asking in a different way";
        }
    }
}