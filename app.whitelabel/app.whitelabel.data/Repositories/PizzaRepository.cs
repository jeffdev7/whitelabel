using app.whitelabel.data.DBConfiguration;
using app.whitelabel.Entities;
using app.whitelabel.Repositories.Interfaces;

namespace app.whitelabel.data.Repositories
{
    public sealed class PizzaRepository : Repository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<Pizza> GetPizzas()
        {
            return _context.Pizzas;
        }
    }
}