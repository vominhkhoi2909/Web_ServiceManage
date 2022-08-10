using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class ContactRepository : IContactRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public ContactRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API

        #region Lấy danh sách dữ liệu
        // Lấy tất cả ds active.
        public async Task<List<DTOGetContact>> GetContact()
        {
            try
            {
                List<DTOGetContact> res = new List<DTOGetContact>();
                var contact = await _context.tContacts.Where(m => m.Status == 1).OrderByDescending(m => m.ContactId).ToListAsync();

                foreach (var item in contact)
                {
                    var option = await _context.tOptions.Where(m => m.OptionId == item.ParentServiceId).FirstOrDefaultAsync();

                    DTOGetContact itemList = new DTOGetContact();

                    itemList.ContactId = item.ContactId;
                    itemList.FullName = item.FullName;
                    itemList.Phone = item.Phone;
                    itemList.Email = item.Email;
                    itemList.Description = item.Description;
                    itemList.ParentServiceId = item.ParentServiceId;
                    if (option != null)
                    {
                        itemList.Service_Name = option.Title;
                    }

                    res.Add(itemList);
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vẫn xảy ra lỗi.
                return null;
            }
        }

        // Lấy ds theo id của service.
        public async Task<List<DTOGetContact>> GetContactService(int service)
        {
            try
            {
                List<DTOGetContact> res = new List<DTOGetContact>();
                var contact = await _context.tContacts.Where(m => m.Status == 1 && m.ParentServiceId == service).OrderByDescending(m => m.ContactId).ToListAsync();

                foreach (var item in contact)
                {
                    var option = await _context.tOptions.Where(m => m.OptionId == item.ParentServiceId).FirstOrDefaultAsync();

                    DTOGetContact itemList = new DTOGetContact();

                    itemList.ContactId = item.ContactId;
                    itemList.FullName = item.FullName;
                    itemList.Phone = item.Phone;
                    itemList.Email = item.Email;
                    itemList.Description = item.Description;
                    itemList.ParentServiceId = item.ParentServiceId;
                    if (option != null)
                    {
                        itemList.Service_Name = option.Title;
                    }

                    res.Add(itemList);
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vẫn xảy ra lỗi.
                return null;
            }
        }

        // Lấy tất cả ds inactive.
        public async Task<List<DTOGetContact>> GetTrash()
        {
            try
            {
                List<DTOGetContact> res = new List<DTOGetContact>();
                var contact = await _context.tContacts.Where(m => m.Status == 0).OrderByDescending(m => m.ContactId).ToListAsync();

                foreach (var item in contact)
                {
                    var option = await _context.tOptions.Where(m => m.OptionId == item.ParentServiceId).FirstOrDefaultAsync();

                    DTOGetContact itemList = new DTOGetContact();

                    itemList.ContactId = item.ContactId;
                    itemList.FullName = item.FullName;
                    itemList.Phone = item.Phone;
                    itemList.Email = item.Email;
                    itemList.Description = item.Description;
                    itemList.ParentServiceId = item.ParentServiceId;
                    if (option != null)
                    {
                        itemList.Service_Name = option.Title;
                    }

                    res.Add(itemList);
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vẫn xảy ra lỗi.
                return null;
            }
        }

        // Lấy ds dữ liệu theo từ khóa.
        // Các từ khóa có thể lấy: Người phụ trách contact / phone / email /tên service.
        public async Task<List<DTOGetContact>> GetSearch(string key)
        {
            try
            {
                List<DTOGetContact> res = new List<DTOGetContact>();
                var contact = await _context.tContacts.Where(m => m.Status == 1).OrderByDescending(m => m.ContactId).ToListAsync();

                foreach (var item in contact)
                {
                    var option = await _context.tOptions.Where(m => m.OptionId == item.ParentServiceId).FirstOrDefaultAsync();

                    if (option != null && option.Title.Contains(key) || item.FullName.Contains(key) || item.Phone.Contains(key) || item.Email.Contains(key))
                    {
                        DTOGetContact itemList = new DTOGetContact();

                        itemList.ContactId = item.ContactId;
                        itemList.FullName = item.FullName;
                        itemList.Phone = item.Phone;
                        itemList.Email = item.Email;
                        itemList.Description = item.Description;
                        itemList.ParentServiceId = item.ParentServiceId;
                        if (option != null)
                        {
                            itemList.Service_Name = option.Title;
                        }

                        res.Add(itemList);
                    }
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vẫn xảy ra lỗi.
                return null;
            }
        }
        #endregion

        #region Chi tiết
        //Xem chi tiết contact.
        public async Task<DTOGetContact> GetContact(int id)
        {
            try
            {
                var contact = await _context.tContacts.Where(m => m.Status == 1 && m.ContactId == id).FirstOrDefaultAsync();
                var option = await _context.tOptions.Where(m => m.OptionId == contact.ParentServiceId).FirstOrDefaultAsync();

                DTOGetContact res = new DTOGetContact();

                res.ContactId = contact.ContactId;
                res.FullName = contact.FullName;
                res.Phone = contact.Phone;
                res.Email = contact.Email;
                res.Description = contact.Description;
                res.ParentServiceId = contact.ParentServiceId;
                if (option != null)
                {
                    res.Service_Name = option.Title;
                }
                return res;
            }
            catch (Exception ex)
            {
                // Truy vẫn xảy ra lỗi.
                return null;
            }
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        //Thêm mới 1 contact.
        public int AddContact(DTOContact value)
        {
            try
            {
                Contact contact = new Contact();

                contact.FullName = value.FullName;
                contact.Phone = value.Phone;
                contact.Email = value.Email;
                contact.Description = value.Description;
                contact.ParentServiceId = value.ParentServiceId;
                contact.Status = 1;
                _context.tContacts.Add(contact);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        //Chỉnh sửa contact theo id.
        public int UpdateContact(int id, DTOContact value)
        {
            try
            {
                var contact = _context.tContacts.Where(m => m.Status == 1 && m.ContactId == id).FirstOrDefault();

                if (contact != null)
                {
                    contact.FullName = value.FullName;
                    contact.Phone = value.Phone;
                    contact.Email = value.Email;
                    contact.Description = value.Description;
                    contact.ParentServiceId = value.ParentServiceId;
                    contact.Status = 1;
                    _context.tContacts.Update(contact);
                    _context.SaveChanges();

                    return 1;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        //Xóa contact theo id.
        public int DeleteContact(int id)
        {
            try
            {
                var contact = _context.tContacts.Where(m => m.Status == 1 && m.ContactId == id).FirstOrDefault();

                if (contact != null)
                {
                    contact.Status = 0;
                    _context.tContacts.Update(contact);
                    _context.SaveChanges();

                    return 1;
                }

                return 0;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion

        #endregion
    }
}
