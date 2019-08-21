using GraphQL.Types;
using System;

namespace Soccer.Api.Graph
{
    public class SoccerSchema : Schema
    {
        public SoccerSchema(IServiceProvider resolver) : base(resolver)
        {
            Query = (SoccerQuery)resolver.GetService(typeof(SoccerQuery));
        }
    }
}
