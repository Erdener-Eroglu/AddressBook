using AddressBookBL.InterfacesOfManagers;
using AddressBookEL.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace AddressBookPL.DefaultData
{
    public class DataDefaultXihan
    {
        public void CheckAndCreateRoles(RoleManager<AppRole> roleManager)
        {
            try
            {
                string[] roles = new string[] { "Admin", "Customer", "Guest" };

                foreach (string item in roles)
                {
                    if (!roleManager.RoleExistsAsync(item.ToLower()).Result)
                    {
                        AppRole role = new AppRole()
                        {
                            Name = item

                        };
                        var result = roleManager.CreateAsync(role).Result;
                    }
                }
            }
            catch (Exception ex)
            {
                //ex loglanabilir.
            }
        }

        public void CreateAllCities(ICityManager cityManager)
        {
            try
            {
                //1) Veritbaanındaki illeri listeye ekleyelim
                //2)Exceli açıp satır satır okuyup 
                //2,5)Olmayan ili veri tabanına ekleyelim
                var cityList = cityManager.GetAll(x => !x.IsRemoved).Data;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Excels");
                string fileName = Path.GetFileName("Cities.xlsx");
                string filePath = Path.Combine(path, fileName);
            }
            catch (Exception ex)
            {
                //loglanacak
            }
        }
    }

}
