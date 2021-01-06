using MongoDB.Bson;
using MongoDB.Driver;
using SalonSpaBooking.DataLayer;
using SalonSpaBooking.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalonSpaBooking.BusinessLayer.Services.Repository
{
    public class AdminSalonSpaRepository : IAdminSalonSpaRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<Appointment> _dbACollection;
        private IMongoCollection<SalonServices> _dbSSCollection;
        private IMongoCollection<ServicesPlan> _dbSPCollection;
        public AdminSalonSpaRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbACollection = _mongoContext.GetCollection<Appointment>(typeof(Appointment).Name);
            _dbSSCollection = _mongoContext.GetCollection<SalonServices>(typeof(SalonServices).Name);
            _dbSPCollection = _mongoContext.GetCollection<ServicesPlan>(typeof(ServicesPlan).Name);
        }
        public async Task<SalonServices> AddSalonServices(SalonServices salonServices)
        {
            try
            {
                if (salonServices == null)
                {
                    throw new ArgumentNullException(typeof(SalonServices).Name + "Object is Null");
                }
                _dbSSCollection = _mongoContext.GetCollection<SalonServices>(typeof(SalonServices).Name);
                await _dbSSCollection.InsertOneAsync(salonServices);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return salonServices;
        }

        public async Task<ServicesPlan> AddServicesPlan(ServicesPlan servicesPlan)
        {
            try
            {
                if (servicesPlan == null)
                {
                    throw new ArgumentNullException(typeof(ServicesPlan).Name + "Object is Null");
                }
                _dbSPCollection = _mongoContext.GetCollection<ServicesPlan>(typeof(ServicesPlan).Name);
                await _dbSPCollection.InsertOneAsync(servicesPlan);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return servicesPlan;
        }

        public async Task<bool> DeleteSalonServices(string SalonServicesId)
        {
            try
            {
                var objectId = new ObjectId(SalonServicesId);
                FilterDefinition<SalonServices> filter = Builders<SalonServices>.Filter.Eq("SalonServicesId", objectId);
                var result = await _dbSSCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteServicesPlan(string PlanId)
        {
            try
            {
                var objectId = new ObjectId(PlanId);
                FilterDefinition<ServicesPlan> filter = Builders<ServicesPlan>.Filter.Eq("PlanId", objectId);
                var result = await _dbSPCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Get a appointment that is request by user
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public async Task<Appointment> GetAppointmentById(string appointmentId)
        {
            try
            {
                var objectId = new ObjectId(appointmentId);
                FilterDefinition<Appointment> filter = Builders<Appointment>.Filter.Eq("AppointmentId", objectId);
                _dbACollection = _mongoContext.GetCollection<Appointment>(typeof(Appointment).Name);
                return await _dbACollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Appointment> UpdateAppointment(string AppointmentId, Appointment appointment)
        {
            if (appointment == null && AppointmentId == null)
            {
                throw new ArgumentNullException(typeof(Appointment).Name + "Object or may be AppointmentId is Null");
            }
            var update = await _dbACollection.FindOneAndUpdateAsync(Builders<Appointment>.
                Filter.Eq("AppointmentId", appointment.AppointmentId), Builders<Appointment>.
                Update.Set("Name", appointment.Name).Set("Mobile", appointment.Mobile).Set("Email", appointment.Email)
                .Set("Takendate", appointment.Takendate).Set("ServicesPlan", appointment.ServicesPlan));
            return update;
        }

        public async Task<SalonServices> UpdateSalonServices(string SalonServicesId, SalonServices salonServices)
        {
            if (salonServices == null && SalonServicesId == null)
            {
                throw new ArgumentNullException(typeof(SalonServices).Name + "Object or may be SalonServicesId is Null");
            }
            var update = await _dbSSCollection.FindOneAndUpdateAsync(Builders<SalonServices>.
                Filter.Eq("SalonServicesId", salonServices.SalonServicesId), Builders<SalonServices>.
                Update.Set("ServicesId", salonServices.ServicesId).Set("Name", salonServices.Name).Set("Url", salonServices.Url)
                .Set("OpenInNewWindow", salonServices.OpenInNewWindow).Set("Description", salonServices.Description));
            return update;
        }

        public async Task<ServicesPlan> UpdateServicesPlan(string PlanId, ServicesPlan servicesPlan)
        {
            if (servicesPlan == null && PlanId == null)
            {
                throw new ArgumentNullException(typeof(ServicesPlan).Name + "Object or may be SalonServicesId is Null");
            }
            var update = await _dbSPCollection.FindOneAndUpdateAsync(Builders<ServicesPlan>.
                Filter.Eq("PlanId", servicesPlan.PlanId), Builders<ServicesPlan>.
                Update.Set("PlanId", servicesPlan.PlanId).Set("PlanName", servicesPlan.PlanName).Set("Title", servicesPlan.Title)
                .Set("Description", servicesPlan.Description).Set("Price", servicesPlan.Price).Set("ServiceId", servicesPlan.ServiceId));
            return update;
        }

        public async Task<IEnumerable<Appointment>> UserAppointment()
        {
            try
            {
                var list = _mongoContext.GetCollection<Appointment>("Appointment")
                .Find(Builders<Appointment>.Filter.Empty, null)
                .SortByDescending(e => e.Takendate);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
