using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IContactRepository
    {
        Task<List<DTOGetContact>> GetContact();

        Task<List<DTOGetContact>> GetTrash();

        Task<List<DTOGetContact>> GetSearch(string key);

        Task<List<DTOGetContact>> GetContactService(int service);

        Task<DTOGetContact> GetContact(int id);

        int AddContact(DTOContact value);

        int UpdateContact(int id, DTOContact value);

        int DeleteContact(int id);
    }
}
