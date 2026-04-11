namespace transformer_generator.src.Model.ControllerResult
{
    /// <summary>
    /// Respuesta que retornan los métodos que deben devolver un objeto de tipo QueryModel. Para añadir información adicional.
    /// </summary>
    public class QueryModelResult : Result
    {
        /// <summary>
        /// Información del objeto QueryModel (lenguaje M analizado sintácticamente).
        /// </summary>
        public QueryModel QueryModelInfo { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        public QueryModelResult() : 
            base()
        {
            QueryModelInfo = new QueryModel();
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_correct">True si es correcto, false si no.</param>
        /// <param name="param_user_text">Texto a mostrar al usuario.</param>
        /// <param name="param_developer_text">Texto informativo para el desarrollador.</param>
        /// <param name="param_query_model">Información del lenguaje M analizado sintácticamente.</param>
        public QueryModelResult(bool param_correct, 
            string param_user_text, 
            string param_developer_text,
            QueryModel param_query_model) : base(param_correct, 
                param_user_text, 
                param_developer_text)
        {
            if (param_query_model == null)
            {
                QueryModelInfo = null;
            }
            else
            {
                QueryModelInfo = new QueryModel(param_query_model.Steps, 
                    param_query_model.InputFile, 
                    param_query_model.Output);
            }
        }
    }
}
