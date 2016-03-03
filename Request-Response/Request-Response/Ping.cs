using MediatR;

namespace Request_Response
{
    public class Ping : IRequest<string>
    {
        public int PingId { get; set; }
    }
}
