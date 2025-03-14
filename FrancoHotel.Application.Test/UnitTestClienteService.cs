
using FrancoHotel.Application.Services;

namespace FrancoHotel.Application.Test
{
    public class UnitTestClienteService
    {
        private readonly ClienteService _clienteService;
        public UnitTestClienteService()
        {
            var mockLogger = MocksTest.GetLoggerMock<ClienteService>();
            var mockConfiguration = MocksTest.GetConfigurationBuilderELi();
            var mockContext = MocksTest.GetContextInMemory();
            _clienteService = new ClienteService(mockContext, mockLogger.Object, mockConfiguration);
        }

        [Fact]
        public async void Save_ShouldReturnFailure_WhenNombreIsInvalid()
        {

        }
    }
}