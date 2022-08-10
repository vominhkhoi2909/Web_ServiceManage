using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface INoteRepository
    {
        Task<List<DTOGetNote>> GetNote();

        Task<List<DTOGetNote>> GetTrash();

        Task<List<DTOGetNote>> GetSearch(string key);

        Task<List<DTOGetNote>> GetNoteType(int type);

        Task<DTOGetNote> GetNote(int id);

        int AddNote(DTONote value);

        int UpdateNote(int id, DTONote value);

        int DeleteNote(int id);
    }
}
