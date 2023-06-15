using HandyMan_Techlift.Models;

namespace HandyMan_Techlift.Repositories
{
    public interface IServicesrep
    {
        int Create(Services s);
        int Edit(Services s);
        int Delete(Guid ServiceId);

        IEnumerable<Services> Details();
    }
}
