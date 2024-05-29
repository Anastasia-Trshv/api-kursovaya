using Kursovaya.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Core.Abstract
{
    public interface ICartService
    {

        Task<string> DeleteSup(string userid, string supId);
        Task<List<Supply>> GetCart(string id);
        Task<string> AddSupplyinCart(string userid, string supId);
    }
}
