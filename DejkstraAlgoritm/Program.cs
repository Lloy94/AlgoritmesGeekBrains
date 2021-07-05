using System;
using System.Collections.Generic;

namespace DejkstraAlgoritm
    //Тимофеев
    //Реализация алгоритма Дейкстры на языке С#
    
{
    public class GraphEdge
    {
        public GraphTop ConnectedTop { get; }
        public int EdgeWeight { get; }
        public GraphEdge(GraphTop connectedTop, int weight)
        {
            ConnectedTop = connectedTop;
            EdgeWeight = weight;
        }
    }
    public class GraphTop
    {
        public string Name { get; }
        public List<GraphEdge> Edges { get; }
        public GraphTop(string TopName)
        {
            Name = TopName;
            Edges = new List<GraphEdge>();
        }
        public void AddEdge(GraphEdge newEdge)
        {
            Edges.Add(newEdge);
        }
        public void AddEdge(GraphTop top, int edgeWeight)
        {
            AddEdge(new GraphEdge(top, edgeWeight));
        }
        public override string ToString() => Name;
    }
    public class Graph
    {
        public List<GraphTop> Vertices { get; }
        public Graph()
        {
            Vertices = new List<GraphTop>();
        }

        public void AddTop(string topName)
        {
            Vertices.Add(new GraphTop(topName));
        }
        public GraphTop FindTop(string topName)
        {
            foreach (var v in Vertices)
            {
                if (v.Name.Equals(topName))
                {
                    return v;
                }
            }

            return null;
        }
        public void AddEdge(string firstName, string secondName, int weight)
        {
            var v1 = FindTop(firstName);
            var v2 = FindTop(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                v2.AddEdge(v1, weight);
            }
        }
    }

    public class GraphTopInfo
    {
        public GraphTop Top { get; set; }
        public bool IsUnvisited { get; set; }
        public int EdgesWeightSum { get; set; }
        public GraphTop PreviousTop { get; set; }
        public GraphTopInfo(GraphTop top)
        {
            Top = top;
            IsUnvisited = true;
            EdgesWeightSum = int.MaxValue;
            PreviousTop = null;
        }
    }

    public class Dejkstra
    {
        Graph graph;
        List<GraphTopInfo> infos;
        public Dejkstra(Graph graph)
        {
            this.graph = graph;
        }
        void InitInfo()
        {
            infos = new List<GraphTopInfo>();
            foreach (var v in graph.Vertices)
            {
                infos.Add(new GraphTopInfo(v));
            }
        }
        GraphTopInfo GetTopInfo(GraphTop v)
        {
            foreach (var i in infos)
            {
                if (i.Top.Equals(v))
                {
                    return i;
                }
            }

            return null;
        }
        public GraphTopInfo FindUnvisitedTopWithMinSum()
        {
            var minValue = int.MaxValue;
            GraphTopInfo minTopInfo = null;
            foreach (var i in infos)
            {
                if (i.IsUnvisited && i.EdgesWeightSum < minValue)
                {
                    minTopInfo = i;
                    minValue = i.EdgesWeightSum;
                }
            }
            return minTopInfo;
        }


        public string FindShortestPath(string startName, string finishName)
        {
            return FindShortestPath(graph.FindTop(startName), graph.FindTop(finishName));
        }
        public string FindShortestPath(GraphTop startTop, GraphTop finishTop)
        {
            InitInfo();
            var first = GetTopInfo(startTop);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedTopWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextTop(current);
            }

            return GetPath(startTop, finishTop);
        }
        void SetSumToNextTop(GraphTopInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in info.Top.Edges)
            {
                var nextInfo = GetTopInfo(e.ConnectedTop);
                var sum = info.EdgesWeightSum + e.EdgeWeight;
                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PreviousTop = info.Top;
                }
            }
        }
        string GetPath(GraphTop startTop, GraphTop endTop)
        {
            var path = endTop.ToString();
            while (startTop != endTop)
            {
                endTop = GetTopInfo(endTop).PreviousTop;
                path = endTop.ToString() + path;
            }

            return path;
        }
        private static void Main(string[] args)
        {
            var g = new Graph();

            g.AddTop("A");
            g.AddTop("B");
            g.AddTop("C");
            g.AddTop("D");
            g.AddTop("E");
            g.AddTop("F");
            g.AddTop("G");

            g.AddEdge("A", "B", 22);
            g.AddEdge("A", "C", 33);
            g.AddEdge("A", "D", 61);
            g.AddEdge("B", "C", 47);
            g.AddEdge("B", "E", 93);
            g.AddEdge("C", "D", 11);
            g.AddEdge("C", "E", 79);
            g.AddEdge("C", "F", 63);
            g.AddEdge("D", "F", 41);
            g.AddEdge("E", "F", 17);
            g.AddEdge("E", "G", 58);
            g.AddEdge("F", "G", 84);

            var dejkstra = new Dejkstra(g);
            var path = dejkstra.FindShortestPath("A", "G");
            Console.WriteLine(path);
            Console.ReadLine();
        }
    }
}