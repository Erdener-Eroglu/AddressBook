using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Models;

namespace AddressBookDL.ImplementationsOfRepo
{
    public class DistrictRepository : Repository<District, int>, IDistrictRepository
    {
        public DistrictRepository(MyContext context) : base(context)
        {

        }
    }
}
