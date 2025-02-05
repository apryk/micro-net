# start docker container
docker run -d --hostname rabbitmq-host --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

# build docker images
docker build -t order.service:v2.0 -f order-microservice/Order.Service/Dockerfile .
docker build -t basket.service:v3.0 -f basket-microservice/Basket.Service/Dockerfile .

# run docker images
docker run -it --rm -p 8001:8080 -e RabbitMq__HostName=host.docker.internal order.service:v2.0
docker run -it --rm -p 8000:8080 -e RabbitMq__HostName=host.docker.internal basket.service:v3.0