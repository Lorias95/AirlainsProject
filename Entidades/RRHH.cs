using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
[DataContract]

public class RRHH
    {
    public RRHH() { }

    [DataMember]

    public string CategoriaID { get; set; }

    [DataMember]

    public string Departamento { get; set; }

    [DataMember]
    public string Nombre { get; set; }

    [MaxLength(50), MinLength(3)]

    [DataMember]



    public string Direccion { get; set; }

    [DataMember]

    public string Telefono { get; set; }

    [DataMember]

    public string Correo { get; set; }

    [DataMember]


    public string Clave { get; set; }

    [DataMember]

    public string Codigo { get; set; }

    [DataMember]

    public List<RRHH> recurso { get; set; }
}

