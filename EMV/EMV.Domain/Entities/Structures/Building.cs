using Enviromental_Measurement.Domain.Common;
using Enviromental_Measurement.Domain.ValueObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviromental_Measurement.Domain.Entities.Structures;

public class Building : Entity
{
    #region Properties
    public PhysicalAddress Address { get; set; } 
    public int BuildingNumber { get; set; } 
    
  

    #endregion

    #region Constructors

    public Building() {

        Address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
        BuildingNumber = 0;
    
    
    }

    public Building(Guid id, PhysicalAddress address, int buildingNumber) : base(id)
    {
        Address = address;
        BuildingNumber = buildingNumber;
      
        
    }

   
    #endregion
}

