using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
// МБ СТОИТ ТАКИ ПИСАТЬ НА КОРЕ



using CancellationTokenSource cts = new();


var botClient = new TelegramBotClient("6712069977:AAFibGJDBA4ihpSJKFNny0kZwpEx2jN0p_k");

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
};

botClient.StartReceiving(
    updateHandler: UpdatesAsync,
    pollingErrorHandler: PollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);
var botMe = await botClient.GetMeAsync();

Console.WriteLine($"Hey there! I'm user {botMe.Id} and everybody calls me {botMe.FirstName}!))");
var clientMessage = Console.ReadLine();





async Task UpdatesAsync(ITelegramBotClient arg1, Update update, CancellationToken arg3)
{
    var message = update.Message;
    var chatId = message.Chat.Id;
    await Console.Out.WriteLineAsync($"chat id is = {chatId}");

    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
{
    new KeyboardButton[] { "Shower schedule 🚿 " },
    new KeyboardButton[] { "Credentials for dorm payments 💳 " }
})
    {
        ResizeKeyboard = true
    };

    Message sentMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: $"chat id is = {chatId}",
        replyMarkup: replyKeyboardMarkup,
        cancellationToken: default);
}

async Task PollingErrorAsync(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
{
    throw new NotImplementedException();
}