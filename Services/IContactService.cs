using Web.CreativeAgency.Models;

namespace Web.CreativeAgency.Services
{
    public interface IContactService
    {
        Task SaveAsync(ContactFormModel model);
    }
}
