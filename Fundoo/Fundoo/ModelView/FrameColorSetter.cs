using Fundoo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fundoo.ModelView
{
    class ColorSetter : ContentPage
    {
        public static void GetColor(Note note, Frame frame)
        {
            if (note.Color.Equals("Green"))
            {
                frame.BackgroundColor = Color.Green;
            }

            if (note.Color.Equals("Aqua"))
            {
                frame.BackgroundColor = Color.Aqua;
            }

            if (note.Color.Equals("DarkGoldenrod"))
            {
                frame.BackgroundColor = Color.DarkGoldenrod;
            }

            if (note.Color.Equals("Gold"))
            {
                frame.BackgroundColor = Color.Gold;
            }

            if (note.Color.Equals("GreenYellow"))
            {
                frame.BackgroundColor = Color.GreenYellow;
            }

            if (note.Color.Equals("Gray"))
            {
                frame.BackgroundColor = Color.Gray;
            }

            if (note.Color.Equals("Lavender"))
            {
                frame.BackgroundColor = Color.Green;
            }

            if (note.Color.Equals("MintCream"))
            {
                frame.BackgroundColor = Color.MintCream;
            }
        }
    }
}
