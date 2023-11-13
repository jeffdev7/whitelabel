using app.whitelabel.Entities;

namespace app.whitelabel.Repositories.Interfaces
{
    public interface IPizzaRepository : IRepository<Pizza>
    {
        IQueryable<Pizza> GetPizzas();
    }
}