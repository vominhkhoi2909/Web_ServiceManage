using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class NoteMockData
    {
        public static List<DTOGetNote> GetNotes()
        {
            return new List<DTOGetNote>
            {
                new DTOGetNote
                {
                    NoteId = 2,
                    CreateAt = new DateTime(2022, 07, 29, 13, 49, 37),
                    Title = "Give salary to employee",
                    Type = 1,
                    Description = "Blandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.",
                    CreateBy = 30,
                },
                new DTOGetNote
                {
                    NoteId = 7,
                    CreateAt = new DateTime(2022, 07, 29, 13, 49, 37),
                    Title = "Give salary to employee",
                    Type = 1,
                    Description = "Blandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.",
                    CreateBy = 31,
                },
                new DTOGetNote
                {
                    NoteId = 6,
                    CreateAt = new DateTime(2022, 07, 29, 13, 49, 37),
                    Title = "Give salary to employee",
                    Type = 1,
                    Description = "s",
                    CreateBy = 30,
                },
            };
        }

        public static List<DTOGetNote> EmptyNote()
        {
            return new List<DTOGetNote>();
        }
    }
}
