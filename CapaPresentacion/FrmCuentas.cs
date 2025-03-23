using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmCuentas : Form
    {
        public FrmCuentas()
        {
            InitializeComponent();
        }

        public void MtdMostrarCuentas()
        {
            CD_Cuentas cd_cuentas = new CD_Cuentas();
            DataTable dtMostrarCuentas = cd_cuentas.MtMostrarCuentas();
            dgvCuentas.DataSource = dtMostrarCuentas;
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoCuenta.Text= "";
            txtCodigoCliente.Text = "";
            txtNumeroCuenta.Text = "";
            txtSaldo.Text = "";
            cboxTipoCuenta.Text = "";
            cboxEstado.Text = "";
        }

        private void FrmCuentas_Load(object sender, EventArgs e)
        {
            MtdMostrarCuentas();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CD_Cuentas cd_cuentas = new CD_Cuentas();
            try
            {
                int codigoCliente;
                decimal saldo;

                if (string.IsNullOrWhiteSpace(txtCodigoCliente.Text) || !int.TryParse(txtCodigoCliente.Text, out codigoCliente))
                {
                    MessageBox.Show("Por favor, ingrese un Código de Cliente válido (número entero).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSaldo.Text) || !decimal.TryParse(txtSaldo.Text, out saldo))
                {
                    MessageBox.Show("Por favor, ingrese un saldo válido (número decimal).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cd_cuentas.MtdAgregarCuentas(codigoCliente, txtNumeroCuenta.Text, cboxTipoCuenta.Text, saldo, cboxEstado.Text);
                MessageBox.Show("El cliente se agrego con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoCuenta.Text = dgvCuentas.SelectedCells[0].Value.ToString();
            txtCodigoCliente.Text=dgvCuentas.SelectedCells[1].Value.ToString();
            txtNumeroCuenta.Text = dgvCuentas.SelectedCells[2].Value.ToString();
            cboxTipoCuenta.Text = dgvCuentas.SelectedCells[3].Value.ToString();
            txtSaldo.Text = dgvCuentas.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvCuentas.SelectedCells[6].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }
    }
}
