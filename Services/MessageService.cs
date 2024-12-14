using System;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using whatsapp_api.Dtos;
using whatsapp_api.Models;
using System.Threading.Tasks;

namespace whatsapp_api.Services;

public class MessageService : IMessageService
{
	private readonly HttpClient _httpClient;
	public MessageService(IHttpClientFactory httpClientFactory){
		_httpClient = httpClientFactory.CreateClient("WhatsappClient");
	}

	public async Task<string> SendMessageAsync(MessageDto messageDto) {
		string jsonData = JsonSerializer.Serialize(messageDto);
		var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

		var response = await _httpClient.PostAsync("message/sendText/Bruno", content);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}

	public async Task<string> SendVoucherAsync(Voucher voucher) {
		var code = $"{voucher.Code.Substring(0, 4)} {voucher.Code.Substring(4, 4)} {voucher.Code.Substring(8, 4)} {voucher.Code.Substring(12, 4)}";
		var text = $@"Congratulations on your choice! Here are the details of your plan:

*Package:* {voucher.ProductName}
*Code:* {code}
*Data:* {voucher.DataAmount} MB
*Duration*: {voucher.DurationDays} days
*Price:* ${voucher.ProductPrice}
";

		string jsonData = JsonSerializer.Serialize(new MessageDto {
			text = text,
			number = voucher.RequestPhone
		});

		var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

		var response = await _httpClient.PostAsync("message/sendText/Bruno", content);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}


	public async Task<string> SendWelcomeAsync(User user) {

		var text = $@"Hi {user.Name}, your contact has been successfully linked!

It's a pleasure to have you on PrivaxNet. Our mission is to make your experience amazing. Start by exploring our VPN with free credits we send to help you discover everything we can do together!

Our team is always here to help you get most out of it. Get ready for an amazing experience!
		";


		string jsonData = JsonSerializer.Serialize(new MessageDto {
			number = user.Phone,
			text = text
		});

		var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

		var response = await _httpClient.PostAsync("message/sendText/Bruno", content);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}
}