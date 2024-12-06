using System.Text.Json;
using System.Text.Json.Serialization;
namespace whatsapp_api.Models;


public class User
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

}
