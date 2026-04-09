using System;
using transformer_generator.src.Model;

namespace transformer_generator.src.Utils.Generator
{
    internal class CSharpGenerator : CodeGenerator
    {
        #region "Constructor"
        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_metadata">Metadatos para crear una salida controlada.</param>
        /// <param name="param_query_model">Ordenes traducidas de lenguaje M.</param>
        public CSharpGenerator(Metadata param_metadata,
            QueryModel param_query_model) : base(param_metadata, 
                param_query_model)
        {
            
        }
        #endregion "Constructor"

        #region "Virtual Methods"
        public override Result GenerateCode()
        {
            throw new NotImplementedException();
        }
        #endregion "Virtual Methods"
    }
}
