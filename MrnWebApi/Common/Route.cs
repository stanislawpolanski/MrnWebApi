using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrnWebApi.Common
{
    public class Route
    {
        private String uriRoute;

        public String GetRoute()
        {
            return uriRoute;
        }

        public class RouteBuilder
        {
            private List<String> Nodes = new List<String>();

            public RouteBuilder Path(String childNode)
            {
                Nodes.Add(childNode);
                return this;
            }

            public Route Build()
            {
                StringBuilder finalRouteStringBuilder = new StringBuilder();
                Nodes.ForEach(currentPath => finalRouteStringBuilder.Append("/" + currentPath));

                return new Route() { uriRoute = finalRouteStringBuilder.ToString() };
            }
        }
    }
}
