using SalonSpaBooking.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalonSpaBooking.BusinessLayer.ViewModels
{
    public class AppointmentViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime Takendate { get; set; }
        [Display(Name = "Services Plan")]
        public string ServicesPlan { get; set; }
        public string Remark { get; set; }
        public virtual SalonServices ServicesTypes { get; set; }
        public virtual ServicesPlan ServicesPlans { get; set; }
    }
}
