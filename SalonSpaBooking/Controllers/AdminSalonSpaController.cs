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
    public class AdminSalonSpaController : ControllerBase
    {
        /// <summary>
        /// Creating referance variable of IAdminSalonSpaServices and ISalonSpaServices
        /// </summary>
        private readonly IAdminSalonSpaServices _adminSalonSpaServices;
        private readonly ISalonSpaServices _salonSpaServices;
        /// <summary>
        /// Injecting referance variable into SalonSpa constructor
        /// </summary>
        public AdminSalonSpaController(IAdminSalonSpaServices adminsalonSpaServices, ISalonSpaServices salonSpaServices)
        {
            _adminSalonSpaServices = adminsalonSpaServices;
            _salonSpaServices = salonSpaServices;
        }
        /// <summary>
        /// Get list of user appointment by date
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Appointment>> AllUserAppointment()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing appointment that is bookied by user
        /// </summary>
        /// <param name="AppointmentId"></param>
        /// <param name="appointment"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updateappointment/{AppointmentId}")]
        public async Task<IActionResult> Updateappointment(string AppointmentId, [FromBody] Appointment appointment)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get a appointment by appointment Id
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AppointmentById/{appointmentId}")]
        public async Task<IActionResult> AppointmentById(string appointmentId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new Salon Services to Db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddSalonServices")]
        public async Task<IActionResult> AddSalonServices([FromBody] SalonServicesViewModel model)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing salon services
        /// </summary>
        /// <param name="SalonServicesId"></param>
        /// <param name="salonServices"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateSalonServices/{SalonServicesId}")]
        public async Task<IActionResult> UpdateSalonServices(string SalonServicesId, [FromBody] SalonServices salonServices)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing salon services by services Id
        /// </summary>
        /// <param name="SalonServicesId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Removeservices/{SalonServicesId}")]
        public async Task<IActionResult> RemoveSalonServices(string SalonServicesId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new services Plan
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Addservicesplan")]
        public async Task<IActionResult> AddServicesPlan([FromBody] ServicesPlanViewModel model)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing services plan
        /// </summary>
        /// <param name="PlanId"></param>
        /// <param name="servicesPlan"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateServicesPlan/{PlanId}")]
        public async Task<IActionResult> UpdateServicesPlan(string PlanId, [FromBody] ServicesPlan servicesPlan)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing Plan by Plan Id
        /// </summary>
        /// <param name="PlanId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Removeservicesplan/{PlanId}")]
        public async Task<IActionResult> RemoveServicesPlan(string PlanId)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}