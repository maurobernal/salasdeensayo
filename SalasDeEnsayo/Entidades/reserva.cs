﻿namespace SalasDeEnsayo.Entidades;

public class reserva
{
    public int id { get; set; }
    public virtual saladeensayo salaDeEnsayo { get; set; }
    public int salaDeEnsayoId { get; set; }
    public DateTime fechaInicio { get; set; }
    public DateTime fechaFin { get; set; }
    public bool confirmado { get; set; }
    public DateTime fechaDeConfirmacion { get; set; }

}
