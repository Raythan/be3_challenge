using be3_challenge.DBContext;
using be3_challenge.ModelDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be3_challenge.Controller
{
    public class ConvenioController
    {
        DataBaseContext context = new DataBaseContext();

        /// <summary>
        /// Método que grava os dados de convênio do paciente na tabela CONVENIO
        /// </summary>
        /// <param name="registro">Objeto contendo os dados para o registro do convênio do paciente.</param>
        public void InsereConvenio(CONVENIOPACIENTE convenio)
        {
            context.InsertData(convenio, "CONVENIO");
        }

        /// <summary>
        /// Método que atualiza os dados de convênio do paciente na tabela CONVENIO
        /// </summary>
        /// <param name="registro">Objeto contendo os dados para atualizar o convênio do paciente.</param>
        public void AtualizaConvenio(CONVENIOPACIENTE convenio)
        {
            context.UpdateData(convenio, "CONVENIO");
        }

        /// <summary>
        /// Método que busca um registro único do convênio do paciente.
        /// </summary>
        /// <param name="whereParm">Parâmetro contendo chave e valor no banco para busca do convênio.</param>
        /// <param name="columnFilter">Filtros com os nomes das colunas separados por vírgula ou "*" caso queira o objeto completo.</param>
        /// <returns>Retorna um objeto do tipo CONVENIOPACIENTE.</returns>
        public CONVENIOPACIENTE BuscaConvenio(string whereParm, string columnFilter)
        {
            string objRetStr = JsonConvert.SerializeObject(context.GetSingleData(new CONVENIOPACIENTE(), "CONVENIO", whereParm, columnFilter));
            return JsonConvert.DeserializeObject<CONVENIOPACIENTE>(objRetStr);
        }

        /// <summary>
        /// Método que recebe como parâmetro uma query do tipo seleção e devolve uma lista dinâmica com os objetos obtidos.
        /// </summary>
        /// <param name="sql">Query parâmetro de entrada do tipo Select</param>
        /// <returns>Retorna uma lista de objetos dinâmicos com base na query parâmetro de entrada.</returns>
        public List<dynamic> QueryAble(string query)
        {
            return context.QueryReadable(query);
        }
    }
}
