﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SalonSpaBooking.Entities
{
    public class ApplicationUser
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "Name Cannot exceed 50 Characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"[a-z0-9][-a-z0-9._]+@([-a-z0-9]+[.])+[a-z]{2,5}$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Emai Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mobile")]
        public long MobileNumber { get; set; }
        [Required]
        [Display(Name = "Pin Code")]
        public long PinCode { get; set; }
        [Required]
        [Display(Name = "HouseNo, Building Name")]
        public string HouseNo_Building_Name { get; set; }
        [Required]
        [Display(Name = "Road Name, Area, Colony")]
        public string Road_area { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
    }
}
