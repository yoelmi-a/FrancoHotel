using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Repositories;

namespace FrancoHotel.Persistence.Test
{
    public class UnitTestServicios
    {
        private readonly ServiciosRepository _repository;

        public UnitTestServicios()
        {
            var mockLogger = MocksTest.GetLoggerMock<ServiciosRepository>();
            var mockConfiguration = MocksTest.GetConfigurationBuilder();
            var mockContext = MocksTest.GetContextInMemory();
            _repository = new ServiciosRepository(mockContext, mockLogger.Object, mockConfiguration);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenServiciosIsNull()
        {

            //Arange

            Servicios servicios = null;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.SaveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenNombreIsNull(string data)
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = data;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.SaveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenNombreIsTooLong()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = new string('a', 201);

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.SaveEntityAsync(servicios);

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
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = data;
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.SaveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenDescripcionIsTooLong()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = new string('a', 1001);
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.SaveEntityAsync(servicios);

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
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = data;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.SaveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = null;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.SaveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(99999999999)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenPrecioIsNotValid(decimal data)
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = data;
            servicios.Nombre = "Nombre";

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.SaveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenServiciosIsNull()
        {

            //Arange

            Servicios servicios = null;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.UpdateEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenNombreIsNull(string data)
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = data;
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.UpdateEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenNombreIsTooLong()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = new string('a', 201);
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.UpdateEntityAsync(servicios);

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
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = data;
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.UpdateEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenDescripcionIsTooLong()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = new string('a', 1001);
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.UpdateEntityAsync(servicios);

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
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = data;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.UpdateEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = null;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.UpdateEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(99999999999)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenPrecioIsNotValid(decimal data)
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = data;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.UpdateEntityAsync(servicios);

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
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = data;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.UpdateEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenFechaModificacionIsNull()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = null;
            servicios.UsuarioMod = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.UpdateEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenServiciosIsNull()
        {

            //Arange

            Servicios servicios = null;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenNombreIsNull(string data)
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = data;
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenNombreIsTooLong()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = new string('a', 201);
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

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
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = data;
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenDescripcionIsTooLong()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = new string('a', 1001);
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

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
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = data;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = null;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(99999999999)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenPrecioIsNotValid(decimal data)
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = data;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

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
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = data;
            servicios.BorradoPorU = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenFechaModificacionIsNull()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = null;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenBorradoIsNull()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = null;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = 1;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

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
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = data;

            //Act
            string message = "Los datos de el servicio no son válidos";
            var result = await _repository.RemoveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            await _repository.SaveEntityAsync(servicios);

            servicios.Descripcion = "Descripcion modificada";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;

            //Act
            var result = await _repository.UpdateEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = 1;
            await _repository.SaveEntityAsync(servicios);

            servicios.Borrado = false;
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;
            servicios.BorradoPorU = 1;

            //Act
            var result = await _repository.RemoveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange
            Servicios servicios = new Servicios();
            servicios.FechaCreacion = DateTime.Now;
            servicios.CreadorPorU = 1;
            servicios.Borrado = false;
            servicios.Descripcion = "Descripcion";
            servicios.Precio = 10;
            servicios.Nombre = "Nombre";
            servicios.FechaModificacion = DateTime.Now;
            servicios.UsuarioMod = 1;

            //Act
            var result = await _repository.SaveEntityAsync(servicios);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }
    }
}
