using Moq;
using SalonSpaBooking.BusinessLayer.Interfaces;
using SalonSpaBooking.BusinessLayer.Services;
using SalonSpaBooking.BusinessLayer.Services.Repository;
using SalonSpaBooking.Entities;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace SalonSpaBooking.Tests.TestCases
{
    public class BoundaryTest
    {
        /// <summary>
        /// Creating Referance of all Service Interfaces and Mocking All Repository
        /// </summary>
        private readonly IAdminSalonSpaServices _adminSSServices;
        private readonly ISalonSpaServices _salonSpaServices;
        public readonly Mock<IAdminSalonSpaRepository> adminService = new Mock<IAdminSalonSpaRepository>();
        public readonly Mock<ISalonSpaRepository> salonServices = new Mock<ISalonSpaRepository>();
        private Appointment _appointment;
        private ApplicationUser _user;
        private SalonServices _salonServices;
        private ServicesPlan _servicesPlan;
        public BoundaryTest()
        {
            _adminSSServices = new AdminSalonSpaServices(adminService.Object);
            _salonSpaServices = new SalonSpaServices(salonServices.Object);
            _appointment = new Appointment
            {
                AppointmentId = "5ff45caf62416905a5e6a1b8",
                Name = "Kumar Kaushal",
                Mobile = 9632545785,
                Email = "services@iiht.co.in",
                ServicesPlan = "1"
            };
            _user = new ApplicationUser
            {
                UserId = "5ff462f59c249e27020bffba",
                Name = "Uma Kumar",
                Email = "umakumarsingh@gmail.com",
                MobileNumber = 9865253568,
                PinCode = 820003,
                HouseNo_Building_Name = "9/11",
                Road_area = "Road_area",
                City = "Gaya",
                State = "Bihar"
            };
            _salonServices = new SalonServices
            {
                SalonServicesId = "5ff467219c249e27020bffbb",
                ServicesId = 1,
                Name = "SKIN",
                Url = "~/SalonSpa/",
                OpenInNewWindow = false,
                Description = null
            };
            _servicesPlan = new ServicesPlan
            {
                PlanId = "5ff45f309c249e27020bffb9",
                PlanName = "Skin Care - Treatments",
                Title = "Spot Lights - Organic Eye- Lip Treatment",
                Description = "Reduce Dryness From Your Eyes And Lips With A Treatment Designed To Tr...",
                Price = 1250,
                ServiceId = 1
            };
        }
        /// <summary>
        /// Creating test output text file that store the result in boolean result
        /// </summary>
        static BoundaryTest()
        {
            if (!File.Exists("../../../../output_boundary_revised.txt"))
                try
                {
                    File.Create("../../../../output_boundary_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_boundary_revised.txt");
                File.Create("../../../../output_boundary_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Test for Validate UserId is used to test UserId is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UserId()
        {
            //Arrange
            bool res = false;
            //Act
            salonServices.Setup(repo => repo.NewApplicationUser(_user)).ReturnsAsync(_user);
            var result = await _salonSpaServices.NewApplicationUser(_user);

            if (result.UserId.Length.ToString() == _user.UserId.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_UserId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Validate AppointmentId is used to test Appointment is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_AppointmentId()
        {
            //Arrange
            bool res = false;
            //Act
            salonServices.Setup(repo => repo.SalonAppointment(_appointment)).ReturnsAsync(_appointment);
            var result = await _salonSpaServices.SalonAppointment(_appointment);

            if (result.AppointmentId.Length.ToString() == _appointment.AppointmentId.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_AppointmentId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Validate SalonServicesId is used to test Salon Services is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_SalonServicesId()
        {
            //Arrange
            bool res = false;
            //Act
            adminService.Setup(repo => repo.AddSalonServices(_salonServices)).ReturnsAsync(_salonServices);
            var result = await _adminSSServices.AddSalonServices(_salonServices);

            if (result.SalonServicesId.Length.ToString() == _salonServices.SalonServicesId.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_SalonServicesId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Validate ServicesPlan Id is used to test Services Plan is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Service_PlanId()
        {
            //Arrange
            bool res = false;
            //Act
            adminService.Setup(repo => repo.AddServicesPlan(_servicesPlan)).ReturnsAsync(_servicesPlan);
            var result = await _adminSSServices.AddServicesPlan(_servicesPlan);

            if (result.PlanId.Length.ToString() == _servicesPlan.PlanId.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_Service_PlanId=" + res + "\n");
            return res;
        }
    }
}
