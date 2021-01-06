using SalonSpaBooking.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalonSpaBooking.BusinessLayer.Services.Repository
{
    public interface ISalonSpaRepository
    {
        //List of method to perform all related operation
        Task<IEnumerable<ServicesPlan>> GetAllServicesPlan();
        Task<ServicesPlan> GetServicesPlanById(string PlanId);
        Task<IEnumerable<ServicesPlan>> ServicesPlanByTitle(string title);
        Task<Appointment> SalonAppointment(Appointment appointment);
        Task<ApplicationUser> NewApplicationUser(ApplicationUser user);
        Task<IEnumerable<SalonServices>> SalonServicesList();
        Task<SalonServices> SalonServicesById(string salonServicesId);
    }
}
