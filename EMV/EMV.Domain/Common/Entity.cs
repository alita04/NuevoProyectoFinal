using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.Domain.Common
{
    public abstract class Entity
    {


        /// <summary>
        /// Identificador de las tablas de bases de datos
        /// Atributos que modifican a Id, que es un id unico para esa clase que no puede tener otra id
        /// especifica como la base de datos genera el valor para una propiedad
        /// </summary>
        /// 
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }

        protected Entity() { }

        protected Entity(Guid id)
        {
            Id = id;

        }


    }
}