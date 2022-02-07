using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Web.Api.Services.Interfaces
{
    public interface IPersonRepositry
    {
        Task<List<Person>> GetAll();

        Task<Person> GetByName(string firstName, string lastName);

        Task<bool> AddOrSave(Person person);
    }
}
