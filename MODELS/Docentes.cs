using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS
{
    public class Docentes
    {
        public int IdDocente { get; set; }

        public string Nombre { get; set; }

        public string telefono { get; set; }

    }

    public class DocentesHorario
    {
        public string Asignatura { get; set; }

        public string Docente { get; set; }

        public string Horas { get; set; }


    }
}
