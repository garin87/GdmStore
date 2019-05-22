using GdmStore.DTO;
using GdmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.Services.Interfaces
{
    public interface IProductParameterService : IBaseServices<ProductParameter>
    {
        Task<IEnumerable<ProductParameter>> GetProductParameters(long id);
        Task<List<string>> GetProductDiameters(int id, string param, int paramId);
        Task<IEnumerable<ProductDTO>> GetProductsByDiameter(int typeId, string param, int paramId, int paramDiameterId, string diameter);
        Task<IEnumerable<ProductParameter>> GetSortProductParameters(long id);
        Task<double> GetSumSteelBars(int value);
        Task<double> GetSumTubes(int value);
        Task<double> GetSumAmountByParam(int typeId, string param, int paramId, int paramDiameterId, string diameter);
    }
}
