using dotnet_aegis_test.Models;
using System.Collections.Generic;


namespace dotnet_aegis_test.Repository
{
    public interface IUserRepository
    {
        List<UserViewModel> GetAllUsers();
    }
}
