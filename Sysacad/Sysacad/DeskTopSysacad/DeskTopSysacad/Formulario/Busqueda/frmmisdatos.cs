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

namespace DeskTopSysacad.Formulario.Busqueda
{
	public partial class frmmisdatos : Form
	{
		List<PersonaDTO> datosdevuelto;
		public frmmisdatos(List<PersonaDTO> datos)
		{
			InitializeComponent();
			this.Text = "Mis Datos";
			datosdevuelto = datos;
		}
		private void LoadBox()
		{
			if (datosdevuelto.Count() > 0)
			{
				foreach (var item in datosdevuelto)
				{
					txtid.Text = item.id_persona.ToString();
					txtapellido.Text = item.apellido;
					txtnombre.Text = item.nombre;
					txtdireccion.Text = item.direccion;
					txttelefono.Text = item.telefono;
					dtfecha_nac.Text = item.fecha_nac.ToString();
					cbplan.Text = new PlanProxy().Get(item.id_plan).desc_plan;
					cbmodulo.Text = new ModuloProxy().Get(item.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().id_modulo).desc_modulo;
					txtidusuario.Text = item.Usuarios.FirstOrDefault().id_usuario.ToString();
					txtusuario.Text = item.Usuarios.FirstOrDefault().nombre_usuario;
					txtclave.Text = item.Usuarios.FirstOrDefault().clave;
					txtcorreo.Text = item.Usuarios.FirstOrDefault().email;
					chckhabilitado.Checked = item.Usuarios.FirstOrDefault().habilitado;
					txtclave.ReadOnly = true;

					txtidmodulousuario.Text = item.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().id_modulo_usuario.ToString();
					chckalta.Checked = item.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().alta;
					chckmodificacion.Checked = item.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().modificacion;
					chckbaja.Checked = item.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().baja;
					chckconsulta.Checked = item.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().consulta;

					groupBox1.Enabled = false;
					groupBox2.Enabled = false;
					groupBox3.Enabled = false;
				}
			}
			else
			{
				groupBox1.Enabled = false;
				groupBox2.Enabled = false;
				groupBox3.Enabled = false;
			}
			
		}

		private void frmmisdatos_Load(object sender, EventArgs e)
		{
			LoadBox();
			//Close();
		}
	}
}
