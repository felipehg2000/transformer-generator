using transformer_generator.src.Model;

namespace transformer_generator.src.Utils.Generator
{
    /// <summary>
    /// Clase base para los generadores de código. Da la capacidad de usar el polimorfismo para un patrón de fábrica.
    /// </summary>
    internal abstract class CodeGenerator
    {
        /// <summary>
        /// Metadatos necesarios para hacer una salida más controlada.
        /// </summary>
        protected Metadata _metadata;

        /// <summary>
        /// Ordenes traducidas de lenguaje M a objeto controlable por la aplicación.
        /// </summary>
        protected QueryModel _query_model;

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_metadata">Metadatos para crear una salida controlada.</param>
        /// <param name="param_query_model">Ordenes traducidas de lenguaje M.</param>
        public CodeGenerator(Metadata param_metadata, 
            QueryModel param_query_model)
        {
            _metadata = param_metadata;
            _query_model = param_query_model;
        }

        /// <summary>
        /// Método a implementar por cada tipo de generador concreto.
        /// </summary>
        /// <returns>Resultado con información del proceso.</returns>
        public abstract Result GenerateCode();
    }
}
