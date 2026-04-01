namespace transformer_generator.src.Model
{
    public class Result
    {
        /// <summary>
        /// True si el retorno es correcto false si no.
        /// </summary>
        public bool Correct { get; set; }

        /// <summary>
        /// Mensaje de retorno para mostrar al usuario.
        /// </summary>
        public string UserText { get; set; }

        /// <summary>
        /// Mensaje de retorno para que el desarrollador encuentre el error facilmente.
        /// </summary>
        public string DeveloperText { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        public Result()
        {
            Correct = true;
            UserText = string.Empty;
            DeveloperText = string.Empty;
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_correct">True si es correcto, false si no.</param>
        /// <param name="param_user_text">Mensaje que mostrar al usuario.</param>
        /// <param name="param_developer_text">Mensaje para que el desarrollador obtenga información.</param>
        public Result(bool param_correct, string param_user_text, string param_developer_text)
        {
            Correct = param_correct;
            UserText = param_user_text;
            DeveloperText = param_developer_text;
        }
    }
}
