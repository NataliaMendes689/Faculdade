
namespace PtesteMetodos
{
    partial class frmExercicio4
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
            this.rchtextPalavra = new System.Windows.Forms.RichTextBox();
            this.lblTexto = new System.Windows.Forms.Label();
            this.btnNumerico = new System.Windows.Forms.Button();
            this.btnEmBranco = new System.Windows.Forms.Button();
            this.btnAlfabetico = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rchtextPalavra
            // 
            this.rchtextPalavra.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rchtextPalavra.Location = new System.Drawing.Point(78, 74);
            this.rchtextPalavra.Name = "rchtextPalavra";
            this.rchtextPalavra.Size = new System.Drawing.Size(458, 143);
            this.rchtextPalavra.TabIndex = 0;
            this.rchtextPalavra.Text = "";
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTexto.Location = new System.Drawing.Point(26, 74);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(46, 20);
            this.lblTexto.TabIndex = 1;
            this.lblTexto.Text = "Texto";
            // 
            // btnNumerico
            // 
            this.btnNumerico.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNumerico.Location = new System.Drawing.Point(26, 249);
            this.btnNumerico.Name = "btnNumerico";
            this.btnNumerico.Size = new System.Drawing.Size(162, 97);
            this.btnNumerico.TabIndex = 2;
            this.btnNumerico.Text = "Mostrar a quantidade de caracteres numéricos";
            this.btnNumerico.UseVisualStyleBackColor = true;
            this.btnNumerico.Click += new System.EventHandler(this.btnNumerico_Click);
            // 
            // btnEmBranco
            // 
            this.btnEmBranco.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEmBranco.Location = new System.Drawing.Point(204, 249);
            this.btnEmBranco.Name = "btnEmBranco";
            this.btnEmBranco.Size = new System.Drawing.Size(135, 97);
            this.btnEmBranco.TabIndex = 3;
            this.btnEmBranco.Text = "Posição do espaço em branco";
            this.btnEmBranco.UseVisualStyleBackColor = true;
            this.btnEmBranco.Click += new System.EventHandler(this.btnEmBranco_Click);
            // 
            // btnAlfabetico
            // 
            this.btnAlfabetico.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAlfabetico.Location = new System.Drawing.Point(354, 249);
            this.btnAlfabetico.Name = "btnAlfabetico";
            this.btnAlfabetico.Size = new System.Drawing.Size(182, 97);
            this.btnAlfabetico.TabIndex = 4;
            this.btnAlfabetico.Text = "Mostrar a quantidade de caracteres alfabéticos";
            this.btnAlfabetico.UseVisualStyleBackColor = true;
            this.btnAlfabetico.Click += new System.EventHandler(this.btnAlfabetico_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Informe um texto:";
            // 
            // frmExercicio4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 364);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAlfabetico);
            this.Controls.Add(this.btnEmBranco);
            this.Controls.Add(this.btnNumerico);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.rchtextPalavra);
            this.Name = "frmExercicio4";
            this.Text = "frmExercicio4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchtextPalavra;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Button btnNumerico;
        private System.Windows.Forms.Button btnEmBranco;
        private System.Windows.Forms.Button btnAlfabetico;
        private System.Windows.Forms.Label label1;
    }
}