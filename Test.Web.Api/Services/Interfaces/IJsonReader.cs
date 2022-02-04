using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Web.Api.Services.Interfaces
{
    public interface IJsonReader
    {
        Task<List<T>> Get<T>(string jsonFilePath);
    }
}
