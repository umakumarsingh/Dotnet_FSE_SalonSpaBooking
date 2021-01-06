using SalonSpaBooking.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalonSpaBooking.BusinessLayer.Interfaces
{
    public interface ISalonSpaServices
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
