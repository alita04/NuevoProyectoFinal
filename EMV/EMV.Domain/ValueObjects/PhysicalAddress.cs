using Enviromental_Measurement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviromental_Measurement.Domain.ValueObjects
{
    public class PhysicalAddress : ValueObject
    {
        #region Properties

        /// <summary>
        /// País.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Ciudad.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Dirección local.
        /// </summary>
        public string Address { get; }

        #endregion


        public PhysicalAddress() { }

        /// <summary>
        /// Inicializa un objeto <see cref="PhysicalLocation"/>.
        /// </summary>
        /// <param name="country">País.</param>
        /// <param name="city">Ciudad.</param>
        /// <param name="address">Dirección.</param>
        public PhysicalAddress(string country, string city, string address)
        {
            Country = country;
            City = city;
            Address = address;
        }

        public override string ToString()
        {
            return $"{Country},{City},{Address}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country;
            yield return City;
            yield return Address;
        }
    }


}







