using MrnWebApi.Common.Exceptions;
using System;
using System.Linq;
using System.Text;

namespace MrnWebApi.Common.Routing
{
    public class UriRoute
    {
        private String uriRoute = String.Empty;

        public void AddNodesToTheRoute(params string[] nodes)
        {
            uriRoute += BuildRouteFromNodes(nodes).ToString();
        }

        private static StringBuilder BuildRouteFromNodes(string[] nodes)
        {
            StringBuilder temporaryRouteBuilder = new StringBuilder();

            nodes
                .OfType<string>()
                .ToList()
                .ForEach(node =>
                {
                    ValidateNode(node);
                    AddNodeToTheTemporaryRoute(node, temporaryRouteBuilder);
                });

            return temporaryRouteBuilder;
        }

        private static void AddNodeToTheTemporaryRoute(string node, StringBuilder finalRouteStringBuilder)
        {
            String finalNode = node.StartsWith("/") ? node : AddSlashToTheBeginningOfTheNode(node);
            finalRouteStringBuilder.Append(finalNode.ToLower());
        }

        private static string AddSlashToTheBeginningOfTheNode(string node)
        {
            return new StringBuilder().Append("/").Append(node).ToString();
        }

        private static void ValidateNode(string node)
        {
            if (node.EndsWith("/"))
            {
                throw new ForbiddenUseOfCharacterInAStringException("Slash in the end of a path");
            }
        }

        public static UriRoute GetRouteFromNodes(params string[] nodes)
        {
            UriRoute route = new UriRoute();
            route.AddNodesToTheRoute(nodes);
            return route;
        }

        public override string ToString()
        {
            return uriRoute;
        }
    }
}
