﻿using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.Users
{
    public class UserIndexViewModel :ViewModelBase
    {
        [Display(Name = "Tên người dùng")]

        public string Name { get; set; }

        [Display(Name = "Email")]

        public string Email { get; set; }


        [Display(Name = "Tài khoản")]

        public string UserName { get; set; }


        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Quyền")]

        public string RoleName { get; set; }
        public int RoleId { get; set; }




        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [Display(Name = "Chức vụ")]
        public string Position { get; set; }

        
        public int WarehouseId { get; set; }

        [Display(Name = "Tên Kho")]

        public int WarehouseName { get; set; }

        [Display(Name = "Số điện thoại")]

        public string Phone { get; set; }
    }
}