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
	public partial class frmespecialidasingle : Form
	{
		EspecialidadDTO dtoaction = new EspecialidadDTO();
		String Operation;
		public BaseSysacadProxy<EspecialidadDTO> Myproxy()
		{
			return new EspecialidadProxy();
		}
		public frmespecialidasingle(EspecialidadDTO dto, string OP)
		{
			InitializeComponent();
			dtoaction = dto;
			Operation = OP;
			if (OP == "A")
			{
				this.Text = "Agregar Especialidad";
				button1.Text = "Agregar";
			}
			else if (OP == "M")
			{
				this.Text = "Actualizar Especialidad";
				txtIdespecialidad.ReadOnly = true;
				button1.Text = "Modificar";

				txtIdespecialidad.Text = dto.id_especialidad.ToString();
				txtespecialidad.Text = dto.desc_especialidad;
			}
			else if (OP == "D")
			{
				txtIdespecialidad.ReadOnly = true;
				txtespecialidad.ReadOnly = true;
				button1.Text = "Eliminar";
				txtIdespecialidad.Text = dto.id_especialidad.ToString();
				txtespecialidad.Text = dto.desc_especialidad;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Operation=="A")
			{
				if (txtespecialidad.Text==String.Empty)
				{
					MessageBox.Show("Debe ingresar la especialidad","Advertencia",MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtespecialidad.Text = String.Empty;
					txtespecialidad.Focus();
				}
				else if (!Seguridad.Validaciones.esDescripcionValida(txtespecialidad.Text))
				{
					MessageBox.Show("Debe ingresar la especialidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtespecialidad.Text = String.Empty;
					txtespecialidad.Focus();
				}
				else
				{
					EspecialidadDTO dtoinsert = new EspecialidadDTO()
					{
						id_especialidad = 0,
						desc_especialidad = txtespecialidad.Text,
						estado = (Int32)EstadoPersona.Alta
					};
					Myproxy().Create(dtoinsert);
					this.Close();
				}						
			}
			else if (Operation=="M")
			{
				if (txtespecialidad.Text == String.Empty)
				{
					MessageBox.Show("Debe ingresar la especialidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtespecialidad.Text = String.Empty;
					txtespecialidad.Focus();
				}
				else if (!Seguridad.Validaciones.esDescripcionValida(txtespecialidad.Text))
				{
					MessageBox.Show("Debe ingresar la especialidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtespecialidad.Text = String.Empty;
					txtespecialidad.Focus();
				}
				else
				{
					EspecialidadDTO dtoinsert = new EspecialidadDTO()
					{
						id_especialidad = Convert.ToInt32(txtIdespecialidad.Text),
						desc_especialidad = txtespecialidad.Text,
						estado =(Int32)EstadoPersona.Alta,
						Id = Convert.ToInt32(txtIdespecialidad.Text),
					};
					Myproxy().Update(dtoinsert);
					this.Close();
				}
			}
			else if(Operation == "D")
			{
				EspecialidadDTO dtoinsert = new EspecialidadDTO()
				{
					id_especialidad = Convert.ToInt32(txtIdespecialidad.Text),
					desc_especialidad = txtespecialidad.Text,
					estado = (Int32)EstadoPersona.Alta,
					Id = Convert.ToInt32(txtIdespecialidad.Text),
				};
				Myproxy().Delete(dtoinsert);
				this.Close();
			}

		}
	}
}
