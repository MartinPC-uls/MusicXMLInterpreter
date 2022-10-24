using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicXML_Parser.Music
{
    /*
     MusicXML Supported Notes:
        256th   -  Two Hundred Fifty-Sixth
        128th   -  One Hundred Twenty-Eighth
        64th    -  Sixty-Fourth
        32nd    -  Thirty-Second
        16th    -  Sixteenth
        eighth  -  Eighth
        quarter -  Quarter
        half    -  Half
        whole   -  Whole
        breve   -  Breve
        long    -  Long

        Font: https://www.w3.org/2021/06/musicxml40/tutorial/notation-basics/
     */
    public class Note
    {
        public string Value { get; private set; }

        public static readonly Note LONG = new Note("384");
        public static readonly Note BREVE = new Note("192");
        public static readonly Note WHOLE = new Note("96");
        public static readonly Note HALF = new Note("48");
        public static readonly Note QUARTER = new Note("24");
        public static readonly Note EIGHTH = new Note("12");
        public static readonly Note SIXTEENTH = new Note("6");
        public static readonly Note THIRTY_SECOND = new Note("3");
        public static readonly Note SIXTY_FOURTH = new Note("1.5");
        public static readonly Note ONE_HUNDRED_TWENTY_EIGHTH = new Note("0.75");
        public static readonly Note TWO_HUNDRED_FIFTY_SIXTH = new Note("0.375");

        protected Note(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
