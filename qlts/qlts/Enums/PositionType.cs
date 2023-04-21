using System.ComponentModel.DataAnnotations;

namespace qlts.Enums
{
    public enum PositionType
    {
        [Display ( Name = "Thủ kho" )]
        Warehouseman = 1,
        [Display ( Name = "Trưởng phòng kế toán" )]
        AccountingManager = 2,
        [Display ( Name = "Trưởng đơn vị" )]
        UnitManager = 3
    }
}