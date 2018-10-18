using DeskTopSysacad.DTO;
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
	public partial class frmsinglenota : Form
	{
		Int32 idalumno = 0;
		Int32 idcurso = 0;

		public frmsinglenota(Alumnos_InscripcionDTO alumno)
		{
			InitializeComponent();

			this.Text="Agregar Nota y Regularidad";
			txtidinscripcion.Text = alumno.id_inscripcion.ToString();
			txtalumno.Text = new PersonaProxy().Get(alumno.id_alumno).nombre + " " + new PersonaProxy().Get(alumno.id_alumno).apellido;
			txtmateria.Text = new MateriaProxy().Get(new CursoProxy().Get(alumno.id_curso).id_materia).desc_materia;

			button1.Text = "Agregar";
			button2.Text = "Cancelar";

			txtalumno.ReadOnly = true;
			txtmateria.ReadOnly = true;
			txtnota.Focus();

			idalumno = alumno.id_alumno;
			idcurso = alumno.id_curso;
		}

		private void frmsinglenota_Load(object sender, EventArgs e)
		{
			txtnota.Focus();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			regularizar();
		}
		#region Private method
		private void regularizar()
		{
			if (txtnota.Text==String.Empty)
			{
				MessageBox.Show("Debe ingresar la nota", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtnota.Text = String.Empty;
				txtnota.Focus();
			}
			else
			{
				Alumnos_InscripcionDTO update = new Alumnos_InscripcionDTO()
				{
					id_inscripcion = Convert.ToInt32(txtidinscripcion.Text),
					Id = Convert.ToInt32(txtidinscripcion.Text),
					id_alumno = idalumno,
					id_curso = idcurso,
					nota = Convert.ToInt32(txtnota.Text),
					estado = (Int32)EnumeradorPublic.EstadoPersona.Alta
				};
				if (update.nota > 3)
				{
					update.condicion = "Regularizada";
				}
				else
				{
					update.condicion = "Libre";
				}
				new Alumnos_InscripcionProxy().Update(update);
				this.Close();
			}
			
		}
		#endregion

	}
}
