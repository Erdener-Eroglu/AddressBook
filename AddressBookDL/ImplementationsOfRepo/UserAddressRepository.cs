using AddressBookEL.Models;

namespace AddressBookDL.ImplementationsOfRepo
{
    public class UserAddressRepository : Repository<UserAddress,int>
    {
        public UserAddressRepository(MyContext context):base(context)
        {
            
        }
    }
}
