using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalonSpaBooking.BusinessLayer.ViewModels
{
    public class ServicesPlanViewModel
    {
        [Required]
        [Display(Name = "Plan Name")]
        public string PlanName { get; set; }
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int ServiceId { get; set; }
    }
}
