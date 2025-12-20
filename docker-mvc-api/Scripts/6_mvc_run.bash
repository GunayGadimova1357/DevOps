docker run -d \
  --name mvc \
  --network app-network \
  -p 5001:8080 \
  mvc-image
