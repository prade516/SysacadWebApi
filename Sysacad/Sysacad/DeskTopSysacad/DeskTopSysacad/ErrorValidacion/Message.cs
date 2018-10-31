using DeskTopSysacad.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskTopSysacad.ErrorValidacion
{
    public class Message
    {
        #region Constructor Single
        private static Message _factory;
        public static Message GetInstance()
        {
            if (_factory == null)
                _factory = new Message();
            return _factory;
        }
        #endregion

        public void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mensaje error
        public void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sysacad", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MensajeAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public DialogResult Mensajeconfirmacion(string mensaje)
        {
            return MessageBox.Show(mensaje, "Sysacad", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        public DialogResult exito(string mensaje)
        {
            return MessageBox.Show(mensaje, "Exitos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void AllowOnlyLetter(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        public void AllowOnlyNumber(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        public Boolean ValidateTextBox(List<TextBox> tbox, List<String> message)
        {
            Boolean txt = true;
            if (tbox.Count() == message.Count())
            {
                //ErrorMessage.error = new List<string>();
                for (int I = 0; I < tbox.Count(); I++)
                {
                    if (tbox[I].Text.Trim().Equals(""))
                    {
                        ErrorMessage.error.Add(message[I]);
                        ErrorMessage.txtactual.Add(tbox[I]);
                        txt = false;
                    }
                }
            }
            else
            {
                ErrorMessage.error.Add("Datos incorrectos");
                txt = false;
            }

            return txt;
        }       

        public Boolean ValidateUser(List<TextBox> tbox, List<String> condition, List<String> message)
        {
            Boolean txt = true;
            if (tbox.Count() == message.Count())
            {
                for (int I = 0; I < tbox.Count(); I++)
                {
                    if (tbox[I].Text.Trim().Equals("") && condition[I] == "")
                    {
                        ErrorMessage.error.Add(message[I]);
                        ErrorMessage.txtactual.Add(tbox[I]);
                        txt = false;
                    }
                    else if (tbox[1].Text.Trim() != tbox[2].Text.Trim() && condition[I] == "")
                    {
                        ErrorMessage.error.Add(message[2]);
                        ErrorMessage.txtactual.Add(tbox[2]);
                        txt = false;
                    }
                }
            }
            else
            {
                ErrorMessage.error.Add("Datos incorrectos");
                txt = false;
            }

            return txt;
        }

        public Boolean ValidateComboBox(List<ComboBox> tbox, List<String> message)
        {
            Boolean txt = true;
            //ErrorMessage.error = new List<string>();

            if (tbox.Count() == message.Count())
            {
                for (int I = 0; I < tbox.Count(); I++)
                {
                    if (tbox[I].SelectedItem == null)
                    {
                        ErrorMessage.error.Add(message[I]);
                        txt = false;
                    }
                }
            }
            else
            {
                ErrorMessage.error.Add("Datos incorrectos");
                txt = false;
            }

            return txt;
        }

        public String ValidarAccento(String nom)
        {
            nom = nom.ToLower();

            Regex replace_a_Accents = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);

            nom = replace_a_Accents.Replace(nom, "a");
            nom = replace_e_Accents.Replace(nom, "e");
            nom = replace_i_Accents.Replace(nom, "i");
            nom = replace_o_Accents.Replace(nom, "o");
            nom = replace_u_Accents.Replace(nom, "u");

            return nom;
        }

        public void FinalMessage(string resp, Form actual, string message)
        {
            if (resp.Equals("Ok"))
            {
                ErrorValidacion.Message.GetInstance().exito(message);
                actual.Close();
            }
            else
            {
                ErrorValidacion.Message.GetInstance().MensajeError(VariableGlobalySession.resp);
            }
        }
    }
}
