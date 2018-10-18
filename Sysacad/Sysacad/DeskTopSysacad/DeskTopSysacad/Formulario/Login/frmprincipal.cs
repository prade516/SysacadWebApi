using DeskTopSysacad.DTO;
using DeskTopSysacad.EnumeradorPublic;
using DeskTopSysacad.Formulario.Busqueda;
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

namespace DeskTopSysacad.Formulario.Login
{
	public partial class frmprincipal : Form
	{
		public Int32 Tipo = 0;
		public Int32 idconectado = 0;
		public String Nombre = "";
		public String Apellido = "";

		public frmprincipal(PersonaDTO dto)
		{
			InitializeComponent();

			Tipo = dto.tipo_persona;
			Nombre = dto.nombre;
			Apellido = dto.apellido;
			idconectado = dto.id_persona;

			this.permision();
		}

		private void ShowNewForm(object sender, EventArgs e)
		{
			frmespecialidad especialidad = new frmespecialidad();
			especialidad.MdiParent = this;
			especialidad.Show();
		}

		private void OpenFile(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string FileName = openFileDialog.FileName;
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string FileName = saveFileDialog.FileName;
			}
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Tipo == (Int32)EnumeradorPublic.Role.Administrador)
			{
				frmbuscamisdatos frm = new frmbuscamisdatos();
				frm.MdiParent = this;
				frm.Show();
			}
			else
			{
				int state = 1;
				int top = 100;
				string orderby = "id_materia";
				string ascending = "asc";
				Int32 tipo = 0;
				int page = 1;
				string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page + "&tipo_persona=" + tipo;

				List<MateriaDTO> materia = new MateriaProxy().GetAll(filters).ToList();
				frestadoacademico frm = new frestadoacademico(materia);
				frm.Show();

			}
		}

		private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//statusStrip.Visible = statusBarToolStripMenuItem.Checked;
		}

		private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmmodulo modulo = new frmmodulo();
			modulo.MdiParent = this;
			modulo.Show();
		}

		private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmcomision comision = new frmcomision();
			comision.MdiParent = this;
			comision.Show();
		}

		private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmplan plan = new frmplan();
			plan.MdiParent = this;
			plan.Show();
		}
		private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmadministrador adm = new frmadministrador();
			adm.MdiParent = this;
			adm.Show();
		}
		private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}
		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmcurso curso = new frmcurso();
			curso.MdiParent = this;
			curso.Show();
		}
		#region Private Method
		private void permision()
		{
			if (Tipo==(Int32)Role.Administrador)
			{
				menuStrip.Visible = true;
			}
			else if (Tipo == (Int32)Role.Docente)
			{
				altaPersonaToolStripMenuItem.Visible = false;
				//correlativadadMenu.Visible = false;
				inscribirAToolStripMenuItem.Visible = false;
				historialMenu.Visible = false;
				altacarreraMenu.Visible = false;
				reportesToolStripMenuItem.Visible = false;
			}
			else if (Tipo == (Int32)Role.Alumno)
			{
				altaPersonaToolStripMenuItem.Visible = false;
				//verEstadoDeAlumnoToolStripMenuItem.Visible = false;
				//miCursoToolStripMenuItem.Visible = false;
				altacarreraMenu.Visible = false;
				notaToolStripMenuItem.Visible = false;
				reportesToolStripMenuItem.Visible = false;

			}
		}

		#endregion

		private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmmateria materia = new frmmateria();
			materia.MdiParent = this;
			materia.Show();
		}

		private void docenteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmdocente materia = new frmdocente();
			materia.MdiParent = this;
			materia.Show();
		}

		private void alumnoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmalumno materia = new frmalumno();
			materia.MdiParent = this;
			materia.Show();
		}

		private void cursarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frminscribircursar frm = new frminscribircursar(Tipo, idconectado);
			frm.MdiParent = this;
			frm.Show();
		}

		private void misDatosToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (Tipo==(Int32)EnumeradorPublic.Role.Administrador)
			{
				frmbuscamisdatos frm = new frmbuscamisdatos();
				frm.MdiParent = this;
				frm.Show();
			}
			else
			{
				int state = 1;
				int top = 100;
				string orderby = "id_persona";
				string ascending = "asc";
				Int32 tipo = 0;
				int page = 1;
				string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page + "&tipo_persona=" + tipo;
								
				List<PersonaDTO> datosdevuelto = new PersonaProxy().GetAll(filters).Where(x => x.id_persona == idconectado).ToList();
				frmmisdatos frm = new frmmisdatos(datosdevuelto);
				frm.Show();		
				
			}
			
		}

		private void misCursoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Tipo == (Int32)EnumeradorPublic.Role.Administrador)
			{
				frmbuscarmiscursos frm = new frmbuscarmiscursos();
				frm.MdiParent = this;
				frm.Show();
			}
			else
			{
				int state = 1;
				int top = 100;
				string orderby = "id_inscripcion";
				string ascending = "asc";
				Int32 tipo = 0;
				int page = 1;
				string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page + "&tipo_persona=" + tipo;

				List<Alumnos_InscripcionDTO> datosdevuelto = new Alumnos_InscripcionProxy().GetAll(filters).Where(x => x.id_alumno == idconectado).ToList();
				frmmiscursos frm = new frmmiscursos(datosdevuelto);
				frm.Show();

			}
		}

		private void notasDeParcialesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Tipo == (Int32)EnumeradorPublic.Role.Administrador)
			{
				fmbuscarnotaparcial frm = new fmbuscarnotaparcial();
				frm.MdiParent = this;
				frm.Show();
			}
			else
			{
				int state = 1;
				int top = 100;
				string orderby = "id_inscripcion";
				string ascending = "asc";
				Int32 tipo = 0;
				int page = 1;
				string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page + "&tipo_persona=" + tipo;

				List<Alumnos_InscripcionDTO> datosdevuelto = new Alumnos_InscripcionProxy().GetAll(filters).Where(x => x.id_alumno == idconectado).ToList();
				frmnotaparcial frm = new frmnotaparcial(datosdevuelto);
				frm.Show();

			}
		}

		private void regularizarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmregularidad frm = new frmregularidad();
			frm.iddocente = idconectado;
			frm.cargo = Tipo;
			frm.Show();
		}

		private void rendirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmrendir frm = new frmrendir();
			frm.idconectado = idconectado;
			frm.cargo = Tipo;
			frm.Show();
		}
	}
}
