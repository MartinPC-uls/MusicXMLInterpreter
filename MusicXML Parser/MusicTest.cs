using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MusicXml;
using MusicXml.Domain;

namespace MusicXML_Parser
{
    public class MusicTest
    {

        public static string[] notes = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

        public int GetNote(string note)
        {
            switch (note)
            {
                case "C":
                    return 0;
                case "C#":
                    return 1;
                case "D":
                    return 2;
                case "D#":
                    return 3;
                case "E":
                    return 4;
                case "F":
                    return 5;
                case "F#":
                    return 6;
                case "G":
                    return 7;
                case "G#":
                    return 8;
                case "A":
                    return 9;
                case "A#":
                    return 10;
                case "B":
                    return 11;
                default:
                    throw new Exception();
            }
        }

        public MusicTest()
        {
            //MusicXmlParser.DecompressFile(@"C:\Users\ghanv\OneDrive\Escritorio\tokyo_ghoul.mxl");
            var score = MusicXmlParser.GetScore(@"C:\Users\ghanv\OneDrive\Escritorio\score.xml");
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"C:\Users\ghanv\OneDrive\Escritorio\tokyo_ghoul.mxl");
            //XmlNode? attributesNode = doc.SelectSingleNode("score-partwise/part[@id='P1']/measure[@number='1']/attributes");
            //Clef clef = MusicXmlParser.GetClef(attributesNode);
            //Console.WriteLine("Sign: " + clef.Sign);
            //Console.WriteLine("Line: " + clef.Line);

            // Measure Sum: 96

            Part part1 = score.Parts[0];
            Measure measure1 = part1.Measures[5];
            List<MeasureElement> measureElements = measure1.MeasureElements;
            foreach (var element in measureElements)
            {
                if (element.Type == MeasureElementType.Note)
                {
                    Note note = (Note)element.Element;
                    if (note.Staff == 1)
                    {
                        if (note.IsRest)
                            Console.WriteLine("Silencio\tRIGHT HAND (G)");
                        else
                        {
                            int _note = GetNote(note.Pitch.Step.ToString());
                            int alter = note.Pitch.Alter;
                            int result = (_note + alter) < 0 ? 12+(_note + alter) : (_note + alter);
                            result = result > 11 ? -12 + (result) : result;
                            if (note.IsChordTone)
                            {
                                Console.WriteLine("Note: " + notes[result] + " " + note.Pitch.Octave + " X\t\tRIGHT HAND (G)");
                            }
                            else
                                Console.WriteLine("Note: " + notes[result] + " " + note.Pitch.Octave + " \t\t\tRIGHT HAND (G)");
                        }
                    } else if (note.Staff == 2)
                    {
                        if (note.IsRest)
                            Console.WriteLine("Silencio\tLEFT HAND (F)");
                        else
                        {
                            int _note = GetNote(note.Pitch.Step.ToString());
                            int alter = note.Pitch.Alter;
                            int result = (_note + alter) < 0 ? 12 + (_note + alter) : (_note + alter);
                            result = result > 11 ? -12 + (result) : result;
                            if (note.IsChordTone)
                                Console.WriteLine("Note: " + notes[result] + " " + note.Pitch.Octave + " X\t\tLEFT HAND (F)");
                            else
                                Console.WriteLine("Note: " + notes[result] + " " + note.Pitch.Octave + " \t\t\tLEFT HAND (F)");
                        }
                    }
                }
                else if (element.Type == MeasureElementType.Forward)
                {
                    Console.WriteLine("Forward");
                }
                else if (element.Type == MeasureElementType.Backup)
                {
                    Console.WriteLine("Backup");
                }
                else
                {
                    Console.WriteLine("--");
                }
            }
        }
    }
}
