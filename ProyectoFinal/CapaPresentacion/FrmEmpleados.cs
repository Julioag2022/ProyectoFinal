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
using CapaLogica;
using ComponentFactory.Krypton.Toolkit;

namespace CapaPresentacion
{
    public partial class FrmEmpleados : KryptonForm
    {
        CD_Empleados cd_empleados = new CD_Empleados();
        CL_Empleados cl_empleados = new CL_Empleados();


        public FrmEmpleados()
        {
            InitializeComponent();
        }

        // Metod que muestra los datos de los empleados en el DataGridView
        public void MtdMuestraDatosDGV()
        {
            DataTable dtEmpleados = cd_empleados.MtdConsultarEmpleados();
            dgvEmpleadoss.DataSource = dtEmpleados;
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            MtdMuestraDatosDGV(); // Carga los datos al iniciar el formulario
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if( 
                string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtDpi.Text) ||
                string.IsNullOrEmpty(txtDireccion.Text) ||
                string.IsNullOrEmpty(dtpFechaingreso.Text) ||
                string.IsNullOrEmpty(txtSalarioBase.Text) ||
                string.IsNullOrEmpty(cboxTipoEmpleado.Text) ||
                string.IsNullOrEmpty(cboxEstado.Text) 
                )
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //Capturar datos del formulario
                string Nombre = txtNombre.Text;
                int Dpi = Convert.ToInt32(txtDpi.Text);
                string Direccion = txtDireccion.Text;
                DateTime FechaIngreso = dtpFechaingreso.Value;
                double SalarioBase = Convert.ToDouble(txtSalarioBase.Text);
                string TipoEmpleado = cboxTipoEmpleado.Text;
                string Estado = cboxEstado.Text;

                // Enviar datos a la capa de datos
                try
                {
                    cd_empleados.MtdAgregarEmpleados(Nombre, Dpi, Direccion, FechaIngreso, SalarioBase, TipoEmpleado, Estado);
                    MessageBox.Show("Empleado agregado correctamente.", "Éxitooooo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdMuestraDatosDGV();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboxTipoEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSalarioBase.Text = cl_empleados.MtdSalarioBase(cboxTipoEmpleado.Text).ToString();
        }

        private void dgvEmpleadoss_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var FilaSeleccionada = dgvEmpleadoss.SelectedRows[0];

            if(FilaSeleccionada.Index == dgvEmpleadoss.Rows.Count - 1)
            {
                MessageBox.Show("Seleccione una fila valida, por favor,", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                txtCodigoEmpleado.Text = FilaSeleccionada.Cells[0].Value.ToString();
                txtNombre.Text = FilaSeleccionada.Cells[1].Value.ToString();
                txtDpi.Text = FilaSeleccionada.Cells[2].Value.ToString();
                txtDireccion.Text = FilaSeleccionada.Cells[3].Value.ToString();
                dtpFechaingreso.Value = Convert.ToDateTime(FilaSeleccionada.Cells[4].Value);
                txtSalarioBase.Text = FilaSeleccionada.Cells[5].Value.ToString();
                cboxTipoEmpleado.Text = FilaSeleccionada.Cells[6].Value.ToString();
                cboxEstado.Text = FilaSeleccionada.Cells[7].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (
                 string.IsNullOrEmpty(txtCodigoEmpleado.Text) ||
                 string.IsNullOrEmpty(txtNombre.Text) ||
                 string.IsNullOrEmpty(txtDpi.Text) ||
                 string.IsNullOrEmpty(txtDireccion.Text) ||
                 string.IsNullOrEmpty(dtpFechaingreso.Text) ||
                 string.IsNullOrEmpty(txtSalarioBase.Text) ||
                 string.IsNullOrEmpty(cboxTipoEmpleado.Text) ||
                 string.IsNullOrEmpty(cboxEstado.Text)
                 )
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //Capturar datos del formulario
                int Codigo = Convert.ToInt32(txtCodigoEmpleado.Text);
                string Nombre = txtNombre.Text;
                int Dpi = Convert.ToInt32(txtDpi.Text);
                string Direccion = txtDireccion.Text;
                DateTime FechaIngreso = dtpFechaingreso.Value;
                double SalarioBase = Convert.ToDouble(txtSalarioBase.Text);
                string TipoEmpleado = cboxTipoEmpleado.Text;
                string Estado = cboxEstado.Text;

                // Enviar datos a la capa de datos
                try
                {
                    cd_empleados.MtdEditarEmpleados(Codigo, Nombre, Dpi, Direccion, FechaIngreso, SalarioBase, TipoEmpleado, Estado);
                    MessageBox.Show("Empleado actualizado correctamente.", "Éxitooooo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdMuestraDatosDGV();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (
                 string.IsNullOrEmpty(txtCodigoEmpleado.Text)
                 )
            {
                MessageBox.Show("Por favor, seleccione un Empleado a eliminar", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //Capturar datos del formulario
                int Codigo = Convert.ToInt32(txtCodigoEmpleado.Text);

                // Enviar datos a la capa de datos
                try
                {
                    cd_empleados.MtdEliminarEmpleados(Codigo);
                    MessageBox.Show("Empleado eliminado correctamente.", "Éxitooooo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdMuestraDatosDGV();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void LimpiarCampos()
        {
            txtCodigoEmpleado.Clear();
            txtNombre.Clear();
            txtDpi.Clear();
            txtDireccion.Clear();
            dtpFechaingreso.Value = DateTime.Now;
            txtSalarioBase.Clear();
            cboxTipoEmpleado.SelectedIndex = -1;
            cboxEstado.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
