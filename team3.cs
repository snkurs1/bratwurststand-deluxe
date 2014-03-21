public class Schiff
    {
        public List<Koordinate> Koordinaten { get; private set; }
        public Schiff(int Groesse, string Startposition,AusrichtungsTyp Ausrichtung)
        {
            Koordinaten = new List<Koordinate>();
            Koordinate _start = StringToKoord(Startposition);
            for(int i = 0;i < Groesse;i++)
            {
                Koordinate _koord = new Koordinate();
                if(Ausrichtung == AusrichtungsTyp.vertikal)
                {
                    _koord.Y = _start.Y++;
                    _koord.X =  _start.X ;
                }
                if(Ausrichtung == AusrichtungsTyp.horizontal)
                {
                    _koord.Y = _start.Y;
                    _koord.X = _start.X++;
                }
                Koordinaten.Add(_koord);
            }
        }
        public static Koordinate StringToKoord(String Koordinate)
        {
            Koordinate _koord = new Koordinate();
            _koord.Y = Koordinate[0] - 64;
            _koord.X = Koordinate.Length > 2 ? Convert.ToInt32((Koordinate[1] + Koordinate[2]).ToString()) : Convert.ToInt32(Koordinate[1].ToString());
            return _koord;
        }
    }
    public enum AusrichtungsTyp
    {
        horizontal, vertikal
    }
public struct Koordinate
    {
        public char Y;
        public int X;
    }
