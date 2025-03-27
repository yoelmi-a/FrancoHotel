using FrancoHotel.Application.Dtos.ServiciosDto;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;

namespace FrancoHotel.Application.Services
{
    public class ServiciosService : IServiciosService
    {
        private readonly IServiciosMapper _mapper;
        private readonly IServiciosRepository _repository;

        public ServiciosService(IServiciosRepository serviciosRepository, IServiciosMapper mapper)
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

        public async Task<OperationResult> Remove(RemoveServiciosDto dto)
        {
            //Faltan validaciones
            OperationResult result = new OperationResult();
            Servicios? servicios = await _repository.GetEntityByIdAsync(dto.IdServicio);
            if (servicios != null)
            {
                result = await _repository.RemoveEntityAsync(_mapper.RemoveDtoToEntity(dto, servicios));
            }
            else
            {
                result.Success = false;
                result.Message = "No se pudo encontrar el servicio para remover";
            }
            return result;
        }

        public async Task<OperationResult> Save(SaveServiciosDto dto)
        {
            OperationResult result = new OperationResult();
            result = await _repository.SaveEntityAsync(_mapper.SaveDtoToEntity(dto));
            return result;
        }

        public async Task<OperationResult> Update(UpdateServiciosDto dto)
        {
            Servicios? servicios = await _repository.GetEntityByIdAsync(dto.IdServicio);
            OperationResult result = new OperationResult();
            if (servicios != null)
            {
                result = await _repository.UpdateEntityAsync(_mapper.UpdateDtoToEntity(dto, servicios));
            }
            else
            {
                result.Success = false;
                result.Message = "El servicio a modificar no está registrado";
            }
            return result;
        }
    }
}
