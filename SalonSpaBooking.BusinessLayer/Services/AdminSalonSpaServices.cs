using SalonSpaBooking.BusinessLayer.Interfaces;
using SalonSpaBooking.BusinessLayer.Services.Repository;
using SalonSpaBooking.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalonSpaBooking.BusinessLayer.Services
{
    public class AdminSalonSpaServices : IAdminSalonSpaServices
    {
        /// <summary>
        /// Creating referance Variable of IAdminSalonSpaServices and injecting in AdminSalonSpaServices constructor
        /// </summary>
        private readonly IAdminSalonSpaRepository _adminSSRepository;
        public AdminSalonSpaServices(IAdminSalonSpaRepository adminSSRepository)
        {
            _adminSSRepository = adminSSRepository;
        }
        /// <summary>
        /// Add Salon Services to MongoDb Collection
        /// </summary>
        /// <param name="salonServices"></param>
        /// <returns></returns>
        public async Task<SalonServices> AddSalonServices(SalonServices salonServices)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add sevices Plan to MongoDb Collcetion
        /// </summary>
        /// <param name="servicesPlan"></param>
        /// <returns></returns>
        public async Task<ServicesPlan> AddServicesPlan(ServicesPlan servicesPlan)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing salon services  from MongoDb Collection
        /// </summary>
        /// <param name="SalonServicesId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteSalonServices(string SalonServicesId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing salon services plan  from MongoDb Collection
        /// </summary>
        /// <param name="PlanId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteServicesPlan(string PlanId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get a appointment from collection
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public async Task<Appointment> GetAppointmentById(string appointmentId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing Appointment that is booked by user
        /// </summary>
        /// <param name="AppointmentId"></param>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<Appointment> UpdateAppointment(string AppointmentId, Appointment appointment)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing salon services
        /// </summary>
        /// <param name="SalonServicesId"></param>
        /// <param name="salonServices"></param>
        /// <returns></returns>
        public async Task<SalonServices> UpdateSalonServices(string SalonServicesId, SalonServices salonServices)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing services plan
        /// </summary>
        /// <param name="PlanId"></param>
        /// <param name="servicesPlan"></param>
        /// <returns></returns>
        public Task<ServicesPlan> UpdateServicesPlan(string PlanId, ServicesPlan servicesPlan)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Book Appointment for salon services.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Appointment>> UserAppointment()
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
