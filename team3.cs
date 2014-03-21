public class Schiff
    {
        List<String> Koordinaten = new List<string>();
        public Schiff(int Groesse, string Startposition,AusrichtungsTyp Ausrichtung)
        {
            char _v = Startposition[0]; 
            char _h = Startposition[1];
            for(int i = 0;i < Groesse;i++)
            {
                if(Ausrichtung == AusrichtungsTyp.vertikal)
                {
                    Koordinaten.Add( ((_v++).ToString() + _h) );
                }
                if(Ausrichtung == AusrichtungsTyp.horizontal)
                {
                    Koordinaten.Add( _v.ToString() + _h++);
                }
            }
        }
    }
    public enum AusrichtungsTyp
    {
        horizontal, vertikal
    }
