

using FrancoHotel.Application.Test;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FrancoHotel.Persistence.Test
{
    public class UnitTestRecepcion
    {
        private readonly RecepcionRepository _recepcionRepository;
        public UnitTestRecepcion()
        {
            var mockLogger = MocksTest.GetLoggerMock<RecepcionRepository>();
            var mockConfiguration = MocksTest.GetConfigurationBuilderGerardo();
            var mockContext = MocksTest.GetContextInMemory();
            _recepcionRepository = new RecepcionRepository(mockContext, mockLogger.Object, mockConfiguration);
        }

        //---------------------//
        //
        //--------------------//
        //[Fact]
    }
}
