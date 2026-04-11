using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using transformer_generator.src.Utils.Generator;
using static transformer_generator.src.Model.DataSource;

namespace transformer_generator.src.Model
{
    /// <summary>
    /// Clase que almacena la información sobre la configuración del generador y las fuentes de datos con las que el generador trabajará para crear los transformadores.
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Información sobre la configuración del generador.
        /// </summary>
        public MainConfiguration Configuration { get; set; }

        /// <summary>
        /// Información sobre las fuentes de datos con las que el generador trabajará para crear los transformadores.
        /// </summary>
        public DataSource Source { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public Metadata()
        {
            Source = new DataSource();
            Configuration = new MainConfiguration();
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="configuration">Configuración del generador.</param>
        /// <param name="param_source">Información de la fuente de datos.</param>
        public Metadata(MainConfiguration configuration, DataSource param_source)
        {
            Configuration = configuration;
            Source = param_source;
        }
    }
}
