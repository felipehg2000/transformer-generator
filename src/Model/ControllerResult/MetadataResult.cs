namespace transformer_generator.src.Model.ControllerResult
{
    /// <summary>
    /// Respuesta que retornan los métodos que deben devolver Metadata. Para añadir información del proceso.
    /// </summary>
    public class MetadataResult : Result
    {
        /// <summary>
        /// Información de los metadatos procesados.
        /// </summary>
        public Metadata MetadataInfo { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        public MetadataResult() : base() 
        { 
            MetadataInfo = new Metadata();
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_correct"></param>
        /// <param name="param_user_text"></param>
        /// <param name="param_developer_text"></param>
        /// <param name="param_metadata"></param>
        public MetadataResult(bool param_correct, 
            string param_user_text, 
            string param_developer_text, 
            Metadata param_metadata) : 
            base(param_correct, 
                param_user_text, 
                param_developer_text)
        {
            MetadataInfo = new Metadata(param_metadata.Configuration, 
                param_metadata.Source,
                param_metadata.QueryModel);
        }
    }
}
