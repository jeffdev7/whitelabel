using app.whitelabel.application.Services.Interfaces;
using app.whitelabel.application.ViewModel;
using app.whitelabel.data.DBConfiguration;
using app.whitelabel.Entities;
using app.whitelabel.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace app.whitelabel.application.Services
{
    public sealed class PizzaServices : IPizzaServices
    {
        private readonly IMapper _mapper;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly ApplicationContext _context;

        public PizzaServices(IMapper mapper, IPizzaRepository pizzaRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _pizzaRepository = pizzaRepository;
            _context = context;
        }

        public async Task<PizzaViewModel> Add(PizzaViewModel vm)
        {
            Pizza pizza = _mapper.Map<Pizza>(vm);
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return _mapper.Map<PizzaViewModel>(pizza);
        }

        public IEnumerable<PizzaViewModelList> GetPizzas()
        {
            return _mapper.Map<IEnumerable<PizzaViewModelList>>(_pizzaRepository.GetPizzas());
        }

        public async Task<bool> Remove(Guid id)
        {
            Pizza? beverage = await _context.Pizzas
               .Where(p => p.Id == id).SingleOrDefaultAsync();

            if (beverage == null)
                return false;

            _context.Pizzas.Remove(beverage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PizzaViewModel> Update(PizzaViewModel vm)
        {
            Pizza beverage = _mapper.Map<Pizza>(vm);
            _context.Pizzas.Update(beverage);
            await _context.SaveChangesAsync();
            return _mapper.Map<PizzaViewModel>(beverage);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}