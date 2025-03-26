using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Moq;

namespace FrancoHotel.Application.Test
{
    public class UnitTestPisoService
    {
        private readonly PisoService _service;
        private readonly HabitacionRepository _mockHabitacionRepository;
        private readonly RecepcionRepository _mockRecepcionRepository;
        private readonly PisoRepository _mockPisoRepository;
        public UnitTestPisoService()
        {
            var mockLogger = MocksTest.GetLoggerMock<PisoService>();
            var mockPisoRepository = new Mock<IPisoRepository>().Object;
            var mockRecepcionRepository = new Mock<IRecepcionRepository>().Object;
            var mockMapper = new Mock<IPisoMapper>();
            var mockConfiguration = MocksTest.GetConfigurationBuilder();
            _service = new PisoService(mockPisoRepository, mockLogger.Object, mockConfiguration, mockMapper.Object, mockRecepcionRepository);

            var mockContext = MocksTest.GetContextInMemory();
            var mockLoggerHabitacion = MocksTest.GetLoggerMock<HabitacionRepository>();
            _mockHabitacionRepository = new HabitacionRepository(mockContext, mockLoggerHabitacion.Object, mockConfiguration);

            var mockLoggerPisoRepository = MocksTest.GetLoggerMock<PisoRepository>();
            _mockPisoRepository = new PisoRepository(mockContext, mockLoggerPisoRepository.Object, mockConfiguration);
            
            var mockLoggerRecepcionRepository = MocksTest.GetLoggerMock<RecepcionRepository>();
            _mockRecepcionRepository = new RecepcionRepository(mockContext, mockLoggerRecepcionRepository.Object, mockConfiguration);
        }

        [Fact]
        public async void Remove_ShouldReturnFailure_WhenPisoHasReservations()
        {
            //Arrange

            Piso piso = new Piso();
            piso.Id = 1;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.Estado = true;
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.Borrado = false;
            
            piso.CreadorPorU = 1;
            RemovePisoDto pisodto = new RemovePisoDto();
            pisodto.Usuario = 1;
            pisodto.Fecha = DateTime.Now;
            pisodto.Id = 1;
            var resultp = await _mockPisoRepository.SaveEntityAsync(piso);

            Habitacion habitacion = new Habitacion();
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;
            habitacion.Id = 1;
            var resulth = await _mockHabitacionRepository.SaveEntityAsync(habitacion);

            Recepcion recepcion = new Recepcion();
            recepcion.Observacion = "a";
            recepcion.FechaEntrada = DateTime.Now;
            recepcion.FechaSalida = new DateTime(2025, 4, 21);
            recepcion.Adelanto = 200;
            recepcion.Borrado = false;
            recepcion.CantidadPersonas = 1;
            recepcion.Estado = EstadoReserva.Confirmada;
            recepcion.IdCliente = 1;
            recepcion.IdHabitacion = 1;
            recepcion.IdServicioPorCategoria = 1;
            recepcion.PrecioInicial = 400;
            recepcion.PrecioRestante = 200;
            recepcion.CreadorPorU = 1;
            recepcion.TotalPagado = 200;
            recepcion.Id = 1;
            recepcion.CreadorPorU = 1;
            var resultr = await _mockRecepcionRepository.SaveEntityAsync(recepcion);


            //Act
            string message = "El piso no se puede remover porque tiene reservas activas";
            var result = await _service.Remove(pisodto);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.True(resultp.Success);
            Assert.True(resulth.Success);
            Assert.True(resultr.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void GetById_ShouldReturnTrue_WhenDataIsCorrect()
        {
            //Arrange

            Piso piso = new Piso();
            piso.Id = 1;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.Estado = true;
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.Borrado = false;

            piso.CreadorPorU = 1;
            RemovePisoDto pisodto = new RemovePisoDto();
            pisodto.Usuario = 1;
            pisodto.Fecha = DateTime.Now;
            pisodto.Id = 1;

            var resultp = await _mockPisoRepository.SaveEntityAsync(piso);
            //Act
            var result = await _service.GetById(pisodto.Id);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
            Assert.True(resultp.Success);
        }
    }
}
