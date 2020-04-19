using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Redirects
{
    class Redirect
    {
        #region Propriedades
        /// <summary>
        /// URL de Origem (que será redirecionada para Url de Destino)
        /// </summary>
        public string De { get; set; }

        /// <summary>
        /// ULR de Destino
        /// </summary>
        public string Para { get; set; }
        #endregion
    }
}
