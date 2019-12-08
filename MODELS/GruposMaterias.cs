using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS
{
    public class GruposMaterias
    {
        public int IdGrupoMateria { get; set; }

        public int IdGrupo { get; set; }

        public string NombreGrupo { get; set; }

        public int IdMateria { get; set; }

        public string NombreMateria { get; set; }

        public int IdDia { get; set; }

        public string NombreDia { get; set; }

        public TimeSpan HoraEntrada { get; set; }

        public TimeSpan HoraSalida { get; set; }

        public int IdDocente { get; set; }

        public string NombreDocente { get; set; }


    }

}

