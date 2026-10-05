using Library_System.Models;
using Library_System.Repo.Interfaces;

namespace Library_System.Repo.Implmentation
{
    public class CategoryCustomRepo : GenericRepo<Category>, ICategory
    {
        public CategoryCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}
