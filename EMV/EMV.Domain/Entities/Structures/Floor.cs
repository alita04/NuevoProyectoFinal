using Enviromental_Measurement.Domain.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviromental_Measurement.Domain.Entities.Structures
{
    public class Floor : Entity
    {

        #region Properties
        public string Location { get; set; }
       
        public Guid Building_Id { get; set; }

       

        

        #endregion

        #region Constructors
        public Floor() { 
        
            Location = string.Empty;
            Building_Id = Guid.Empty;
        
        }


        public Floor(Guid id, string location, Guid building_Id) : base(id)
        {
            
            Building_Id = building_Id;
            Location = location;
            
            
        }

        

     

        #endregion
    }
}

