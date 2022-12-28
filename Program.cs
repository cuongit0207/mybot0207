

using System.Text;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient("5924715807:AAE5EskOWFH8ffNBeoG-1cl_QtfId-rBd3k");

using CancellationTokenSource cts = new();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);




var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Message is not { } message)
        return;
    // Only process text messages
    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
    var chatFullName = message.Chat.FirstName + " " + message.Chat.LastName;
    var tmm = await botClient.SendTextMessageAsync(5885030686, $"Thông tin chat: ChatId: {chatId} - FullName: {chatFullName}, messageText: @{messageText}");//5503977113

    StringBuilder sb = new StringBuilder();
    if (messageText.Equals("/start"))
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "BACCARAT", "TÀI XỈU" },
        })
        {
            ResizeKeyboard = true
        };

        Message sentMessage1 = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Bạn chơi Baccarat hay Tài xỉu?",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }
    else if (messageText.Equals("BACCARAT"))
    {
        sb.AppendLine("BACCARAT");
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "SEXY", "DG" },
        })
        {
            ResizeKeyboard = true
        };

        Message sentMessage1 = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Bạn chơi sảnh nào?",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }
    else if (messageText.Equals("TÀI XỈU"))
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "SẢNH SEXY", "SẢNH DG", "SẢNH EVOLUTION" },
        })
        {
            ResizeKeyboard = true
        };

        Message sentMessage1 = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Bạn chơi sảnh nào?",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }
    else if (messageText.Equals("SEXY") || messageText.Equals("DG"))
    {
        sb.AppendLine(messageText);
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] { "01", "02","03", "04","05", "06","07", "08","09" },
            })
        {
            ResizeKeyboard = true
        };

        Message sentMessage1 = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Bạn chơi bàn nào?",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }
    //else if (messageText.Equals("SẢNH SEXY"))
    //{
    //    sb.AppendLine(messageText);
    //    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    //        {
    //            new KeyboardButton[] { "TÀI XỈU 51" },
    //        })
    //    {
    //        ResizeKeyboard = true
    //    };

    //    Message sentMessage1 = await botClient.SendTextMessageAsync(
    //        chatId: chatId,
    //        text: "Bạn chơi bàn nào?",
    //        replyMarkup: replyKeyboardMarkup,
    //        cancellationToken: cancellationToken);
    //}
    //else if (messageText.Equals("SẢNH DG"))
    //{
    //    sb.AppendLine(messageText);
    //    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    //        {
    //            new KeyboardButton[] { "XÚC SẮC 22" },
    //        })
    //    {
    //        ResizeKeyboard = true
    //    };

    //    Message sentMessage1 = await botClient.SendTextMessageAsync(
    //        chatId: chatId,
    //        text: "Bạn chơi bàn nào?",
    //        replyMarkup: replyKeyboardMarkup,
    //        cancellationToken: cancellationToken);
    //}
    //else if (messageText.Equals("SẢNH EVOLUTION"))
    //{
    //    sb.AppendLine(messageText);
    //    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
    //        {
    //            new KeyboardButton[] { "SIỂU TX" ,"HOÀNG ĐẾ TÀI XỈU"},
    //        })
    //    {
    //        ResizeKeyboard = true
    //    };

    //    Message sentMessage1 = await botClient.SendTextMessageAsync(
    //        chatId: chatId,
    //        text: "Bạn chơi bàn nào?",
    //        replyMarkup: replyKeyboardMarkup,
    //        cancellationToken: cancellationToken);
    //}
    else if (messageText.StartsWith("0"))
    {
        sb.AppendLine(messageText);
        //#region Send ms
        //var ms = await botClient.SendTextMessageAsync(chatId, $"Boot tổng sẽ liên hệ với bạn");
        //#endregion
        var chatName = message.Chat.FirstName + " " + message.Chat.LastName;
        var t = await botClient.SendTextMessageAsync(5885030686, $"Thông tin chat: ChatId: {chatId} - FullName: {chatName}, UserName: @{message.Chat.Username}");//5503977113
        //var tm = await botClient.SendTextMessageAsync(5503977113, $"Thông tin chat: ChatId: {chatId} - FullName: {chatName}, UserName: @{message.Chat.Username}");//5503977113
        Message sentMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "Vui lòng vào bàn chờ",
        replyMarkup: new ReplyKeyboardRemove(),
        cancellationToken: cancellationToken);
    }

}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}
