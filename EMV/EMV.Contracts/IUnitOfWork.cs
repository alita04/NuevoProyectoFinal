﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviromental_Measurement.Contracts
{
    /// <summary>
    /// Define las propiedades y funcionalidades de un elemento de
    /// acceso a datos que utiliza el patrón Unit of Work.
    /// </summary>
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
