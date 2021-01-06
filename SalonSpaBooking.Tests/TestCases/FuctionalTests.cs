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
    public class FuctionalTests
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
        public FuctionalTests()
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
        static FuctionalTests()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Using this test methd try to test and get all Services Plan from Services and Repository method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllServicesPlan()
        {
            //Arrange
            var res = false;
            //Action
            salonServices.Setup(repos => repos.GetAllServicesPlan());
            var result = await _salonSpaServices.GetAllServicesPlan();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetAllServicesPlan=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test method get a services plan if return same object by method test is passed
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetServicesPlanById()
        {
            //Arrange
            var res = false;
            //Action
            salonServices.Setup(repos => repos.GetServicesPlanById(_servicesPlan.PlanId)).ReturnsAsync(_servicesPlan);
            var result = await _salonSpaServices.GetServicesPlanById(_servicesPlan.PlanId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetServicesPlanById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this method try to get services plan by title if result is true test is passed.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ServicesPlanByTitle()
        {
            //Arrange
            var res = false;
            //Action
            salonServices.Setup(repos => repos.ServicesPlanByTitle(_servicesPlan.Title));
            var result = await _salonSpaServices.ServicesPlanByTitle(_servicesPlan.Title);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_ServicesPlanByTitle=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor Validate Book valid Appointment if all data is passed, case is True
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Valid_SalonAppointment()
        {
            //Arrange
            bool res = false;
            //Act
            salonServices.Setup(repo => repo.SalonAppointment(_appointment)).ReturnsAsync(_appointment);
            var result = await _salonSpaServices.SalonAppointment(_appointment);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Valid_SalonAppointment=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor Validate Register valid User if all data is passed, case is True
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Valid_NewApplicationUser()
        {
            //Arrange
            bool res = false;
            //Act
            salonServices.Setup(repo => repo.NewApplicationUser(_user)).ReturnsAsync(_user);
            var result = await _salonSpaServices.NewApplicationUser(_user);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Valid_NewApplicationUser=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test methd try to test and get all Services List from Services and Repository method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_SalonServicesList()
        {
            //Arrange
            var res = false;
            //Action
            salonServices.Setup(repos => repos.SalonServicesList());
            var result = await _salonSpaServices.SalonServicesList();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_SalonServicesList=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test method get a salon services if return same object by method test is passed
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_SalonServicesById()
        {
            //Arrange
            var res = false;
            //Action
            salonServices.Setup(repos => repos.SalonServicesById(_salonServices.SalonServicesId)).ReturnsAsync(_salonServices);
            var result = await _salonSpaServices.SalonServicesById(_salonServices.SalonServicesId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_SalonServicesById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test methd try to test and get all User Appointment from Services and Repository method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAll_UserAppointment()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.UserAppointment());
            var result = await _adminSSServices.UserAppointment();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetAll_UserAppointment=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Appointment by Appointment Id and _appointmentUpdate Collection
        /// if get updated then test Passed to true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateAppointment()
        {
            //Arrange
            bool res = false;
            var _appointmentUpdate = new Appointment
            {
                AppointmentId = "5ff45caf62416905a5e6a1b8",
                Name = "Kumar Kaushal",
                Mobile = 9632545785,
                Email = "services@iiht.co.in",
                ServicesPlan = "1"
            };
            //Act
            adminService.Setup(repo => repo.UpdateAppointment(_appointmentUpdate.AppointmentId, _appointmentUpdate)).ReturnsAsync(_appointmentUpdate);
            var result = await _adminSSServices.UpdateAppointment(_appointmentUpdate.AppointmentId, _appointmentUpdate);
            if (result == _appointmentUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateAppointment=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test method get a appointment if return same object by method test is passed
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAppointmentById()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.GetAppointmentById(_appointment.AppointmentId)).ReturnsAsync(_appointment);
            var result = await _adminSSServices.GetAppointmentById(_appointment.AppointmentId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetAppointmentById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to test Add Salon Services information is getting added, if added then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Add_Valid_SalonServices()
        {
            //Arrange
            bool res = false;
            //Act
            adminService.Setup(repo => repo.AddSalonServices(_salonServices)).ReturnsAsync(_salonServices);
            var result = await _adminSSServices.AddSalonServices(_salonServices);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Add_Valid_SalonServices=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Salon services by SalonServicesId Id and SalonServices Collection
        /// if get updated then test Passed to true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateSalonServices()
        {
            //Arrange
            bool res = false;
            var _salonServicesUpdate = new SalonServices
            {
                SalonServicesId = "5ff467219c249e27020bffbb",
                ServicesId = 1,
                Name = "SKIN",
                Url = "~/SalonSpa/",
                OpenInNewWindow = false,
                Description = null
            };
            //Act
            adminService.Setup(repo => repo.UpdateSalonServices(_salonServicesUpdate.SalonServicesId, _salonServicesUpdate)).ReturnsAsync(_salonServicesUpdate);
            var result = await _adminSSServices.UpdateSalonServices(_salonServicesUpdate.SalonServicesId, _salonServicesUpdate);
            if (result == _salonServicesUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateSalonServices=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to Delete Salon Services by SalonServices Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteSalonServices()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DeleteSalonServices(_salonServices.SalonServicesId)).ReturnsAsync(true);
            var resultDelete = await _adminSSServices.DeleteSalonServices(_salonServices.SalonServicesId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteSalonServices=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to test Add Salon Services Plan information is getting added, if added then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Add_Valid_ServicesPlan()
        {
            //Arrange
            bool res = false;
            //Act
            adminService.Setup(repo => repo.AddServicesPlan(_servicesPlan)).ReturnsAsync(_servicesPlan);
            var result = await _adminSSServices.AddServicesPlan(_servicesPlan);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Add_Valid_ServicesPlan=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Salon services Plan by Plan Id and ServicesPlan Collection
        /// if get updated then test Passed to true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateServicesPlan()
        {
            //Arrange
            bool res = false;
            var _servicesPlanUpdate = new ServicesPlan
            {
                PlanId = "5ff45f309c249e27020bffb9",
                PlanName = "Skin Care - Treatments",
                Title = "Spot Lights - Organic Eye- Lip Treatment",
                Description = "Reduce Dryness From Your Eyes And Lips With A Treatment Designed To Tr...",
                Price = 1250,
                ServiceId = 1
            };
            //Act
            adminService.Setup(repo => repo.UpdateServicesPlan(_servicesPlanUpdate.PlanId, _servicesPlanUpdate)).ReturnsAsync(_servicesPlanUpdate);
            var result = await _adminSSServices.UpdateServicesPlan(_servicesPlanUpdate.PlanId, _servicesPlanUpdate);
            if (result == _servicesPlanUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateServicesPlan=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to Delete ServicesPlan by Plan Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteServicesPlan()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DeleteServicesPlan(_servicesPlan.PlanId)).ReturnsAsync(true);
            var resultDelete = await _adminSSServices.DeleteServicesPlan(_servicesPlan.PlanId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteServicesPlan=" + res + "\n");
            return res;
        }
    }
}
