using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Redirects
{
    /// <summary>
    /// Classe de Modelo para definir o progresso da tarefa em execução
    /// </summary>
    class ProgressoDaTarefa
    {
        #region Propriedades
        /// <summary>
        /// Progresso atual da tarefa (entre 0 e 100)
        /// </summary>
        public int Progresso { get; set; }

        /// <summary>
        /// Etapa atual do processamento
        /// </summary>
        public string EtapaAtual{ get; set; }
        #endregion
    }
}
