using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/*using PhamMinhNhut_DoAnWeb.CustomValidation;*/
namespace PhamMinhNhut_DoAnWeb.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Display(Name = "Tên sản phẩm ")]
        [Required(ErrorMessage = "  Tên sản phẩm không được trống !")]
        [RegularExpression(@"^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ ]*$", ErrorMessage = "Tên sản phẩm chỉ nhập chữ cái và khoảng trắng")]
        //[MinLength(2, ErrorMessage = "Tên sản phẩm phải có nhiều hơn 2 kí tự")]
        public string ProductName { get; set; }

        [Display(Name = "Màu xe ")]
        [Required(ErrorMessage = "  Màu xe không được trống !")]
        [RegularExpression(@"^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ ]*$", ErrorMessage = "BodyColor chỉ nhập chữ cái và khoảng trắng")]
        //[MinLength(2, ErrorMessage = "BodyColor phải có nhiều hơn 2 kí tự")]
        public string BodyColor { get; set; }

        [Display(Name = "BodyType ")]
        [Required(ErrorMessage = "  BodyType không được trống !")]
        [RegularExpression(@"^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ ]*$", ErrorMessage = "BodyType chỉ nhập chữ cái và khoảng trắng")]
        //[MinLength(2, ErrorMessage = "BodyType phải có nhiều hơn 2 kí tự")]
        public string BodyType { get; set; } /*dòng xe SUV,....*/

        [Display(Name = "TransmissionType ")]
        [Required(ErrorMessage = "  TransmissionType không được trống !")]
        [RegularExpression(@"^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ ]*$", ErrorMessage = "TransmissionType chỉ nhập chữ cái và khoảng trắng")]
        //[MinLength(2, ErrorMessage = "TransmissionType phải có nhiều hơn 2 kí tự")]
        public string TransmissionType { get; set; } /*số tự động hay số sàn*/

        [Display(Name = "Consumption ")]
        [Required(ErrorMessage = "  Consumption không được trống !")]
       
        //[MinLength(2, ErrorMessage = "Consumption phải có nhiều hơn 2 kí tự")]
        public string Consumption {  get; set; } /*tiêu tụ /100km*/
        
        [Display(Name = "Power")]
        [Required(ErrorMessage = "Power không được trống.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Power chỉ được nhập số.")]
        //[MinLength(2, ErrorMessage = "Power phải có nhiều hơn 2 kí tự")]
        public string Power {  get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price không được trống.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Price chỉ được nhập số.")]
        //[MinLength(2, ErrorMessage = "Price phải có nhiều hơn 2 kí tự")]
        public int Price { get; set; }

        [Display(Name = "Fuel")]
        [Required(ErrorMessage = "Fuel không được trống.")]
        [RegularExpression(@"^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ ]*$", ErrorMessage = "Fuel chỉ nhập chữ cái và khoảng trắng")]
        //[MinLength(2, ErrorMessage = "Fuel phải có nhiều hơn 2 kí tự")]
        public string Fuel {  get; set; }
        public int BrandId { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual Brand Brand { get; set; }

    }
}