namespace transformer_generator.src.Model.ControllerResult
{
    /// <summary>
    /// Respuesta que retornan los métodos que deberían devolver un objeto de tipo Step. Para añadir información adicional.
    /// </summary>
    internal class StepResult : Result
    {
        /// <summary>
        /// Inofrmación del objeto Step (orden en lenguaje M analizado sintácticamente).
        /// </summary>
        public Step StepInfo { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        public StepResult() : base()
        {
            StepInfo = new Step();
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_correct">True si es correcto, false si no.</param>
        /// <param name="param_user_text">Texto a mostrar al usuario.</param>
        /// <param name="param_developer_text">Texto informativo para el desarrollador.</param>
        /// <param name="param_step">Información de una orden en lenguaje M analizado sintácticamente.</param>
        public StepResult(bool param_correct,
            string param_user_text, 
            string param_developer_text, 
            Step param_step) : base(param_correct, 
                param_user_text, 
                param_developer_text)
        {
            if (param_step == null)
            {
                StepInfo = null;
            }
            else
            {
                StepInfo = new Step(param_step.Name,
                    param_step.Input,
                    param_step.Operation,
                    param_step.Arguments);
            }
        }
    }
}
