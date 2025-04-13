# Ocelot API Gateway in Microservices Architecture

## Overview
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

## Ocelot: Lightweight API Gateway for .NET

> Ocelot is an open-source .NET-based API Gateway tailored for microservices-based applications.

### Core Features
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

## Basic Ocelot Configuration

Ocelot relies on a single configuration file: `ocelot.json`.

### Structure:
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
```

---

## Kubernetes vs Ocelot

### Do You Need Ocelot When Using Kubernetes?

**Short Answer**: In most cases, **No**. Kubernetes provides its own native solutions such as **Ingress Controller**, which handle many gateway responsibilities.

---

## Kubernetes Features That Ocelot Lacks

| Feature                       | Kubernetes (w/ Ingress Controller)        | Ocelot                                |
|------------------------------|--------------------------------------------|----------------------------------------|
| Service Discovery            | Built-in via DNS and labels                | Manual                                 |
| Auto Scaling                 | Yes (HPA, VPA)                             | Not supported                          |
| Self-Healing                 | Yes (Pod restart, health checks)           | Not supported                          |
| Rolling Updates              | Yes                                        | Not supported                          |
| Ingress Routing              | Native path/host-based routing             | Path & method-based routing            |
| TLS Termination              | Native with cert-manager                   | Supported with additional setup        |
| Network Policies             | Yes (fine-grained control)                 | No                                     |
| Observability & Metrics      | Prometheus, Grafana, etc.                  | Basic logging only                     |
| Declarative Config           | Full YAML-based, GitOps-friendly           | Simple JSON file                       |

---

## When to Use Ocelot?

| Use Ocelot if... |
|------------------|
| ✅ Your app is **not hosted in Kubernetes**. |
| ✅ You want a .NET-native solution. |
| ✅ You need quick and easy **routing + auth + caching** without container orchestration. |
| ✅ You want to handle QoS and rate limiting internally. |

---

## Conclusion
If you're already in the **Kubernetes ecosystem**, leverage its **Ingress Controllers** (like NGINX or Traefik) for API gateway capabilities. Reserve **Ocelot** for simpler setups or when you're working **outside Kubernetes** with a .NET-centric microservices architecture.

---

## 📘 References & Further Reading
- [Ocelot GitHub](https://github.com/ThreeMammals/Ocelot)
- [Kubernetes Ingress Docs](https://kubernetes.io/docs/concepts/services-networking/ingress/)
- [Polly .NET Resilience](https://github.com/App-vNext/Polly)
- [CacheManager for .NET](https://github.com/MichaCo/CacheManager)
- [Kubernetes GitOps](https://www.weave.works/technologies/gitops/)

---

