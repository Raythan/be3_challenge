using be3_challenge.Controller;
using be3_challenge.ModelDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static be3_challenge.EnumTypes;

namespace be3_challenge
{
    public partial class MainScreen : Form
    {
        string padraoNumeros = @"[^0-9]+";
        string padraoLetras = @"[^a-zA-Z]+";
        string padraoLetrasNumeros = @"[^0-9a-zA-Z]";
        REGISTROPACIENTE registro = new REGISTROPACIENTE();
        CONVENIOPACIENTE convenio = new CONVENIOPACIENTE();

        public MainScreen()
        {
            InitializeComponent();

            cbxGenero.DataSource = Enum.GetValues(typeof(TipoGenero));
            cbxUfExpedicaoRg.DataSource = Enum.GetValues(typeof(UfExpedicao));
            btnBuscaRegistro.Enabled = true;
            btnInsereRegistro.Enabled = true;
            btnAtualizaRegistro.Enabled = false;
            btnLimparCampos.Enabled = true;

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Text = $"Paciente - Software desenvolvido para be3 Health Tech v.{fvi.FileVersion} {fvi.LegalCopyright}";
        }

        #region Eventos

        private void btnBuscaRegistro_Click(object sender, EventArgs e)
        {
            BuscaRegistro();
        }

