using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class AsveinNetwork
    {
        public int Join_Id { get; set; }     
        
        [Display(Name ="招聘")]
        public string Join_Recruitment { get; set; }
       
        [Display(Name ="求职者")]
        public string join_Seeker { get; set; }
    }
}
