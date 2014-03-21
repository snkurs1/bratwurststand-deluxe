using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {

           
        }

        static String spielfeld_bauen(List<Field> shotliste)
        {
            String field = "";
            Dictionary<int, Field> fields = new Dictionary<int, Field>();
            int yCounter = 1;

            for (int i = 1; i <= 100; i++)
            {
                if (i % 10 != 0)
                {
                    fields.Add(i, new Field((i % 10), yCounter, "."));
                }
                else
                {
                    fields.Add(i, new Field(10, yCounter, ".\n"));
                    yCounter++;
                }
            }

            var fields2 = fields.Select(kv => new KeyValuePair<int, Field>(kv.Key, shoot(kv.Value, shotliste)));


            foreach (var item in fields2)
            {
                field = field + item.Value.status;
            }

            return field;
        }

        static Field shoot(Field field, List<Field> shots)
        {
            var list = shots.Where(shot => (field.x == shot.x && field.y == shot.y));
            var status = (list.ToList().Count > 0) ? list.First().status : field.status;

            return new Field(field.x, field.y, status);
        }

    }

    public class Schiff
    {
        public List<String> Koordinaten = new List<string>();
        public Schiff(int Groesse, string Startposition, AusrichtungsTyp Ausrichtung)
        {
            char _v = Startposition[0];
            char _h = Startposition[1];
            for (int i = 0; i < Groesse; i++)
            {
                String _koord = (Ausrichtung == AusrichtungsTyp.vertikal) ?
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
        public static List<Schuss> Fire(String Koordinate, List<Schiff> Schiffe, List<Schuss> OldShots)
        {
            Schuss _shot = new Schuss();
            _shot.Koordinaten = Koordinate;
            _shot.getroffen = Schiffe.Exists(s => s.Koordinaten.Contains(_shot.Koordinaten));

            OldShots.Add(_shot);
            return OldShots;
        }
    }
    public struct Schuss
    {
        public bool getroffen;
        public String Koordinaten;
    }

    class Field
    {
        public int x;
        public int y;
        public String status;

        public Field(int xCoordinate, int yCoordinate, String fieldStatus)
        {
            x = xCoordinate;
            y = yCoordinate;
            status = fieldStatus;
        }
    }
    public struct Koordinate
    {
        public char Y;
        public int X;
    }


}
