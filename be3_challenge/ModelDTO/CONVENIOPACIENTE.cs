using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be3_challenge.ModelDTO
{
    public class CONVENIOPACIENTE
    {
        [Description("PRIMARYKEY")]
        public long ID { get; set; }
        public string CONVENIO { get; set; }
        public string CARTEIRACONVENIO { get; set; }
        public string VALIDADEMESANO { get; set; }
        public long PACIENTEID { get; set; }
    }
}
