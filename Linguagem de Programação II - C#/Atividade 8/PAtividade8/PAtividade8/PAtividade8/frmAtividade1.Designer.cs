
namespace PAtividade8
{
    partial class frmAtividade1
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
            this.rchtxtFrase = new System.Windows.Forms.RichTextBox();
            this.btnBrancos = new System.Windows.Forms.Button();
            this.btnR = new System.Windows.Forms.Button();
            this.btnParesLetras = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rchtxtFrase
            // 
            this.rchtxtFrase.Location = new System.Drawing.Point(58, 120);
            this.rchtxtFrase.Margin = new System.Windows.Forms.Padding(4);
            this.rchtxtFrase.Name = "rchtxtFrase";
            this.rchtxtFrase.Size = new System.Drawing.Size(557, 149);
            this.rchtxtFrase.TabIndex = 0;
            this.rchtxtFrase.Text = "";
            // 
            // btnBrancos
            // 
            this.btnBrancos.BackColor = System.Drawing.Color.Tomato;
            this.btnBrancos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBrancos.ForeColor = System.Drawing.Color.White;
            this.btnBrancos.Location = new System.Drawing.Point(58, 296);
            this.btnBrancos.Name = "btnBrancos";
            this.btnBrancos.Size = new System.Drawing.Size(201, 56);
            this.btnBrancos.TabIndex = 1;
            this.btnBrancos.Text = "Contar espaços em branco";
            this.btnBrancos.UseVisualStyleBackColor = false;
            this.btnBrancos.Click += new System.EventHandler(this.btnBrancos_Click);
            // 
            // btnR
            // 
            this.btnR.BackColor = System.Drawing.Color.Tomato;
            this.btnR.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnR.ForeColor = System.Drawing.Color.White;
            this.btnR.Location = new System.Drawing.Point(279, 296);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(119, 56);
            this.btnR.TabIndex = 2;
            this.btnR.Text = "Contar letras \"R\"";
            this.btnR.UseVisualStyleBackColor = false;
            this.btnR.Click += new System.EventHandler(this.btnR_Click);
            // 
            // btnParesLetras
            // 
            this.btnParesLetras.BackColor = System.Drawing.Color.Tomato;
            this.btnParesLetras.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnParesLetras.ForeColor = System.Drawing.Color.White;
            this.btnParesLetras.Location = new System.Drawing.Point(416, 296);
            this.btnParesLetras.Name = "btnParesLetras";
            this.btnParesLetras.Size = new System.Drawing.Size(199, 56);
            this.btnParesLetras.TabIndex = 3;
            this.btnParesLetras.Text = "Contar pares de letras iguais";
            this.btnParesLetras.UseVisualStyleBackColor = false;
            this.btnParesLetras.Click += new System.EventHandler(this.btnParesLetras_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(58, 95);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(557, 21);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Escreva uma frase no espaço abaixo e clique nos botões para executar as ações:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(259, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "ATIVIDADE 1";
            // 
            // frmAtividade1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 376);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnParesLetras);
            this.Controls.Add(this.btnR);
            this.Controls.Add(this.btnBrancos);
            this.Controls.Add(this.rchtxtFrase);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAtividade1";
            this.Text = "Atividade1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchtxtFrase;
        private System.Windows.Forms.Button btnBrancos;
        private System.Windows.Forms.Button btnR;
        private System.Windows.Forms.Button btnParesLetras;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
    }
}