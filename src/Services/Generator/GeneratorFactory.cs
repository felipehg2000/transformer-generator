using System;
using transformer_generator.src.Model;

namespace transformer_generator.src.Utils.Generator
{
    /// <summary>
    /// Método de fábrica para generar el generador de código según el tipo de salida.
    /// </summary>
    internal class GeneratorFactory
    {
        /// <summary>
        /// Genera un generador de código basado en el tipo de salida especificada en la configuración inicial.
        /// </summary>
        /// <param name="param_language">Tipo de lenguaje de salida.</param>
        /// <param name="param_metadata">Metadatos del proceso.</param>
        /// <param name="param_query_model">Ordenes del lenguaje M procesadas.</param>
        /// <returns>Generador de código.</returns>
        /// <exception cref="ArgumentException">Excepción de tipo de lenguaje no válido.</exception>
        public static CodeGenerator CreateGenerator(MainConfiguration.OutputType param_language, 
            Metadata param_metadata, 
            QueryModel param_query_model)
        {
            CodeGenerator generator = null;
            switch (param_language)
            {
                case MainConfiguration.OutputType.CSharp:
                    generator = new CSharpGenerator(param_metadata, param_query_model);
                    break;
                case MainConfiguration.OutputType.Cpp:
                    generator = new CppGenerator(param_metadata, param_query_model);
                    break;
                default:
                    throw new ArgumentException("Invalid output type.");
            }
            return generator;
        }
    }
}
