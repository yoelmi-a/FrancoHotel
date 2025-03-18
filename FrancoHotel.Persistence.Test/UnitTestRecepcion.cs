using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
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
        //SaveEntityAsync
        //--------------------//
        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenRecepcionIsNull()
        {
            // Arrange
            Recepcion recepcion = null;

            // Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenRecepcionCreadoPorUIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                CreadorPorU = id
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenRecepcionIdClienteIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                IdCliente = id
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenRecepcionIdHabitacionIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                IdHabitacion = id
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenRecepcionFechaEntradaIsNull()
        {
            //Arrange
            var recepcion = new Recepcion
            {
                FechaEntrada = null
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenRecepcionFechaSalidaIsNull()
        {
            //Arrange
            var recepcion = new Recepcion
            {
                FechaSalida = null
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void SaveEntityAsync_ShoulRetunrFailure_WhenRecepcionPrecioInicialIsNull(int precioinicial)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                PrecioInicial = precioinicial
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        
        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void SaveEntityAsync_ShouldRetunrFailure_WhenAdelantoIsNull(int adelanto)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                Adelanto = adelanto
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(999999999)]
        public async void SaveEntityAsync_ShouldRetunrFailure_WhenPrecioRestanteIsNull(int precio)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                PrecioRestante = precio
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
        

        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenRecepcionTotalPagadoIsNull(int? TotalPagado)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                TotalPagado = TotalPagado
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(999999999)]
        public async void SaveEntityAsync_ShouldRetunrFailure_WhenCostoPenalidadIsNull(int precio)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                CostoPenalidad = precio
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenObservacionIsGreaterThan500()
        {
            //Arrange
            var recepcion = new Recepcion
            {
                Observacion = new string('a', 501)
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            //Arrange
            var recepcion = new Recepcion()
            {
                Observacion = " "
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData((EstadoReserva)0)]
        [InlineData((EstadoReserva)4)]
        public async void SaveEntityAsync_ShouldRetunrFailure_WhenEstadoIsNull(EstadoReserva estado)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                Estado = estado
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldRetunrFailure_WhenCantidadPersonasIsNull(int cantidad)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                CantidadPersonas = cantidad
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenRecepcionIdServicioPorCategoriaIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                IdServicioPorCategoria = id
            }; 

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenRecepcionPrecioServiciosExtraIsNull(int precio)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                PrecioServiciosExtra = precio
            };

            //Act
            string message = "Error al crear Recepcion por datos invalidos";
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
        //---------------------//
        //UpdateEntityAsync
        //--------------------//
        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionIsNull()
        {
            // Arrange
            Recepcion recepcion = null;

            // Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionCreadoPorUIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                CreadorPorU = id
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionIdClienteIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                IdCliente = id
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionIdHabitacionIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                IdHabitacion = id
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionFechaEntradaIsNull()
        {
            //Arrange
            var recepcion = new Recepcion
            {
                FechaEntrada = null
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionFechaSalidaIsNull()
        {
            //Arrange
            var recepcion = new Recepcion
            {
                FechaSalida = null
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionFechaSalidaConfirmacionIsNull()
        {
            //Arrange
            var recepcion = new Recepcion
            {
                FechaSalidaConfirmacion = null
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void UpdateEntityAsync_ShoulRetunrFailure_WhenRecepcionPrecioInicialIsNull(int precioinicial)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                PrecioInicial = precioinicial
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void UpdateEntityAsync_ShouldRetunrFailure_WhenAdelantoIsNull(int adelanto)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                Adelanto = adelanto
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(999999999)]
        public async void UpdateEntityAsync_ShouldRetunrFailure_WhenPrecioRestanteIsNull(int precio)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                PrecioRestante = precio
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionTotalPagadoIsNull(int? TotalPagado)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                TotalPagado = TotalPagado
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(999999999)]
        public async void UpdateEntityAsync_ShouldRetunrFailure_WhenCostoPenalidadIsNull(int precio)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                CostoPenalidad = precio
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenObservacionIsGreaterThan500()
        {
            //Arrange
            var recepcion = new Recepcion
            {
                Observacion = new string('a', 501)
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            //Arrange
            var recepcion = new Recepcion()
            {
                Observacion = " "
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData((EstadoReserva)0)]
        [InlineData((EstadoReserva)4)]
        public async void UpdateEntityAsync_ShouldRetunrFailure_WhenEstadoIsNull(EstadoReserva estado)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                Estado = estado
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void UpdateEntityAsync_ShouldRetunrFailure_WhenCantidadPersonasIsNull(int cantidad)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                CantidadPersonas = cantidad
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionIdServicioPorCategoriaIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                IdServicioPorCategoria = id
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionPrecioServiciosExtraIsNull(int precio)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                PrecioServiciosExtra = precio
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionIdIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                Id = id
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionUsuarioModIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                UsuarioMod = id
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRecepcionFechaModificacionIsNull()
        {
            //Arrange
            var recepcion = new Recepcion
            {
                FechaModificacion = null
            };

            //Act
            string message = "Error al actualizar Recepcion por datos invalidos";
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //---------------------//
        //RemoveEntityAsync
        //--------------------//
        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRecepcionIsNull()
        {
            // Arrange
            Recepcion recepcion = null;

            // Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRecepcionCreadoPorUIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                CreadorPorU = id
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRecepcionIdClienteIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                IdCliente = id
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRecepcionIdHabitacionIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                IdHabitacion = id
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRecepcionFechaEntradaIsNull()
        {
            //Arrange
            var recepcion = new Recepcion
            {
                FechaEntrada = null
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRecepcionFechaSalidaIsNull()
        {
            //Arrange
            var recepcion = new Recepcion
            {
                FechaSalida = null
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void RemoveEntityAsync_ShoulRetunrFailure_WhenRecepcionPrecioInicialIsNull(int precioinicial)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                PrecioInicial = precioinicial
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void RemoveEntityAsync_ShouldRetunrFailure_WhenAdelantoIsNull(int adelanto)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                Adelanto = adelanto
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(999999999)]
        public async void RemoveEntityAsync_ShouldRetunrFailure_WhenPrecioRestanteIsNull(int precio)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                PrecioRestante = precio
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRecepcionTotalPagadoIsNull(int? TotalPagado)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                TotalPagado = TotalPagado
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(999999999)]
        public async void RemoveEntityAsync_ShouldRetunrFailure_WhenCostoPenalidadIsNull(int precio)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                CostoPenalidad = precio
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenObservacionIsGreaterThan500()
        {
            //Arrange
            var recepcion = new Recepcion
            {
                Observacion = new string('a', 501)
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            //Arrange
            var recepcion = new Recepcion()
            {
                Observacion = " "
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData((EstadoReserva)0)]
        [InlineData((EstadoReserva)4)]
        public async void RemoveEntityAsync_ShouldRetunrFailure_WhenEstadoIsNull(EstadoReserva estado)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                Estado = estado
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void RemoveEntityAsync_ShouldRetunrFailure_WhenCantidadPersonasIsNull(int cantidad)
        {
            //Arrange  
            var recepcion = new Recepcion
            {
                CantidadPersonas = cantidad
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRecepcionIdServicioPorCategoriaIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion
            {
                IdServicioPorCategoria = id
            };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRecepcionPrecioServiciosExtraIsNull(int precio)
        {
            //Arrange
            var recepcion = new Recepcion { PrecioServiciosExtra = precio };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRecepcionFechaModificacionIsNull()
        {
            //Arrange
            var recepcion = new Recepcion { FechaModificacion = null };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRecepcionUsuarioModIsLessThan1(int id)
        {
            //Arrange
            var recepcion = new Recepcion { BorradoPorU = id };

            //Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenBorradoIsNull()
        {
            // Arrange
            var recepcion = new Recepcion { Borrado = null };

            // Act
            string message = "Error al borrar Recepcion por datos invalidos";
            var result = await _recepcionRepository.RemoveEntityAsync(recepcion);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}
