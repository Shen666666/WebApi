using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Web.Api.Services.Interfaces
{
    public interface IJsonWriter
    {
        Task<bool> Write<T>(List<T> jsonObjects, string jsonFilePath);
    }
}
