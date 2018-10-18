using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Tools.Misc
{
    public class Qualitiers
    {
        private int widht;
        private int height;
        private int quality;
        private FitMode fitmode;

        public FitMode Fitmode
        {
            get
            {
                return fitmode;
            }

            set
            {
                fitmode = value;
            }
        }

        public int Quality
        {
            get
            {
                return quality;
            }

            set
            {
                quality = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public int Widht
        {
            get
            {
                return widht;
            }

            set
            {
                widht = value;
            }
        }

    }

    //
    // Resumen:
    //     How to resolve aspect ratio differences between the requested size and the original
    //     image's size.
    public enum FitMode
    {
        //
        // Resumen:
        //     Fit mode will be determined by other settings, such as &carve=true, &stretch=fill,
        //     and &crop=auto. If none are specified and width/height are specified , &mode=pad
        //     will be used. If maxwidth/maxheight are used, &mode=max will be used.
        None = 0,
        //
        // Resumen:
        //     Width and height are considered maximum values. The resulting image may be smaller
        //     to maintain its aspect ratio. The image may also be smaller if the source image
        //     is smaller
        Max = 1,
        //
        // Resumen:
        //     Width and height are considered exact values - padding is used if there is an
        //     aspect ratio difference. Use &anchor to override the MiddleCenter default.
        Pad = 2,
        //
        // Resumen:
        //     Width and height are considered exact values - cropping is used if there is an
        //     aspect ratio difference. Use &anchor to override the MiddleCenter default.
        Crop = 3,
        //
        // Resumen:
        //     Width and height are considered exact values - seam carving is used if there
        //     is an aspect ratio difference. Requires the SeamCarving plugin to be installed,
        //     otherwise behaves like 'pad'.
        Carve = 4,
        //
        // Resumen:
        //     Width and height are considered exact values - if there is an aspect ratio difference,
        //     the image is stretched.
        Stretch = 5
    }
}