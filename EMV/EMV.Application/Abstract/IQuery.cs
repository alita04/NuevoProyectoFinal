using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eviromental_Variable_Measurement.Application.Abstract
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
