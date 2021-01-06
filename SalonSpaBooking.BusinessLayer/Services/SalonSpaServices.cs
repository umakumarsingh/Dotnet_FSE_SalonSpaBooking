using SalonSpaBooking.BusinessLayer.Interfaces;
using SalonSpaBooking.BusinessLayer.Services.Repository;
using SalonSpaBooking.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalonSpaBooking.BusinessLayer.Services
{
    public class SalonSpaServices : ISalonSpaServices
    {
        /// <summary>
        /// Creating referance Variable of ISalonSpaServices and injecting in SalonSpaServices constructor
        /// </summary>
        private readonly ISalonSpaRepository _salonSpaRepository;
        public SalonSpaServices(ISalonSpaRepository salonSpaRepository)
        {
            _salonSpaRepository = salonSpaRepository;
        }
        /// <summary>
        /// Get all services plan  for MongoDb collection.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ServicesPlan>> GetAllServicesPlan()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Services plan by Plan Id
        /// </summary>
        /// <param name="PlanId"></param>
        /// <returns></returns>
        public async Task<ServicesPlan> GetServicesPlanById(string PlanId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> NewApplicationUser(ApplicationUser user)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Book Salon Appointment.
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<Appointment> SalonAppointment(Appointment appointment)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get salon services by Id.
        /// </summary>
        /// <param name="salonServicesId"></param>
        /// <returns></returns>
        public async Task<SalonServices> SalonServicesById(string salonServicesId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Salon services List
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<SalonServices>> SalonServicesList()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get salon services plan by Title and Name
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public Task<IEnumerable<ServicesPlan>> ServicesPlanByTitle(string title)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
