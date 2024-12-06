using whatsapp_api.Dtos;
using whatsapp_api.Models;

namespace whatsapp_api.Services;

public interface IMessageService
{
	Task<string> SendMessageAsync(MessageDto messageDto);
	Task<string> SendWelcomeAsync(User user);
	Task<string> SendVoucherAsync(Voucher voucher);
}