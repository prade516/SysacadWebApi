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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DeskTopSysacad.Formulario.Single
{
	public partial class frmpersonasingle : Form
	{
		PersonaDTO dtoaction = new PersonaDTO();
		String Operation;
		Int32 ultimolegajo = 0;
		String role;
		Int32 Tipo;
		public BaseSysacadProxy<PersonaDTO> Myproxy()
		{
			return new PersonaProxy();
		}

		public frmpersonasingle(PersonaDTO dto, string OP,String Role,String Titulo)
		{
			InitializeComponent();

			Operation = OP;
			dtoaction = dto;
			role = Role;

			if (Role== "Administrador")
			{
				cbplan.Visible = false;
				Tipo = (Int32)EnumeradorPublic.Role.Administrador;
				label8.Visible = false;
			}
			else if (Role=="Docente")
			{
				Tipo = (Int32)EnumeradorPublic.Role.Docente;
			}
			else if (Role == "Alumno")
			{
				Tipo = (Int32)EnumeradorPublic.Role.Alumno;
			}
			if (OP == "A")
			{
				this.Text = Titulo;
				button1.Text = "Agregar";
				button2.Text = "Cancelar";
				ultimolegajo = GetLastLegajo() + 2;
				txtlegajo.Text = ultimolegajo.ToString();
				Guid g = Guid.NewGuid();
				txtclave.Text = g.ToString("N").Substring(0,8);
				FillComboPlan();
				FillComboModulo();				
			}
			else if (OP == "M")
			{
				this.Text = Titulo;
				txtid.ReadOnly = true;
				button1.Text = "Modificar";
				button2.Text = "Cancelar";				

				txtid.Text = dto.id_persona.ToString();
				txtapellido.Text = dto.apellido;
				txtnombre.Text = dto.nombre;
				txtdireccion.Text = dto.direccion;
				txttelefono.Text = dto.telefono;
				dtfecha_nac.Value = dto.fecha_nac;
				txtlegajo.Text = dto.legajo.ToString();
				txtlegajo.ReadOnly = true;

				txtidusuario.Text = dto.Usuarios.FirstOrDefault().id_usuario.ToString();
				txtusuario.Text = dto.Usuarios.FirstOrDefault().nombre_usuario;
				txtclave.Text = dto.Usuarios.FirstOrDefault().clave;
				txtcorreo.Text = dto.Usuarios.FirstOrDefault().email;
				chckhabilitado.Checked = dto.Usuarios.FirstOrDefault().habilitado;
				txtclave.ReadOnly = true;

				txtidmodulousuario.Text = dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().id_modulo_usuario.ToString();
				chckalta.Checked = dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().alta;
				chckmodificacion.Checked = dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().modificacion;
				chckbaja.Checked = dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().baja;
				chckconsulta.Checked = dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().consulta;

				FillComboPlan(dto.id_plan);
				FillComboModulo(dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().id_modulo);
			}
			else if (OP == "D")
			{
				this.Text = Titulo;
				txtid.ReadOnly = true;
				txtapellido.ReadOnly = true;
				txtnombre.ReadOnly = true;

				button1.Text = "Eliminar";
				button2.Text = "Cancelar";
				txtid.Text = dto.id_persona.ToString();
				txtapellido.Text = dto.apellido;
				txtnombre.Text = dto.nombre;
				txtdireccion.Text = dto.direccion;
				txttelefono.Text = dto.telefono;
				dtfecha_nac.Text = dto.fecha_nac.ToString();
				txtlegajo.Text = dto.legajo.ToString();
				txtlegajo.ReadOnly = true;

				txtidusuario.Text = dto.Usuarios.FirstOrDefault().id_usuario.ToString();
				txtnombre.Text = dto.Usuarios.FirstOrDefault().nombre_usuario;
				txtclave.Text = dto.Usuarios.FirstOrDefault().clave;
				txtcorreo.Text = dto.Usuarios.FirstOrDefault().email;
				chckconsulta.Checked = dto.Usuarios.FirstOrDefault().habilitado;
				txtclave.ReadOnly = true;

				txtidmodulousuario.Text = dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().id_modulo_usuario.ToString();
				chckalta.Checked = dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().alta;
				chckmodificacion.Checked = dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().modificacion;
				chckbaja.Checked = dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().baja;
				chckconsulta.Checked = dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().consulta;

				FillComboPlan(dto.id_plan);
				FillComboModulo(dto.Usuarios.FirstOrDefault().modulo_usuario.FirstOrDefault().id_modulo_usuario);

				groupBox1.Enabled = false;
				groupBox2.Enabled = false;
				groupBox3.Enabled = false;
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
				InsertPersona();
			}
			else if (Operation == "M")
			{
				UpdatePersona();
			}
			else if (Operation == "D")
			{
				DeletePersona();
			}
		}
		private void frmpersonasingle_Load(object sender, EventArgs e)
		{
		}
		#region Evento Click
		private void cbplan_MouseClick(object sender, MouseEventArgs e)
		{
			FillComboPlan();
		}

		private void cbmodulo_MouseClick(object sender, MouseEventArgs e)
		{
			FillComboModulo();
		}
		#endregion

		#region Method Private
		#region Plan
		public BaseSysacadProxy<PlanDTO> MyproxyPlan()
		{
			return new PlanProxy();
		}
		private void FillComboPlan(Int32 codigo = 0)
		{
			int state = 1;
			int top = 100;
			string orderby = "id_plan";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;


			List<PlanDTO> resultado = MyproxyPlan().GetAll(filters);
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
		#region Modulo
		public BaseSysacadProxy<ModuloDTO> MyproxyModulo()
		{
			return new ModuloProxy();
		}
		private void FillComboModulo(Int32 codigo = 0)
		{
			int state = 1;
			int top = 100;
			string orderby = "id_modulo";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;


			List<ModuloDTO> resultado = MyproxyModulo().GetAll(filters);
			var list = (from plan in resultado
						select new
						{
							Codigo = plan.id_modulo,
							Modulo = plan.desc_modulo
						}).ToList();

			cbmodulo.DataSource = list.FindAll(x => x.Codigo == codigo || codigo == 0);
			cbmodulo.DisplayMember = "Modulo";
			cbmodulo.ValueMember = "Codigo";
		}
		#endregion
		#region LastLegajo
		private Int32 GetLastLegajo()
		{
			int state = 0;
			int top = 100;
			string orderby = "id_persona";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;

			var lastlegajo = 0;
			var resultado = Myproxy().GetAll(filters);
			if (resultado.Count() != 0)
			{
				lastlegajo = Myproxy().GetAll(filters).LastOrDefault().id_persona;
			}
			else
			{
				lastlegajo = 0;
			}

			return lastlegajo;
		}
		#endregion		
		#region ABM
		private void InsertPersona()
		{
			DateTime fechaDeNacimiento = new DateTime();
			fechaDeNacimiento = dtfecha_nac.Value;
			Int32 edad = (DateTime.Now.Subtract(fechaDeNacimiento).Days / 365);

			if (txtapellido.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar el apellido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtapellido.Text = String.Empty;
				txtapellido.Focus();
			}
			else if (!Seguridad.Validaciones.esNombreValido(txtapellido.Text))
			{
				MessageBox.Show("Debe ingresar el apellido,'Letra'", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtapellido.Text = String.Empty;
				txtapellido.Focus();
			}
			else if (txtnombre.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar el nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtnombre.Text = String.Empty;
				txtnombre.Focus();
			}
			else if (!Seguridad.Validaciones.esNombreValido(txtnombre.Text))
			{
				MessageBox.Show("Debe ingresar el nombre,'Letra'", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtnombre.Text = String.Empty;
				txtnombre.Focus();
			}
			else if (!Seguridad.Validaciones.esTelefonoValido(txttelefono.Text))
			{
				MessageBox.Show("Debe ingresar un numero telefono valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txttelefono.Text = String.Empty;
				txttelefono.Focus();
			}
			else if (edad < 16)
			{
				MessageBox.Show("Debe ser mayor que  16 años", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (txtcorreo.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar un correo valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcorreo.Text = String.Empty;
				txtcorreo.Focus();
			}
			else if (!Seguridad.Validaciones.esEmailValido(txtcorreo.Text))
			{
				MessageBox.Show("Debe ingresar coreo valido con formato<xxx@gmail.com>", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcorreo.Text = String.Empty;
				txtcorreo.Focus();
			}			
			else if (chckhabilitado.Checked == false)
			{
				MessageBox.Show("Debe habilitar el usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (!chckalta.Checked && !chckbaja.Checked && !chckconsulta.Checked)
			{
				MessageBox.Show("Debe dar permiso por lo menos a uno", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				Int32 idplanfinal = 0;
				if (role== "Administrador")
				{
					idplanfinal = 1;
				}				
				else
				{
					idplanfinal = Convert.ToInt32(cbplan.SelectedValue);
				}
				PersonaDTO dtoinsert = new PersonaDTO()
				{
					id_plan = idplanfinal,
					nombre = txtnombre.Text,
					apellido = txtapellido.Text,
					direccion = txtdireccion.Text,
					telefono = txttelefono.Text,
					fecha_nac = dtfecha_nac.Value,
					legajo = Convert.ToInt32(txtlegajo.Text),
					tipo_persona = Tipo,
					estado = (Int32)EstadoPersona.Alta
				};
				dtoinsert.Usuarios = new List<UsuarioDTO>()
					{
						new UsuarioDTO()
						{
							nombre_usuario=txtusuario.Text,
							clave=txtclave.Text,
							habilitado=chckhabilitado.Checked,
							email=txtcorreo.Text,
							cambia_clave=false,
							estado=(Int32)EstadoPersona.Alta,
							modulo_usuario = new List<Modulos_UsuarioDTO>()
							{
								new Modulos_UsuarioDTO()
								{
									id_modulo= Convert.ToInt32(cbmodulo.SelectedValue),
									alta=chckalta.Checked,
									modificacion=chckmodificacion.Checked,
									baja=chckbaja.Checked,
									consulta=chckconsulta.Checked,
									estado=(Int32)EstadoPersona.Alta,
								}
							}
						},
					};
				Myproxy().Create(dtoinsert);
				UsuarioContrasña();
				this.Close();
			}
		}

		private void UpdatePersona()
		{

			if (txtapellido.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar el apellido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtapellido.Text = String.Empty;
				txtapellido.Focus();
			}
			else if (!Seguridad.Validaciones.esNombreValido(txtapellido.Text))
			{
				MessageBox.Show("Debe ingresar el apellido,'Letra'", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtapellido.Text = String.Empty;
				txtapellido.Focus();
			}
			else if (txtnombre.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar el nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtnombre.Text = String.Empty;
				txtnombre.Focus();
			}
			else if (!Seguridad.Validaciones.esNombreValido(txtnombre.Text))
			{
				MessageBox.Show("Debe ingresar el nombre,'Letra'", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtnombre.Text = String.Empty;
				txtnombre.Focus();
			}
			else if (!Seguridad.Validaciones.esTelefonoValido(txttelefono.Text))
			{
				MessageBox.Show("Debe ingresar un numero telefono valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txttelefono.Text = String.Empty;
				txttelefono.Focus();
			}
			else if (dtfecha_nac.Value > DateTime.Now)
			{
				MessageBox.Show("Debe ingresa una fecha manor que hoy", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (txtcorreo.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar un correo valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcorreo.Text = String.Empty;
				txtcorreo.Focus();
			}
			else if (!Seguridad.Validaciones.esEmailValido(txtcorreo.Text))
			{
				MessageBox.Show("Debe ingresar coreo valido con formato<xxx@gmail.com>", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtcorreo.Text = String.Empty;
				txtcorreo.Focus();
			}
			else if (txtusuario.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar el nombre usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtusuario.Text = String.Empty;
				txtusuario.Focus();
			}
			else if (!Seguridad.Validaciones.esUsuarioValido(txtusuario.Text))
			{
				MessageBox.Show("Debe ingresar el nombre usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtusuario.Text = String.Empty;
				txtusuario.Focus();
			}
			else if (txtclave.Text == String.Empty)
			{
				MessageBox.Show("Debe ingresar la contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtclave.Text = String.Empty;
				txtclave.Focus();
			}
			else if (!Seguridad.Validaciones.esPasswordValida(txtclave.Text))
			{
				MessageBox.Show("Debe ingresar la contraseña mayor de 8 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtclave.Text = String.Empty;
				txtclave.Focus();
			}
			else if (chckhabilitado.Checked == false)
			{
				MessageBox.Show("Debe habilitar el usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (!chckalta.Checked && !chckbaja.Checked && !chckconsulta.Checked && !chckmodificacion.Checked)
			{
				MessageBox.Show("Debe dar permiso por lo menos a uno", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				Int32 idplanfinal = 0;
				if (role== "Administrador")
				{
					idplanfinal = 1;
				}				
				else
				{
					idplanfinal = Convert.ToInt32(cbplan.SelectedValue);
				}
				PersonaDTO dtoupdate = new PersonaDTO()
				{
					Id = Convert.ToInt32(txtid.Text),
					id_plan = idplanfinal,
					nombre = txtnombre.Text,
					apellido = txtapellido.Text,
					direccion = txtdireccion.Text,
					telefono = txttelefono.Text,
					fecha_nac = dtfecha_nac.Value,
					legajo = dtoaction.legajo,
					tipo_persona = Tipo,
					estado = (Int32)EstadoPersona.Alta
				};
				dtoupdate.Usuarios = new List<UsuarioDTO>()
					{
						new UsuarioDTO()
						{
							id_usuario=Convert.ToInt32(txtidusuario.Text),
							id_persona=Convert.ToInt32(txtid.Text),
							nombre_usuario=txtusuario.Text,
							clave=txtusuario.Text,
							habilitado=chckhabilitado.Checked,
							email=txtcorreo.Text,
							cambia_clave=false,
							estado=(Int32)EstadoPersona.Alta,
							modulo_usuario = new List<Modulos_UsuarioDTO>()
							{
								new Modulos_UsuarioDTO()
								{
									id_modulo_usuario=Convert.ToInt32(txtidmodulousuario.Text),
									id_usuario=Convert.ToInt32(txtidusuario.Text),
									id_modulo= Convert.ToInt32(cbmodulo.SelectedValue),
									alta=chckalta.Checked,
									modificacion=chckmodificacion.Checked,
									baja=chckbaja.Checked,
									consulta=chckconsulta.Checked,
									estado=(Int32)EstadoPersona.Alta,
								}
							}
						},
					};
				Myproxy().Update(dtoupdate);
				this.Close();
			}
		}

		private void DeletePersona()
		{
			PersonaDTO dtodelete = new PersonaDTO()
			{
				Id = Convert.ToInt32(txtid.Text)
			};
			Myproxy().Delete(dtodelete);
			this.Close();
		}
		#endregion
		private void txtnombre_TextChanged(object sender, EventArgs e)
		{
			Role(role);
		}
		#region Usuario
		private void Role(String role)
		{
			var nombre = txtnombre.Text;
			if (role == "Administrador")
			{
				nombre = nombre + "ADMIN";
				txtusuario.Text = nombre.Substring(0, 5) + "_" + txtlegajo.Text;
			}
			else if (role == "Docente")
			{
				nombre = nombre + "Docente";
				txtusuario.Text = nombre.Substring(0, 5) + "_" + txtlegajo.Text;
			}
			else if (role == "Alumno")
			{
				nombre = nombre + "Alumno";
				txtusuario.Text = nombre.Substring(0, 5) + "_" + txtlegajo.Text;
			}
		}
		private void UsuarioContrasña()
		{
			int state = 0;
			int top = 100000000;
			string orderby = "id_persona";
			string ascending = "asc";
			int page = 1;
			string filters = "?state=" + state + "&top=" + top + "&orderby=" + orderby + "&ascending=" + ascending + "&page=" + page;
			var usr = Myproxy().GetAll(filters).LastOrDefault().Usuarios.LastOrDefault();
			MessageBox.Show("El Usuario es :" + usr.nombre_usuario + "  Y Sucontraseña es : " + usr.clave + "", "Exitos", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		#endregion
		#endregion


	}
}
