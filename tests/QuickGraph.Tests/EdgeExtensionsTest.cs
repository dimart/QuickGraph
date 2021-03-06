// <copyright file="EdgeExtensionsTest.cs" company="Jonathan de Halleux">Copyright http://quickgraph.codeplex.com/</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGraph;
using QuickGraph.Collections;

namespace QuickGraph
{
    /// <summary>This class contains parameterized unit tests for EdgeExtensions</summary>
    [TestClass]
    [PexClass(typeof(EdgeExtensions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class EdgeExtensionsTest
    {
        /// <summary>Test stub for GetOtherVertex(!!1, !!0)</summary>
        [PexMethod]
        public TVertex GetOtherVertex<TVertex,TEdge>(TEdge edge, TVertex vertex)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method EdgeExtensionsTest.GetOtherVertex(!!1, !!0)
            TVertex result = EdgeExtensions.GetOtherVertex<TVertex, TEdge>(edge, vertex);
            Assert.AreNotEqual(vertex, result);
            Assert.IsTrue(
                edge.Source.Equals(result) ||
                edge.Target.Equals(result));
            return result;
        }

        /// <summary>Test stub for HasCycles(IEnumerable`1&lt;!!1&gt;)</summary>
        [PexMethod(MaxRuns = 40)]
        public bool HasCycles<TVertex,TEdge>(IEnumerable<TEdge> path)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method EdgeExtensionsTest.HasCycles(IEnumerable`1<!!1>)
            bool result = EdgeExtensions.HasCycles<TVertex, TEdge>(path);
            return result;
        }

        /// <summary>Test stub for IsAdjacent(!!1, !!0)</summary>
        [PexMethod]
        public bool IsAdjacent<TVertex,TEdge>(TEdge edge, TVertex vertex)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method EdgeExtensionsTest.IsAdjacent(!!1, !!0)
            bool result = EdgeExtensions.IsAdjacent<TVertex, TEdge>(edge, vertex);
            return result;
        }

        /// <summary>Test stub for IsPath(IEnumerable`1&lt;!!1&gt;)</summary>
        [PexMethod]
        public bool IsPath<TVertex,TEdge>(IEnumerable<TEdge> path)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method EdgeExtensionsTest.IsPath(IEnumerable`1<!!1>)
            bool result = EdgeExtensions.IsPath<TVertex, TEdge>(path);
            return result;
        }

        /// <summary>Test stub for IsPathWithoutCycles(IEnumerable`1&lt;!!1&gt;)</summary>
        [PexMethod]
        public bool IsPathWithoutCycles<TVertex,TEdge>(IEnumerable<TEdge> path)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method EdgeExtensionsTest.IsPathWithoutCycles(IEnumerable`1<!!1>)
            bool result = EdgeExtensions.IsPathWithoutCycles<TVertex, TEdge>(path);
            return result;
        }

        /// <summary>Test stub for IsPredecessor(IDictionary`2&lt;!!0,!!1&gt;, !!0, !!0)</summary>
        [PexMethod]
        public bool IsPredecessor<TVertex,TEdge>(
            IDictionary<TVertex, TEdge> predecessors,
            TVertex root,
            TVertex vertex
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method EdgeExtensionsTest.IsPredecessor(IDictionary`2<!!0,!!1>, !!0, !!0)
            bool result
               = EdgeExtensions.IsPredecessor<TVertex, TEdge>(predecessors, root, vertex);
            return result;
        }

        /// <summary>Test stub for IsSelfEdge(IEdge`1&lt;!!0&gt;)</summary>
        [PexMethod]
        public bool IsSelfEdge<TVertex,TEdge>(TEdge edge)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method EdgeExtensionsTest.IsSelfEdge(IEdge`1<!!0>)
            bool result = EdgeExtensions.IsSelfEdge<TVertex, TEdge>(edge);
            return result;
        }

        /// <summary>Test stub for ToVertexPair(IEdge`1&lt;!!0&gt;)</summary>
        [PexMethod]
        public SEquatableEdge<TVertex> ToVertexPair<TVertex, TEdge>(TEdge edge)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method EdgeExtensionsTest.ToVertexPair(IEdge`1<!!0>)
            SEquatableEdge<TVertex> result = EdgeExtensions.ToVertexPair<TVertex, TEdge>(edge);
            return result;
        }

        /// <summary>Test stub for TryGetPath(IDictionary`2&lt;!!0,!!1&gt;, !!0, IEnumerable`1&lt;!!1&gt;&amp;)</summary>
        [PexMethod]
        public bool TryGetPath<TVertex,TEdge>(
            IDictionary<TVertex, TEdge> predecessors,
            TVertex v,
            out IEnumerable<TEdge> result
        )
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method EdgeExtensionsTest.TryGetPath(IDictionary`2<!!0,!!1>, !!0, IEnumerable`1<!!1>&)
            bool result01
               = EdgeExtensions.TryGetPath<TVertex, TEdge>(predecessors, v, out result);
            return result01;
        }
    }
}
