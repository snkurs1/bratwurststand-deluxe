using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace schiffe_vernichten_zerstören_whooaaaa_
{
    class Program
    {
        static void Main(string[] args)
        {
            var sl = new List<Field>() { new Field(1, 1, "x"), new Field(1,2,"~")};
            Console.WriteLine(spielfeld_bauen(sl));
            Console.ReadKey();
        }


        static String spielfeld_bauen(List<Field> shotliste)
        {
            String field = "";
            Dictionary<int, Field> fields = new Dictionary<int,Field>();
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

            var fields2= fields.Select(kv => new KeyValuePair<int,Field>(kv.Key, shoot(kv.Value,shotliste)) );

            
            foreach (var item in fields2)
            {
                field = field + item.Value.status;
            }

            return field;
        }

        static  Field shoot(Field field,List<Field> shots)
        {
            var list = shots.Where(shot => (field.x == shot.x && field.y == shot.y));
            var status = (list.ToList().Count > 0) ? list.First().status : field.status;

            return  new Field(field.x,field.y,status); 
        }
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
