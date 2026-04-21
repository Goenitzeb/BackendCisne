using System;
using System.Collections.Generic;
using System.Text;

namespace BackendMacetas.Contracts.Services;

public interface IConverter<TSource, TDestination>
{
    TDestination Convert(TSource source);
}
