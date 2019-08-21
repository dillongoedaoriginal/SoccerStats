using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class PostgresProvider
    {
        protected SoccerContext SoccerContext;
        public PostgresProvider(SoccerContext context)
        {
            SoccerContext = context;
        }
    }
}
