 public class Schiff
    {
        List<String> Koordinaten = new List<string>();
        public Schiff(int Groesse, string Startposition,AusrichtungsTyp Ausrichtung)
        {
            char _v = Startposition[0]; 
            char _h = Startposition[1];
            for(int i = 0;i < Groesse;i++)
            {
                 String _koord =(Ausrichtung == AusrichtungsTyp.vertikal)?
                    ((_v++).ToString() + _h) : _v.ToString() + _h++;
                    
                Koordinaten.Add(_koord);
            }
        }
    }
    public enum AusrichtungsTyp
    {
        horizontal, vertikal
    }


class Treffer
    {
        public static List<Schuss> Fire(String Koordinate, List<Schiff> Schiffe, List<Schuss> OldSchots)
        {
            Schuss _shot = new Schuss();
            _shot.Koordinaten = Koordinate;
            _shot.getroffen = Schiffe.Exists(s => s.Koordinaten.Contains(_shot.Koordinaten));

            OldSchots.Add(_shot);
            return OldSchots;
        }
    }
public struct Schuss
    {
        public bool getroffen;
        public String Koordinaten;
    }
