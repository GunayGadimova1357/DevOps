docker run -d \
  --name api \
  --network app-network \
  -e ConnectionStrings__DefaultConnection="Host=postgres;Port=5432;Database=appdb;Username=postgres;Password=postgres" \
  api-image
