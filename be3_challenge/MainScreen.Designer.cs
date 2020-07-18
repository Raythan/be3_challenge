namespace be3_challenge
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.btnInsereRegistro = new System.Windows.Forms.Button();
            this.txtProntuario = new System.Windows.Forms.TextBox();
            this.lblProntuario = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNumeroFixo = new System.Windows.Forms.TextBox();
            this.txtNumeroCelular = new System.Windows.Forms.TextBox();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.txtAnoValidade = new System.Windows.Forms.TextBox();
            this.lblDivisorMonthYear = new System.Windows.Forms.Label();
            this.lblDataValidade = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblCarteiraConvenio = new System.Windows.Forms.Label();
            this.lblNumeroFixo = new System.Windows.Forms.Label();
            this.lblConvenio = new System.Windows.Forms.Label();
            this.lblCelularNumero = new System.Windows.Forms.Label();
            this.txtMesValidade = new System.Windows.Forms.TextBox();
            this.lblUfExpedicaoRg = new System.Windows.Forms.Label();
            this.cbxUfExpedicaoRg = new System.Windows.Forms.ComboBox();
            this.txtConvenio = new System.Windows.Forms.TextBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.txtCarteiraConvenio = new System.Windows.Forms.TextBox();
            this.cbxGenero = new System.Windows.Forms.ComboBox();
            this.dtpDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.lblDataNascimento = new System.Windows.Forms.Label();
            this.lblRg = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtRg = new System.Windows.Forms.TextBox();
            this.btnBuscaRegistro = new System.Windows.Forms.Button();
            this.btnGeraDadosDebug = new System.Windows.Forms.Button();
            this.txtSelectOptional = new System.Windows.Forms.TextBox();
            this.lblSelectField = new System.Windows.Forms.Label();
            this.btnSelectJsonObject = new System.Windows.Forms.Button();
            this.txtJsonObjectResponse = new System.Windows.Forms.TextBox();
            this.lblObjectAnswer = new System.Windows.Forms.Label();
            this.btnAtualizaRegistro = new System.Windows.Forms.Button();
            this.btnLimparCampos = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInsereRegistro
            // 
            this.btnInsereRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsereRegistro.Image = ((System.Drawing.Image)(resources.GetObject("btnInsereRegistro.Image")));
            this.btnInsereRegistro.Location = new System.Drawing.Point(12, 220);
            this.btnInsereRegistro.Name = "btnInsereRegistro";
            this.btnInsereRegistro.Size = new System.Drawing.Size(273, 47);
            this.btnInsereRegistro.TabIndex = 1;
            this.btnInsereRegistro.Text = "Insere Registro";
            this.btnInsereRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsereRegistro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInsereRegistro.UseVisualStyleBackColor = true;
            this.btnInsereRegistro.Click += new System.EventHandler(this.btnInsereRegistro_Click);
            // 
            // txtProntuario
            // 
            this.txtProntuario.Location = new System.Drawing.Point(279, 115);
            this.txtProntuario.Name = "txtProntuario";
            this.txtProntuario.ShortcutsEnabled = false;
            this.txtProntuario.Size = new System.Drawing.Size(129, 20);
            this.txtProntuario.TabIndex = 19;
            this.txtProntuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProntuario_KeyPress);
            // 
            // lblProntuario
            // 
            this.lblProntuario.AutoSize = true;
            this.lblProntuario.Location = new System.Drawing.Point(279, 99);
            this.lblProntuario.Name = "lblProntuario";
            this.lblProntuario.Size = new System.Drawing.Size(65, 13);
            this.lblProntuario.TabIndex = 18;
            this.lblProntuario.Text = "Prontuário";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.txtNumeroFixo);
            this.groupBox2.Controls.Add(this.txtNumeroCelular);
            this.groupBox2.Controls.Add(this.txtCpf);
            this.groupBox2.Controls.Add(this.txtAnoValidade);
            this.groupBox2.Controls.Add(this.lblDivisorMonthYear);
            this.groupBox2.Controls.Add(this.lblDataValidade);
            this.groupBox2.Controls.Add(this.lblEmail);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.lblCarteiraConvenio);
            this.groupBox2.Controls.Add(this.lblProntuario);
            this.groupBox2.Controls.Add(this.lblNumeroFixo);
            this.groupBox2.Controls.Add(this.lblConvenio);
            this.groupBox2.Controls.Add(this.txtProntuario);
            this.groupBox2.Controls.Add(this.lblCelularNumero);
            this.groupBox2.Controls.Add(this.txtMesValidade);
            this.groupBox2.Controls.Add(this.lblUfExpedicaoRg);
            this.groupBox2.Controls.Add(this.cbxUfExpedicaoRg);
            this.groupBox2.Controls.Add(this.txtConvenio);
            this.groupBox2.Controls.Add(this.lblGenero);
            this.groupBox2.Controls.Add(this.txtCarteiraConvenio);
            this.groupBox2.Controls.Add(this.cbxGenero);
            this.groupBox2.Controls.Add(this.dtpDataNascimento);
            this.groupBox2.Controls.Add(this.lblDataNascimento);
            this.groupBox2.Controls.Add(this.lblRg);
            this.groupBox2.Controls.Add(this.lblCpf);
            this.groupBox2.Controls.Add(this.lblNome);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Controls.Add(this.txtRg);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 199);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados do paciente";
            // 
            // txtNumeroFixo
            // 
            this.txtNumeroFixo.Location = new System.Drawing.Point(415, 76);
            this.txtNumeroFixo.MaxLength = 15;
            this.txtNumeroFixo.Name = "txtNumeroFixo";
            this.txtNumeroFixo.Size = new System.Drawing.Size(128, 20);
            this.txtNumeroFixo.TabIndex = 15;
            this.txtNumeroFixo.TextChanged += new System.EventHandler(this.txtNumeroFixo_TextChanged);
            this.txtNumeroFixo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroFixo_KeyPress);
            // 
            // txtNumeroCelular
            // 
            this.txtNumeroCelular.Location = new System.Drawing.Point(279, 75);
            this.txtNumeroCelular.MaxLength = 15;
            this.txtNumeroCelular.Name = "txtNumeroCelular";
            this.txtNumeroCelular.Size = new System.Drawing.Size(129, 20);
            this.txtNumeroCelular.TabIndex = 13;
            this.txtNumeroCelular.TextChanged += new System.EventHandler(this.txtNumeroCelular_TextChanged);
            this.txtNumeroCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroCelular_KeyPress);
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(144, 31);
            this.txtCpf.MaxLength = 14;
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(129, 20);
            this.txtCpf.TabIndex = 3;
            this.txtCpf.TextChanged += new System.EventHandler(this.txtCpf_TextChanged);
            this.txtCpf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCpf_KeyPress);
            this.txtCpf.Leave += new System.EventHandler(this.txtCpf_Leave);
            // 
            // txtAnoValidade
            // 
            this.txtAnoValidade.Location = new System.Drawing.Point(347, 158);
            this.txtAnoValidade.MaxLength = 4;
            this.txtAnoValidade.Name = "txtAnoValidade";
            this.txtAnoValidade.Size = new System.Drawing.Size(61, 20);
            this.txtAnoValidade.TabIndex = 27;
            this.txtAnoValidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnoValidade_KeyPress);
            // 
            // lblDivisorMonthYear
            // 
            this.lblDivisorMonthYear.AutoSize = true;
            this.lblDivisorMonthYear.Location = new System.Drawing.Point(329, 161);
            this.lblDivisorMonthYear.Name = "lblDivisorMonthYear";
            this.lblDivisorMonthYear.Size = new System.Drawing.Size(13, 13);
            this.lblDivisorMonthYear.TabIndex = 26;
            this.lblDivisorMonthYear.Text = "/";
            // 
            // lblDataValidade
            // 
            this.lblDataValidade.AutoSize = true;
            this.lblDataValidade.Location = new System.Drawing.Point(279, 141);
            this.lblDataValidade.Name = "lblDataValidade";
            this.lblDataValidade.Size = new System.Drawing.Size(165, 13);
            this.lblDataValidade.TabIndex = 24;
            this.lblDataValidade.Text = "Data de validade mês / ano";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 99);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(37, 13);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(9, 115);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(264, 20);
            this.txtEmail.TabIndex = 17;
            // 
            // lblCarteiraConvenio
            // 
            this.lblCarteiraConvenio.AutoSize = true;
            this.lblCarteiraConvenio.Location = new System.Drawing.Point(144, 141);
            this.lblCarteiraConvenio.Name = "lblCarteiraConvenio";
            this.lblCarteiraConvenio.Size = new System.Drawing.Size(126, 13);
            this.lblCarteiraConvenio.TabIndex = 22;
            this.lblCarteiraConvenio.Text = "Carteira do Convênio";
            // 
            // lblNumeroFixo
            // 
            this.lblNumeroFixo.AutoSize = true;
            this.lblNumeroFixo.Location = new System.Drawing.Point(414, 59);
            this.lblNumeroFixo.Name = "lblNumeroFixo";
            this.lblNumeroFixo.Size = new System.Drawing.Size(98, 13);
            this.lblNumeroFixo.TabIndex = 14;
            this.lblNumeroFixo.Text = "Tel. número fixo";
            // 
            // lblConvenio
            // 
            this.lblConvenio.AutoSize = true;
            this.lblConvenio.Location = new System.Drawing.Point(9, 141);
            this.lblConvenio.Name = "lblConvenio";
            this.lblConvenio.Size = new System.Drawing.Size(60, 13);
            this.lblConvenio.TabIndex = 20;
            this.lblConvenio.Text = "Convênio";
            // 
            // lblCelularNumero
            // 
            this.lblCelularNumero.AutoSize = true;
            this.lblCelularNumero.Location = new System.Drawing.Point(279, 58);
            this.lblCelularNumero.Name = "lblCelularNumero";
            this.lblCelularNumero.Size = new System.Drawing.Size(92, 13);
            this.lblCelularNumero.TabIndex = 12;
            this.lblCelularNumero.Text = "Número celular";
            // 
            // txtMesValidade
            // 
            this.txtMesValidade.Location = new System.Drawing.Point(279, 158);
            this.txtMesValidade.MaxLength = 2;
            this.txtMesValidade.Name = "txtMesValidade";
            this.txtMesValidade.Size = new System.Drawing.Size(44, 20);
            this.txtMesValidade.TabIndex = 25;
            this.txtMesValidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMesValidade_KeyPress);
            // 
            // lblUfExpedicaoRg
            // 
            this.lblUfExpedicaoRg.AutoSize = true;
            this.lblUfExpedicaoRg.Location = new System.Drawing.Point(141, 58);
            this.lblUfExpedicaoRg.Name = "lblUfExpedicaoRg";
            this.lblUfExpedicaoRg.Size = new System.Drawing.Size(104, 13);
            this.lblUfExpedicaoRg.TabIndex = 10;
            this.lblUfExpedicaoRg.Text = "Uf expedição RG";
            // 
            // cbxUfExpedicaoRg
            // 
            this.cbxUfExpedicaoRg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUfExpedicaoRg.FormattingEnabled = true;
            this.cbxUfExpedicaoRg.Location = new System.Drawing.Point(144, 75);
            this.cbxUfExpedicaoRg.Name = "cbxUfExpedicaoRg";
            this.cbxUfExpedicaoRg.Size = new System.Drawing.Size(129, 21);
            this.cbxUfExpedicaoRg.TabIndex = 11;
            // 
            // txtConvenio
            // 
            this.txtConvenio.Location = new System.Drawing.Point(9, 158);
            this.txtConvenio.MaxLength = 20;
            this.txtConvenio.Name = "txtConvenio";
            this.txtConvenio.Size = new System.Drawing.Size(129, 20);
            this.txtConvenio.TabIndex = 21;
            this.txtConvenio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConvenio_KeyPress);
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(6, 59);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(48, 13);
            this.lblGenero.TabIndex = 8;
            this.lblGenero.Text = "Gênero";
            // 
            // txtCarteiraConvenio
            // 
            this.txtCarteiraConvenio.Location = new System.Drawing.Point(144, 158);
            this.txtCarteiraConvenio.MaxLength = 20;
            this.txtCarteiraConvenio.Name = "txtCarteiraConvenio";
            this.txtCarteiraConvenio.Size = new System.Drawing.Size(129, 20);
            this.txtCarteiraConvenio.TabIndex = 23;
            // 
            // cbxGenero
            // 
            this.cbxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGenero.FormattingEnabled = true;
            this.cbxGenero.Location = new System.Drawing.Point(9, 75);
            this.cbxGenero.Name = "cbxGenero";
            this.cbxGenero.Size = new System.Drawing.Size(129, 21);
            this.cbxGenero.TabIndex = 9;
            // 
            // dtpDataNascimento
            // 
            this.dtpDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNascimento.Location = new System.Drawing.Point(415, 31);
            this.dtpDataNascimento.Name = "dtpDataNascimento";
            this.dtpDataNascimento.Size = new System.Drawing.Size(128, 20);
            this.dtpDataNascimento.TabIndex = 7;
            this.dtpDataNascimento.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // lblDataNascimento
            // 
            this.lblDataNascimento.AutoSize = true;
            this.lblDataNascimento.Location = new System.Drawing.Point(414, 15);
            this.lblDataNascimento.Name = "lblDataNascimento";
            this.lblDataNascimento.Size = new System.Drawing.Size(120, 13);
            this.lblDataNascimento.TabIndex = 6;
            this.lblDataNascimento.Text = "Data de nascimento";
            // 
            // lblRg
            // 
            this.lblRg.AutoSize = true;
            this.lblRg.Location = new System.Drawing.Point(279, 15);
            this.lblRg.Name = "lblRg";
            this.lblRg.Size = new System.Drawing.Size(25, 13);
            this.lblRg.TabIndex = 4;
            this.lblRg.Text = "RG";
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(144, 15);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(30, 13);
            this.lblCpf.TabIndex = 2;
            this.lblCpf.Text = "CPF";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 16);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(39, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(9, 32);
            this.txtNome.MaxLength = 30;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(129, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // txtRg
            // 
            this.txtRg.Location = new System.Drawing.Point(279, 32);
            this.txtRg.MaxLength = 20;
            this.txtRg.Name = "txtRg";
            this.txtRg.Size = new System.Drawing.Size(129, 20);
            this.txtRg.TabIndex = 5;
            this.txtRg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRg_KeyPress);
            // 
            // btnBuscaRegistro
            // 
            this.btnBuscaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaRegistro.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscaRegistro.Image")));
            this.btnBuscaRegistro.Location = new System.Drawing.Point(294, 220);
            this.btnBuscaRegistro.Name = "btnBuscaRegistro";
            this.btnBuscaRegistro.Size = new System.Drawing.Size(303, 47);
            this.btnBuscaRegistro.TabIndex = 2;
            this.btnBuscaRegistro.Text = "Buscar Registro";
            this.btnBuscaRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscaRegistro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscaRegistro.UseVisualStyleBackColor = true;
            this.btnBuscaRegistro.Click += new System.EventHandler(this.btnBuscaRegistro_Click);
            // 
            // btnGeraDadosDebug
            // 
            this.btnGeraDadosDebug.Location = new System.Drawing.Point(652, 267);
            this.btnGeraDadosDebug.Name = "btnGeraDadosDebug";
            this.btnGeraDadosDebug.Size = new System.Drawing.Size(167, 23);
            this.btnGeraDadosDebug.TabIndex = 10;
            this.btnGeraDadosDebug.Text = "Preenche dados!";
            this.btnGeraDadosDebug.UseVisualStyleBackColor = true;
            this.btnGeraDadosDebug.Click += new System.EventHandler(this.btnGeraDadosDebug_Click);
            // 
            // txtSelectOptional
            // 
            this.txtSelectOptional.Location = new System.Drawing.Point(652, 28);
            this.txtSelectOptional.Multiline = true;
            this.txtSelectOptional.Name = "txtSelectOptional";
            this.txtSelectOptional.Size = new System.Drawing.Size(167, 153);
            this.txtSelectOptional.TabIndex = 6;
            // 
            // lblSelectField
            // 
            this.lblSelectField.AutoSize = true;
            this.lblSelectField.Location = new System.Drawing.Point(652, 9);
            this.lblSelectField.Name = "lblSelectField";
            this.lblSelectField.Size = new System.Drawing.Size(62, 13);
            this.lblSelectField.TabIndex = 5;
            this.lblSelectField.Text = "Select Field";
            // 
            // btnSelectJsonObject
            // 
            this.btnSelectJsonObject.Location = new System.Drawing.Point(652, 188);
            this.btnSelectJsonObject.Name = "btnSelectJsonObject";
            this.btnSelectJsonObject.Size = new System.Drawing.Size(167, 23);
            this.btnSelectJsonObject.TabIndex = 7;
            this.btnSelectJsonObject.Text = "Query!";
            this.btnSelectJsonObject.UseVisualStyleBackColor = true;
            this.btnSelectJsonObject.Click += new System.EventHandler(this.btnSelectJsonObject_Click);
            // 
            // txtJsonObjectResponse
            // 
            this.txtJsonObjectResponse.Location = new System.Drawing.Point(652, 234);
            this.txtJsonObjectResponse.Name = "txtJsonObjectResponse";
            this.txtJsonObjectResponse.Size = new System.Drawing.Size(167, 20);
            this.txtJsonObjectResponse.TabIndex = 9;
            // 
            // lblObjectAnswer
            // 
            this.lblObjectAnswer.AutoSize = true;
            this.lblObjectAnswer.Location = new System.Drawing.Point(652, 218);
            this.lblObjectAnswer.Name = "lblObjectAnswer";
            this.lblObjectAnswer.Size = new System.Drawing.Size(114, 13);
            this.lblObjectAnswer.TabIndex = 8;
            this.lblObjectAnswer.Text = "Json Object Response";
            // 
            // btnAtualizaRegistro
            // 
            this.btnAtualizaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizaRegistro.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizaRegistro.Image")));
            this.btnAtualizaRegistro.Location = new System.Drawing.Point(12, 273);
            this.btnAtualizaRegistro.Name = "btnAtualizaRegistro";
            this.btnAtualizaRegistro.Size = new System.Drawing.Size(273, 47);
            this.btnAtualizaRegistro.TabIndex = 3;
            this.btnAtualizaRegistro.Text = "Atualiza Registro";
            this.btnAtualizaRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtualizaRegistro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAtualizaRegistro.UseVisualStyleBackColor = true;
            this.btnAtualizaRegistro.Click += new System.EventHandler(this.btnAtualizaRegistro_Click);
            // 
            // btnLimparCampos
            // 
            this.btnLimparCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCampos.Image = ((System.Drawing.Image)(resources.GetObject("btnLimparCampos.Image")));
            this.btnLimparCampos.Location = new System.Drawing.Point(294, 273);
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.Size = new System.Drawing.Size(303, 47);
            this.btnLimparCampos.TabIndex = 4;
            this.btnLimparCampos.Text = "Limpar Campos";
            this.btnLimparCampos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimparCampos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimparCampos.UseVisualStyleBackColor = true;
            this.btnLimparCampos.Click += new System.EventHandler(this.btnLimparCampos_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(610, 376);
            this.Controls.Add(this.btnLimparCampos);
            this.Controls.Add(this.btnAtualizaRegistro);
            this.Controls.Add(this.lblObjectAnswer);
            this.Controls.Add(this.txtJsonObjectResponse);
            this.Controls.Add(this.btnSelectJsonObject);
            this.Controls.Add(this.lblSelectField);
            this.Controls.Add(this.txtSelectOptional);
            this.Controls.Add(this.btnGeraDadosDebug);
            this.Controls.Add(this.btnBuscaRegistro);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnInsereRegistro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.Text = "Paciente";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsereRegistro;
        private System.Windows.Forms.TextBox txtProntuario;
        private System.Windows.Forms.Label lblProntuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDataNascimento;
        private System.Windows.Forms.Label lblRg;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtRg;
        private System.Windows.Forms.DateTimePicker dtpDataNascimento;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cbxGenero;
        private System.Windows.Forms.ComboBox cbxUfExpedicaoRg;
        private System.Windows.Forms.Label lblUfExpedicaoRg;
        private System.Windows.Forms.Label lblCelularNumero;
        private System.Windows.Forms.Label lblNumeroFixo;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnBuscaRegistro;
        private System.Windows.Forms.Button btnGeraDadosDebug;
        private System.Windows.Forms.TextBox txtSelectOptional;
        private System.Windows.Forms.Label lblSelectField;
        private System.Windows.Forms.Button btnSelectJsonObject;
        private System.Windows.Forms.TextBox txtJsonObjectResponse;
        private System.Windows.Forms.Label lblObjectAnswer;
        private System.Windows.Forms.Button btnAtualizaRegistro;
        private System.Windows.Forms.Button btnLimparCampos;
        private System.Windows.Forms.TextBox txtAnoValidade;
        private System.Windows.Forms.Label lblDivisorMonthYear;
        private System.Windows.Forms.Label lblDataValidade;
        private System.Windows.Forms.Label lblCarteiraConvenio;
        private System.Windows.Forms.Label lblConvenio;
        private System.Windows.Forms.TextBox txtMesValidade;
        private System.Windows.Forms.TextBox txtConvenio;
        private System.Windows.Forms.TextBox txtCarteiraConvenio;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.TextBox txtNumeroCelular;
        private System.Windows.Forms.TextBox txtNumeroFixo;
    }
}

