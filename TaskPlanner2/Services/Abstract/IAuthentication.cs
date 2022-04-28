using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskPlanner2.Models.DataBase;

namespace TaskPlanner2.Services.Abstract
{
    public interface IAuthentication
    {
        void Authenticate(User userToAuthenticate);
        void Logout();
    }
}
