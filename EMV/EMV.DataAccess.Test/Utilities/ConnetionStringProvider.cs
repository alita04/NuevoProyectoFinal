﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviromental_Variable_Measurement.DataAccess.Tests.Utilities
{
    /// <summary>
    /// Proveedor de cadenas de conexión.
    /// </summary>
    public static class ConnectionStringProvider
    {
        /// <summary>
        /// Obtiene la cadena de conexión a utilizar en las pruebas.
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString() => "Data Source =  EMVDB.sqlite";

    }
}
