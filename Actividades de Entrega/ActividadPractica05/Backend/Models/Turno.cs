﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend.Models;

public partial class Turno
{
    public int IdTurno { get; set; }
    [JsonIgnore]
    public DateOnly Fecha { get; set; }
    [JsonIgnore]
    public TimeOnly Hora { get; set; }

    public string Cliente { get; set; }

    public virtual ICollection<DetallesTurno> DetallesTurnos { get; set; } = new List<DetallesTurno>();
}