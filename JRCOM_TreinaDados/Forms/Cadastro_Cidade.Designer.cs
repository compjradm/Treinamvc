namespace JRCOM_TreinaDados
{
    partial class Cadastro_Cidade
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
            this.BtnUltimo = new System.Windows.Forms.Button();
            this.BtnProx = new System.Windows.Forms.Button();
            this.BtnAnterior = new System.Windows.Forms.Button();
            this.BtnPrimeiro = new System.Windows.Forms.Button();
            this.BtnApaga = new System.Windows.Forms.Button();
            this.BtnSalva = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.TxtCidade = new System.Windows.Forms.TextBox();
            this.TxtEstado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblUltatualiza = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnUltimo
            // 
            this.BtnUltimo.Location = new System.Drawing.Point(319, 220);
            this.BtnUltimo.Name = "BtnUltimo";
            this.BtnUltimo.Size = new System.Drawing.Size(75, 23);
            this.BtnUltimo.TabIndex = 36;
            this.BtnUltimo.Text = "Último";
            this.BtnUltimo.UseVisualStyleBackColor = true;
            this.BtnUltimo.Click += new System.EventHandler(this.BtnUltimo_Click);
            // 
            // BtnProx
            // 
            this.BtnProx.Location = new System.Drawing.Point(319, 191);
            this.BtnProx.Name = "BtnProx";
            this.BtnProx.Size = new System.Drawing.Size(75, 23);
            this.BtnProx.TabIndex = 35;
            this.BtnProx.Text = "Próximo";
            this.BtnProx.UseVisualStyleBackColor = true;
            this.BtnProx.Click += new System.EventHandler(this.BtnProx_Click);
            // 
            // BtnAnterior
            // 
            this.BtnAnterior.Location = new System.Drawing.Point(319, 162);
            this.BtnAnterior.Name = "BtnAnterior";
            this.BtnAnterior.Size = new System.Drawing.Size(75, 23);
            this.BtnAnterior.TabIndex = 34;
            this.BtnAnterior.Text = "Anterior";
            this.BtnAnterior.UseVisualStyleBackColor = true;
            this.BtnAnterior.Click += new System.EventHandler(this.BtnAnterior_Click);
            // 
            // BtnPrimeiro
            // 
            this.BtnPrimeiro.Location = new System.Drawing.Point(319, 133);
            this.BtnPrimeiro.Name = "BtnPrimeiro";
            this.BtnPrimeiro.Size = new System.Drawing.Size(75, 23);
            this.BtnPrimeiro.TabIndex = 33;
            this.BtnPrimeiro.Text = "Primeiro";
            this.BtnPrimeiro.UseVisualStyleBackColor = true;
            this.BtnPrimeiro.Click += new System.EventHandler(this.BtnPrimeiro_Click);
            // 
            // BtnApaga
            // 
            this.BtnApaga.Location = new System.Drawing.Point(319, 104);
            this.BtnApaga.Name = "BtnApaga";
            this.BtnApaga.Size = new System.Drawing.Size(75, 23);
            this.BtnApaga.TabIndex = 32;
            this.BtnApaga.Text = "Remove";
            this.BtnApaga.UseVisualStyleBackColor = true;
            this.BtnApaga.Click += new System.EventHandler(this.BtnApaga_Click);
            // 
            // BtnSalva
            // 
            this.BtnSalva.Enabled = false;
            this.BtnSalva.Location = new System.Drawing.Point(319, 75);
            this.BtnSalva.Name = "BtnSalva";
            this.BtnSalva.Size = new System.Drawing.Size(75, 23);
            this.BtnSalva.TabIndex = 31;
            this.BtnSalva.Text = "Salva";
            this.BtnSalva.UseVisualStyleBackColor = true;
            this.BtnSalva.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.Location = new System.Drawing.Point(319, 46);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(75, 23);
            this.BtnNovo.TabIndex = 30;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(85, 34);
            this.TxtId.Name = "TxtId";
            this.TxtId.ReadOnly = true;
            this.TxtId.Size = new System.Drawing.Size(100, 20);
            this.TxtId.TabIndex = 37;
            // 
            // TxtCidade
            // 
            this.TxtCidade.Location = new System.Drawing.Point(85, 60);
            this.TxtCidade.Name = "TxtCidade";
            this.TxtCidade.Size = new System.Drawing.Size(100, 20);
            this.TxtCidade.TabIndex = 38;
            // 
            // TxtEstado
            // 
            this.TxtEstado.Location = new System.Drawing.Point(85, 86);
            this.TxtEstado.Name = "TxtEstado";
            this.TxtEstado.Size = new System.Drawing.Size(100, 20);
            this.TxtEstado.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "ID Cidade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Cidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Último Movimento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Estado";
            // 
            // LblUltatualiza
            // 
            this.LblUltatualiza.AutoSize = true;
            this.LblUltatualiza.Location = new System.Drawing.Point(123, 114);
            this.LblUltatualiza.Name = "LblUltatualiza";
            this.LblUltatualiza.Size = new System.Drawing.Size(10, 13);
            this.LblUltatualiza.TabIndex = 44;
            this.LblUltatualiza.Text = "-";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(208, 84);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 45;
            this.button8.Text = "Buscar";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // Cadastro_Cidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 275);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.LblUltatualiza);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtEstado);
            this.Controls.Add(this.TxtCidade);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.BtnUltimo);
            this.Controls.Add(this.BtnProx);
            this.Controls.Add(this.BtnAnterior);
            this.Controls.Add(this.BtnPrimeiro);
            this.Controls.Add(this.BtnApaga);
            this.Controls.Add(this.BtnSalva);
            this.Controls.Add(this.BtnNovo);
            this.Name = "Cadastro_Cidade";
            this.Text = "Cadastro de Cidade";
            this.Load += new System.EventHandler(this.Cadastro_Cidade_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnUltimo;
        private System.Windows.Forms.Button BtnProx;
        private System.Windows.Forms.Button BtnAnterior;
        private System.Windows.Forms.Button BtnPrimeiro;
        private System.Windows.Forms.Button BtnApaga;
        private System.Windows.Forms.Button BtnSalva;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.TextBox TxtCidade;
        private System.Windows.Forms.TextBox TxtEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblUltatualiza;
        private System.Windows.Forms.Button button8;
    }
}