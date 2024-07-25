using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace Prot.Service.Services.Telegrams;

public class TelegramService
{
    private readonly ITelegramBotClient _botClient;

    public TelegramService(IConfiguration configuration)
    {
        _botClient = new TelegramBotClient(configuration["TelegramBot:ProtGameBotToken"]);
    }

    public async Task SendMessageAsync(string chatId, string message)
    {
        await _botClient.SendTextMessageAsync(chatId, message);
    }
}
