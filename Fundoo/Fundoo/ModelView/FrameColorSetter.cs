using Fundoo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fundoo.ModelView
{
    class FrameColorSetter : ContentPage
    {
        public static void GetColor(Note note, Frame frame)
        {
            if (note.Color.Equals("Green"))
            {
                frame.BackgroundColor = Color.Green;
                return;
            }

            if (note.Color.Equals("Aqua"))
            {
                frame.BackgroundColor = Color.Aqua;
                return;
            }

            if (note.Color.Equals("DarkGoldenrod"))
            {
                frame.BackgroundColor = Color.DarkGoldenrod;
                return;
            }

            if (note.Color.Equals("Gold"))
            {
                frame.BackgroundColor = Color.Gold;
                return;
            }

            if (note.Color.Equals("GreenYellow"))
            {
                frame.BackgroundColor = Color.GreenYellow;
                return;
            }

            if (note.Color.Equals("Gray"))
            {
                frame.BackgroundColor = Color.Gray;
                return;
            }

            if (note.Color.Equals("Lavender"))
            {
                frame.BackgroundColor = Color.Lavender;
                return;
            }

            if (note.Color.Equals("MintCream"))
            {
                frame.BackgroundColor = Color.MintCream;
                return;
            }
        }

        public static string GetHexColor(Note note)
        {
            if (note.Color.Equals("Green"))
            {                
                return "008000";
            }

            if (note.Color.Equals("Aqua"))
            {
                
                return "00ffff";
            }

            if (note.Color.Equals("DarkGoldenrod"))
            {
               
                return "b8860b";
            }

            if (note.Color.Equals("Gold"))
            {
                
                return "ffd700";
            }

            if (note.Color.Equals("GreenYellow"))
            {
               
                return "adff2f";
            }

            if (note.Color.Equals("Gray"))
            {
                
                return "808080";
            }

            if (note.Color.Equals("Lavender"))
            {
               
                return "e6e6fa";
            }

            if (note.Color.Equals("MintCream"))
            {
                
                return "f5fffa";
            }

            return "ffffff";
        }

        public static void GetColor(Archive archiveNote, Frame frame)
        {
            if (archiveNote.Color.Equals("Green"))
            {
                frame.BackgroundColor = Color.Green;
                return;
            }

            if (archiveNote.Color.Equals("Aqua"))
            {
                frame.BackgroundColor = Color.Aqua;
                return;
            }

            if (archiveNote.Color.Equals("DarkGoldenrod"))
            {
                frame.BackgroundColor = Color.DarkGoldenrod;
                return;
            }

            if (archiveNote.Color.Equals("Gold"))
            {
                frame.BackgroundColor = Color.Gold;
                return;
            }

            if (archiveNote.Color.Equals("GreenYellow"))
            {
                frame.BackgroundColor = Color.GreenYellow;
                return;
            }

            if (archiveNote.Color.Equals("Gray"))
            {
                frame.BackgroundColor = Color.Gray;
                return;
            }

            if (archiveNote.Color.Equals("Lavender"))
            {
                frame.BackgroundColor = Color.Lavender;
                return;
            }

            if (archiveNote.Color.Equals("MintCream"))
            {
                frame.BackgroundColor = Color.MintCream;
                return;
            }
        }

        public static string GetHexColor(Archive archiveNote)
        {
            if (archiveNote.Color.Equals("Green"))
            {
                return "008000";
            }

            if (archiveNote.Color.Equals("Aqua"))
            {

                return "00ffff";
            }

            if (archiveNote.Color.Equals("DarkGoldenrod"))
            {

                return "b8860b";
            }

            if (archiveNote.Color.Equals("Gold"))
            {

                return "ffd700";
            }

            if (archiveNote.Color.Equals("GreenYellow"))
            {

                return "adff2f";
            }

            if (archiveNote.Color.Equals("Gray"))
            {

                return "808080";
            }

            if (archiveNote.Color.Equals("Lavender"))
            {

                return "e6e6fa";
            }

            if (archiveNote.Color.Equals("MintCream"))
            {

                return "f5fffa";
            }

            return "ffffff";
        }
    }
}
