using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
// МБ СТОИТ ТАКИ ПИСАТЬ НА КОРЕ

// 6712069977:AAFibGJDBA4ihpSJKFNny0kZwpEx2jN0p_k

Console.WriteLine("DORM BOT");

var botClient = new TelegramBotClient("6712069977:AAFibGJDBA4ihpSJKFNny0kZwpEx2jN0p_k");

using CancellationTokenSource cts = new();

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

async Task UpdatesAsync(ITelegramBotClient arg1, Update message, CancellationToken arg3)
{
    throw new NotImplementedException();
}

async Task PollingErrorAsync(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
{
    throw new NotImplementedException();
}