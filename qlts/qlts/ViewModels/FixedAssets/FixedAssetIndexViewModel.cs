using qlts.Enums;
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

        [Display(Name = "Part Number")]

        public string SerialNumber { get; set; }

        [Display(Name = "Lĩnh vực")]
        public string FieldName { get; set; }
        public int FieldId { get; set; }




        [Display(Name = "Hãng sản xuất")]

        public string ManufacturerName { get; set; }
        public int ManufacturerId { get; set; }


        [Display(Name = "Tình trạng")]

        public string FixedAssetStatusName { get; set; }
        public int FixedAssetStatusId { get; set; }



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