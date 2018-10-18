using DeskTopSysacad.DTO;
using DeskTopSysacad.EnumeradorPublic;
using DeskTopSysacad.Formulario.List;
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
	public partial class frmcursosingle : Form
	{
		public BaseSysacadProxy<CursoDTO> Myproxy()
		{
			return new CursoProxy();
		}

		CursoDTO dtoaction = new CursoDTO();
		String Operation;

		Int32 codtitular = 0;
		Int32 codAyudante = 0;
		Int32 coddictado = 0;

		public frmcursosingle(CursoDTO dto,String OP)
		{
			InitializeComponent();
			Operation = OP;
			dtoaction = dto;
			if (OP == "A")
			{
				button1.Text = "Agregar";
				button2.Text = "Cancelar";
				this.Text = "Alta Curso";
			}
			else if (OP=="M")
			{
				txtIdcurso.Text = dto.id_curso.ToString();
				txtdescmateria.Text = new MateriaProxy().Get(dto.id_materia).desc_materia;
				txtcomision.Text = new ComisionProxy().Get(dto.id_comision).desc_comision;
				txtcalendario.Text = dto.anio_calendario.ToString();
				txtcupo.Text = dto.cupo.ToString();
				foreach (var item in dto.Docente_curso)
				{
					if (item.cargo==(Int32)EnumDocente.Titula)
					{
						codtitular = item.id_docente;
						coddictado = item.id_dictado;
						var persona= new PersonaProxy().Get(item.id_docente);
						txttitular.Text = persona.nombre + "" + persona.apellido;
					}
					else if (item.cargo == (Int32)EnumDocente.Auydante)
					{
						codAyudante = item.id_docente;
						coddictado = item.id_dictado;
						var persona = new PersonaProxy().Get(item.id_docente);
						txtjtp.Text = persona.nombre + "" + persona.apellido;
					}
				}
				button1.Text = "Actualizar";
				button2.Text = "Cancelar";
				this.Text = "Actualizar Curso";
			}
			else if (OP=="D")
			{
				txtIdcurso.Text = dto.id_curso.ToString();
				txtdescmateria.Text = new MateriaProxy().Get(dto.id_materia).desc_materia;
				txtcomision.Text = new ComisionProxy().Get(dto.id_comision).desc_comision;
				txtcalendario.Text = dto.anio_calendario.ToString();
				txtcupo.Text = dto.cupo.ToString();

				txtIdcurso.ReadOnly=true;
				txtdescmateria.ReadOnly = true;
				txtcomision.ReadOnly = true;
				txtcalendario.ReadOnly = true;
				txtcupo.ReadOnly = true;

				button1.Text = "Eliminar";
				button2.Text = "Cancelar";
				this.Text = "Eliminar Curso";
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			frmlistmateria frm = new frmlistmateria();
			frm.ShowDialog();
			dtoaction.id_materia = frm.codigo;
			txtdescmateria.Text = frm.materia;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			frmlistcomision frm = new frmlistcomision();
			
			frm.ShowDialog();
			dtoaction.id_comision = frm.codigo;
			txtcomision.Text = frm.materia;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Operation == "A")
			{
				InsertCurso();
			}
			else if (Operation == "M")
			{
				UpdateCurso();
			}
			else if (Operation == "D")
			{
				DeleteCurso();
			}
		}
		#region Private Method
		private void InsertCurso()
		{
			//var Materia = Myproxy().GetAll("?state=1").Where(x => x.anio_calendario == txtcalendario);
			//var comision = Myproxy().GetAll("?state=1").Where(x => x.id_comision == dtoaction.id_comision);
			if (txtdescmateria.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar la materia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtdescmateria.Text = String.Empty;
				txtdescmateria.Focus();
			}
			else if (txtcomision.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar la comision", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcomision.Text = String.Empty;
				txtcomision.Focus();
			}			
			else if (txtcalendario.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar el año calendario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcalendario.Text = String.Empty;
				txtcalendario.Focus();
			}
			else if (!Seguridad.Validaciones.esAnioCalendarioValido(txtcalendario.Text))
			{
				MessageBox.Show("Debe ingresar el año calendario en formato 'AAAA'", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcalendario.Text = String.Empty;
				txtcalendario.Focus();
			}
			else if (txtcupo.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar el cupo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcupo.Text = String.Empty;
				txtcupo.Focus();
			}
			else if (!Seguridad.Validaciones.esDescripcionConNumerosValida(txtcupo.Text))
			{
				MessageBox.Show("Debe ingresar el cupo con numero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcupo.Text = String.Empty;
				txtcupo.Focus();
			}
			else if (txttitular.Text == String.Empty)
			{
				MessageBox.Show("Debe Ingresar el docente titula para esa curso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txttitular.Text = String.Empty;
				txttitular.Focus();
			}
			else if (txtjtp.Text == String.Empty)
			{
				MessageBox.Show("Debe Ingresar el ayudante para esa curso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtjtp.Text = String.Empty;
				txtjtp.Focus();
			}
			else if (codtitular==codAyudante)
			{
				MessageBox.Show("El Docente titular no pueder ser ayudante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtjtp.Text = String.Empty;
				txtjtp.Focus();
			}
			else
			{
				CursoDTO dtoinsert = new CursoDTO()
				{					
					id_materia = dtoaction.id_materia,
					id_comision = dtoaction.id_comision,
					anio_calendario = Convert.ToInt32(txtcalendario.Text),
					cupo= Convert.ToInt32(txtcupo.Text),
					estado = Convert.ToInt32(EstadoPersona.Alta)	
				};
				dtoinsert.Docente_curso = new List<Docente_CursoDTO>()
				{
					new Docente_CursoDTO()
					{
						id_docente=codtitular,
						cargo=(Int32)EnumDocente.Titula,
						estado=(Int32)EstadoPersona.Alta
					},
					new Docente_CursoDTO()
					{
						id_docente=codAyudante,
						cargo=(Int32)EnumDocente.Auydante,
						estado=(Int32)EstadoPersona.Alta
					},
				};
				Myproxy().Create(dtoinsert);
				this.Close();
			}

		}
		private void UpdateCurso()
		{
			if (txtcomision.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar la comision", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcomision.Text = String.Empty;
				txtcomision.Focus();
			}			
			else if (txtcalendario.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar el año calendario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcalendario.Text = String.Empty;
				txtcalendario.Focus();
			}
			else if (!Seguridad.Validaciones.esAnioCalendarioValido(txtcalendario.Text))
			{
				MessageBox.Show("Debe ingresar el año calendario en formato 'AAAA'", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcalendario.Text = String.Empty;
				txtcalendario.Focus();
			}
			else if (txtcupo.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar el cupo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcupo.Text = String.Empty;
				txtcupo.Focus();
			}
			else if (!Seguridad.Validaciones.esDescripcionConNumerosValida(txtcupo.Text))
			{
				MessageBox.Show("Debe ingresar el cupo con numero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcupo.Text = String.Empty;
				txtcupo.Focus();
			}
			else
			{
				CursoDTO dtoupdate = new CursoDTO()
				{
					id_curso = Convert.ToInt32(txtIdcurso.Text),
					Id = Convert.ToInt32(txtIdcurso.Text),
					id_materia = dtoaction.id_materia,
					id_comision = dtoaction.id_comision,
					anio_calendario = Convert.ToInt32(txtcalendario.Text),
					cupo = Convert.ToInt32(txtcupo.Text),
					estado = dtoaction.estado
				};
				dtoupdate.Docente_curso = new List<Docente_CursoDTO>()
				{
					new Docente_CursoDTO()
					{
						id_cursos=Convert.ToInt32(txtIdcurso.Text),
						id_dictado=coddictado,
						id_docente=codtitular,
						cargo=(Int32)EnumDocente.Titula,
						estado=(Int32)EstadoPersona.Alta
					},
					new Docente_CursoDTO()
					{
						id_cursos =Convert.ToInt32(txtIdcurso.Text),
						id_dictado=coddictado,
						id_docente=codAyudante,
						cargo=(Int32)EnumDocente.Auydante,
						estado=(Int32)EstadoPersona.Alta
					},
				};
				Myproxy().Update(dtoupdate);
				this.Close();
			}
		}
		private void DeleteCurso()
		{
			CursoDTO dtodelate = new CursoDTO()
			{
				Id = dtoaction.id_curso,
			};
			Myproxy().Delete(dtodelate);
			this.Close();
		}
		#endregion

		private void button5_Click(object sender, EventArgs e)
		{
			frmshowdocente frm = new frmshowdocente();
			frm.role = "Docente";
			frm.ShowDialog();
			
			codtitular = frm.codigo;
			txttitular.Text = frm.docente;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			frmshowdocente frm = new frmshowdocente();
			frm.role = "Ayudante";
			frm.ShowDialog();

			codAyudante = frm.codigojtp;
			txtjtp.Text = frm.ayudante;
		}
	}
}
