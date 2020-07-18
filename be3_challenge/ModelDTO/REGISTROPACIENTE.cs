using System;
using System.ComponentModel;
using static be3_challenge.EnumTypes;

namespace be3_challenge.ModelDTO
{
    public class REGISTROPACIENTE
    {
        [Description("PRIMARYKEY")]
        public long ID { get; set; }
        public long PRONTUARIO { get; set; }
        public string NOME { get; set; }
        public DateTime DATANASCIMENTO { get; set; }
        public TipoGenero GENERO { get; set; }
        public long? CPF { get; set; }
        public string RG { get; set; }
        public UfExpedicao UFEXPEDICAORG { get; set; }
        public string EMAIL { get; set; }
        public long? CELULARNUMERO { get; set; }
        public long? TELEFONEFIXONUMERO { get; set; }
    }
}
