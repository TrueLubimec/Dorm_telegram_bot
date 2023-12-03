using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
// МБ СТОИТ ТАКИ ПИСАТЬ НА КОРЕ

// 6712069977:AAFibGJDBA4ihpSJKFNny0kZwpEx2jN0p_k

Console.WriteLine("DORM BOT");
Console.ReadLine();

var botClient = new TelegramBotClient("6712069977:AAFibGJDBA4ihpSJKFNny0kZwpEx2jN0p_k");
var botIdentifier = await botClient.GetMeAsync();

Console.WriteLine($"Hey there! I'm user {botIdentifier.Id} and everybody calls me {botIdentifier.FirstName}!))");

using CancellationTokenSource cts = new();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);



