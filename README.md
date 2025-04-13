# Ocelot API Gateway in Microservices Architecture

## 🧩 Overview

**API Gateway** acts as a mediator between client applications and backend services within a **Microservices Architecture**. It is a software layer that serves as a **single entry point** for various APIs and performs tasks such as:

- Request Composition  
- Routing  
- Protocol Translation  
- Authentication and Authorization  
- Load Balancing  
- Rate Limiting  
- Caching  
- Quality of Service (QoS)  
- Header Transformation  
- Middleware Pipeline Support  

---

## 🚀 Ocelot: Lightweight API Gateway for .NET

> Ocelot is an open-source .NET-based API Gateway tailored for microservices-based applications.

### ✅ Core Features

- **Routing**: Maps incoming requests to the correct downstream microservice.
- **Caching**: Uses `Ocelot.Cache.CacheManager` to cache downstream responses.
- **Rate Limiting**: Controls the number of requests within a specific time window.
- **QoS (Circuit Breaker)**: Integrates with **Polly** to handle service faults gracefully.
- **Authentication and Authorization**: Supports JWT, IdentityServer4, etc.
- **Load Balancing**: Round-robin load balancing across instances.
- **Header Transformation**: Add/modify/remove headers.
- **Middleware Support**: Custom middleware in pipeline.
- **HTTPS & SSL Termination**
- **Logging & Tracing**: Compatible with logging tools.

---

## 🛠 Basic Ocelot Configuration

Ocelot relies on a single configuration file: `ocelot.json`.

### 🧾 Example:

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
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [
        { "Host": "localhost", "Port": 5002 }
      ],
      "RateLimitOptions": {
        "EnableRateLimiting": true,
        "Period": "10s",
        "Limit": 3
      },
      "FileCacheOptions": {
        "TtlSeconds": 10
      },
      "QoSOptions": {
        "ExceptionsAllowedBeforeBreaking": 3,
        "DurationOfBreak": 10000,
        "TimeoutValue": 5000
      }
    }
  ]
}
