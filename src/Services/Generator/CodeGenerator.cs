using System;
using System.Collections.Generic;
using transformer_generator.src.Model;

namespace transformer_generator.src.Services.Generator
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

        #region "Protected methods"
        /// <summary>
        /// Transforma una expresión de tipo string almacenada en el objeto QueryModel a su equivalente en c++ para el código generado.
        /// </summary>
        /// <param name="param_expression">Expresión traducida del lenguaje M.</param>
        /// <returns>Texto traducido a código legible por c++.</returns>
        protected string TransformRowAccess(string param_expression)
        {
            return param_expression
                .Replace("[", "row.at(\"")
                .Replace("]", "\")");
        }

        /// <summary>
        /// Busca igualdades entre los nombres de los parámetros y la tabla y devuelve el nombre de la tabla para que funcione correctamente.
        /// </summary>
        /// <remarks>
        /// Las ordenes diferencian entre mayúsculas y minúsculas. Se crea este método para que esté escrito de la misma manera.
        /// Si dos columnas tienen la misma cabecera el algoritmo cogerá el primero.
        /// </remarks>
        /// <param name="param_column_name">Nombre de la columna que se está procesando.</param>
        /// <returns>Nombre de la columna tal y como está escrito en la tabla.</returns>
        /// <exception cref="Exception">Nombre de columna no encontrado</exception>
        protected string CheckColumnName(string param_column_name)
        {
            param_column_name = param_column_name.Replace("\"", "");
            List<Column> table = _metadata.Source.Columns;

            foreach (Column column in table)
            {
                if (param_column_name.ToLower().Trim() == column.Name.ToLower().Trim())
                {
                    return column.Name;
                }
            }

            throw new Exception($"Nombre de columna no encontrado: {param_column_name}");
        }

        /// <summary>
        /// Busca una columna por su nombre y devuelve el tipo de datos que muestra esa columna.
        /// </summary>
        /// <remarks>
        /// Si dos columnas tienen la misma cabecera el algoritmo cogerá el primero.
        /// </remarks>
        /// <param name="param_expression">Expresión traducida del lenguaje M.</param>
        /// <returns>Texto traducido a código legible por c++.</returns>
        /// <exception cref="Exception">Nombre de la columna no encontrado.</exception>
        protected Column.DataType GetDataType(string param_column_name)
        {
            param_column_name = param_column_name.Replace("\"", "");
            List<Column> table = _metadata.Source.Columns;

            foreach (Column column in table)
            {
                if (param_column_name.ToLower().Trim() == column.Name.ToLower().Trim())
                {
                    return column.Type;
                }
            }

            throw new Exception($"Nombre de columna no encontrado: {param_column_name}");
        }

        #endregion "Protected methods"
    }
}
