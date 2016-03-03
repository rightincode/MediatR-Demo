using MediatR;

namespace Request_Response
{
    public class PingHandler : IRequestHandler<Ping, string>
    {
        public string Handle(Ping request)
        {
            if (request.PingId > 0)
            {
                return ("Pong for " + request.PingId);
            }

            return "Pong";
        }
    }
}
