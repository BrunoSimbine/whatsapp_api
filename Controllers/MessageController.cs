using Microsoft.AspNetCore.Mvc;
using whatsapp_api.Dtos;
using whatsapp_api.Services;
using whatsapp_api.Models;



namespace whatsapp_api.Controllers;


[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{

    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService){
        _messageService = messageService;
    }

    [HttpPost("send")]
    public async Task<ActionResult<bool>> SendMessage(MessageDto messagaDto)
    {
        try {
            var result = await _messageService.SendMessageAsync(messagaDto);
            return Ok(result);
        } catch (HttpRequestException ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("send/welcome")]
    public async Task<ActionResult<bool>> SendMessage(User user)
    {
        try {
            var result = await _messageService.SendWelcomeAsync(user);
            return Ok(result);
        } catch (HttpRequestException ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("send/voucher")]
    public async Task<ActionResult<bool>> SendMessage(Voucher voucher)
    {
        try {
            var result = await _messageService.SendVoucherAsync(voucher);
            return Ok(result);
        } catch (HttpRequestException ex) {
            return BadRequest(ex.Message);
        }
    }
}
