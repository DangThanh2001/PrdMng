using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        [DisplayName("Chỉ số mắt trái")]
        public string? realRecordL { get; set; }
        [DisplayName("Chỉ số mắt phải")]
        public string? realRecordR { get; set; }
        public DateTime recordDate { get; set; }
        [DisplayName("Ngày tạo")]
        public string? recordTimeStr { get; set; }
        [StringLength(500, ErrorMessage = "Chỉ trong khoảng 500 chữ")]
        [DisplayName("Ghi chú")]
        public string? note { get; set; }
    }
}
