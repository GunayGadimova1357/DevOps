docker run -d \
  --name postgres \
  --network app-network \
  -e POSTGRES_DB=appdb \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_PASSWORD=postgres \
  postgres:15
