using DeskTopSysacad.DTO;
using DeskTopSysacad.EnumeradorPublic;
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
	public partial class frmcomisionsingle : Form
	{
		public BaseSysacadProxy<ComisionDTO> Myproxy()
		{
			return new ComisionProxy();
		}

		ComisionDTO dtoaction = new ComisionDTO();
		String Operation = "";
		public frmcomisionsingle(ComisionDTO dto , String OP)
		{
			InitializeComponent();
			Operation = OP;
			dtoaction = dto;
			if (OP == "A")
			{
				button1.Text = "Agregar";
				button2.Text = "Cancelar";
				this.Text = "Alta Comision";
				FillComboPlan();
			}
			else if (OP=="M")
			{
				button1.Text = "Actualizar";
				button2.Text = "Cancelar";
				this.Text = "Alta Comision";

				txtIdcomision.Text = dto.id_comision.ToString();
				txtdesccomision.Text = dto.desc_comision;
				txtanioespecialidad.Text = dto.anio_especialidad.ToString();			

				FillComboPlan(dto.id_plan);
			}
			else if (OP=="D")
			{
				button1.Text = "Eliminar";
				button2.Text = "Cancelar";
				this.Text = "Eliminar Comision";

				txtIdcomision.Text = dto.id_comision.ToString();
				txtdesccomision.Text = dto.desc_comision;
				txtanioespecialidad.Text = dto.anio_especialidad.ToString();

				FillComboPlan(dto.id_plan);

				txtdesccomision.ReadOnly = true;
				txtanioespecialidad.ReadOnly = true;
				cbplan.Enabled = false;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Operation=="A")
			{
				Insertcomision();
			}
			else if (Operation=="M")
			{
				Updatecomision();
			}
			else if (Operation=="D")
			{
				DeleteComision();
			}
		}

		#region Plan		
		private void FillComboPlan(Int32 codigo = 0)
		{
			int state = 1;
			int top = 100;
			string orderby = "id_plan";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;


			List<PlanDTO> resultado = new PlanProxy().GetAll(filters);
			var list = (from plan in resultado
						select new
						{
							Codigo = plan.id_plan,
							Plan = plan.desc_plan
						}).ToList();

			cbplan.DataSource = list.FindAll(x => x.Codigo == codigo || codigo == 0);
			cbplan.DisplayMember = "Plan";
			cbplan.ValueMember = "Codigo";
		}
		#endregion
		#region Private Method
		private void Insertcomision()
		{
			var comision = Myproxy().GetAll("?state=1").Where(x=>x.desc_comision==txtdesccomision.Text);
			if (txtdesccomision.Text==String.Empty)
			{
				MessageBox.Show("Debe ingresar la comision", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtdesccomision.Text = String.Empty;
				txtdesccomision.Focus();
			}
			else if (comision.Count()!=0)
			{
				MessageBox.Show("Ya existe ese Comision", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtdesccomision.Text = String.Empty;
				txtdesccomision.Focus();
			}
			else if (txtanioespecialidad.Text==String.Empty)
			{
				MessageBox.Show("Debe ingresar el año de especialidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtanioespecialidad.Text = String.Empty;
				txtanioespecialidad.Focus();
			}
			else
			{
				ComisionDTO dtoinsert = new ComisionDTO()
				{
					desc_comision = txtdesccomision.Text,
					anio_especialidad = Convert.ToInt32(txtanioespecialidad.Text),
					estado = Convert.ToInt32(EstadoPersona.Alta),
                    id_plan = Convert.ToInt32(cbplan.SelectedValue),    
				};
				Myproxy().Create(dtoinsert);
				this.Close();
			}
			
		}
		private void Updatecomision()
		{
			if (txtdesccomision.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar la comision", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtdesccomision.Text = String.Empty;
				txtdesccomision.Focus();
			}
			else if (txtanioespecialidad.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar el año de especialidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtanioespecialidad.Text = String.Empty;
				txtanioespecialidad.Focus();
			}
			else
			{
				ComisionDTO dtoupdate = new ComisionDTO()
				{
					Id= Convert.ToInt32(txtIdcomision.Text),
					id_comision= Convert.ToInt32(txtIdcomision.Text),
					desc_comision = txtdesccomision.Text,
					anio_especialidad = Convert.ToInt32(txtanioespecialidad.Text),
					estado = dtoaction.estado,
                    id_plan = Convert.ToInt32(cbplan.SelectedValue),
                    
				};
				Myproxy().Update(dtoupdate);
				this.Close();
			}			
		}

		private void DeleteComision()
		{
			ComisionDTO dtodelate = new ComisionDTO()
			{
				Id = Convert.ToInt32(txtIdcomision.Text),
			};
			Myproxy().Delete(dtodelate);
			this.Close();
		}
		#endregion

		private void cbplan_MouseClick(object sender, MouseEventArgs e)
		{
			FillComboPlan();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
