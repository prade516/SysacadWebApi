using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Enums
{
    public class GenreEnum
    {
        private static List<Genre> mylist;

        public static List<Genre> Genres
        {
            get
            {
                if (mylist == null)
                    mylist = ChargeGenres();
                return mylist;
            }

            set
            {
                mylist = value;
            }
        }

        public enum Genre
        {
            Masculino,
            Femenino
        }

       private static List<Genre> ChargeGenres()
        {
            return new List<Genre>() { Genre.Masculino, Genre.Femenino };
        }
    }
}