using BackendMacetas.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendMacetas.Contracts.Services;
public interface IEntityCreator<TBindingModel, TEntity> 
    where TEntity : IEntity
{
    Task<TEntity> CreateAsync(TBindingModel bindingModel);
}
