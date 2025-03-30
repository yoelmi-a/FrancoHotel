using FrancoHotel.Application.Dtos.CategoriaDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace FrancoHotel.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IHabitacionRepository habitacionRepository;
        private readonly ILogger<CategoriaService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICategoriaMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository,
                                IHabitacionRepository habitacionRepository,
                                ILogger<CategoriaService> logger,
                                IConfiguration configuration,
                                ICategoriaMapper mapper)
        {
            this._categoriaRepository = categoriaRepository;
            this.habitacionRepository = habitacionRepository;
            this._logger = logger;
            this._configuration = configuration;
            _mapper = mapper;
        }

        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.DtoList(await _categoriaRepository.GetAllAsync());
            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.EntityToDto(await _categoriaRepository.GetEntityByIdAsync(id));
            return result;
        }

        public async Task<OperationResult> Remove(RemoveCategoriaDto dto)
        {
            OperationResult result = new OperationResult();

            Expression<Func<Habitacion, bool>> habitaciones = x => x.IdCategoria == dto.Id;
            if (await habitacionRepository.Exists(habitaciones))
            {
                result.Success = false;
                result.Message = _configuration["ErrorCategoriaService:CategoriaConHabitacionesAsociadas"];
                return result;
            }


            Categoria? categoria = await _categoriaRepository.GetEntityByIdAsync(dto.Id);
            if (categoria != null)
            {
                result = await _categoriaRepository.RemoveEntityAsync(_mapper.RemoveDtoToEntity(dto, categoria));
                return result;
            }
            else
            {
                result.Success = false;
                result.Message = _configuration["ErrorCategoriaService:CategoriaNoEncontrada"];
                return result;
            }
        }

        public async Task<OperationResult> Save(SaveCategoriaDto dto)
        {
            OperationResult result = new OperationResult();

            if (dto == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorCategoriaService:DatosInvalidos"];
                return result;
            }

            result = await _categoriaRepository.SaveEntityAsync(_mapper.SaveDtoToEntity(dto));
            return result;
        }

        public async Task<OperationResult> Update(UpdateCategoriaDto dto)
        {
            OperationResult result = new OperationResult();

            if (dto == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorCategoriaService:DatosInvalidos"];
                return result;
            }

            var categoria = await _categoriaRepository.GetEntityByIdAsync(dto.Id);

            result = await _categoriaRepository.UpdateEntityAsync(_mapper.UpdateDtoToEntity(dto, categoria));

            return result;
        }

    }
}
