
namespace PCalcDesconto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblNome = new System.Windows.Forms.Label();
            this.lblBruto = new System.Windows.Forms.Label();
            this.lblFilhos = new System.Windows.Forms.Label();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.lblAliquotaINSS = new System.Windows.Forms.Label();
            this.lblAliquotaIR = new System.Windows.Forms.Label();
            this.lblBolsaFamilia = new System.Windows.Forms.Label();
            this.lblLiquido = new System.Windows.Forms.Label();
            this.lblDescontoINSS = new System.Windows.Forms.Label();
            this.lblDescontoIR = new System.Windows.Forms.Label();
            this.gbxSexo = new System.Windows.Forms.GroupBox();
            this.rbtnMasculino = new System.Windows.Forms.RadioButton();
            this.rbtnFeminino = new System.Windows.Forms.RadioButton();
            this.gbxEstadoCivil = new System.Windows.Forms.GroupBox();
            this.rbtnDivorciado = new System.Windows.Forms.RadioButton();
            this.rbtnSolteiro = new System.Windows.Forms.RadioButton();
            this.rbtnViuvo = new System.Windows.Forms.RadioButton();
            this.rbtnCasado = new System.Windows.Forms.RadioButton();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNomeSocial = new System.Windows.Forms.Label();
            this.txtNomeSocial = new System.Windows.Forms.TextBox();
            this.mskbxBruto = new System.Windows.Forms.MaskedTextBox();
            this.cbxFilhos = new System.Windows.Forms.ComboBox();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbxPronome = new System.Windows.Forms.GroupBox();
            this.rbtnEleDele = new System.Windows.Forms.RadioButton();
            this.rbtnElaDela = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.mskbxAliquotaINSS = new System.Windows.Forms.MaskedTextBox();
            this.mskbxAliquotaIR = new System.Windows.Forms.MaskedTextBox();
            this.mskbxDescINSS = new System.Windows.Forms.MaskedTextBox();
            this.mskbxDescIR = new System.Windows.Forms.MaskedTextBox();
            this.mskbxFamilia = new System.Windows.Forms.MaskedTextBox();
            this.mskbxLiquido = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbxSexo.SuspendLayout();
            this.gbxEstadoCivil.SuspendLayout();
            this.gbxPronome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(23, 61);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(125, 21);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome Completo";
            // 
            // lblBruto
            // 
            this.lblBruto.AutoSize = true;
            this.lblBruto.Location = new System.Drawing.Point(23, 140);
            this.lblBruto.Name = "lblBruto";
            this.lblBruto.Size = new System.Drawing.Size(100, 21);
            this.lblBruto.TabIndex = 1;
            this.lblBruto.Text = "Salário Bruto";
            // 
            // lblFilhos
            // 
            this.lblFilhos.AutoSize = true;
            this.lblFilhos.Location = new System.Drawing.Point(23, 180);
            this.lblFilhos.Name = "lblFilhos";
            this.lblFilhos.Size = new System.Drawing.Size(134, 21);
            this.lblFilhos.TabIndex = 2;
            this.lblFilhos.Text = "Número de Filhos";
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Location = new System.Drawing.Point(22, 284);
            this.lblMensagem.MaximumSize = new System.Drawing.Size(20000, 100);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(19, 21);
            this.lblMensagem.TabIndex = 3;
            this.lblMensagem.Text = "...";
            this.lblMensagem.Visible = false;
            // 
            // lblAliquotaINSS
            // 
            this.lblAliquotaINSS.AutoSize = true;
            this.lblAliquotaINSS.Location = new System.Drawing.Point(23, 326);
            this.lblAliquotaINSS.Name = "lblAliquotaINSS";
            this.lblAliquotaINSS.Size = new System.Drawing.Size(106, 21);
            this.lblAliquotaINSS.TabIndex = 4;
            this.lblAliquotaINSS.Text = "Aliquota INSS";
            // 
            // lblAliquotaIR
            // 
            this.lblAliquotaIR.AutoSize = true;
            this.lblAliquotaIR.BackColor = System.Drawing.Color.Transparent;
            this.lblAliquotaIR.Location = new System.Drawing.Point(23, 372);
            this.lblAliquotaIR.Name = "lblAliquotaIR";
            this.lblAliquotaIR.Size = new System.Drawing.Size(86, 21);
            this.lblAliquotaIR.TabIndex = 5;
            this.lblAliquotaIR.Text = "Aliquota IR";
            // 
            // lblBolsaFamilia
            // 
            this.lblBolsaFamilia.AutoSize = true;
            this.lblBolsaFamilia.Location = new System.Drawing.Point(22, 420);
            this.lblBolsaFamilia.Name = "lblBolsaFamilia";
            this.lblBolsaFamilia.Size = new System.Drawing.Size(100, 21);
            this.lblBolsaFamilia.TabIndex = 6;
            this.lblBolsaFamilia.Text = "Bolsa Família";
            // 
            // lblLiquido
            // 
            this.lblLiquido.AutoSize = true;
            this.lblLiquido.BackColor = System.Drawing.Color.Gainsboro;
            this.lblLiquido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLiquido.Location = new System.Drawing.Point(261, 420);
            this.lblLiquido.Name = "lblLiquido";
            this.lblLiquido.Size = new System.Drawing.Size(125, 21);
            this.lblLiquido.TabIndex = 7;
            this.lblLiquido.Text = "Salário Líquido";
            // 
            // lblDescontoINSS
            // 
            this.lblDescontoINSS.AutoSize = true;
            this.lblDescontoINSS.Location = new System.Drawing.Point(261, 326);
            this.lblDescontoINSS.Name = "lblDescontoINSS";
            this.lblDescontoINSS.Size = new System.Drawing.Size(113, 21);
            this.lblDescontoINSS.TabIndex = 8;
            this.lblDescontoINSS.Text = "Desconto INSS";
            // 
            // lblDescontoIR
            // 
            this.lblDescontoIR.AutoSize = true;
            this.lblDescontoIR.Location = new System.Drawing.Point(261, 372);
            this.lblDescontoIR.Name = "lblDescontoIR";
            this.lblDescontoIR.Size = new System.Drawing.Size(93, 21);
            this.lblDescontoIR.TabIndex = 9;
            this.lblDescontoIR.Text = "Desconto IR";
            // 
            // gbxSexo
            // 
            this.gbxSexo.Controls.Add(this.rbtnMasculino);
            this.gbxSexo.Controls.Add(this.rbtnFeminino);
            this.gbxSexo.Location = new System.Drawing.Point(491, 53);
            this.gbxSexo.Name = "gbxSexo";
            this.gbxSexo.Size = new System.Drawing.Size(271, 62);
            this.gbxSexo.TabIndex = 10;
            this.gbxSexo.TabStop = false;
            this.gbxSexo.Text = "Sexo";
            // 
            // rbtnMasculino
            // 
            this.rbtnMasculino.AutoSize = true;
            this.rbtnMasculino.Location = new System.Drawing.Point(138, 28);
            this.rbtnMasculino.Name = "rbtnMasculino";
            this.rbtnMasculino.Size = new System.Drawing.Size(99, 25);
            this.rbtnMasculino.TabIndex = 32;
            this.rbtnMasculino.Text = "Masculino";
            this.rbtnMasculino.UseVisualStyleBackColor = true;
            // 
            // rbtnFeminino
            // 
            this.rbtnFeminino.AutoSize = true;
            this.rbtnFeminino.Checked = true;
            this.rbtnFeminino.Location = new System.Drawing.Point(16, 28);
            this.rbtnFeminino.Name = "rbtnFeminino";
            this.rbtnFeminino.Size = new System.Drawing.Size(93, 25);
            this.rbtnFeminino.TabIndex = 31;
            this.rbtnFeminino.TabStop = true;
            this.rbtnFeminino.Text = "Feminino";
            this.rbtnFeminino.UseVisualStyleBackColor = true;
            // 
            // gbxEstadoCivil
            // 
            this.gbxEstadoCivil.Controls.Add(this.rbtnDivorciado);
            this.gbxEstadoCivil.Controls.Add(this.rbtnSolteiro);
            this.gbxEstadoCivil.Controls.Add(this.rbtnViuvo);
            this.gbxEstadoCivil.Controls.Add(this.rbtnCasado);
            this.gbxEstadoCivil.Location = new System.Drawing.Point(491, 119);
            this.gbxEstadoCivil.Name = "gbxEstadoCivil";
            this.gbxEstadoCivil.Size = new System.Drawing.Size(271, 85);
            this.gbxEstadoCivil.TabIndex = 13;
            this.gbxEstadoCivil.TabStop = false;
            this.gbxEstadoCivil.Text = "Estado Civil";
            // 
            // rbtnDivorciado
            // 
            this.rbtnDivorciado.AutoSize = true;
            this.rbtnDivorciado.Location = new System.Drawing.Point(138, 28);
            this.rbtnDivorciado.Name = "rbtnDivorciado";
            this.rbtnDivorciado.Size = new System.Drawing.Size(121, 25);
            this.rbtnDivorciado.TabIndex = 35;
            this.rbtnDivorciado.Text = "Divorciado(a)";
            this.rbtnDivorciado.UseVisualStyleBackColor = true;
            // 
            // rbtnSolteiro
            // 
            this.rbtnSolteiro.AutoSize = true;
            this.rbtnSolteiro.Location = new System.Drawing.Point(16, 54);
            this.rbtnSolteiro.Name = "rbtnSolteiro";
            this.rbtnSolteiro.Size = new System.Drawing.Size(100, 25);
            this.rbtnSolteiro.TabIndex = 34;
            this.rbtnSolteiro.Text = "Solteiro(a)";
            this.rbtnSolteiro.UseVisualStyleBackColor = true;
            // 
            // rbtnViuvo
            // 
            this.rbtnViuvo.AutoSize = true;
            this.rbtnViuvo.Location = new System.Drawing.Point(138, 54);
            this.rbtnViuvo.Name = "rbtnViuvo";
            this.rbtnViuvo.Size = new System.Drawing.Size(86, 25);
            this.rbtnViuvo.TabIndex = 33;
            this.rbtnViuvo.Text = "Viúvo(a)";
            this.rbtnViuvo.UseVisualStyleBackColor = true;
            // 
            // rbtnCasado
            // 
            this.rbtnCasado.AutoSize = true;
            this.rbtnCasado.Checked = true;
            this.rbtnCasado.Location = new System.Drawing.Point(16, 28);
            this.rbtnCasado.Name = "rbtnCasado";
            this.rbtnCasado.Size = new System.Drawing.Size(97, 25);
            this.rbtnCasado.TabIndex = 33;
            this.rbtnCasado.TabStop = true;
            this.rbtnCasado.Text = "Casado(a)";
            this.rbtnCasado.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(163, 58);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(288, 29);
            this.txtNome.TabIndex = 14;
            this.txtNome.Validated += new System.EventHandler(this.txtNome_Validated);
            // 
            // lblNomeSocial
            // 
            this.lblNomeSocial.AutoSize = true;
            this.lblNomeSocial.Location = new System.Drawing.Point(23, 97);
            this.lblNomeSocial.Name = "lblNomeSocial";
            this.lblNomeSocial.Size = new System.Drawing.Size(98, 21);
            this.lblNomeSocial.TabIndex = 15;
            this.lblNomeSocial.Text = "Nome Social";
            // 
            // txtNomeSocial
            // 
            this.txtNomeSocial.Location = new System.Drawing.Point(163, 97);
            this.txtNomeSocial.Name = "txtNomeSocial";
            this.txtNomeSocial.Size = new System.Drawing.Size(288, 29);
            this.txtNomeSocial.TabIndex = 16;
            // 
            // mskbxBruto
            // 
            this.mskbxBruto.Location = new System.Drawing.Point(163, 137);
            this.mskbxBruto.Mask = "09990.00";
            this.mskbxBruto.Name = "mskbxBruto";
            this.mskbxBruto.Size = new System.Drawing.Size(139, 29);
            this.mskbxBruto.TabIndex = 17;
            this.mskbxBruto.Validated += new System.EventHandler(this.mskbxBruto_Validated);
            // 
            // cbxFilhos
            // 
            this.cbxFilhos.FormattingEnabled = true;
            this.cbxFilhos.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbxFilhos.Location = new System.Drawing.Point(163, 177);
            this.cbxFilhos.Name = "cbxFilhos";
            this.cbxFilhos.Size = new System.Drawing.Size(73, 29);
            this.cbxFilhos.TabIndex = 18;
            // 
            // btnVerificar
            // 
            this.btnVerificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnVerificar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVerificar.Location = new System.Drawing.Point(24, 219);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(427, 29);
            this.btnVerificar.TabIndex = 19;
            this.btnVerificar.Text = "Verificar Descontos";
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLimpar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpar.Location = new System.Drawing.Point(22, 482);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(158, 34);
            this.btnLimpar.TabIndex = 26;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSair.Location = new System.Drawing.Point(333, 482);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(161, 34);
            this.btnSair.TabIndex = 27;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(220, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(343, 25);
            this.lblTitulo.TabIndex = 28;
            this.lblTitulo.Text = "Calcular Descontos de Colaboradores";
            // 
            // gbxPronome
            // 
            this.gbxPronome.Controls.Add(this.rbtnEleDele);
            this.gbxPronome.Controls.Add(this.rbtnElaDela);
            this.gbxPronome.Location = new System.Drawing.Point(491, 208);
            this.gbxPronome.Name = "gbxPronome";
            this.gbxPronome.Size = new System.Drawing.Size(271, 65);
            this.gbxPronome.TabIndex = 29;
            this.gbxPronome.TabStop = false;
            this.gbxPronome.Text = "Pronome";
            // 
            // rbtnEleDele
            // 
            this.rbtnEleDele.AutoSize = true;
            this.rbtnEleDele.Location = new System.Drawing.Point(138, 29);
            this.rbtnEleDele.Name = "rbtnEleDele";
            this.rbtnEleDele.Size = new System.Drawing.Size(85, 25);
            this.rbtnEleDele.TabIndex = 1;
            this.rbtnEleDele.TabStop = true;
            this.rbtnEleDele.Text = "Ele/Dele";
            this.rbtnEleDele.UseVisualStyleBackColor = true;
            // 
            // rbtnElaDela
            // 
            this.rbtnElaDela.AutoSize = true;
            this.rbtnElaDela.Checked = true;
            this.rbtnElaDela.Location = new System.Drawing.Point(16, 29);
            this.rbtnElaDela.Name = "rbtnElaDela";
            this.rbtnElaDela.Size = new System.Drawing.Size(85, 25);
            this.rbtnElaDela.TabIndex = 0;
            this.rbtnElaDela.TabStop = true;
            this.rbtnElaDela.Text = "Ela/Dela";
            this.rbtnElaDela.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "(campo não obrigatório)";
            // 
            // mskbxAliquotaINSS
            // 
            this.mskbxAliquotaINSS.Enabled = false;
            this.mskbxAliquotaINSS.Location = new System.Drawing.Point(131, 323);
            this.mskbxAliquotaINSS.Name = "mskbxAliquotaINSS";
            this.mskbxAliquotaINSS.Size = new System.Drawing.Size(100, 29);
            this.mskbxAliquotaINSS.TabIndex = 31;
            // 
            // mskbxAliquotaIR
            // 
            this.mskbxAliquotaIR.Enabled = false;
            this.mskbxAliquotaIR.Location = new System.Drawing.Point(131, 369);
            this.mskbxAliquotaIR.Mask = "99.0%";
            this.mskbxAliquotaIR.Name = "mskbxAliquotaIR";
            this.mskbxAliquotaIR.Size = new System.Drawing.Size(100, 29);
            this.mskbxAliquotaIR.TabIndex = 32;
            // 
            // mskbxDescINSS
            // 
            this.mskbxDescINSS.Enabled = false;
            this.mskbxDescINSS.Location = new System.Drawing.Point(394, 323);
            this.mskbxDescINSS.Mask = "$ 999.00";
            this.mskbxDescINSS.Name = "mskbxDescINSS";
            this.mskbxDescINSS.Size = new System.Drawing.Size(100, 29);
            this.mskbxDescINSS.TabIndex = 33;
            // 
            // mskbxDescIR
            // 
            this.mskbxDescIR.Enabled = false;
            this.mskbxDescIR.Location = new System.Drawing.Point(394, 369);
            this.mskbxDescIR.Mask = "$ 999.00";
            this.mskbxDescIR.Name = "mskbxDescIR";
            this.mskbxDescIR.Size = new System.Drawing.Size(100, 29);
            this.mskbxDescIR.TabIndex = 34;
            // 
            // mskbxFamilia
            // 
            this.mskbxFamilia.Enabled = false;
            this.mskbxFamilia.Location = new System.Drawing.Point(131, 417);
            this.mskbxFamilia.Mask = "$ 999.99";
            this.mskbxFamilia.Name = "mskbxFamilia";
            this.mskbxFamilia.Size = new System.Drawing.Size(100, 29);
            this.mskbxFamilia.TabIndex = 35;
            // 
            // mskbxLiquido
            // 
            this.mskbxLiquido.Enabled = false;
            this.mskbxLiquido.Location = new System.Drawing.Point(394, 417);
            this.mskbxLiquido.Mask = "$ 99900.00";
            this.mskbxLiquido.Name = "mskbxLiquido";
            this.mskbxLiquido.Size = new System.Drawing.Size(100, 29);
            this.mskbxLiquido.TabIndex = 36;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(467, 237);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(365, 338);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(793, 530);
            this.Controls.Add(this.mskbxLiquido);
            this.Controls.Add(this.mskbxFamilia);
            this.Controls.Add(this.mskbxDescIR);
            this.Controls.Add(this.mskbxDescINSS);
            this.Controls.Add(this.mskbxAliquotaIR);
            this.Controls.Add(this.mskbxAliquotaINSS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbxPronome);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.cbxFilhos);
            this.Controls.Add(this.mskbxBruto);
            this.Controls.Add(this.txtNomeSocial);
            this.Controls.Add(this.lblNomeSocial);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.gbxEstadoCivil);
            this.Controls.Add(this.gbxSexo);
            this.Controls.Add(this.lblDescontoIR);
            this.Controls.Add(this.lblDescontoINSS);
            this.Controls.Add(this.lblLiquido);
            this.Controls.Add(this.lblBolsaFamilia);
            this.Controls.Add(this.lblAliquotaIR);
            this.Controls.Add(this.lblAliquotaINSS);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.lblFilhos);
            this.Controls.Add(this.lblBruto);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Calcular Descontos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxSexo.ResumeLayout(false);
            this.gbxSexo.PerformLayout();
            this.gbxEstadoCivil.ResumeLayout(false);
            this.gbxEstadoCivil.PerformLayout();
            this.gbxPronome.ResumeLayout(false);
            this.gbxPronome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblBruto;
        private System.Windows.Forms.Label lblFilhos;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Label lblAliquotaINSS;
        private System.Windows.Forms.Label lblAliquotaIR;
        private System.Windows.Forms.Label lblBolsaFamilia;
        private System.Windows.Forms.Label lblLiquido;
        private System.Windows.Forms.Label lblDescontoINSS;
        private System.Windows.Forms.Label lblDescontoIR;
        private System.Windows.Forms.GroupBox gbxSexo;
        private System.Windows.Forms.GroupBox gbxEstadoCivil;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNomeSocial;
        private System.Windows.Forms.TextBox txtNomeSocial;
        private System.Windows.Forms.MaskedTextBox mskbxBruto;
        private System.Windows.Forms.ComboBox cbxFilhos;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbxPronome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnFeminino;
        private System.Windows.Forms.RadioButton rbtnMasculino;
        private System.Windows.Forms.RadioButton rbtnDivorciado;
        private System.Windows.Forms.RadioButton rbtnSolteiro;
        private System.Windows.Forms.RadioButton rbtnViuvo;
        private System.Windows.Forms.RadioButton rbtnCasado;
        private System.Windows.Forms.RadioButton rbtnEleDele;
        private System.Windows.Forms.RadioButton rbtnElaDela;
        private System.Windows.Forms.MaskedTextBox mskbxAliquotaINSS;
        private System.Windows.Forms.MaskedTextBox mskbxAliquotaIR;
        private System.Windows.Forms.MaskedTextBox mskbxDescINSS;
        private System.Windows.Forms.MaskedTextBox mskbxDescIR;
        private System.Windows.Forms.MaskedTextBox mskbxFamilia;
        private System.Windows.Forms.MaskedTextBox mskbxLiquido;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

