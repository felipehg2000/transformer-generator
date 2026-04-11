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
        public DataSource Source { get; set; }

        /// <summary>
        /// Datos sobre el fichero de lenguaje M de entrada y las ordenes que contiene.
        /// </summary>
        public QueryModel QueryModel { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public Metadata()
        {
            Source = new DataSource();
            Configuration = new MainConfiguration();
            QueryModel = new QueryModel();
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="configuration">Configuración del generador.</param>
        /// <param name="param_source">Información de la fuente de datos.</param>
        /// <param name="param_query_model">Datos sobre el fichero de lenguaje M de entrada y las ordenes que contiene.</param>
        public Metadata(MainConfiguration configuration, 
            DataSource param_source,
            QueryModel param_query_model)
        {
            Configuration = configuration;
            Source = param_source;
            QueryModel = param_query_model;
        }
    }
}
