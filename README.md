# P7


## Dockerizing and Running the System
Be placed in the same directory as the docker compose file and do the following for the different parts of the system:

### The Frontend
For running the frontend do the following:
```
docker-compose -f docker-compose-frontend.yaml up -d
```
And you should then be able to access the website at localhost:80.


Regarding docker swarm do the following:

```
docker stack deploy -c docker-compose-frontend.yaml frontend
```

where "frontend", at the end, is simply the name you give to the stack you are building and deploying to the swarm.


### The Backend
Simple docker compose:
```
docker-compose -f docker-compose-backend.yaml up -d
```

For docker swarm:
```
docker stack deploy -c docker-compose-frontend.yaml frontend
```


### The Visualizer
Simple docker compose:
```
docker-compose -f docker-compose-monitoring.yaml up -d
```

For docker swarm:
```
docker stack deploy -c docker-compose-monitoring.yaml visualizer
```

