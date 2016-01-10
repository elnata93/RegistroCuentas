using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace RegistroCuentas
{
    public partial class RegistroCuentas : Form
    {
        Cuentas cuenta = new Cuentas();

        public RegistroCuentas()
        {
            InitializeComponent();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (DescripciontextBox.TextLength == 0 && BalancetextBox.TextLength == 0)
            {
                MessageBox.Show("No puede dejar ningun campo vacio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                cuenta.Descripcion = DescripciontextBox.Text;
                cuenta.Balance = Convert.ToDouble(BalancetextBox.Text);
                if (CuentaIdtextBox.TextLength == 0)
                {
                    if (cuenta.Insertar())
                        {
                            MessageBox.Show("Cuenta Guardada Correctamente");
                        }
                        else
                        {
                            MessageBox.Show("Error! la Cuenta no se Guardo Correctamente");
                        }
                }else
                    if (CuentaIdtextBox.TextLength != 0)
                    {
                        cuenta.CuentaId = Convert.ToInt32(CuentaIdtextBox.Text);
                        if (cuenta.Editar())
                        {
                            MessageBox.Show("Cuenta Editada Correctamente");
                        }
                        else
                        {
                            MessageBox.Show("Error! la Cuenta no se Edito Correctamente");
                        }
                    }
                    DescripciontextBox.Clear();
                    BalancetextBox.Clear();
                    CuentaIdtextBox.Clear();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if(CuentaIdtextBox.TextLength > 0)
            {
                cuenta.CuentaId = int.Parse(CuentaIdtextBox.Text);
                if(cuenta.Eliminar())
                {
                    MessageBox.Show("Cuenta Eliminada Correctamente");
                }
                else
                {
                    MessageBox.Show("Error! la Cuenta no se Elimino Correctamente");
                }
            }
            CuentaIdtextBox.Clear();
            DescripciontextBox.Clear();
            BalancetextBox.Clear();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if(CuentaIdtextBox.TextLength > 0)
            {
                int id;
                int.TryParse(CuentaIdtextBox.Text, out id);
                cuenta.Buscar(id);

                DescripciontextBox.Text  = cuenta.Descripcion;
                BalancetextBox.Text = cuenta.Balance.ToString();
            }
        }

        private void Limpiarbutton_Click(object sender, EventArgs e)
        {
            DescripciontextBox.Clear();
            BalancetextBox.Clear();
            CuentaIdtextBox.Clear();
        }
    }
}
