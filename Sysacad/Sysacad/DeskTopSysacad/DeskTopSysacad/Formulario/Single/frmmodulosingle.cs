using DeskTopSysacad.DTO;
using DeskTopSysacad.EnumeradorPublic;
using DeskTopSysacad.Properties;
using DeskTopSysacad.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskTopSysacad.Formulario.Single
{
	public partial class frmmodulosingle : Form
	{
		ModuloDTO dtoaction = new ModuloDTO();
		String Operation;		
		public BaseSysacadProxy<ModuloDTO> Myproxy()
		{
			return new ModuloProxy();
		}
		public frmmodulosingle(ModuloDTO dto, string OP)
		{
			InitializeComponent();
			dtoaction = dto;
			Operation = OP;
			if (OP == "A")
			{
				this.Text = "Agregar Modulo";
				button1.Text = "Agregar";
				button2.Text = "Cancelar";
			}
			else if (OP == "M")
			{
				this.Text = "Actualizar Modulo";
				txtidmodulo.ReadOnly = true;
				button1.Text = "Modificar";
				button2.Text = "Cancelar";

				txtidmodulo.Text = dto.id_modulo.ToString();
				txtmodulo.Text = dto.desc_modulo;
				txtejecuta.Text = dto.ejecuta;
			}
			else if (OP == "D")
			{
				this.Text = "Eliminar Modulo";
				txtidmodulo.ReadOnly = true;
				txtmodulo.ReadOnly = true;
				txtejecuta.ReadOnly = true;

				button1.Text = "Eliminar";
				button2.Text = "Cancelar";
				txtidmodulo.Text = dto.id_modulo.ToString();
				txtmodulo.Text = dto.desc_modulo;
				txtejecuta.Text = dto.ejecuta;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Operation == "A")
			{
				if (txtmodulo.Text == String.Empty)
				{
					MessageBox.Show("Debe ingresar el modulo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtmodulo.Text = String.Empty;
					txtmodulo.Focus();
				}
				else if (!Seguridad.Validaciones.esDescripcionValida(txtmodulo.Text))
				{
					MessageBox.Show("Debe ingresar el modulo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtmodulo.Text = String.Empty;
					txtmodulo.Focus();
				}
                else
				if (txtejecuta.Text == String.Empty)
				{
					MessageBox.Show("Debe ingresar el lugar del modulo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtejecuta.Text = String.Empty;
					txtejecuta.Focus();
				}
				else if (!Seguridad.Validaciones.esDescripcionValida(txtejecuta.Text))
				{
					MessageBox.Show("Debe ingresar el lugar del modulo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtejecuta.Text = String.Empty;
					txtejecuta.Focus();
				}
				else
				{
					ModuloDTO dtoinsert = new ModuloDTO()
					{
						id_modulo = 0,
						desc_modulo = txtmodulo.Text,
						ejecuta=txtejecuta.Text,
						estado = (Int32)EstadoPersona.Alta,						
					};
					Myproxy().Create(dtoinsert);
					this.Close();
				}
			}
			else if (Operation == "M")
			{
				if (txtmodulo.Text == String.Empty)
				{
					MessageBox.Show("Debe ingresar el modulo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtmodulo.Text = String.Empty;
					txtmodulo.Focus();
				}
				else if (!Seguridad.Validaciones.esDescripcionValida(txtmodulo.Text))
				{
					MessageBox.Show("Debe ingresar el modulo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtmodulo.Text = String.Empty;
					txtmodulo.Focus();
				}
				if (txtejecuta.Text == String.Empty)
				{
					MessageBox.Show("Debe ingresar el lugar del modulo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtejecuta.Text = String.Empty;
					txtejecuta.Focus();
				}
				else if (!Seguridad.Validaciones.esDescripcionValida(txtejecuta.Text))
				{
					MessageBox.Show("Debe ingresar el lugar del modulo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtejecuta.Text = String.Empty;
					txtejecuta.Focus();
				}
				else
				{
					ModuloDTO dtoinsert = new ModuloDTO()
					{
						id_modulo = Convert.ToInt32(txtidmodulo.Text),
						Id = Convert.ToInt32(txtidmodulo.Text),
						desc_modulo = txtmodulo.Text,
						ejecuta = txtejecuta.Text,
						estado = (Int32)EstadoPersona.Alta,
					};
					Myproxy().Update(dtoinsert);
					this.Close();
				}
			}
			else if (Operation == "D")
			{
				ModuloDTO dtodelate = new ModuloDTO()
				{
					id_modulo = Convert.ToInt32(txtidmodulo.Text),
					Id = Convert.ToInt32(txtidmodulo.Text),
					desc_modulo = txtmodulo.Text,
					ejecuta = txtejecuta.Text,
					estado = (Int32)EstadoPersona.Baja,
				};
				Myproxy().Delete(dtodelate);
				this.Close();
			}
		}
	}
}
