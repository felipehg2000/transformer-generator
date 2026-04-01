using System.Collections.Generic;
using System.Text.Json.Serialization;
using transformer_generator.src.Utils.Generator;

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
        public List<DataSource> Sources { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public Metadata()
        {
            Sources = new List<DataSource>();
            Configuration = new MainConfiguration();
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="configuration">Configuración del generador.</param>
        /// <param name="sources">Información de las fuentes de datos.</param>
        public Metadata(MainConfiguration configuration, List<DataSource> sources)
        {
            Configuration = configuration;
            Sources = sources;
        }
    }
}
