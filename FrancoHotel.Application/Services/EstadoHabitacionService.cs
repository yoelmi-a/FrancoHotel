using System.Linq.Expressions;
using FrancoHotel.Application.Dtos.EstadoHabitacionDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;

namespace FrancoHotel.Application.Services
{
    public class EstadoHabitacionService : IEstadoHabitacionService
    {
        private readonly IEstadoHabitacionMapper _mapper;
        private readonly IEstadoHabitacionRepository _repository;
        private readonly IHabitacionRepository _habitacionRepository;

        public EstadoHabitacionService(IEstadoHabitacionRepository serviciosRepository, IEstadoHabitacionMapper mapper)
        {
            _mapper = mapper;
            _repository = serviciosRepository;
        }
        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.DtoList(await _repository.GetAllAsync());
            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.EntityToDto(await _repository.GetEntityByIdAsync(id));
            return result;
        }

        public async Task<OperationResult> Remove(RemoveEstadoHabitacionDto dto)
        {
            OperationResult result = new OperationResult();
            Expression<Func<Habitacion, bool>> IsNotRemoved = h => h.Borrado == false && h.IdEstadoHabitacion == dto.IdEstadoHabitacion;

            if (await _habitacionRepository.Exists(IsNotRemoved))
            {
                result.Success = false;
                result.Message = "El estado no se puede remover porque tiene habitaciones activas";
                return result;
            }
            EstadoHabitacion? estado = await _repository.GetEntityByIdAsync(dto.IdEstadoHabitacion);
            if (estado != null)
            {
                result = await _repository.UpdateEntityAsync(_mapper.RemoveDtoToEntity(dto, estado));
            }
            else
            {
                result.Success = false;
                result.Message = "El estado a remover no está registrado";
            }
            return result;
        }

        public async Task<OperationResult> Save(SaveEstadoHabitacionDto dto)
        {
            OperationResult result = new OperationResult();
            result = await _repository.SaveEntityAsync(_mapper.SaveDtoToEntity(dto));
            return result;
        }

        public async Task<OperationResult> Update(UpdateEstadoHabitacionDto dto)
        {
            EstadoHabitacion? estado = await _repository.GetEntityByIdAsync(dto.IdEstadoHabitacion);
            OperationResult result = new OperationResult();
            if (estado != null)
            {
                result = await _repository.UpdateEntityAsync(_mapper.UpdateDtoToEntity(dto, estado));
            }
            else
            {
                result.Success = false;
                result.Message = "El estado a modificar no está registrado";
            }
            return result;
        }
    }
}
