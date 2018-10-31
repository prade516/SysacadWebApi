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
	public partial class frmplansingle : Form
	{
		PlanDTO dtoaction = new PlanDTO();
		String Operation;
		public BaseSysacadProxy<EspecialidadDTO> MyproxyEspecialidad()
		{
			return new EspecialidadProxy();
		}
		public BaseSysacadProxy<PlanDTO> Myproxy()
		{
			return new PlanProxy();
		}
		public frmplansingle(PlanDTO dto, string OP)
		{
			InitializeComponent();
			dtoaction = dto;
			Operation = OP;
			if (OP == "A")
			{
				this.Text = "Agregar Plan";
				button1.Text = "Agregar";
				button2.Text = "Cancelar";
				FillComboESpecialidad();
			}
			else if (OP == "M")
			{
				this.Text = "Actualizar Plan";
				txtIdplan.ReadOnly = true;
				button1.Text = "Modificar";
				button2.Text = "Cancelar";
				FillComboESpecialidad(dto.id_especialidad);

				txtIdplan.Text = dto.id_plan.ToString();
				txtdescplan.Text = dto.desc_plan;
			}
			else if (OP == "D")
			{
				txtIdplan.ReadOnly = true;
				txtdescplan.ReadOnly = true;
				button1.Text = "Eliminar";
				button2.Text = "Cancelar";
				txtIdplan.Text = dto.id_plan.ToString();
				txtdescplan.Text = dto.desc_plan;
				FillComboESpecialidad();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Operation == "A")
			{
				if (txtdescplan.Text == String.Empty)
				{
					MessageBox.Show("Debe ingresar el plan", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtdescplan.Text = String.Empty;
					txtdescplan.Focus();
				}
				else if (Seguridad.Validaciones.esDescripcionValida(txtdescplan.Text))
				{
					MessageBox.Show("Debe ingresar el plan", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtdescplan.Text = String.Empty;
					txtdescplan.Focus();
				}
				else
				{
					PlanDTO dtoinsert = new PlanDTO()
					{
						id_plan = 0,
						desc_plan = txtdescplan.Text,
                        id_especialidad = Convert.ToInt32(cbBespecialidad.SelectedValue),
                        estado = (Int32)EstadoPersona.Alta						
					};
                    ErrorValidacion.Message.GetInstance().FinalMessage(Myproxy().Create(dtoinsert), this, "El registro ha sido registrado corectamente.");
				}
			}
			else if (Operation == "M")
			{
				if (txtdescplan.Text == String.Empty)
				{
					MessageBox.Show("Debe ingresar el plan", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtdescplan.Text = String.Empty;
					txtdescplan.Focus();
				}
				else if (Seguridad.Validaciones.esDescripcionValida(txtdescplan.Text))
				{
					MessageBox.Show("Debe ingresar el plan", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtdescplan.Text = String.Empty;
					txtdescplan.Focus();
				}
				else
				{
					var idplanespecialidad = 0;
					
					PlanDTO dtoupdate = new PlanDTO()
					{
						id_plan = Convert.ToInt32(txtIdplan.Text),
						Id= Convert.ToInt32(txtIdplan.Text),
						desc_plan = txtdescplan.Text,
						estado = (Int32)EstadoPersona.Alta,
                        id_especialidad = Convert.ToInt32(cbBespecialidad.SelectedValue),
					};
                    ErrorValidacion.Message.GetInstance().FinalMessage(Myproxy().Update(dtoupdate), this, "El registro ha sido registrado corectamente.");
				}
			}
			else if (Operation == "D")
			{		
				PlanDTO dtodelate = new PlanDTO()
				{
					id_plan = Convert.ToInt32(txtIdplan.Text),
					Id = Convert.ToInt32(txtIdplan.Text),
					desc_plan = txtdescplan.Text,
					estado = (Int32)EstadoPersona.Alta,
                    id_especialidad = Convert.ToInt32(cbBespecialidad.SelectedValue),
                };
                ErrorValidacion.Message.GetInstance().FinalMessage(Myproxy().Delete(dtodelate), this, "El registro ha sido eliminado corectamente.");
            }
		}
		private void FillComboESpecialidad(Int32 codigo=0)
		{
			int state = 1;
			int top = 100;
			string orderby = "id_especialidad";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			
			List<EspecialidadDTO> resultado = MyproxyEspecialidad().GetAll(filters);
			var list = (from especialidad in resultado
						select new
						{
							Codigo = especialidad.id_especialidad,
							Especialidad = especialidad.desc_especialidad
						}).ToList();

            var xp = list.FindAll(x => x.Codigo == codigo || codigo == 0);
            cbBespecialidad.DataSource = list.FindAll(x=>x.Codigo==codigo||codigo==0);
			cbBespecialidad.DisplayMember = "Especialidad";
			cbBespecialidad.ValueMember = "Codigo";
		}
		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cbBespecialidad_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void cbBespecialidad_MouseClick(object sender, MouseEventArgs e)
		{
			FillComboESpecialidad();
		}

		private void frmplansingle_MouseClick(object sender, MouseEventArgs e)
		{

		}
	}
}
