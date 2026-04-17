using System;
using transformer_generator.src.Model;

namespace transformer_generator.src.Services.Generator
{
    /// <summary>
    /// Método de fábrica para generar el generador de código según el tipo de salida.
    /// </summary>
    internal class GeneratorFactory
    {
        /// <summary>
        /// Genera un generador de código basado en el tipo de salida especificada en la configuración inicial.
        /// </summary>
        /// <param name="param_metadata">Metadatos del proceso.</param>
        /// <returns>Generador de código.</returns>
        /// <exception cref="ArgumentException">Excepción de tipo de lenguaje no válido.</exception>
        public static CodeGenerator CreateGenerator(Metadata param_metadata)
        {
            CodeGenerator generator = null;
            switch (param_metadata.Configuration.Type)
            {
                case MainConfiguration.OutputType.CSharp:
                    generator = new CSharpGenerator(param_metadata);
                    break;
                case MainConfiguration.OutputType.Cpp:
                    generator = new CppGenerator(param_metadata);
                    break;
                default:
                    throw new ArgumentException("Invalid output type.");
            }
            return generator;
        }
    }
}
