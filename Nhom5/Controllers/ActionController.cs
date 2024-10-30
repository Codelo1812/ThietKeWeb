using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Nhom5.Controllers
{
    public class ActionController : Controller
    {
        [HttpGet]
        public ActionResult Dangky()
        {            
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // Xử lý đăng ký
        [HttpPost]
        public ActionResult Dangky(string name, string phone, string email, string password, string confirmPassword, string sltDC, string radGT)
        {           
            if (password != confirmPassword)
            {
                ViewBag.ErrorMessage = "Mật khẩu xác nhận không khớp.";
                return View();
            }

            if (IsEmailTaken(email))
            {
                ViewBag.ErrorMessage = "Email này đã được sử dụng.";
                return View();
            }
            // Lưu thông tin người dùng vào cơ sở dữ liệu (giả lập, thay bằng logic thực tế)
            SaveUserToDatabase(name, phone, email, password, sltDC, radGT);

            // Đăng ký thành công, chuyển hướng đến trang đăng nhập
            return RedirectToAction("Dangnhap", "home"); // Điều hướng đến trang đăng nhập
        }        
        private bool IsEmailTaken(string email)
        {           
            return false; 
        }      
        private void SaveUserToDatabase(string name, string phone, string email, string password, string sltDC, string radGT)
        {
            // Thêm logic lưu vào cơ sở dữ liệu thực tế ở đây
        }
    }
}