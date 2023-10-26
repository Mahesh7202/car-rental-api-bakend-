using System.Threading.Tasks;
using WebAPI.Helper;

namespace WebAPI.Service
{
  public interface IEmailService
  {
    Task SendEmailAsync(Mailrequest mailrequest);

  }
}
