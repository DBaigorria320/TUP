﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Backend.Data.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string Nombre { get; set; }

    public decimal Costo { get; set; }

    public bool EnPromocion { get; set; }
    public DetallesTurno DetallesTurno {  get; set; }
}