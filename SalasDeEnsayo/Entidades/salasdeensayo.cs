﻿namespace SalasDeEnsayo.Entidades;
public class saladeensayo : entidadbase
{
    public virtual tipodesala tipo { get; set; }
    public int tipodesalaid { get; set; }
    public int capacidad { get; set; }
<<<<<<< HEAD
    public virtual List<saladeensayoequipamiento> equipamiento { get; set; }

=======
    public virtual List<reserva> reservas { get; set; }
    public int reservaid { get; set; }
>>>>>>> main
}
