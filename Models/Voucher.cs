using System.Text.Json;
using System.Text.Json.Serialization;

namespace whatsapp_api.Models;


public class Voucher
{
    public string Code { get; set; }

    public string ProductName { get; set; }
    public double ProductPrice { get; set; }
    public int DurationDays { get; set; }
    public int DataAmount { get; set; }

    public string RequestPhone { get; set; }
}
