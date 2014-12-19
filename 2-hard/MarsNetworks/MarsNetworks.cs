using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class MarsNetworks
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                // code here

                string[] points = line.Split(' ');
                List<Point> realPoints = new List<Point>();

                foreach(string point in points)
                {
                    int[] p = point.Split(',').Select(x => int.Parse(x)).ToArray();
                    realPoints.Add(new Point(p[0], p[1]));
                }

                var kruskal = new Kruskal(realPoints.ToArray());
                Console.WriteLine(String.Format("{0}", Math.Ceiling(kruskal.Span)));

                // end of code
            }

        Console.ReadLine();
    }

    public class Edge
    {
        public double Length { get; private set; }
        public int Point1 { get; private set; }
        public int Point2 { get; private set; }

        public Edge(int pt1, int pt2, double length)
        {
            Point1 = pt1;
            Point2 = pt2;
            Length = length;
        }

        public override string ToString()
        {
            return String.Format("({0}-{1})={2:0.00}", Point1, Point2, Length);
        }
    }

    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class Kruskal
    {
        public Edge[] Result { get; private set; }
        public double Span { get; private set; }
        public Kruskal(Point[] points)
        {
            int edgesArrayLength = 0;
            //dla N krawędzi będzie (N-1)+(N-2)+...+1 połączeń
            for (int i = points.Length - 1; i > 0; i--)
                edgesArrayLength += i;
            Edge[] edges = new Edge[edgesArrayLength];

            //Stwórz obiekty krawędzi dla każdego możliwego połączenia
            for (int i = 0, index = 0; i < points.Length; i++)
                for (int j = i + 1; j < points.Length; j++)
                {
                    int dx = points[i].X - points[j].X;
                    int dy = points[i].Y - points[j].Y;
                    edges[index] = new Edge(i, j, Math.Sqrt(dx * dx + dy * dy));
                    index++;
                }

            var sortEdges = edges.OrderBy(a => a.Length);
            //definiuje istniejące zbiory, dodana krawędź nie może tworzyć cyklu
            //cykl pojawia się, gdy obie krawędzie należą do tego samego zbioru
            int[] sets = new int[points.Length];
            Result = new Edge[points.Length - 1];
            int processedEdges = 0;
            foreach (var edge in sortEdges)
            {
                //Znaleziono N-1 niecyklicznych krawędzi
                //Całe drzewo rozpinające jest wyliczone
                if (processedEdges == points.Length - 1)
                    break;

                //Jest pięć możliwości:
                // 0-0 nie należą do zbioru
                // 0-X pierwszy węzeł nie należy do zbioru
                // X-0 drugi węzeł nie należy do zbioru
                // X-X oba węzły należą do jednego zbioru - CYKL!
                // X-Y węzły należą do różnych zbiorów
                // Pomijamy zatem te węzły, których zbiory się różnią
                // Lub jedna z krawędzi (np. pierwsza, jak niżej) nie należy do zbioru
                if (sets[edge.Point1] == 0 || sets[edge.Point1] != sets[edge.Point2])
                {
                    Result[processedEdges] = edge;
                    Span += edge.Length;
                    processedEdges++;
                    //Jeżeli krawędź nie należy do żadnego zbioru, pomiń
                    //Krawędź nie należy do żadnego zbioru, jeżeli oba znaczniki są równe 0
                    if (sets[edge.Point1] != 0 || sets[edge.Point2] != 0)
                    {
                        //To te zbiory będą łączone w jeden
                        int set1 = sets[edge.Point1];
                        int set2 = sets[edge.Point2];
                        //Zdefiniuj nowy zbiór składający się z dwóch łączonych zbiorów
                        //0 oznacza brak zbioru, jest pomijane na tym etapie
                        for (int i = 0; i < points.Length; i++)
                            if (sets[i] != 0 && (sets[i] == set1 || sets[i] == set2))
                                sets[i] = processedEdges;
                    }
                    //Oznacz końce krawędzi jako element nowego zbioru
                    //To tutaj dołączane są punkty spoza oznaczonych zbiorów
                    sets[edge.Point1] = processedEdges;
                    sets[edge.Point2] = processedEdges;
                }
            }
        }
    }
}