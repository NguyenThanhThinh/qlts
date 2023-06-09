﻿using qlts.Datas;
using qlts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace qlts.ViewModels.Users
{
    public class UserCreateUpdateViewModel :ViewModelBase
    {
        [Display(Name = "Tên người dùng")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Password { get; set; }

        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Mật khẩu xác nhận không trùng")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        


        [Display(Name = "Ghi chú")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Note { get; set; }

        [Display(Name = "Chức vụ")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [Range(1, 3, ErrorMessage = "Vui lòng chọn chức vụ")]
        public PositionType Position { get; set; }

        [Display(Name = "Kho")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        public Guid WarehouseId { get; set; }

        public List<DropdownModel> Warehouses { get; set; } = new List<DropdownModel>();

        public IEnumerable<SelectListItem> WarehouseDropdown =>
            new SelectList(Warehouses, DropdownModel.ValueField, DropdownModel.DisplayField);

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Phone { get; set; }
    }
}