using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Repositories;

namespace FrancoHotel.Persistence.Test
{
    public class UnitTestPiso
    {
        private readonly PisoRepository _repository;
        public UnitTestPiso()
        {
            var mockLogger = MocksTest.GetLoggerMock<PisoRepository>();
            var mockConfiguration = MocksTest.GetConfigurationBuilder();
            var mockContext = MocksTest.GetContextInMemory();
            _repository = new PisoRepository(mockContext, mockLogger.Object, mockConfiguration);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenPisoIsNull()
        {

            //Arange

            Piso piso = null;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.SaveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenDescripcionIsNull(string data)
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = data;
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.SaveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenDescripcionIsTooLong()
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.SaveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenEstadoIsNull()
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = null;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.SaveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = null;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.SaveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenCreadorPorUIsLessThan1(int data)
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = data;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.SaveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenPisoIsNull()
        {

            //Arange

            Piso piso = null;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.UpdateEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenDescripcionIsNull(string data)
        {

            //Arange

            Piso piso = new Piso();
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = data;
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.UpdateEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenDescripcionIsTooLong()
        {

            //Arange

            Piso piso = new Piso();
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.UpdateEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenEstadoIsNull()
        {

            //Arange

            Piso piso = new Piso();
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = null;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.UpdateEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange

            Piso piso = new Piso();
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = null;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.UpdateEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenCreadorPorUIsLessThan1(int data)
        {

            //Arange

            Piso piso = new Piso();
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = data;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.UpdateEntityAsync(piso);

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

            Piso piso = new Piso();
            piso.Id = data;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.UpdateEntityAsync(piso);

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

            Piso piso = new Piso();
            piso.Id = 1;
            piso.UsuarioMod = data;
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.UpdateEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenFechaModificacionIsNull()
        {

            //Arange

            Piso piso = new Piso();
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = null;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.UpdateEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenPisoIsNull()
        {

            //Arange

            Piso piso = null;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.RemoveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenDescripcionIsNull(string data)
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = data;
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.Borrado = true;
            piso.BorradoPorU = 1;


            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.RemoveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenDescripcionIsTooLong()
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.Borrado = true;
            piso.BorradoPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.RemoveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenEstadoIsNull()
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = null;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.Borrado = true;
            piso.BorradoPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.RemoveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = null;
            piso.CreadorPorU = 1;
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.Borrado = true;
            piso.BorradoPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.RemoveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenCreadorPorUIsLessThan1(int data)
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = data;
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.Borrado = true;
            piso.BorradoPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.RemoveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenFechaModificacionIsNull()
        {

            //Arange

            Piso piso = new Piso();
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = null;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;
            piso.Borrado = true;
            piso.BorradoPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.RemoveEntityAsync(piso);

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

            Piso piso = new Piso();
            piso.Id = 1;
            piso.UsuarioMod = data;
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;
            piso.Borrado = true;
            piso.BorradoPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.RemoveEntityAsync(piso);

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

            Piso piso = new Piso();
            piso.Id = data;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;
            piso.Borrado = true;
            piso.BorradoPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.RemoveEntityAsync(piso);

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

            Piso piso = new Piso();
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;
            piso.Borrado = true;
            piso.BorradoPorU = data;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.RemoveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenBorradoIsNull()
        {

            //Arange

            Piso piso = new Piso();
            piso.Id = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;
            piso.Borrado = null;
            piso.BorradoPorU = 1;

            //Act
            string message = "Los datos del piso no son válidos";
            var result = await _repository.RemoveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async Task RemoveEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange

            Piso piso = new Piso();
            piso.Id = 1;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            await _repository.SaveEntityAsync(piso);
            piso.Borrado = true;
            piso.BorradoPorU = 1;
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            var result = await _repository.RemoveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange

            Piso piso = new Piso();
            piso.FechaModificacion = DateTime.Now;
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;

            //Act
            var result = await _repository.SaveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task UpdateEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = "Descripcion";
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            await _repository.SaveEntityAsync(piso);
            piso.UsuarioMod = 1;
            piso.FechaModificacion = DateTime.Now;
            var result = await _repository.UpdateEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }
    }
}
