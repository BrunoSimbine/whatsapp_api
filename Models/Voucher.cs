using System.Text.Json;
using System.Text.Json.Serialization;

namespace whatsapp_api.Models;


public class Voucher
{
    public Guid Id { get; set; }
    public string Code { get; set; }

    public string ProductName { get; set; }
    public double ProductPrice { get; set; }
    public int DurationDays { get; set; }
    public int DataAmount { get; set; }

    public string UserName { get; set; }
    public string RequestPhone { get; set; }
}
