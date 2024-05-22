using Domain.Entites;

namespace McDonalds.Helpers;

public class PaginatedList<T> where T : Product
{
    public List<T> Products { get; set; }
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages => (int)System.Math.Ceiling((decimal)TotalItems / ItemsPerPage);

    public PaginatedList(List<T> products, int totalItems, int itemsPerPage, int currentPage)
    {
        Products = products;
        TotalItems = totalItems;
        ItemsPerPage = itemsPerPage;
        CurrentPage = currentPage;
    }
    
    public IEnumerable<Product> GetProductsByPage(int page)
    {
        return Products.Skip((page - 1) * ItemsPerPage).Take(ItemsPerPage);
    }
    
    public IEnumerable<Product> GetProducts()
    {
        return Products.Skip((CurrentPage - 1) * ItemsPerPage).Take(ItemsPerPage);
    }
}