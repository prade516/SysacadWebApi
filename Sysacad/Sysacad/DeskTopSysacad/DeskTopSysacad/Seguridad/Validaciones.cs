using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeskTopSysacad.Seguridad
{
   public class Validaciones
    {
        string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";

        //ENCRIPTA CONTRASEÑA
        public string EncryptKey(string cadena)
        {
            //arreglo de bytes donde guardaremos la llave

            byte[] keyArray;

            //arreglo de bytes donde guardaremos el texto

            //que vamos a encriptar

            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(cadena);

            //se utilizan las clases de encriptación

            //provistas por el Framework

            //Algoritmo MD5

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice

            //hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo 3DAS

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;

            tdes.Mode = CipherMode.ECB;

            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena

            ICryptoTransform cTransform = tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la

            //cadena cifrada

            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena

            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }


        //DESENCRIPTA CONTRASEÑA
        public string DecryptKey(string clave)
        {
            byte[] keyArray;

            //convierte el texto en una secuencia de bytes

            byte[] Array_a_Descifrar = Convert.FromBase64String(clave);

            //se llama a las clases que tienen los algoritmos

            //de encriptación se le aplica hashing

            //algoritmo MD5

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;

            tdes.Mode = CipherMode.ECB;

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

            tdes.Clear();

            //se regresa en forma de cadena

            return UTF8Encoding.UTF8.GetString(resultArray);

        }
    
    public static bool esEmailValido(string email)
		{
            if (!String.IsNullOrEmpty(email.Trim()))
            {
                for (int k = 0; k < email.Length; ++k)
                {
                    if (Convert.ToChar(email[k]) == 32)
                    {
                        return false;
                    }


                }

                if (Regex.IsMatch(email, "(@)(.+)$"))
                {
                    return true;
                }

                else return false;
            }
            else return false;
        }

        public static bool esPasswordValida(string pass)
        {
            if (!String.IsNullOrEmpty(pass.Trim()))
            {
                //"- La clave debe tener al menos 6 caracteres." + "\n";
                if (pass.Length == 0 || pass.Trim().Length < 6)
                    return false;

                else
                    return true;
            }
            else return false;
        }

        public static bool coincidePass(string pass, string repetirPass)
        {  

                if (pass.Trim() != repetirPass.Trim())
                    return false;
                else 
                    return true;
        }
        public static bool esNombreValido(string nom)
        {
            if (!String.IsNullOrEmpty(nom.Trim()))
            {
                for (int k = 0; k < nom.Length; ++k)
                {
                    if (((Convert.ToChar(nom[k]) >= 65) && (Convert.ToChar(nom[k]) <= 90)) || ((Convert.ToChar(nom[k]) >= 97) && (Convert.ToChar(nom[k]) <= 122)) || (Convert.ToChar(nom[k]) == 32))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            }
            else return false;
        }

        public static bool esApellidoValido(string ape)
        {
            if (!String.IsNullOrEmpty(ape.Trim()))
            {
                for (int k = 0; k < ape.Length; ++k)
                {
                    if (((Convert.ToChar(ape[k]) >= 65) && (Convert.ToChar(ape[k]) <= 90)) || ((Convert.ToChar(ape[k]) >= 97) && (Convert.ToChar(ape[k]) <= 122)) || (Convert.ToChar(ape[k]) == 32))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            } return false;
        }

        public static bool esLegajoValido(string leg)
        {
            if (!String.IsNullOrEmpty(leg.Trim()))
            {
                for (int k = 0; k < leg.Length; ++k)
                {
                    if (((Convert.ToChar(leg[k]) >= 48) && (Convert.ToChar(leg[k]) <= 57)))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;

            } else return false;
        }

        public static bool esTelefonoValido(string tel)
        {
            if (!String.IsNullOrEmpty(tel.Trim())&& tel.Trim().Length < 11)
            {
                for (int k = 0; k < tel.Length; ++k)
                {
                    if (((Convert.ToChar(tel[k]) >= 48) && (Convert.ToChar(tel[k]) <= 57) || (Convert.ToChar(tel[k]) == 45)))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            }
            else return false;
        }

        public static bool esUsuarioValido(string usu)
        {
            if (!String.IsNullOrEmpty(usu.Trim()))
            {
                for (int k = 0; k < usu.Length; ++k)
                {
                    if (((Convert.ToChar(usu[k]) >= 65) && (Convert.ToChar(usu[k]) <= 90)) || ((Convert.ToChar(usu[k]) >= 96) && (Convert.ToChar(usu[k]) <= 122)))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            }
            else return false;
        }

        public static bool esDescripcionValida(string des)
        {
            if (!String.IsNullOrEmpty(des.Trim()))
            {
                for (int k = 0; k < des.Length; ++k)
                {
                    if (Convert.ToChar(des[k]) == 32 || ((Convert.ToChar(des[k]) >= 65) && (Convert.ToChar(des[k]) <= 90)) || ((Convert.ToChar(des[k]) >= 97) && (Convert.ToChar(des[k]) <= 122)))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            }
            else return false;
        }

        public static bool esDescripcionConNumerosValida(string des)
        {
            if (!String.IsNullOrEmpty(des.Trim()))
            {
                for (int k = 0; k < des.Length; ++k)
                {
                    if (Convert.ToChar(des[k]) == 32 || ((Convert.ToChar(des[k]) >= 48) && (Convert.ToChar(des[k]) <= 57)) || ((Convert.ToChar(des[k]) >= 65) && (Convert.ToChar(des[k]) <= 90)) || ((Convert.ToChar(des[k]) >= 97) && (Convert.ToChar(des[k]) <= 122)))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            }
            else return false;
        }

        public static bool esDescripcionComisionValida(string desc)
        {
            bool band = true;
            for (int k = 0; k < desc.Length; ++k)
            {
                if ((Convert.ToChar(desc[k]) >= 48) && (Convert.ToChar(desc[k]) <= 57))
                    continue;

                else
                {
                    band = false;
                    break;
                }
            }
                if (band)
                    return true;
                else
                    return false;
            
        }

        public static bool esCantidadHorasValidas(string hor)
        {
            if (!String.IsNullOrEmpty(hor.Trim()))
            {
                for (int k = 0; k < hor.Length; ++k)
                {
                    if ((Convert.ToChar(hor[k]) >= 48) && (Convert.ToChar(hor[k]) <= 57))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            }
            else return false;
        }

        public static bool esAnioCursoValido(string anio)
        {
            if (!String.IsNullOrEmpty(anio.Trim()))
            {
                for (int k = 1; k < 7; ++k)
                {
                    if (Convert.ToInt32(anio) == k)
                    {
                        return true;
                    }
                }

                return false;
            }
            else return false;
        }

        public static bool esAnioEspecialidadValido(string anio)
        {
            bool band=true;

            if (!String.IsNullOrEmpty(anio.Trim()))
            {
                for (int k = 0; k < anio.Length; ++k)
                {
                    if (Convert.ToChar(anio[k]) >= 48 && Convert.ToChar(anio[k]) <= 57)
                    {
                        continue;
                    }
                    else
                    {
                        band = false;
                        break;
                    }

                }

                if (band)
                {
                    int anioInt = Convert.ToInt32(anio);
                    if (anioInt >= 1 && anioInt <= 6)
                    {
                        return true;
                    }
                }
                else
                { return false; }
                }
            
            return false;
        }
        
        public static bool esAnioCalendarioValido(string anio)
        {
            bool band=true;

            if (!String.IsNullOrEmpty(anio.Trim()))
            {
                for (int k = 0; k < anio.Length; ++k)
                {
                    if (Convert.ToChar(anio[k]) >= 48 && Convert.ToChar(anio[k]) <= 57)
                    {
                        continue;
                    }
                    else
                    {
                        band = false;
                        break;
                    }

                }

                if (band)
                {
                    int anioInt = Convert.ToInt32(anio);
                    if (anioInt >= 1950 && anioInt <= DateTime.Today.Year)
                    {
                        return true;
                    }
                }
                else
                { return false; }
                }
            
            return false;
        }
		
        }
}
