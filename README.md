# Healthcheck Test

Application created with the sole purpose of testing the Healthcheck functionality of Docker.

Code pushed to [GitHub](https://github.com/leonardogm85/healthcheck-test/).

Image pushed to [DockerHub](https://hub.docker.com/r/leonardogm85/healthcheck-test/).

## Build the image from a Dockerfile and push the image to a registry:
```sh
# Build the image from a Dockerfile:
docker image build -t leonardogm85/healthcheck-test:1.0.0 -f HealthcheckTest/Dockerfile .

# Create the tag latest:
docker image tag leonardogm85/healthcheck-test:1.0.0 leonardogm85/healthcheck-test:latest

# Push the version 1.0.0 to a registry:
docker image push leonardogm85/healthcheck-test:1.0.0

# Push the latest version to a registry:
docker image push leonardogm85/healthcheck-test:latest
```

## Create and start containers with Docker Autoheal:
``` sh
# Start containers:
docker compose -f docker-compose-with-autoheal.yml up -d
```

## Create and start containers with Docker Swarm:
``` sh
# Initialize the swarm:
docker swarm init --advertise-addr <ip|interface>[:port]

# Manage join tokens:
docker swarm join-token <worker|manager>

# Join the swarm as a node or manager:
docker swarm join --token <id> <ip|interface>[:port]

# Deploy the new stack:
docker stack deploy -c healthcheck-test/docker-compose-with-swarm.yml healthcheck-test-stack
```

## Manager servers:
``` sh
# Up the servers:
vagrant up

# Access the servers:
vargrant ssh <server-name>

# Halt the servers:
vagrant halt
```

## Reference:

Monitor and restart unhealthy docker containers [GitHub Autoheal](https://github.com/willfarrell/docker-autoheal/) and [DockerHub Autoheal](https://hub.docker.com/r/willfarrell/autoheal/)

Guides, terms and commands [Docker Docs](https://docs.docker.com/) and [Vagrant Docs](https://developer.hashicorp.com/vagrant/docs/)
