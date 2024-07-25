using Prot.Domain.Entities.TelegramCode;
using System.Collections.Concurrent;

namespace Prot.Service.Services.Telegrams;

internal class VerificationService
{
    private readonly TelegramService _telegramService;
    private readonly ConcurrentDictionary<string, VerificationCode> _verificationCodes;

    public VerificationService(TelegramService telegramService)
    {
        _telegramService = telegramService;
        _verificationCodes = new ConcurrentDictionary<string, VerificationCode>();
    }

    public async Task SendVerificationCodeAsync(string phoneNumber, string chatId)
    {
        var code = new Random().Next(1000, 9999).ToString();
        var verificationCode = new VerificationCode
        {
            PhoneNumber = phoneNumber,
            Code = code,
            ExpirationTime = DateTime.UtcNow.AddMinutes(10)
        };

        _verificationCodes[phoneNumber] = verificationCode;
        await _telegramService.SendMessageAsync(chatId, $"Your verification code is: {code}");
    }

    public bool VerifyCode(string phoneNumber, string code)
    {
        if (_verificationCodes.TryGetValue(phoneNumber, out var verificationCode) &&
            verificationCode.Code == code &&
            verificationCode.ExpirationTime > DateTime.UtcNow)
        {
            _verificationCodes.TryRemove(phoneNumber, out _);
            return true;
        }

        return false;
    }
}
