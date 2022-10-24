using MusicXML_Parser;
using System.Xml;
using MusicXML_Parser.Music;

//MusicTest musicTest = new MusicTest();
SheetConfiguration sheet = new SheetConfiguration()
{
    WorkTitle = "Test",
    Composer = "Martín Pizarro",
    Accidental = true,
    Beam = true,
    Print_NewPage = true,
    Print_NewSystem = true,
    Stem = true,
    WordFont = "FreeSerif",
    WordFontSize = 10,
    LyricFont = "FreeSerif",
    LyricFontSize = 11,
    CreditWords_Title = "Just a test",
    CreditWords_Subtitle = "Testing",
    CreditWords_Composer = "Martín",
    StaffLayout = 2,
    StaffDistance = 65,
    Divisions = 24,
    Tempo = 134,
    TimeBeats = 4,
    TimeBeatType = 4
};
XmlDocument score = sheet.Init("score.xml", Key.FMajor);
//XmlDocument score = sheet.Load(AppDomain.CurrentDomain.BaseDirectory + "score.xml");
XmlNode node = score.SelectSingleNode("score-partwise/part[@id='P1']");
XmlNode measure = sheet.AddMeasure(node);

string[] notes = new string[7] { "C", "D", "E", "F", "G", "A", "B" };
Note[] _notes = new Note[2] { Note.HALF, Note.QUARTER };

var rand = new Random();
for (int i = 1; i <= 20; i++)
{
    sheet.AddNote(1, notes[rand.Next(0, 7)], null, 5, _notes[rand.Next(0, 2)], measure);
}
/*sheet.AddNote(1, "C", null, 5, Note.QUARTER, measure);
sheet.AddNote(1, "D", null, 5, Note.QUARTER, measure);
sheet.AddNote(1, "E", -1, 5, Note.QUARTER, measure);
sheet.AddNote(1, "F", null, 5, Note.QUARTER, measure);
sheet.AddNote(1, "G", null, 5, Note.QUARTER, measure);
sheet.AddNote(1, "A", null, 5, Note.QUARTER, measure);
sheet.AddNote(1, "B", -1, 5, Note.QUARTER, measure);*/
/*
sheet.Backup(measure);
sheet.AddNote(2, "C", null, 3, Note.QUARTER, measure);
sheet.AddNote(2, "D", null, 3, Note.QUARTER, measure);
sheet.AddNote(2, "E", -1, 3, Note.QUARTER, measure);
sheet.AddNote(2, "F", null, 3, Note.QUARTER, measure);*/
