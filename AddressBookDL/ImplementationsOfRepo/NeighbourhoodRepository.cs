using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Models;

namespace AddressBookDL.ImplementationsOfRepo
{
    public class NeighbourhoodRepository : Repository<Neighbourhood,int>, INeighbourhoodRepository
    {
        public NeighbourhoodRepository(MyContext context): base(context)
        {
            
        }
    }
}
