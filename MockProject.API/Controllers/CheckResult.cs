using MockProject.API.DTO;

namespace MockProject.API.Controllers
{
    public class CheckResult
    {
        //Hàm thực hiện trả về kết quả phản hồi của return.
        public ResponseModel CheckingResult(int type, int act, int number, object res)
        {
            string mess = "";
            //act = 0 hay number = 0 tức là k dùng tới.
            //Type 0 = list / 1 = detail / 2 =  add - update - delete.

            if (type == 0) // List.
            {
                if (number > 0)
                {
                    mess = "Get data from server success.";
                }
                else if (number == 0)
                {
                    mess = "Not found data from server.";
                }
                else
                {
                    mess = "Error -1: Get data send to server fail.";
                }

                return new ResponseModel()
                {
                    //Number > 0 là dữ liệu trả về có ít nhất 1 dòng dữ liệu tồn tại.
                    //Number = 0 là dữ liệu trả về rỗng.
                    //Number = null là thực hiện chức năng bị fail.
                    Success = (number > 0) ? true : false,
                    Message = mess,
                    Data = (number > 0) ? res : null
                };
            }

            else if (type == 1) // Detail.
            {
                return new ResponseModel()
                {
                    //Nếu giá trị nhận từ repon khác null thì trả về true + giá trị nhận được. 
                    Success = (res != null) ? true : false,
                    Message = (res != null) ? "Get data from server success." : "Not found data from server.",
                    Data = (res != null) ? res : null
                };
            }

            else // Add / Update / Delete.
            {
                if (number == 1 || type == 3 && number >= 1) //Nếu chức năng thực hiện thành công. //type = 3 dành cho add/update của joborder.
                {
                    string text = "";
                    if (act == 1)
                    {
                        text = "Add";
                    }
                    if (act == 2)
                    {
                        text = "Update";
                    }
                    if (act == 3)
                    {
                        text = "Delete";
                    }
                    mess = type == 3 ? text + " data to server success.\nJob Order Id: #" + number.ToString() : text + " data to server success.";
                }

                else if (number == 0) //Nếu không kiếm được id cần để thực hiện chức năng.
                {
                    mess = "Not found data from server.";
                }
                else if (number == -2) //Tên username đã tồn tại.
                {
                    mess = "Username in server already exist.";
                }
                else if (number == -3) //Title đã tồn tại.
                {
                    mess = "Title in server already exist.";
                }
                else if (number == -4) //Notification không tồn tại trong service.
                {
                    mess = "Nofitication does't exist in server.";
                }
                else if (number == -5) //Customer không tồn tại trong service.
                {
                    mess = "Customer does't exist in server.";
                }
                else if (number == -6) //Staff không tồn tại trong service.
                {
                    mess = "Staff does't exist in server.";
                }
                else if (number == -7) //Ngày bắt đầu k thể nhỏ hơn ngày hiện tại.
                {
                    mess = "Booking date must not be less than Date now.";
                }
                else if (number == -8) //Title của type này đã tồn tại trong notification.
                {
                    mess = "Title in type of notification already exits.";
                }
                else if (number == -9) //Title của type này đã tồn tại trong option.
                {
                    mess = "Title in type of option already exits.";
                }
                else if (number == -10) //Name của service này đã tồn tại.
                {
                    mess = "Name of service already exits.";
                }
                else if (number == -11) //Duration phải là số.
                {
                    mess = "Duration is number.";
                }
                else if (number == -12) //Tên service đã tồn tại trong type.
                {
                    mess = "Service name in type already exits.";
                }
                else //Thực hiện thất bại. (-1)
                {
                    mess = "Function execution failed.";
                }

                return new ResponseModel()
                {
                    Success = number >= 1 ? true : false,
                    Message = mess,
                    Data = number >= 1 ? res : null
                };
            }
        }
    }
}
