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
        public CSharpGenerator(Metadata param_metadata) : base(param_metadata, 
                param_metadata.QueryModel)
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
