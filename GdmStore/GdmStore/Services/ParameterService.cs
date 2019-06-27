using System.Threading.Tasks;
using GdmStore.Models;
using GdmStore.Services.Interfaces;

namespace GdmStore.Services
{
    public class ParameterService : BaseService<Parameter>, IParameterService
    {
        private readonly DataContext _context;

        public ParameterService(DataContext context) : base(context)
        {
            _context = context;
        }


        public async Task<Parameter> UpdateParameter(long id, Parameter parameter)
        {
            Parameter p = await GetItem(parameter.Id);
            p.Name = parameter.Name;
            await _context.SaveChangesAsync();
            return parameter;
        }
    }
}
