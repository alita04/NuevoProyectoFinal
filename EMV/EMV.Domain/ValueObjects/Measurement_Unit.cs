using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMV.Domain.Common;

namespace EMV.Domain.ValueObjects
{
    public class Measurement_Unit : ValueObject
    {

        #region Properties
        public string Symbol { get; }
        public string Name { get; }
        #endregion


        public Measurement_Unit(string symbol, string name)
        {

            Symbol = symbol;
            Name = name;

        }


        #region Value Object Desing Pattern

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones
        /// </summary>
        protected Measurement_Unit()
        {
            Symbol = string.Empty;
            Name = string.Empty;
        }

        public override string ToString()
        {
            return $"{Symbol},{Name}";
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Symbol;
            yield return Name;
        }
        #endregion
    }
}
