﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickGraph.Algorithms.GraphColoring.VertexColoring
{
    public  class InputModel<TVertex, TEdge> 
        where TEdge : IEdge<TVertex>
    {
        public UndirectedGraph<TVertex, TEdge> Graph { get; set; }
    }

    public class OutputModel<TVertex, TEdge>
        : InputModel<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
        public Dictionary<TVertex, Nullable<int>> Colors { get; set; }
    }

    public class VertexColoringAlgorithm<TVertex, TEdge> 
        where TEdge : IEdge<TVertex>
    {
        private InputModel<TVertex, TEdge> input;

        public VertexColoringAlgorithm(InputModel<TVertex, TEdge> input)
        {
            this.input = input;
        }

        public event VertexAction<TVertex> ColourVertex;
        private void OnColourVertex(TVertex v)
        {
            var eh = this.ColourVertex;
            if (eh != null)
                eh(v);
        }

        public event VertexAction<TVertex> DiscoverVertex;
        private void OnDiscoverVertex(TVertex v)
        {
            var eh = this.DiscoverVertex;
            if (eh != null)
                eh(v);
        }

        public event VertexAction<TVertex> FinishVertex;
        private void OnFinishVertex(TVertex v)
        {
            var eh = this.FinishVertex;
            if (eh != null)
                eh(v);
        }

        public OutputModel<TVertex, TEdge> Compute()
        {
            int V = input.Graph.VertexCount;
            var listOfVertex = new List<IEnumerable<TVertex>>();
            var vertexColor = new Dictionary<TVertex, Nullable<int>>();
            var firstVertex = input.Graph.Vertices.First();


            // Initialize remaining vertices as unassigned
            foreach (var vertex in input.Graph.Vertices)
            {
                vertexColor[vertex] = null; // no color is assigned to vertex
            }

            // Assign the first color to first vertex
            this.OnDiscoverVertex(firstVertex);
            vertexColor[firstVertex] = 0;
            this.OnColourVertex(firstVertex);
            this.OnFinishVertex(firstVertex);

            /*
            A temporary array to store the available colors. True
            value of available[usedColor] would mean that the color usedColor is
            assigned to one of its adjacent vertices
            */
            bool[] available = new bool[V];
            for (int usingColor = 0; usingColor < V; usingColor++)
            {
                available[usingColor] = false;
            }

            // Assign colors to remaining V-1 vertices            
            foreach (var vertexOfGraph in input.Graph.Vertices)
            {
                if (!(vertexOfGraph.Equals(firstVertex)))
                {
                    //this.OnDiscoverVertex(vertexOfGraph);
                    // Process all adjacent vertices and flag their colors as unavailable
                    foreach (var edgesOfProcessVertex in input.Graph.AdjacentEdges(vertexOfGraph))
                    {
                        var adjacentVertex = edgesOfProcessVertex.GetOtherVertex(vertexOfGraph);

                        if (vertexColor[adjacentVertex].HasValue)
                        {
                            //this.OnDiscoverVertex(adjacentVertex);
                            available[vertexColor[adjacentVertex].Value] = true;
                            //this.OnFinishVertex(adjacentVertex);
                        }
                        
                    }

                    // Find the first available color
                    int usingColor = new int();
                    for (usingColor = 0; usingColor < V; usingColor++)
                    {
                        if (!(available[usingColor]))
                            break;
                    }

                    // Assign the found color
                    vertexColor[vertexOfGraph] = usingColor;
                    this.OnColourVertex(vertexOfGraph);
                    //this.OnFinishVertex(vertexOfGraph);
                    // Reset the values back to false for the next iteration
                    foreach (var edgesOfProcessVertex in input.Graph.AdjacentEdges(vertexOfGraph))
                    {
                        if (vertexColor[edgesOfProcessVertex.GetOtherVertex(vertexOfGraph)].HasValue)
                        {
                            available[vertexColor[edgesOfProcessVertex.GetOtherVertex(vertexOfGraph)].Value] = false;
                        }
                    }
                }
            }
            // Return the Graph with colored Vertices
            return new OutputModel<TVertex, TEdge>
            {
                Graph = input.Graph,
                Colors = vertexColor
            };

        }
    }
}