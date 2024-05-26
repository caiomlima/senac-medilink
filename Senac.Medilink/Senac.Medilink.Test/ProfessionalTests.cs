using Microsoft.EntityFrameworkCore;
using Moq;
using Senac.Medilink.Data;
using Senac.Medilink.Data.Entity;
using Senac.Medilink.Services;
using Xunit;

namespace Senac.Medilink.Test
{
    public class ProfessionalTests
    {
        private static Mock<DbSet<T>> BuildMockDbSet<T>(IQueryable<T> data) where T : class
        {
            var mockDbSet = new Mock<DbSet<T>>();
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockDbSet;
        }

        [Fact]
        public async Task GetAvailableTimeSlots_ShouldReturnCorrectFreeSlots()
        {
            var professionalId = 1L;
            var startDate = new DateTime(2023, 5, 26, 13, 0, 0);
            var durationInMinutes = 20;
            var cancellationToken = CancellationToken.None;

            var mockDbContext = new Mock<DatabaseContext>();

            var workSchedules = new List<ProfessionalWorkSchedules>
            {
                new ProfessionalWorkSchedules(DayOfWeek.Friday, new TimeSpan(13, 0, 0), new TimeSpan(14, 0, 0), professionalId, 1)
            };

            var workSchedulesDbSet = BuildMockDbSet(workSchedules.AsQueryable());
            mockDbContext.Setup(db => db.ProfessionalWorkSchedules).Returns(workSchedulesDbSet.Object);

            var professionalSchedules = new List<Schedule>
            {
                new Schedule(180, professionalId, 1, 1, startDate, startDate.AddMinutes(durationInMinutes), Common.FormOfService.Presential, Common.ServiceType.Appointment)
            };
            var professionalSchedulesDbSet = BuildMockDbSet(professionalSchedules.AsQueryable());
            mockDbContext.Setup(db => db.Schedules).Returns(professionalSchedulesDbSet.Object);

            var service = new ScheduleService(mockDbContext.Object);
            var availableSlots = await service.GetAvailableSlotsForScheduling(professionalId, startDate, durationInMinutes, cancellationToken);

            Assert.NotNull(availableSlots);
            Assert.Equals(2, availableSlots.Count);
            Assert.True(availableSlots.Any(slot => slot.StartTime == new TimeSpan(13, 0, 0) && slot.EndTime == new TimeSpan(13, 20, 0)));
            Assert.True(availableSlots.Any(slot => slot.StartTime == new TimeSpan(13, 40, 0) && slot.EndTime == new TimeSpan(14, 0, 0)));
        }
    }
}