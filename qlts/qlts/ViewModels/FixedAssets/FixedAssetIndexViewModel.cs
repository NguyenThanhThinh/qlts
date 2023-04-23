using qlts.Enums;
using qlts.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.FixedAssets
{
    public class FixedAssetIndexViewModel : ViewModelBase
    {
        [Display(Name = "Mã tài sản")]

        public string Code { get; set; }

        [Display(Name = "Tên tài sản")]

        public string Name { get; set; }

        [Display(Name = "Mô tả")]

        public string Description { get; set; }

        [Display(Name = "Số lượng")]

        public int Quantity { get; set; }

        [Display(Name = "Đơn vị tính")]

        public FixedAssetUnit Unit { get; set; }

        [Display(Name = "Part Number")]

        public string PartNumber { get; set; }

        [Display(Name = "Serial Number")]

        public string SerialNumber { get; set; }

        [Display(Name = "Lĩnh vực")]
        public string FieldName { get; set; }
        public Guid FieldId { get; set; }




        [Display(Name = "Hãng sản xuất")]

        public string ManufacturerName { get; set; }
        public Guid ManufacturerId { get; set; }


        [Display(Name = "Tình trạng")]

        public string FixedAssetStatusName { get; set; }
        public Guid FixedAssetStatusId { get; set; }



        [Display(Name = "Ngày thực hiện")]
        public string FixedAssetDateFormatted => FixedAssetDate.ToString("dd/MM/yyyy");
        public DateTime FixedAssetDate { get; set; }


        [Display(Name = "Đơn giá")]
        public string CostFormatted => Price.ToMoneyFormatted("đ");
        public decimal Price { get; set; }

        [Display(Name = "Thành tiền")]
        public string Total => (Price * Quantity).ToMoneyFormatted("đ");

        [Display(Name = "Ngày sản xuất")]
        public DateTime ManufacturerDate { get; set; }

        [Display(Name = "Hạn bảo hành")]
        public DateTime WarrantyPeriodDate { get; set; }

        public string WarehouseName { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
    }
}