using HandyMan_Techlift.Models;


namespace HandyMan_Techlift.Repositories
{
    public interface ICategoriesrep
    {
        int Create(Categories c);
        int Edit(Categories c);
        int Delete(Guid CategoryId);

        IEnumerable<Categories> Details();


    }
}
