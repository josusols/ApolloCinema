//Librerias.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloCinema
{
    class Pelicula
    {
        public string Nombre { get; set; }
        public string Sala { get; set; }
        public string Horario { get; set; }
        public UInt32 PrecioTicket { get; set; } //entero no negativo
        public bool LlenoAdmin = false;
        public bool LlenoUsuario = false;
        public string[,] Asientos = new string[8,10];
        public bool[,] TablaVerdad = new bool[8, 10];
        public double[,] PrecioConDescuento = new double[8, 10];
    }
}
