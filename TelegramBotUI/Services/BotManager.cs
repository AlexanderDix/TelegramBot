using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotUI.Services
{
    internal class BotManager
    {
        #region Fields

        private readonly CancellationTokenSource _cts = new();

        #endregion

        #region Properties

        #endregion

        #region Methods

        private async Task HandleUpdateAsync(ITelegramBotClient bot, Update update,
            CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message)
            {
                Message message = update.Message;

                if (message?.Text is null) return;

                if (message.Text.ToLower() == "/start")
                {
                    await bot.SendTextMessageAsync(message.Chat, "Добро пожаловать!",
                        cancellationToken: cancellationToken);
                    return;
                }

                await bot.SendTextMessageAsync(message.Chat, "Привет", cancellationToken: cancellationToken);
            }
        }

        private static async Task HandleErrorAsync(ITelegramBotClient bot, Exception exception,
            CancellationToken cancellationToken)
        {
            await Task.Run(() => MessageBox.Show($"{exception}"), cancellationToken);
        }

        #endregion

        #region Constructors

        public BotManager(TokenService tokenService)
        {
            try
            {
                ITelegramBotClient botClient = new TelegramBotClient(tokenService.GetToken());
                CancellationToken cancellationToken = _cts.Token;
                var receiverOptions = new ReceiverOptions
                {
                    AllowedUpdates = { }
                };
                botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Ошибка запуска бота");
            }
        }

        #endregion
    }
}