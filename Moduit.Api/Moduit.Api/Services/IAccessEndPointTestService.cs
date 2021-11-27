using System.Collections.Generic;
using System.Threading.Tasks;
using Moduit.Api.Models;

namespace Moduit.Api.Services
{
    public interface IAccessEndPointTestService
    {
        Task<ResponseOne> GetResponseOne(string endPoint);
        Task<IEnumerable<ResponseTwo>> GetResponseTwo(string endPoint);
        Task<IEnumerable<ResponseThreeFlatten>> GetResponseThree(string endPoint);
    }
}