using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS
{
    public class Materias
    {
        public int IdMateria { get; set; }

        public string Nombre { get; set; }

        public string NombreDia { get; set; }

        public int IdDia { get; set; }

        public TimeSpan HoraEntrada { get; set; }

        public TimeSpan HoraSalida { get; set; }

        public string NombreDocente { get; set; }

        public int IdDocente { get; set; }

        public string NombreMateriaCustom
        {
            get
            {
                return NombreDia + " - " + HoraEntrada + " - " + HoraSalida + "  "  + Nombre + "  ( " + NombreDocente + "  )";
            }
        }

    }
}
