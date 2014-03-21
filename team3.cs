 public class Schiff
    {
        List<String> Koordinaten = new List<string>();
        public Schiff(int Groesse, string Startposition,AusrichtungsTyp Ausrichtung)
        {
            char _v = Startposition[0]; 
            char _h = Startposition[1];
            for(int i = 0;i < Groesse;i++)
            {
                String _koord = String.Empty;
                if(Ausrichtung == AusrichtungsTyp.vertikal)
                {
                    _koord =  ((_v++).ToString() + _h) ;
                }
                if(Ausrichtung == AusrichtungsTyp.horizontal)
                {
                    _koord = _v.ToString() + _h++;
                }
                Koordinaten.Add(_koord);
            }
        }
    }
    public enum AusrichtungsTyp
    {
        horizontal, vertikal
    }
