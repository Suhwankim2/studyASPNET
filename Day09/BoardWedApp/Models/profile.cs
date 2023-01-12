


using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BoardWedApp.Models
{

    // 실제 
    public class profile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Division { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

      
        public string? Url { get; set; }

        // 저장된 파일명만 들어간다
        [FileExtensions(Extensions = ".jpg, .png, .jpeg", ErrorMessage = "이미지 파일을 선택하세요.")]

        public string? FileName { get; set; }
    }
    
    // 파일을 업로드하기 위해 중간단계 모델
    public class TempProfile
    {
        public int Id { get; set; }

        [Required]
        public string Division { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        
        public string? Url { get; set; }

        // 핵심
        [Display(Name = "이미지 파일")]
        public IFormFile? ProfileImage { get; set; }

        public string? FileName { get; set; }
    }
}