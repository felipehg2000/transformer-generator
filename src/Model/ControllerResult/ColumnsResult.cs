using System.Collections.Generic;

namespace transformer_generator.src.Model.ControllerResult
{
    /// <summary>
    /// Representa el resultado de una operación que devuelve una colección de columnas asociadas a una tabla.
    /// </summary>
    internal class ColumnsResult : Result
    {
        /// <summary>
        /// Vector a devolver con una lista de columnas que representan una tabla.
        /// </summary>
        public List<Column> _columns { get; set; }

        /// <summary>
        /// Constructor vacío, inicializa atributos a vacío.
        /// </summary>
        public ColumnsResult() : 
            base()
        {
            _columns = new List<Column>();
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_correct">True si es correcto, false si no.</param>
        /// <param name="param_user_text">Mensaje que mostrar al usuario.</param>
        /// <param name="param_developer_text">Mensaje para que el desarrollador obtenga información.</param>
        /// <param name="param_columns">Lista de columnas que representan una tabla.</param>
        public ColumnsResult(bool param_correct, 
            string param_user_text, 
            string param_developer_text, 
            List<Column> param_columns) : base(param_correct, 
                param_user_text, 
                param_developer_text)
        {
            _columns = param_columns;
        }
    }
}
