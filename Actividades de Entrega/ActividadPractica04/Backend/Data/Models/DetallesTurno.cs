﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Backend.Data.Models;

public partial class DetallesTurno
{
    public int IdDetalle { get; set; }

    public int IdServicio { get; set; }

    public int IdTurno { get; set; }

    public string Observaciones { get; set; }

    public virtual Servicio IdServicioNavigation { get; set; }

    public virtual Turno IdTurnoNavigation { get; set; }
}