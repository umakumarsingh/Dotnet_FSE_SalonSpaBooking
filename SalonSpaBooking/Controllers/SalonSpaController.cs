using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSpaBooking.BusinessLayer.Interfaces;
using SalonSpaBooking.BusinessLayer.ViewModels;
using SalonSpaBooking.Entities;

namespace SalonSpaBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonSpaController : ControllerBase
    {
        /// <summary>
        /// Creating referance variable of IAdminSalonSpaServices and ISalonSpaServices
        /// </summary>
        private readonly ISalonSpaServices _salonSpaServices;
        /// <summary>
        /// Injecting referance variable into SalonSpa constructor
        /// </summary>
        public SalonSpaController(ISalonSpaServices salonSpaServices)
        {
            _salonSpaServices = salonSpaServices;
        }
        /// <summary>
        /// Get all Salon services plan for visitor and user.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ServicesPlan>> SalonServicesPlan()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Salon services plan by Plan Id and show a single plan.
        /// </summary>
        /// <param name="PlanId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SalonServicesPlanById/{PlanId}")]
        public async Task<IActionResult> SalonServicesPlanById(string PlanId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Salon services plan by Title or Plan Name
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PlanByTitle/{Title}")]
        public async Task<IEnumerable<ServicesPlan>> PlanByTitle(string title)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Book new appointment with salon
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Appointment")]
        public async Task<IActionResult> SalonAppointment([FromBody] AppointmentViewModel model)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register new user to application
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] ApplicationUserViewModel model)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all salon Services List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ServicesList")]
        public async Task<IEnumerable<SalonServices>> SalonServicesList()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get a salon services by services Id
        /// </summary>
        /// <param name="SalonServicesId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SalonServicesById/{SalonServicesId}")]
        public async Task<IActionResult> SalonServicesById(string SalonServicesId)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
