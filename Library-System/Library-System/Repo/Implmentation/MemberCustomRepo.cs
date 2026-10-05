using Library_System.Models;
using Library_System.Repo.Interfaces;

namespace Library_System.Repo.Implmentation
{
    public class MemberCustomRepo : GenericRepo<Member>, IMember
    {
        public MemberCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}
