using Domain.Entites;
using McDonalds.Helpers;

namespace McDonalds.Models.ViewModel;

public class HomeListViewModel
{
    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<Product> Products { get; set; }
    public int CurrentCategoryId { get; set; }
    public PagingInfo PagingInfo { get; set; }
}