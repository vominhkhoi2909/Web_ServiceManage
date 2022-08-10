using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class ContactMockData
    {
        public static List<DTOGetContact> GetContacts()
        {
            return new List<DTOGetContact>
            {
                new DTOGetContact
                {
                    ContactId = 1,
                    FullName = "Jonny Khoi",
                    Phone = "0919813001",
                    Email = "KhoiVM@gmail.com",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem.",
                    ParentServiceId = 1
                },
                new DTOGetContact
                {
                    ContactId = 2,
                    FullName = "Mikel Nguyen",
                    Phone = "0919813002",
                    Email = "LongNH@gmail.com",
                    Description = "want to contact",
                    ParentServiceId = 2
                },
                new DTOGetContact
                {
                    ContactId = 3,
                    FullName = "Johny Minh",
                    Phone = "0919813003",
                    Email = "QuangNM@gmail.com",
                    Description = "want to contact",
                    ParentServiceId = 3
                },
            };
        }

        public static List<DTOGetContact> EmptyContact()
        {
            return new List<DTOGetContact>();
        }
    }
}
