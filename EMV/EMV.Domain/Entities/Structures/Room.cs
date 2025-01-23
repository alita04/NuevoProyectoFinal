using Enviromental_Measurement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviromental_Measurement.Domain.Entities.Structures
{

    public class Room : Entity
    {
        #region Properties
        public int Number { get; set; }
        public bool IsProduction { get; set; }

        public string? Description { get; set; }

        public Guid FloorId { get; set; } 

    


        #endregion

        #region Constructos
        public Room() {

            Number = 0;
            IsProduction = false;
            Description =string.Empty;
            FloorId = Guid.Empty;
           
        
        }

        public Room(Guid id,int number, bool isProduction, string? description, Guid floorId) : base(id)
        {
            
            Number = number;
            IsProduction = isProduction;
            Description = description;
            FloorId = floorId;
            
        }

       
        #endregion
    }
}
 