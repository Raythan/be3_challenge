using be3_challenge.DBContext;
using be3_challenge.ModelDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace be3_challenge.Controller
{
    public class RegistroController
    {
        DataBaseContext context = new DataBaseContext();

        /// <summary>
        /// Método que grava o registro do paciente na tabela REGISTRO_PACIENTE
        /// </summary>
        /// <param name="registro">Objeto contendo os dados para o registro do paciente.</param>
        public void GravaRegistroPaciente(REGISTROPACIENTE registro)
        {
            context.InsertData(registro, "REGISTRO_PACIENTE");
        }

        /// <summary>
        /// Método que grava o registro do paciente na tabela REGISTRO_PACIENTE e devolve o objeto
        /// </summary>
        /// <param name="registro">Objeto de entrada e retorno.</param>
        /// <returns>Retorna um objeto do tipo REGISTROPACIENTE após salvar no banco.</returns>
        public REGISTROPACIENTE GravaRegistroPacienteSincronizando(REGISTROPACIENTE registro)
        {
            string objRetStr = JsonConvert.SerializeObject(context.InsertDataAlignReturn(registro, "REGISTRO_PACIENTE"));
            return JsonConvert.DeserializeObject<REGISTROPACIENTE>(objRetStr);
        }
        
        /// <summary>
        /// Método que atualiza o registro do paciente na tabela REGISTRO_PACIENTE
        /// </summary>
        /// <param name="registro">Objeto contendo os dados para atualização do paciente.</param>
        public void AtualizaRegistroPaciente(REGISTROPACIENTE registro)
        {
            context.UpdateData(registro, "REGISTRO_PACIENTE");
        }

        /// <summary>
        /// Método que busca um registro único do paciente.
        /// </summary>
        /// <param name="whereParm">Parâmetro contendo chave e valor no banco para busca do registro.</param>
        /// <param name="columnFilter">Filtros com os nomes das colunas separados por vírgula ou "*" caso queira o objeto completo.</param>
        /// <returns>Retorna um objeto do tipo REGISTROPACIENTE.</returns>
        public REGISTROPACIENTE BuscaRegistroPaciente(string whereParm, string columnFilter)
        {
            string objRetStr = JsonConvert.SerializeObject(context.GetSingleData(new REGISTROPACIENTE(), "REGISTRO_PACIENTE", whereParm, columnFilter));
            return JsonConvert.DeserializeObject<REGISTROPACIENTE>(objRetStr);
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
