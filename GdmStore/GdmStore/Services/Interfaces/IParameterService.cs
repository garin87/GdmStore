using GdmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.Services.Interfaces
{
    public interface IParameterService : IBaseServices<Parameter>
    {
        Task<Parameter> UpdateParameter(long id, Parameter parameter);
    }
}