        private void btnInsereRegistro_Click(object sender, EventArgs e)
        {
            BloqueiaCampos();

            string inconsistenciaCampo = null;
            if (!ConsisteCampos(ref inconsistenciaCampo))
            {
                MessageBox.Show(inconsistenciaCampo, "Inconsistência", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DesbloqueiaCampos();
                HabilitaInsercao();
                return;
            }

            try
            {
                RegistroController regControl = new RegistroController();
                ConvenioController convControl = new ConvenioController();
                long? celularNumeroValidado = null;
                long? cpfSemMascara = null;
                long prontuarioValidado = 0;
                long? telefoneFixoValidado = null;
                string mesVencimentoValidado = null;
                string anoVencimentoValidado = null;

                celularNumeroValidado = string.IsNullOrEmpty(txtNumeroCelular.Text) ? null : regexNumberNullable(txtNumeroCelular.Text);
                cpfSemMascara = string.IsNullOrEmpty(txtCpf.Text) ? null : regexNumberNullable(txtCpf.Text);
                prontuarioValidado = regexNumber(txtProntuario.Text);
                telefoneFixoValidado = string.IsNullOrEmpty(txtNumeroFixo.Text) ? null : regexNumberNullable(txtNumeroFixo.Text);
                mesVencimentoValidado = regexStringNumber(txtMesValidade.Text);
                anoVencimentoValidado = regexStringNumber(txtAnoValidade.Text);

                if (cpfSemMascara.HasValue)
                {
                    string countConvert = JsonConvert.SerializeObject(regControl.QueryAble($@"select * from registro_paciente where cpf={cpfSemMascara}"));
                    List<REGISTROPACIENTE> consist = JsonConvert.DeserializeObject<List<REGISTROPACIENTE>>(countConvert);

                    if (consist.Count > 0)
                    {
                        MessageBox.Show($"Registro já localizado, impossível inserir novamente.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DesbloqueiaCampos();
                        HabilitaInsercao();
                        return;
                    }
                }

                registro = new REGISTROPACIENTE()
                {
                    CELULARNUMERO = celularNumeroValidado,
                    CPF = cpfSemMascara,
                    DATANASCIMENTO = dtpDataNascimento.Value,
                    EMAIL = txtEmail.Text,
                    GENERO = (TipoGenero)cbxGenero.SelectedValue,
                    NOME = txtNome.Text,
                    PRONTUARIO = prontuarioValidado,
                    RG = txtRg.Text,
                    TELEFONEFIXONUMERO = telefoneFixoValidado,
                    UFEXPEDICAORG = (UfExpedicao)cbxUfExpedicaoRg.SelectedValue
                };

                registro = regControl.GravaRegistroPacienteSincronizando(registro);

                if (registro.ID > 0)
                {
                    convenio.PACIENTEID = registro.ID;
                    convenio.CARTEIRACONVENIO = txtCarteiraConvenio.Text;
                    convenio.CONVENIO = txtConvenio.Text;
                    convenio.VALIDADEMESANO = $"{txtMesValidade.Text}/{txtAnoValidade.Text}";
                    convControl.InsereConvenio(convenio);
                }

                MessageBox.Show($"Dados inseridos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                HabilitaAtualizacao();
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Argumentos inválidos na tentativa de conversão.\r\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HabilitaInsercao();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"Argumentos nulos na tentativa de conversão.\r\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HabilitaInsercao();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Argumentos inválidos na tentativa de conversão.\r\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HabilitaInsercao();
            }
            catch (RegexMatchTimeoutException ex)
            {
                MessageBox.Show($"Tempo de conversão excedido em função Regex.\r\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HabilitaInsercao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Uma excessão não tratada foi acionada.\r\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HabilitaInsercao();
            }
            finally
            {
                DesbloqueiaCampos();
            }
        }

        private void btnAtualizaRegistro_Click(object sender, EventArgs e)
        {
            BloqueiaCampos();

            string inconsistenciaCampo = null;
            if (!ConsisteCampos(ref inconsistenciaCampo))
            {
                MessageBox.Show(inconsistenciaCampo, "Inconsistência", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DesbloqueiaCampos();
                HabilitaAtualizacao();
                return;
            }

            RegistroController regControl = new RegistroController();
            ConvenioController convControl = new ConvenioController();

            long? celularNumeroValidado = null;
            long? cpfSemMascara = null;
            long prontuarioValidado = 0;
            long? telefoneFixoValidado = null;
            string mesVencimentoValidado = null;
            string anoVencimentoValidado = null;

            celularNumeroValidado = string.IsNullOrEmpty(txtNumeroCelular.Text) ? null : regexNumberNullable(txtNumeroCelular.Text);
            cpfSemMascara = string.IsNullOrEmpty(txtCpf.Text) ? null : regexNumberNullable(txtCpf.Text);
            prontuarioValidado = regexNumber(txtProntuario.Text);
            telefoneFixoValidado = string.IsNullOrEmpty(txtNumeroFixo.Text) ? null : regexNumberNullable(txtNumeroFixo.Text);
            mesVencimentoValidado = regexStringNumber(txtMesValidade.Text);
            anoVencimentoValidado = regexStringNumber(txtAnoValidade.Text);
            
            try
            {
                //register.CONVENIO.CARTEIRACONVENIO = txtCarteiraConvenio.Text;
                registro.CELULARNUMERO = celularNumeroValidado;
                //register.CONVENIO = txtConvenio.Text;
                registro.CPF = cpfSemMascara;
                registro.DATANASCIMENTO = dtpDataNascimento.Value;
                registro.EMAIL = txtEmail.Text;
                registro.GENERO = (TipoGenero)cbxGenero.SelectedValue;
                registro.NOME = txtNome.Text;
                registro.PRONTUARIO = prontuarioValidado;
                registro.RG = txtRg.Text;
                registro.TELEFONEFIXONUMERO = telefoneFixoValidado;
                registro.UFEXPEDICAORG = (UfExpedicao)cbxUfExpedicaoRg.SelectedValue;
                //register.VALIDADEMESANO = $"{mesVencimentoValidado}/{anoVencimentoValidado}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na conversão dos campos! {ex.Message}", ex.GetType().ToString(), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                throw ex;
            }

            try
            {
                regControl.AtualizaRegistroPaciente(registro);

                convenio.CARTEIRACONVENIO = txtCarteiraConvenio.Text;
                convenio.CONVENIO = txtConvenio.Text;
                convenio.VALIDADEMESANO = $"{mesVencimentoValidado}/{anoVencimentoValidado}";

                convControl.AtualizaConvenio(convenio);

                MessageBox.Show($"Dados atualizados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na atualização do paciente! {ex.Message}", ex.GetType().ToString(), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                throw ex;
            }

            DesbloqueiaCampos();
            HabilitaAtualizacao();
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            BloqueiaCampos();

            txtCarteiraConvenio.Text = "";
            txtNumeroCelular.Text = "";
            txtConvenio.Text = "";
            txtCpf.Text = "";
            dtpDataNascimento.Value = new DateTime(1753, 1, 1);
            txtEmail.Text = "";
            txtNome.Text = "";
            txtProntuario.Text = "";
            txtRg.Text = "";
            txtNumeroFixo.Text = "";
            txtMesValidade.Text = "";
            txtAnoValidade.Text = "";
            cbxGenero.DataSource = Enum.GetValues(typeof(TipoGenero));
            cbxUfExpedicaoRg.DataSource = Enum.GetValues(typeof(UfExpedicao));

            DesbloqueiaCampos();
            HabilitaInsercao();
        }

        private void txtCpf_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCpf.Text))
                BuscaRegistro();
        }

        private void BuscaRegistro()
        {
            BloqueiaCampos();

            RegistroController regControl = new RegistroController();
            ConvenioController convControl = new ConvenioController();
            string whereParam = null;

            try
            {
                if (!string.IsNullOrEmpty(txtCpf.Text))
                    whereParam += $" where cpf={regexNumber(txtCpf.Text)} ";
                else
                {
                    MessageBox.Show($"Digite um número de CPF válido para consultar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DesbloqueiaCampos();
                    HabilitaInsercao();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Uma tentativa de conversão inválida foi acionada.\r\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DesbloqueiaCampos();
                HabilitaInsercao();
                return;
            }

            try
            {
                registro = regControl.BuscaRegistroPaciente(whereParam, "*");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na conexão com o banco de dados.\r\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DesbloqueiaCampos();
                HabilitaInsercao();
                return;
            }

            if (registro.ID > 0)
            {
                try
                {
                    txtNumeroCelular.Text = registro.CELULARNUMERO.HasValue ? string.Format(@"{0:\(##\) #####-####}", Convert.ToInt64(regexStringNumber(registro.CELULARNUMERO.ToString()))) : string.Empty;
                    txtCpf.Text = registro.CPF.ToString();
                    dtpDataNascimento.Value = registro.DATANASCIMENTO;
                    txtEmail.Text = registro.EMAIL;
                    txtNome.Text = registro.NOME;
                    txtProntuario.Text = registro.PRONTUARIO.ToString();
                    txtRg.Text = registro.RG;
                    txtNumeroFixo.Text = registro.TELEFONEFIXONUMERO.HasValue ? string.Format(@"{0:\(##\) #####-####}", Convert.ToInt64(regexStringNumber(registro.TELEFONEFIXONUMERO.ToString()))) : string.Empty;
                    cbxGenero.SelectedItem = registro.GENERO;
                    cbxUfExpedicaoRg.SelectedItem = registro.UFEXPEDICAORG;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Uma tentativa de conversão inválida foi acionada.\r\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DesbloqueiaCampos();
                    HabilitaInsercao();
                    return;
                }

                try
                {
                    whereParam = $" where pacienteid={registro.ID} ";
                    convenio = convControl.BuscaConvenio(whereParam, "*");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro na conexão com o banco de dados.\r\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DesbloqueiaCampos();
                    HabilitaInsercao();
                    return;
                }

                if (convenio.ID > 0)
                {
                    try
                    {
                        txtMesValidade.Text = convenio.VALIDADEMESANO.Split('/').FirstOrDefault();
                        txtAnoValidade.Text = convenio.VALIDADEMESANO.Split('/').LastOrDefault();
                        txtConvenio.Text = convenio.CONVENIO;
                        txtCarteiraConvenio.Text = convenio.CARTEIRACONVENIO;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Uma tentativa de conversão inválida foi acionada.\r\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DesbloqueiaCampos();
                        HabilitaInsercao();
                        return;
                    }
                }
            }
            else
            {
                DesbloqueiaCampos();
                HabilitaInsercao();
                return;
            }

            DesbloqueiaCampos();
            HabilitaAtualizacao();
        }

        #endregion

        #region Controle de campos

        /// <summary>
        /// Método que faz o bloqueio dos controles em tela.
        /// </summary>
        private void BloqueiaCampos()
        {
            txtCarteiraConvenio.Enabled = false;
            txtNumeroCelular.Enabled = false;
            txtConvenio.Enabled = false;
            txtCpf.Enabled = false;
            dtpDataNascimento.Enabled = false;
            txtEmail.Enabled = false;
            txtNome.Enabled = false;
            txtProntuario.Enabled = false;
            txtRg.Enabled = false;
            txtNumeroFixo.Enabled = false;
            txtMesValidade.Enabled = false;
            txtAnoValidade.Enabled = false;
            cbxGenero.Enabled = false;
            cbxUfExpedicaoRg.Enabled = false;
            btnBuscaRegistro.Enabled = false;
            btnInsereRegistro.Enabled = false;
            btnAtualizaRegistro.Enabled = false;
            btnLimparCampos.Enabled = false;
        }

        /// <summary>
        /// Método que faz o desbloqueio dos controles em tela.
        /// </summary>
        private void DesbloqueiaCampos()
        {
            txtCarteiraConvenio.Enabled = true;
            txtNumeroCelular.Enabled = true;
            txtConvenio.Enabled = true;
            txtCpf.Enabled = true;
            dtpDataNascimento.Enabled = true;
            txtEmail.Enabled = true;
            txtNome.Enabled = true;
            txtProntuario.Enabled = true;
            txtRg.Enabled = true;
            txtNumeroFixo.Enabled = true;
            txtMesValidade.Enabled = true;
            txtAnoValidade.Enabled = true;
            cbxGenero.Enabled = true;
            cbxUfExpedicaoRg.Enabled = true;
            btnLimparCampos.Enabled = true;
            btnBuscaRegistro.Enabled = true;
        }

        /// <summary>
        /// Método que habilita o botão inserir.
        /// </summary>
        private void HabilitaInsercao()
        {
            btnInsereRegistro.Enabled = true;
        }

        /// <summary>
        /// Método que habilita o botão atualiza.
        /// </summary>
        private void HabilitaAtualizacao()
        {
            btnAtualizaRegistro.Enabled = true;
        }

        #endregion

        #region Consistência de campos

        /// <summary>
        /// Método que faz a consistência de tudo que foi digitado em tela.
        /// <para>Validação antes de inserir ou atualizar os dados.</para>
        /// <para>Devolve os campos inconsistentes utilizando como referência o parâmetro de entrada.</para>
        /// </summary>
        /// <param name="msgParam">Parâmetro que pode ser usado para recuperar as inconsistências.</param>
        /// <returns>Devolve verdadeiro caso todos os valores em tela sejam consistentes.</returns>
        private bool ConsisteCampos(ref string msgParam)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNumeroCelular.Text) && txtNumeroCelular.Text.Length < 12)
                    msgParam += "Celular, ";
                else if (!string.IsNullOrEmpty(txtNumeroCelular.Text))
                    regexNumber(txtNumeroCelular.Text);
            }
            catch (Exception)
            {
                msgParam += "Celular, ";
            }

            try
            {
                regexLetterNumber(txtCarteiraConvenio.Text);
                if (string.IsNullOrEmpty(txtCarteiraConvenio.Text))
                    msgParam += "Carteira convênio, ";
            }
            catch (Exception)
            {
                msgParam += "Carteira convênio, ";
            }

            try
            {
                regexLetterNumber(txtConvenio.Text);
                if (string.IsNullOrEmpty(txtConvenio.Text))
                    msgParam += "Convênio, ";
            }
            catch (Exception)
            {
                msgParam += "Convênio, ";
            }

            try
            {
                if (!string.IsNullOrEmpty(txtCpf.Text) && txtCpf.Text.Length < 14)
                {
                    if (!IsCpf(txtCpf.Text))
                    {
                        msgParam += "\r\nCPF inválido.";
                        return false;
                    }

                    regexNumber(txtCpf.Text);
                }
            }
            catch (Exception)
            {
                msgParam += "CPF, ";
            }

            try
            {
                if (!string.IsNullOrEmpty(txtEmail.Text))
                    regexEmail(txtEmail.Text);
            }
            catch (Exception)
            {
                msgParam += "Email, ";
            }

            try
            {
                regexLetterNumber(txtNome.Text);
                if (string.IsNullOrEmpty(txtNome.Text))
                    msgParam += "Nome, ";
            }
            catch (Exception)
            {
                msgParam += "Nome, ";
            }

            try
            {
                regexNumber(txtProntuario.Text);
                if (string.IsNullOrEmpty(txtProntuario.Text))
                    msgParam += "Prontuário, ";
            }
            catch (Exception)
            {
                msgParam += "Prontuário, ";
            }

            try
            {
                if (!string.IsNullOrEmpty(txtRg.Text))
                    regexLetterNumber(txtRg.Text);
            }
            catch (Exception)
            {
                msgParam += "RG, ";
            }

            try
            {
                if (!string.IsNullOrEmpty(txtNumeroFixo.Text))
                    regexNumber(txtNumeroFixo.Text);
            }
            catch (Exception)
            {
                msgParam += "Número Fixo, ";
            }

            try
            {
                regexStringNumber(txtMesValidade.Text);
                if (string.IsNullOrEmpty(txtMesValidade.Text) || Convert.ToInt32(txtMesValidade.Text) > 12 || Convert.ToInt32(txtMesValidade.Text) < 1)
                    msgParam += "Mês validade, ";
            }
            catch (Exception)
            {
                msgParam += "Mês validade, ";
            }

            try
            {
                regexStringNumber(txtAnoValidade.Text);
                if (string.IsNullOrEmpty(txtAnoValidade.Text) || txtAnoValidade.Text.Length < 4)
                    msgParam += "Ano validade, ";
            }
            catch (Exception)
            {
                msgParam += "Ano validade, ";
            }

            try
            {
                if (!string.IsNullOrEmpty(cbxUfExpedicaoRg.Text))
                    regexStringNumber(cbxUfExpedicaoRg.Text);
            }
            catch (Exception)
            {
                msgParam += "Uf expedição RG, ";
            }

            try
            {
                DateTime dataMin = new DateTime(1753, 1, 1);

                if (dtpDataNascimento.Value < dataMin || dtpDataNascimento.Value > DateTime.Now)
                    msgParam += "Data de nascimento, ";
            }
            catch (Exception)
            {
                msgParam += "Data de nascimento, ";
            }

            if (!string.IsNullOrEmpty(msgParam))
            {
                msgParam += msgParam.Substring(0, msgParam.Length - 1) + " contém caracteres inválidos.";
                return false;
            }

            if (string.IsNullOrEmpty(txtNumeroCelular.Text) && string.IsNullOrEmpty(txtNumeroFixo.Text))
            {
                msgParam += "\r\nAo menos um telefone deve ser informado.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método que verifica se o CPF digitado é válido.
        /// <para>Solução retirada de http://www.macoratti.net/11/09/c_val1.htm
        /// </para>
        /// </summary>
        /// <param name="cpf">Número de cpf contendo caracteres especiais.</param>
        /// <returns>Retorna verdadeiro caso seja um número válido.</returns>
        private bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "").Replace(",", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Método que faz o regex de uma string e devolve apenas os números.
        /// <para>Se a entrada for nulo, devolve 0.
        /// </para>
        /// </summary>
        /// <param name="param">String que vai ser feito regex.</param>
        /// <returns>Devolve um número do tipo long.</returns>
        private long regexNumber(string param)
        {
            try
            {
                return Convert.ToInt64(Regex.Replace(param, padraoNumeros, ""));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que faz o regex de uma string e devolve apenas os números.
        /// <para>Se a entrada for nulo, devolve 0.
        /// </para>
        /// </summary>
        /// <param name="param">String que vai ser feito regex.</param>
        /// <returns>Devolve um número do tipo long.</returns>
        private long? regexNumberNullable(string param)
        {
            try
            {
                return Convert.ToInt64(Regex.Replace(param, padraoNumeros, ""));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que faz o regex de uma string e devolve apenas os números como string.
        /// <para>Se a entrada for nulo, devolve nulo.
        /// </para>
        /// </summary>
        /// <param name="param">String que vai ser feito regex.</param>
        /// <returns>Devolve um número como string.</returns>
        private string regexStringNumber(string param)
        {
            try
            {
                return Regex.Replace(param, padraoNumeros, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que faz o regex de uma string e devolve apenas letras e números como string.
        /// <para>Se a entrada for nulo, devolve nulo.
        /// </para>
        /// </summary>
        /// <param name="param">String que vai ser feito regex.</param>
        /// <returns>Devolve letras e números como string.</returns>
        private string regexLetterNumber(string param)
        {
            try
            {
                return Regex.Replace(param, padraoLetrasNumeros, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que faz a validação para verificar se a string é um email válido.
        /// </summary>
        /// <param name="param">String para verificação.</param>
        private void regexEmail(string param)
        {
            try
            {
                MailAddress email = new MailAddress(param);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Validações que impedem dígitos incorretos em tela.

        private void txtProntuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumber(e);
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumber(e);
        }

        private void txtNumeroCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumber(e);
        }

        private void txtNumeroFixo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumber(e);
        }

        private void txtConvenio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsLetterNumber(e);
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsLetterNumber(e);

            if (e.KeyChar == ' ')
                e.Handled = false;
        }

        private void txtRg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsLetterNumber(e);
        }

        private void txtMesValidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumber(e);
        }

        private void txtAnoValidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumber(e);
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
            if (txtCpf.Text.Length == 11)
                txtCpf.Text = string.Format(@"{0:###\.###\.###-##}", Convert.ToInt64(regexStringNumber(txtCpf.Text)));
        }

        private void txtNumeroCelular_TextChanged(object sender, EventArgs e)
        {
            if (txtNumeroCelular.Text.Length == 11)
                txtNumeroCelular.Text = string.Format(@"{0:\(##\) #####-####}", Convert.ToInt64(regexStringNumber(txtNumeroCelular.Text)));
        }

        private void txtNumeroFixo_TextChanged(object sender, EventArgs e)
        {
            if (txtNumeroFixo.Text.Length == 11)
                txtNumeroFixo.Text = string.Format(@"{0:\(##\) #####-####}", Convert.ToInt64(regexStringNumber(txtNumeroFixo.Text)));
        }

        #endregion

        #region Métodos que validam se o que está sendo digitado é valido em cada campo.

        private bool IsNumber(KeyPressEventArgs e)
        {
            return !char.IsNumber(e.KeyChar) && !e.KeyChar.Equals('\b');
        }

        private bool IsLetter(KeyPressEventArgs e)
        {
            return !char.IsLetter(e.KeyChar) && !e.KeyChar.Equals('\b');
        }

        private bool IsLetterNumber(KeyPressEventArgs e)
        {
            return !char.IsLetterOrDigit(e.KeyChar) && !e.KeyChar.Equals('\b');
        }

        #endregion

        #endregion

        #region DEBUG

        /// <summary>
        /// Botão inserido para geração de dados automáticamente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeraDadosDebug_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            txtCarteiraConvenio.Text = $"CART{rand.Next(0, 99999)}";
            txtNumeroCelular.Text = $"{rand.Next(111111, 999999)}{rand.Next(11111, 99999)}";
            txtConvenio.Text = $"CONV{rand.Next(111, 999)}";
            dtpDataNascimento.Value = new DateTime(rand.Next(1900, DateTime.Now.Year), rand.Next(1, 12), rand.Next(1, 31));
            txtEmail.Text = $"a{rand.Next(11111, 99999)}@abc.com";
            txtNome.Text = $"NomeTeste{rand.Next(11111, 99999)}";
            txtProntuario.Text = $"{rand.Next(11111, 99999)}{rand.Next(11111, 99999)}";
            txtRg.Text = $"{rand.Next(1111, 9999)}{rand.Next(1111, 9999)}";
            txtNumeroFixo.Text = $"{rand.Next(111111, 999999)}{rand.Next(11111, 99999)}";
            txtMesValidade.Text = $"{string.Format("{0}", rand.Next(1, 12))}";
            txtAnoValidade.Text = $"{rand.Next(1900, DateTime.Now.Year)}";
            cbxGenero.SelectedIndex = rand.Next(0, Enum.GetNames(typeof(TipoGenero)).Length);
            cbxUfExpedicaoRg.SelectedIndex = rand.Next(0, Enum.GetNames(typeof(UfExpedicao)).Length);

            bool cpfValido = false;
            while (!cpfValido)
            {
                string cpfParametro = $"{rand.Next(111111, 999999)}{rand.Next(11111, 99999)}";

                if (IsCpf(cpfParametro))
                {
                    txtCpf.Text = cpfParametro;
                    cpfValido = true;
                }
            }
        }

        /// <summary>
        /// Botão que pode ser utilizado para fazer uma query sem a necessidade de um gerenciador.
        /// <para>Insere um Json que é o objeto deserializado no TextBox abaixo do botão.
        /// </para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectJsonObject_Click(object sender, EventArgs e)
        {
            RegistroController regControl = new RegistroController();

            try
            {
                txtJsonObjectResponse.Text = JsonConvert.SerializeObject(regControl.QueryAble(txtSelectOptional.Text));
            }
            catch (Exception ex)
            {
                txtJsonObjectResponse.Text = $"Exception: {ex.Message}";
            }
        }





        #endregion
    }
}
