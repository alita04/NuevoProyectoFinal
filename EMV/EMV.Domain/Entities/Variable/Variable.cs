
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enviromental_Measurement.Domain.Entities.Structures;
using System.ComponentModel.DataAnnotations.Schema;
using Enviromental_Measurement.Domain.Entities.Samples;
using Enviromental_Measurement.Domain.Types;
using Enviromental_Measurement.Domain.Common;
using Enviromental_Measurement.Domain.ValueObjects;

namespace Enviromental_Measurement.Domain.Entities.Variable;

/// <summary>
/// Clase base para las Variables de Medicion
/// </summary>
public class Variable : Entity
{


    #region Properties

    public string VariableName { get; set; }

    public Measurement_Unit unit { get; set; }

    public string VariableCode { get; set; }

    public VariableType type { get; set; }
    public Guid? BuildingID { get; set; }

    public Guid? FloorID { get; set; }
    public Guid? RoomID { get; set; }

    #endregion



    #region Constructors


    public Variable()
    {

        VariableName = string.Empty;
        unit = new Measurement_Unit("Vacio", "Vacio");

    }



    public Variable(Guid id, string variableName, Measurement_Unit measurement_Unit, string variableCode, VariableType type, Guid? buildingID = null, Guid? floorID = null, Guid? roomID = null) : base(id)

    {

        // Validar asociación antes de asignar valores

        ValidateAssociation(buildingID, floorID, roomID);


        VariableName = variableName;

        unit = measurement_Unit;

        VariableCode = variableCode;

        this.type = type;


        // Asignar IDs

        BuildingID = buildingID;

        FloorID = floorID;

        RoomID = roomID;

    }

    #endregion

    #region Methods

    private void ValidateAssociation(Guid? buildingID, Guid? floorID, Guid? roomID)

    {

        int count = 0;

        if (buildingID.HasValue) count++;

        if (floorID.HasValue) count++;

        if (roomID.HasValue) count++;


        if (count > 1)

        {

            throw new InvalidOperationException("Una variable solo puede estar asociada a un edificio, piso o habitación, no a más de uno.");

        }

    }






    #endregion



}




