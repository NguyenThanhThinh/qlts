using qlts.Datas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace qlts.ViewModels.FixedAssets
{
    public class FixedAssetCreateUpdateViewModel :ViewModelBase
    {
        [Display(Name = "Mã tài sản")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Code { get; set; }

        [Display(Name = "Tên tài sản")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Description { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [Range(1, 10000, ErrorMessage = "Số lượng phải lớn hơn 0 và nhỏ hơn 10000")]
        public int Quantity { get; set; }

        [Display(Name = "Đơn vị tính")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Unit { get; set; }

        [Display(Name = "Part Number")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string PartNumber { get; set; }

        [Display(Name = "Part Number")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string SerialNumber { get; set; }

        [Display(Name = "Lĩnh vực")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        public int FieldId { get; set; }

        public List<DropdownModel> Fields { get; set; } = new List<DropdownModel>();

        public IEnumerable<SelectListItem> FieldDropdown =>
            new SelectList(Fields, DropdownModel.ValueField, DropdownModel.DisplayField);


        [Display(Name = "Hãng sản xuất")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        public int ManufacturerId { get; set; }
        public List<DropdownModel> Manufacturers { get; set; } = new List<DropdownModel>();

        public IEnumerable<SelectListItem> ManufacturerDropdown =>
            new SelectList(Manufacturers, DropdownModel.ValueField, DropdownModel.DisplayField);


        [Display(Name = "Tình trạng")]
        public int FixedAssetStatusId { get; set; }

        public List<DropdownModel> FixedAssetStatus { get; set; } = new List<DropdownModel>();

        public IEnumerable<SelectListItem> FixedAssetStatusDropdown =>
            new SelectList(FixedAssetStatus, DropdownModel.ValueField, DropdownModel.DisplayField);

        [Display(Name = "Ngày thực hiện")]
        public string FixedAssetDateFormatted { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public DateTime? FixedAssetDate { get; set; }

        [Display(Name = "Ngày thực hiện")]
        public string FixedAssetDateFormattedEdit { get; set; }

        [Display(Name = "Đơn giá")]
        public string CostFormatted { get; set; }
        public decimal Price { get; set; }
    }
}