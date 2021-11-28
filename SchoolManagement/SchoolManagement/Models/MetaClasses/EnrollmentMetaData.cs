using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class EnrollmentMetaData
    {
        [Display(Name = "Student Grade")]
        public Nullable<decimal> Grade { get; set; }
        [Display(Name = "Course")]
        public int CourseID { get; set; }
        [Display(Name = "Course")]
        public virtual Course Course { get; set; }
        [Display(Name = "Student")]
        public int StudentID { get; set; }
        [Display(Name = "Student")]
        public virtual Student Student { get; set; }
        [Display(Name = "Lecturer")]
        public Nullable<int> LecturerId { get; set; }
        [Display(Name = "Lecturer")]
        public virtual Lecturers Lecturers { get; set; }

        [MetadataType(typeof(EnrollmentMetaData))]
        public partial class Enrollment { }
    }
}