using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Repositories;

namespace FrancoHotel.Persistence.Test
{
    public class UnitTestHabitacion
    {
        private readonly HabitacionRepository _repository;

        public UnitTestHabitacion()
        {
            var mockLogger = MocksTest.GetLoggerMock<HabitacionRepository>();
            var mockConfiguration = MocksTest.GetConfigurationBuilder();
            var mockContext = MocksTest.GetContextInMemory();
            _repository = new HabitacionRepository(mockContext, mockLogger.Object, mockConfiguration);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenHabitacionIsNull()
        {

            //Arange

            Habitacion habitacion = null;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.SaveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenDetalleIsNull(string data)
        {

            //Arange

            Habitacion habitacion = new Habitacion();
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = data;
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.SaveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenDetalleIsTooLong()
        {

            //Arange

            Habitacion habitacion = new Habitacion();
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = new string('a', 101);
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.SaveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenNumeroIsNull(string data)
        {

            //Arange

            Habitacion habitacion = new Habitacion();
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = data;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.SaveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenNumeroIsTooLong()
        {

            //Arange

            Habitacion habitacion = new Habitacion();
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = new string('a', 51);
            habitacion.CreadorPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.SaveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenIdPisoIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = data;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.SaveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenIdCategoriaIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = data;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.SaveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenEstadoIsNull()
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = null;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.SaveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = null;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.SaveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenIdCreadorporUIsLessThan1(int data)
        {

            //Arange
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
            habitacion.CreadorPorU = data;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.SaveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenHabitacionIsNull()
        {

            //Arange

            Habitacion habitacion = null;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenDetalleIsNull(string data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = data;
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenDetalleIsTooLong()
        {

            //Arange

            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = new string('a', 101);
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenNumeroIsNull(string data)
        {

            //Arange

            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = data;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenNumeroIsTooLong()
        {

            //Arange

            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = new string('a', 51);
            habitacion.CreadorPorU = 1;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenIdPisoIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = data;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenIdCategoriaIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = data;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenEstadoIsNull()
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = null;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = null;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenIdCreadorporUIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = data;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenIdIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = data;
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
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenUsuarioModIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
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
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = data;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenFechaModificacionIsNull()
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
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
            habitacion.FechaModificacion = null;
            habitacion.UsuarioMod = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenHabitacionIsNull()
        {

            //Arange

            Habitacion habitacion = null;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenDetalleIsNull(string data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = data;
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenDetalleIsTooLong()
        {

            //Arange

            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = new string('a', 101);
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenNumeroIsNull(string data)
        {

            //Arange

            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = data;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenNumeroIsTooLong()
        {

            //Arange

            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = new string('a', 51);
            habitacion.CreadorPorU = 1;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdPisoIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = data;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdCategoriaIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = data;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenEstadoIsNull()
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = null;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = null;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = 1;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdCreadorporUIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
            habitacion.IdEstadoHabitacion = 1;
            habitacion.Capacidad = 2;
            habitacion.Borrado = false;
            habitacion.Detalle = "Detalles";
            habitacion.EstadoYFecha.FechaCreacion = DateTime.Now;
            habitacion.EstadoYFecha.Estado = true;
            habitacion.IdCategoria = 1;
            habitacion.IdPiso = 1;
            habitacion.Numero = "1";
            habitacion.CreadorPorU = data;
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = data;
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
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenUsuarioModIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
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
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = data;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenFechaModificacionIsNull()
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
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
            habitacion.FechaModificacion = null;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenBorradoPorUIsLessThan1(int data)
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
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
            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = data;

            //Act
            string message = "Los datos de la habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange
            Habitacion habitacion = new Habitacion();
            habitacion.Id = 1;
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
            await _repository.SaveEntityAsync(habitacion);

            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.BorradoPorU = 1;
            habitacion.Borrado = true;

            //Act
            var result = await _repository.RemoveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange
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
            await _repository.SaveEntityAsync(habitacion);

            habitacion.FechaModificacion = DateTime.Now;
            habitacion.UsuarioMod = 1;
            habitacion.Detalle = "Detalles modificados";

            //Act
            var result = await _repository.UpdateEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange
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

            //Act
            var result = await _repository.SaveEntityAsync(habitacion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }
    }
}
