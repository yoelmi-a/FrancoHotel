using System.Linq.Expressions;
using FrancoHotel.Application.Dtos.HabitacionDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;

namespace FrancoHotel.Application.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHabitacionRepository _habitacionRepository;
        private readonly IHabitacionMapper _mapper;
        private readonly IRecepcionRepository _recepcionRepository;
        public HabitacionService(IHabitacionRepository habitacionRepository, 
                                 IHabitacionMapper habitacionMapper, 
                                 IRecepcionRepository recepcionRepository)
        {
            _habitacionRepository = habitacionRepository;
            _mapper = habitacionMapper;
            _recepcionRepository = recepcionRepository;
        }
        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.DtoList(await _habitacionRepository.GetAllAsync());
            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.EntityToDto(await _habitacionRepository.GetEntityByIdAsync(id));
            return result;
        }

        public async Task<OperationResult> Remove(RemoveHabitacionDto dto)
        {
            OperationResult result = new OperationResult();
            Expression<Func<Recepcion, bool>> reservations = x => DateTime.Now <= x.FechaSalida && x.IdHabitacion == dto.IdHabitacion;
            if (await _recepcionRepository.Exists(reservations))
            {
                result.Success = false;
                result.Message = "La habitación no se puede remover porque tiene reservas activas";
                return result;
            }

            Habitacion? habitacion = await _habitacionRepository.GetEntityByIdAsync(dto.IdHabitacion);
            if (habitacion != null)
            {
                result = await _habitacionRepository.RemoveEntityAsync(_mapper.RemoveDtoToEntity(dto, habitacion));
                return result;
            }
            else
            {
                result.Success = false;
                result.Message = "No se pudo encontrar la habitación a remover";
                return result;
            }


        }

        public async Task<OperationResult> Save(SaveHabitacionDto dto)
        {
            OperationResult result = new OperationResult();
            result = await _habitacionRepository.SaveEntityAsync(_mapper.SaveDtoToEntity(dto));
            return result;
        }

        public async Task<OperationResult> Update(UpdateHabitacionDto dto)
        {
            Habitacion? habitacion = await _habitacionRepository.GetEntityByIdAsync(dto.IdHabitacion);
            OperationResult result = new OperationResult();
            if (habitacion != null)
            {
                result = await _habitacionRepository.UpdateEntityAsync(_mapper.UpdateDtoToEntity(dto, habitacion));
            }
            result.Success = false;
            result.Message = "La habitacion a modificar no esta registrada";
            return result;
        }
    }
}
