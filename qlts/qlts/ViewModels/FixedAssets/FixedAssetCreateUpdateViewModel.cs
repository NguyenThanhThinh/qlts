using qlts.Datas;
using qlts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace qlts.ViewModels.FixedAssets
{
    public class FixedAssetCreateUpdateViewModel :ViewModelBase
    {
        [Display(Name = "Mã tài sản")]
        //[Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Code { get; set; }

        [Display(Name = "Tên tài sản")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Description { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [Range(1, 10000, ErrorMessage = "Số lượng phải lớn hơn 0 và nhỏ hơn 10000")]
        public int Quantity { get; set; } = 1;

        [Display(Name = "Đơn vị tính")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [Range(1, 5, ErrorMessage = "Vui lòng chọn đơn vị tính")]
        public FixedAssetUnit Unit { get; set; }

        [Display(Name = "Part Number")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string PartNumber { get; set; }

        [Display(Name = "Serial Number")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string SerialNumber { get; set; }

        [Display(Name = "Lĩnh vực")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        public Guid FieldId { get; set; }

        public List<DropdownModel> Fields { get; set; } = new List<DropdownModel>();

        public IEnumerable<SelectListItem> FieldDropdown =>
            new SelectList(Fields, DropdownModel.ValueField, DropdownModel.DisplayField);


        [Display(Name = "Mã tài sản")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        public Guid FixedAssetManufacturerId { get; set; }
        public List<DropdownModel> FixedAssetManufacturers { get; set; } = new List<DropdownModel>();

        public IEnumerable<SelectListItem> FixedAssetManufacturerDropdown =>
            new SelectList(FixedAssetManufacturers, DropdownModel.ValueField, DropdownModel.DisplayField);


        [Display(Name = "Tình trạng")]
        public Guid FixedAssetStatusId { get; set; }

        public List<DropdownModel> FixedAssetStatuss { get; set; } = new List<DropdownModel>();

        public IEnumerable<SelectListItem> FixedAssetStatusDropdown =>
            new SelectList(FixedAssetStatuss, DropdownModel.ValueField, DropdownModel.DisplayField);

        [Display(Name = "Ngày thực hiện")]
        public string FixedAssetDateFormatted { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public DateTime FixedAssetDate { get; set; }

        [Display(Name = "Ngày thực hiện")]
        public string FixedAssetDateFormattedEdit { get; set; }

        [Display(Name = "Đơn giá")]
        public string CostFormatted { get; set; }
        public decimal Price { get; set; }

        public FixedAssetType FixedAssetType { get; set; } = FixedAssetType.UseAsset;

        [Display(Name = "Ghi chú")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Note { get; set; }

        [Display(Name = "Kho")]
        public Guid WarehouseId { get; set; }

        public List<DropdownModel> Warehouses { get; set; } = new List<DropdownModel>();

        public IEnumerable<SelectListItem> WarehouseDropdown =>
            new SelectList(Warehouses, DropdownModel.ValueField, DropdownModel.DisplayField);

        public CenterUnit Center { get; set; }
    }
}