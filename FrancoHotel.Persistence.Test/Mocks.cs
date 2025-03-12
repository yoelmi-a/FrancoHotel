using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace FrancoHotel.Application.Test
{
    public static class MocksTest
    {
        public static HotelContext GetContextInMemory()
        {
            var options = new DbContextOptionsBuilder<HotelContext>()
                .UseInMemoryDatabase(databaseName: "DBHotelYoelmi")
                .Options;
            return new HotelContext(options);
        }

        public static Mock<ILogger<TRepository>> GetLoggerMock<TRepository>()
        {
            return new Mock<ILogger<TRepository>>();
        }

        public static IConfigurationRoot GetConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("C:\\Users\\Yoelmi\\Proyecto Final\\FrancoHotel\\FrancoHotel.Web\\appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
