using Enviromental_Measurement.Domain.Common;
using Enviromental_Measurement.Domain.Types;

using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviromental_Measurement.Domain.Entities.Samples
{

    public  class Sample : Entity
    {
        #region Properties
        public DateTime DateTime { get; set; }

        public Guid VariableId { get; set; }

        public SampleType type { get; set; }

        public double? DecimalValue { get; set; } 
        public int? IntValue { get; set; }  
        public bool? BoolValue { get; set; }

        #endregion

        #region Constructors



        public Sample()
        {

        }

        public Sample(Guid id,DateTime dateTime, Guid variableID, SampleType Type, double? decimalValue = null, int? intValue = null, bool? boolValue = null) : base(id)
        {
            DateTime = dateTime;
            VariableId = variableID; 
            type = Type;

            // Asignar el valor correspondiente según el tipo de muestra
            switch (Type)
            {
                case SampleType.ContinueSample:
                    DecimalValue = decimalValue;
                    break;
                case SampleType.BooleanSample:
                    BoolValue= boolValue;
                    break;
                case SampleType.DiscreteSample:
                    IntValue = intValue;
                    break;
                default:
                    throw new ArgumentException("Tipo de muestra no válido");
            }
        }

        
           
       
        #endregion
    }
}
