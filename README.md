# API Gateway with Ocelot

This project demonstrates the implementation of an **API Gateway** using **Ocelot**, a lightweight and open-source API Gateway built for .NET microservice architecture.

## What is an API Gateway?

An **API Gateway** acts as a mediator between client applications and backend microservices.  
It is a software layer that functions as a single entry point for various APIs and performs several key tasks:

1. **Request Composition**
2. **Routing**
3. **Protocol Translation**

## Ocelot

**Ocelot** is an open-source API Gateway designed for microservices architecture in .NET.

### Key Features:
- Caching results
- Implementing rate limits
- Lightweight and configuration-based

> **Note:** Ocelot relies solely on a configuration file (`ocelot.json`) to route requests between the client and microservices.

---

## Basic Configuration

Ocelot's routing is configured using the `ocelot.json` file.

### Concepts:

- **Upstream (Gateway Level):** The endpoint exposed to clients.
- **Downstream (Microservice Level):** The actual microservice endpoint that processes the request.

### Configuration Structure

```json
{
  "GlobalConfiguration": {
    "BaseUrl": "http://localhost:5000"
  },
  "Routes": [
    {
      "UpstreamPathTemplate": "/products",
      "UpstreamHttpMethod": [ "GET" ],
      "DownstreamPathTemplate": "/products",
      "DownstreamPathScheme": "http",
      "DownstreamHostAndPorts": [
        {
          "Host": "localhost",
          "Port": 5002
        }
      ],
      "RateLimitOptions": {
        "EnableRateLimiting": true,
        "Period": "10s",
        "Limit": 3,
        "PeriodTimespan": 10
      },
      "FileCacheOptions": {
        "TtlSeconds": 10,
        "Period": "10s",
        "Limit": 3,
        "PeriodTimespan": 10
      }
    }
  ]
}
