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
            var shiplist = init();
            var shotlist = new List<Field>();
            do
            {
                var feld=spielfeld_bauen(shotlist);
                display(feld);
                var answer=ask("Koordinaten?");
                if (answer.Count() == 1) break;
                shotlist = Fire(answer, shiplist, shotlist);

                
            } while (true);

           
        }

        static String ask(String question)
        {
            display(question);
            return Console.ReadLine();
        }
        static void display(String s)
        {
            Console.WriteLine(s);
        }
        
        static List<Schiff> init()
        {
            return new List<Schiff>() 
            {
                new Schiff(2,"a1",AusrichtungsTyp.horizontal), 
                new Schiff(3,"c2",AusrichtungsTyp.vertikal )
            };
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

        public static List<Field> Fire(String Koordinate, List<Schiff> Schiffe, List<Field> OldShots)
        {
            var koord = StringToKoord(Koordinate);
            var hit = Schiffe.Exists(s => s.Koordinaten.Contains(koord));
            

            OldShots.Add(new Field(koord.X,koord.Y, (hit)? "x" : "~")) ;
            return OldShots;
        }

        public static Koordinate StringToKoord(String Koordinate)
        {
            Koordinate _koord = new Koordinate();
            _koord.Y = char.ToUpper(Koordinate[0]) - 64;
            _koord.X = Koordinate.Length > 2 ? Convert.ToInt32((Koordinate[1] + Koordinate[2]).ToString()) : Convert.ToInt32(Koordinate[1].ToString());
            return _koord;
        }
    }

    public class Schiff
    {
        public List<Koordinate> Koordinaten { get; private set; }
        public Schiff(int Groesse, string Startposition, AusrichtungsTyp Ausrichtung)
        {
            Koordinaten = new List<Koordinate>();
            Koordinate _start = Program.StringToKoord(Startposition);
            for (int i = 0; i < Groesse; i++)
            {
                Koordinate _koord = new Koordinate();
                if (Ausrichtung == AusrichtungsTyp.vertikal)
                {
                    _koord.Y = _start.Y++;
                    _koord.X = _start.X;
                }
                if (Ausrichtung == AusrichtungsTyp.horizontal)
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
        public int Y;
        public int X;
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
    

}
