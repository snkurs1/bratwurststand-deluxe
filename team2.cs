class Treffer
    {
        public static List<Schuss> Fire(String Koordinate, List<Schiff> Schiffe, List<Schuss> OldSchots)
        {
            Schuss _shot = new Schuss();
            _shot.Koordinaten = Koordinate;
            _shot.getroffen = Schiffe.Exists(s => s.Koordinaten.Contains(_shot.Koordinaten)); ;

            OldSchots.Add(_shot);
            return OldSchots;
        }
    }
public struct Schuss
    {
        public bool getroffen;
        public String Koordinaten;
    }
