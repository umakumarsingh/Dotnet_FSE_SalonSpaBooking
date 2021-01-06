using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalonSpaBooking.BusinessLayer.ViewModels
{
    public class SalonServicesViewModel
    {
        [Required]
        public int ServicesId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        public bool OpenInNewWindow { get; set; }
        public string Description { get; set; }
    }
}
