using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Entities;

namespace AddressBookDL.ImplementationsOfRepo
{
    public class CityRepository : Repository<City,int>, ICityRepository
    {
        public CityRepository(MyContext context) : base(context)
        {
            
        }
    }
}
