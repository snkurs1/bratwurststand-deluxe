 public class Schiff
    {
        public List<Koordinate> Koordinaten { get; private set; }
        public Schiff(int Groesse, string Startposition,AusrichtungsTyp Ausrichtung)
        {
            Koordinaten = new List<Koordinate>();
            Koordinate _start = new Koordinate();
            _start.Y = Startposition[0];
            _start.X = Startposition.Length > 2 ? Convert.ToInt32((Startposition[1] + Startposition[2]).ToString()): Convert.ToInt32(Startposition[1].ToString());
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
