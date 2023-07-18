using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagerCustomer.Entity
{
    public class Customer
    {
        public Guid id { get; set; }
        [DisplayName("Tên")]
        [Required(ErrorMessage = "Yêu cầu nhập tên")]
        public string fullName { get; set; }
        [StringLength(10)]
        [DisplayName("SDT")]
        public string? phone { get; set; }
        [DisplayName("Địa chỉ")]
        public string? address { get; set; }
        [DisplayName("Máy đo mắt trái")]
        public string? machineRecordL { get; set; }
        [DisplayName("Máy đo mắt phải")]
        public string? machineRecordR { get; set; }
        [DisplayName("Chỉ số mắt kính trái")]
        public string? realRecordL { get; set; }
        [DisplayName("Chỉ số mắt kính phải")]
        public string? realRecordR { get; set; }
        public DateTime recordDate { get; set; }
        [DisplayName("Ngày tạo")]
        public string? recordTimeStr { get; set; }
        [StringLength(750, ErrorMessage = "Chỉ trong khoảng 750 chữ")]
        [DisplayName("Ghi chú")]
        public string? note { get; set; }
    }
}
