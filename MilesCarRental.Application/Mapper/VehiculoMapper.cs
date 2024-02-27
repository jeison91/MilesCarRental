using MilesCarRental.Application.DTO.Response;
using MilesCarRental.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Mapper
{
    public static class VehiculoMapper
    {
        public static VehiculoResponseDTO MapDTO(VehiculoModel model)
        {
            //var model = new CustomerDTO();
            if (model != null)
                return AttibutesDTO(model);
            return null;
        }

        public static List<VehiculoResponseDTO> MapDTOList(List<VehiculoModel> model)
        {
            List<VehiculoResponseDTO> responseDTOs = new();
            if (model != null)
            {
                foreach (VehiculoModel item in model)
                {
                    var fl = AttibutesDTO(item);
                    responseDTOs.Add(fl);
                }
            }
            return responseDTOs;
        }

        private static VehiculoResponseDTO AttibutesDTO(VehiculoModel model)
        {
            if (model != null)
            {
                return new VehiculoResponseDTO()
                {
                    Id = model.Id,
                    Placa = model.Placa,
                    Modelo = model.Modelo,
                    Marca = model.Marca.Descripcion,
                    UbicacionActual = model.Localidad.Nombre
                };
            }
            return new VehiculoResponseDTO();
        }
    }
}
