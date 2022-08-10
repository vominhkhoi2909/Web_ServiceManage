using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class NoteRepository : INoteRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public NoteRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API

        #region Lấy danh sách dữ liệu
        public async Task<List<DTOGetNote>> GetNote()
        {
            try
            {
                List<DTOGetNote> res = new List<DTOGetNote>();
                var note = await _context.tNotes.Where(m => m.Status == 1).OrderByDescending(m => m.NoteId).ToListAsync();

                foreach (var item in note)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.CreateBy).FirstOrDefaultAsync();

                    DTOGetNote itemList = new DTOGetNote();

                    itemList.NoteId = item.NoteId;

                    TimeZoneInfo vn = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                    DateTime vnDatetime = TimeZoneInfo.ConvertTimeFromUtc(item.CreateAt, vn);
                    itemList.CreateAt = vnDatetime;

                    itemList.Title = item.Title;
                    itemList.Type = item.Type;
                    itemList.Description = item.Description;
                    itemList.CreateBy = item.CreateBy;
                    if (admin != null)
                    {
                        itemList.CreateBy_Name = admin.FullName;
                        itemList.Email = admin.Email;
                        itemList.Avatar = admin.Avatar;
                    }

                    res.Add(itemList);
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lôi.
                return null;
            }
        }

        public async Task<List<DTOGetNote>> GetTrash()
        {
            try
            {
                List<DTOGetNote> res = new List<DTOGetNote>();
                var note = await _context.tNotes.Where(m => m.Status == 0).OrderByDescending(m => m.NoteId).ToListAsync();

                foreach (var item in note)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.CreateBy).FirstOrDefaultAsync();

                    DTOGetNote itemList = new DTOGetNote();

                    itemList.NoteId = item.NoteId;
                    itemList.CreateAt = item.CreateAt;
                    itemList.Title = item.Title;
                    itemList.Type = item.Type;
                    itemList.Description = item.Description;
                    itemList.CreateBy = item.CreateBy;
                    if (admin != null)
                    {
                        itemList.CreateBy_Name = admin.FullName;
                        itemList.Email = admin.Email;
                        itemList.Avatar = admin.Avatar;
                    }

                    res.Add(itemList);
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lôi.
                return null;
            }
        }

        public async Task<List<DTOGetNote>> GetSearch(string key)
        {
            try
            {
                List<DTOGetNote> res = new List<DTOGetNote>();
                var note = await _context.tNotes.Where(m => m.Status == 1).OrderByDescending(m => m.NoteId).ToListAsync();

                foreach (var item in note)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.CreateBy).FirstOrDefaultAsync();

                    if (admin != null && (admin.FullName.Contains(key) || admin.Email.Contains(key)) || item.Title.Contains(key))
                    {
                        DTOGetNote itemList = new DTOGetNote();

                        itemList.NoteId = item.NoteId;
                        itemList.CreateAt = item.CreateAt;
                        itemList.Title = item.Title;
                        itemList.Type = item.Type;
                        itemList.Description = item.Description;
                        itemList.CreateBy = item.CreateBy;
                        if (admin != null)
                        {
                            itemList.CreateBy_Name = admin.FullName;
                            itemList.Email = admin.Email;
                            itemList.Avatar = admin.Avatar;
                        }

                        res.Add(itemList);
                    }
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lôi.
                return null;
            }
        }

        public async Task<List<DTOGetNote>> GetNoteType(int type)
        {
            try
            {
                List<DTOGetNote> res = new List<DTOGetNote>();
                var note = await _context.tNotes.Where(m => m.Status == 1 && m.Type == type).OrderByDescending(m => m.NoteId).ToListAsync();

                foreach (var item in note)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.CreateBy).FirstOrDefaultAsync();

                    DTOGetNote itemList = new DTOGetNote();

                    itemList.NoteId = item.NoteId;
                    itemList.CreateAt = item.CreateAt;
                    itemList.Title = item.Title;
                    itemList.Type = item.Type;
                    itemList.Description = item.Description;
                    itemList.CreateBy = item.CreateBy;
                    if (admin != null)
                    {
                        itemList.CreateBy_Name = admin.FullName;
                        itemList.Email = admin.Email;
                        itemList.Avatar = admin.Avatar;
                    }

                    res.Add(itemList);
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lôi.
                return null;
            }
        }
        #endregion

        #region Chi tiết
        public async Task<DTOGetNote> GetNote(int id)
        {
            try
            {
                DTOGetNote res = new DTOGetNote();
                var note = await _context.tNotes.Where(m => m.Status == 1 && m.NoteId == id).FirstOrDefaultAsync();
                var admin = await _context.tAdminUsers.Where(m => m.UserId == note.CreateBy).FirstOrDefaultAsync();

                res.NoteId = note.NoteId;

                TimeZoneInfo vn = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                DateTime vnDatetime = TimeZoneInfo.ConvertTimeFromUtc(note.CreateAt, vn);
                res.CreateAt = vnDatetime;

                res.Title = note.Title;
                res.Type = note.Type;
                res.Description = note.Description;
                res.CreateBy = note.CreateBy;
                if (admin != null)
                {
                    res.CreateBy_Name = admin.FullName;
                    res.Email = admin.Email;
                    res.Avatar = admin.Avatar;
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lôi.
                return null;
            }
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        public int AddNote(DTONote value)
        {
            try
            {
                Note note = new Note();

                note.CreateAt = DateTime.UtcNow;
                note.Title = value.Title;
                note.Description = value.Description;
                note.Type = value.Type;
                note.CreateBy = value.CreateBy;
                note.Status = 1;
                _context.tNotes.Add(note);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int UpdateNote(int id, DTONote value)
        {
            try
            {
                var note = _context.tNotes.Where(m => m.Status == 1 && m.NoteId == id).FirstOrDefault();

                if (note != null)
                {
                    note.Title = value.Title;
                    note.Description = value.Description;
                    note.Type = value.Type;
                    note.CreateBy = value.CreateBy;
                    note.Status = 1;
                    _context.tNotes.Update(note);
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

        public int DeleteNote(int id)
        {
            try
            {
                var Note = _context.tNotes.Where(m => m.Status == 1 && m.NoteId == id).FirstOrDefault();

                if (Note != null)
                {
                    Note.Status = 0;
                    _context.tNotes.Update(Note);
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
