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
	public partial class frmmateriasingle : Form
	{
		public BaseSysacadProxy<MateriaDTO> Myproxy()
		{
			return new MateriaProxy();
		}
		MateriaDTO dtoaction = new MateriaDTO();
		String Operation;
		public frmmateriasingle(MateriaDTO dto,String OP)
		{
			InitializeComponent();
			Operation = OP;
			dtoaction = dto;
			if (OP == "A")
			{
				button1.Text = "Agregar";
				button2.Text = "Cancelar";
				this.Text = "Alta Materia";
				FillComboPlan();
			}
			else if (OP == "M")
			{
				button1.Text = "Actualizar";
				button2.Text = "Cancelar";
				this.Text = "Actualizar Materia";

				txtIdmateria.Text = dto.id_materia.ToString();
				txtdescmateria.Text = dto.desc_materia;
				txths_semanales.Text = dto.hs_semanales.ToString();
				txths_total.Text = dto.hs_totales.ToString();

				FillComboPlan(dto.id_plan);
			}
			else if (OP == "D")
			{
				button1.Text = "Eliminar";
				button2.Text = "Cancelar";
				this.Text = "Eliminar Materia";

				txtIdmateria.Text = dto.id_materia.ToString();
				txtdescmateria.Text = dto.desc_materia;
				txths_semanales.Text = dto.hs_semanales.ToString();
				txths_total.Text = dto.hs_totales.ToString();

				FillComboPlan(dto.id_plan);

				txtdescmateria.ReadOnly = true;
				txths_semanales.ReadOnly = true;
				cbplan.Enabled = false;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
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

		private void cbplan_MouseClick(object sender, MouseEventArgs e)
		{
			FillComboPlan();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Operation == "A")
			{
				InsertMateria();
			}
			else if (Operation == "M")
			{
				UpdateMateria();
			}
			else if (Operation == "D")
			{
				DeleteMateria();
			}
		}
		#region Private Method
		private void InsertMateria()
		{
			var materia = Myproxy().GetAll("?state=1").Where(x => x.desc_materia == txtdescmateria.Text);
			if (txtdescmateria.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar la materia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtdescmateria.Text = String.Empty;
				txtdescmateria.Focus();
			}
			else if (materia.Count() != 0)
			{
				MessageBox.Show("Ya existe ese materia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtdescmateria.Text = String.Empty;
				txtdescmateria.Focus();
			}
			else if (txths_semanales.Text==String.Empty)
			{
				MessageBox.Show("Debe ingresar la cantidad de horas semanales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txths_semanales.Text = String.Empty;
				txths_semanales.Focus();
			}
			else if (!Seguridad.Validaciones.esCantidadHorasValidas(txths_semanales.Text))
			{
				MessageBox.Show("Debe ingresar la cantidad de horas semanales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txths_semanales.Text = String.Empty;
				txths_semanales.Focus();
			}			
			else
			{
				MateriaDTO dtoinsert = new MateriaDTO()
				{
					desc_materia = txtdescmateria.Text,
					hs_semanales = Convert.ToInt32(txths_semanales.Text),
					hs_totales = Convert.ToInt32(txths_total.Text),
					estado = Convert.ToInt32(EstadoPersona.Alta),
                    id_plan = Convert.ToInt32(cbplan.SelectedValue)   
				};
				Myproxy().Create(dtoinsert);
				this.Close();
			}
		}

		private void UpdateMateria()
		{
			if (txtdescmateria.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar la materia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtdescmateria.Text = String.Empty;
				txtdescmateria.Focus();
			}
			else if (txths_semanales.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar la cantidad de horas semanales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txths_semanales.Text = String.Empty;
				txths_semanales.Focus();
			}
			else if (!Seguridad.Validaciones.esCantidadHorasValidas(txths_semanales.Text))
			{
				MessageBox.Show("Debe ingresar la cantidad de horas semanales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txths_semanales.Text = String.Empty;
				txths_semanales.Focus();
			}
			else
			{
				MateriaDTO dtoupdate = new MateriaDTO()
				{
					Id = Convert.ToInt32(txtIdmateria.Text),
					id_materia = Convert.ToInt32(txtIdmateria.Text),
					desc_materia = txtdescmateria.Text,
					hs_semanales = Convert.ToInt32(txths_semanales.Text),
					hs_totales = Convert.ToInt32(txths_total.Text),
					estado = dtoaction.estado,
                    id_plan = Convert.ToInt32(cbplan.SelectedValue)
                };
				Myproxy().Update(dtoupdate);
				this.Close();
			}
		}

		private void DeleteMateria()
		{
			MateriaDTO dtodelete = new MateriaDTO()
			{
				Id = Convert.ToInt32(txtIdmateria.Text),
				id_materia = Convert.ToInt32(txtIdmateria.Text),
			};
			Myproxy().Delete(dtodelete);
			this.Close();
		}
		#endregion

		private void txths_semanales_TextChanged(object sender, EventArgs e)
		{
			if (txths_semanales.Text!=String.Empty)
			{
				txths_total.Text = (Convert.ToInt32(txths_semanales.Text) * 4).ToString();
			}
			else
			{
				txths_total.Text = String.Empty;
			}
			
		}
	}
}
