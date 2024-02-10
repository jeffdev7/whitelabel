using app.whitelabel.application.ViewModel;

namespace app.whitelabel.application.Services.Interfaces
{
    public interface IPizzaServices : IDisposable
    {
        Task<PizzaViewModel> Update(PizzaViewModel vm);
        Task<PizzaViewModel> Add(PizzaViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<PizzaViewModelList> GetPizzas();
    }
}