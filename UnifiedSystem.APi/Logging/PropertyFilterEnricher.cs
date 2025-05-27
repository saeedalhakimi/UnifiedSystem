using Serilog.Core;
using Serilog.Events;

namespace UnifiedSystem.APi.Logging
{
    public class PropertyFilterEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.RemovePropertyIfPresent("EventId");
            logEvent.RemovePropertyIfPresent("ActionId");
            logEvent.RemovePropertyIfPresent("ActionName");
            logEvent.RemovePropertyIfPresent("RequestId");
        }
    }
}
