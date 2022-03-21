//------------------------------------------------------------------------------
// <auto-generated>
//    Ten kod źródłowy został wygenerowany na podstawie szablonu.
//
//    Ręczne modyfikacje tego pliku mogą spowodować nieoczekiwane zachowanie aplikacji.
//    Ręczne modyfikacje tego pliku zostaną zastąpione w przypadku ponownego wygenerowania kodu.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quiz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_questions
    {
        public int q_id { get; set; }
        [Display(Name ="Question")]
        [Required(ErrorMessage ="*")]
        public string q_text { get; set; }
        [Display(Name = "Question A")]
        [Required(ErrorMessage = "*")]
        public string QA { get; set; }
        [Display(Name = "Question B")]
        [Required(ErrorMessage = "*")]
        public string QB { get; set; }
        [Display(Name = "Question C")]
        [Required(ErrorMessage = "*")]
        public string QC { get; set; }
        [Display(Name = "Question D")]
        [Required(ErrorMessage = "*")]
        public string QD { get; set; }
        [Display(Name = "Correct Answer")]
        [Required(ErrorMessage = "*")]
        public string QCorrectAns { get; set; }
        [Display(Name = "Select Category")]
        [Required(ErrorMessage = "*")]
        public Nullable<int> q_fk_catid { get; set; }
    
        public virtual tbl_category tbl_category { get; set; }
    }
}
