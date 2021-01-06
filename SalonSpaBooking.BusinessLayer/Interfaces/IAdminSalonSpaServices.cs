using SalonSpaBooking.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalonSpaBooking.BusinessLayer.Interfaces
{
    public interface IAdminSalonSpaServices
    {
        Task<IEnumerable<Appointment>> UserAppointment();
        Task<Appointment> UpdateAppointment(string AppointmentId, Appointment appointment);
        Task<Appointment> GetAppointmentById(string appointmentId);
        Task<SalonServices> AddSalonServices(SalonServices salonServices);
        Task<SalonServices> UpdateSalonServices(string SalonServicesId, SalonServices salonServices);
        Task<bool> DeleteSalonServices(string SalonServicesId);
        Task<ServicesPlan> AddServicesPlan(ServicesPlan servicesPlan);
        Task<ServicesPlan> UpdateServicesPlan(string PlanId, ServicesPlan servicesPlan);
        Task<bool> DeleteServicesPlan(string PlanId);
    }
}
