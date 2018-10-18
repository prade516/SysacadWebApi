using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MVCPeaton.Models.ViewModels.CustomDA
{
    public class ListValidator : ValidationAttribute
    {
        private Int32 minimum;
        private Int32 maximum;
        public ListValidator(Int32 min = 0, Int32 max = 0)
        {
            minimum = min;
            maximum = max;
        }

        public override bool IsValid(object value)
        {
            var mylist = value as IList;
            PropertyInfo myproperty = mylist == null ? null : mylist[0].GetType().GetProperty("ischecked");
            var count = 0;
            if (myproperty == null)
                count = mylist == null ? 0 : mylist.Count;
            else
                for (var o = 0; o < mylist.Count; o++)
                {
                    if ((Boolean)myproperty.GetValue(mylist[o]))
                        count++;
                }

            if (mylist != null)
            {
                if (maximum > 0)
                    return count >= minimum && count <= maximum;
                else
                    return count >= minimum;
            }
            else
                if (minimum == 0)
                    return true;
                else
                    return false;
        }
    }
}