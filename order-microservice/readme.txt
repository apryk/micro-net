# Error

Unhandled exception. RabbitMQ.Client.Exceptions.BrokerUnreachableException: None of the specified endpoints were reachable

# Fix

docker run -it --rm -p 8001:8080 -e RabbitMq__HostName=host.docker.internal order.service:v1.0

Here, we pass a new arg with the -e flag. We set our HostName to host.docker.internal, which is a special 
DNS name that resolves to the internal IP address used by our host machine.