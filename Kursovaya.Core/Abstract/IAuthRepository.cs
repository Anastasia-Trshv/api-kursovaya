using Kursovaya.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Core.Abstract
{
    public interface IAuthRepository
    {
        Task<string> GenerateRefreshToken(User user);
         Task<string> GenerateAccessToken(User user);

    }
}
