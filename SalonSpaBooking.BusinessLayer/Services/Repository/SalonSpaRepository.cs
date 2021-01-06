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
    public class SalonSpaRepository : ISalonSpaRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<Appointment> _dbACollection;
        private IMongoCollection<SalonServices> _dbSSCollection;
        private IMongoCollection<ServicesPlan> _dbSPCollection;
        private IMongoCollection<ApplicationUser> _dbAUCollection;
        public SalonSpaRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbACollection = _mongoContext.GetCollection<Appointment>(typeof(Appointment).Name);
            _dbSSCollection = _mongoContext.GetCollection<SalonServices>(typeof(SalonServices).Name);
            _dbSPCollection = _mongoContext.GetCollection<ServicesPlan>(typeof(ServicesPlan).Name);
            _dbAUCollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
        }
        /// <summary>
        /// Get all services plan for user.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ServicesPlan>> GetAllServicesPlan()
        {
            try
            {
                var list = _mongoContext.GetCollection<ServicesPlan>("ServicesPlan")
                .Find(Builders<ServicesPlan>.Filter.Empty, null)
                .SortByDescending(e => e.PlanName);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ServicesPlan> GetServicesPlanById(string PlanId)
        {
            try
            {
                var objectId = new ObjectId(PlanId);
                FilterDefinition<ServicesPlan> filter = Builders<ServicesPlan>.Filter.Eq("PlanId", objectId);
                _dbSPCollection = _mongoContext.GetCollection<ServicesPlan>(typeof(ServicesPlan).Name);
                return await _dbSPCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ApplicationUser> NewApplicationUser(ApplicationUser user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(typeof(ApplicationUser).Name + "Object is Null");
                }
                _dbAUCollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
                await _dbAUCollection.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return user;
        }

        public async Task<Appointment> SalonAppointment(Appointment appointment)
        {
            try
            {
                if (appointment == null)
                {
                    throw new ArgumentNullException(typeof(Appointment).Name + "Object is Null");
                }
                _dbACollection = _mongoContext.GetCollection<Appointment>(typeof(Appointment).Name);
                await _dbACollection.InsertOneAsync(appointment);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return appointment;
        }

        public async Task<SalonServices> SalonServicesById(string salonServicesId)
        {
            try
            {
                var objectId = new ObjectId(salonServicesId);
                FilterDefinition<SalonServices> filter = Builders<SalonServices>.Filter.Eq("SalonServicesId", objectId);
                _dbSSCollection = _mongoContext.GetCollection<SalonServices>(typeof(SalonServices).Name);
                return await _dbSSCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<SalonServices>> SalonServicesList()
        {
            try
            {
                var list = _mongoContext.GetCollection<SalonServices>("SalonServices")
                .Find(Builders<SalonServices>.Filter.Empty, null)
                .SortByDescending(e => e.Name);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<ServicesPlan>> ServicesPlanByTitle(string title)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<ServicesPlan>();
                var findName = filterBuilder.Eq(s => s.Title, title);
                var planname = filterBuilder.Eq(s => s.PlanName, title.ToString());
                _dbSPCollection = _mongoContext.GetCollection<ServicesPlan>(typeof(ServicesPlan).Name);
                var result = await _dbSPCollection.FindAsync(findName | planname).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
