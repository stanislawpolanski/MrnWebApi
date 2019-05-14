using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrnWebApi.Common
{
    public class UriRoute
    {
        private String uriRoute;

        public String GetRoute()
        {
            return uriRoute;
        }

        public class Builder
        {
            private List<String> Nodes = new List<String>();

            public Builder Path(String childNode)
            {
                Nodes.Add(childNode);
                return this;
            }

            public UriRoute Build()
            {
                StringBuilder finalRouteStringBuilder = new StringBuilder();
                Nodes.ForEach(currentPath => finalRouteStringBuilder.Append("/" + currentPath));

                return new UriRoute() { uriRoute = finalRouteStringBuilder.ToString() };
            }
        }
    }
}
