# ECommerceAppSolution.UserService

Part of a **3-service microservices architecture** built with **ASP.NET Core**, demonstrating clean architecture, polyglot persistence, and resilient inter-service communication.

## 📝 Note for Reviewers

[!IMPORTANT]
> This is a **cost-optimized learning deployment**. The databases run as **ephemeral pods with no persistent storage attached**, and the AKS cluster is shut down outside of demo hours to keep Azure costs near zero.

**What this means in practice:**
- **Data does not persist.** Products, users, and orders you create live only inside the pod's container filesystem.
- **State resets** whenever the cluster is turned off, or when pods are recreated (which happens on every restart — effectively a daily reset).
- Each pod comes back **fresh and empty**.
- If you revisit the app the next day, expect a **clean slate** — this is intentional, not a bug.

In a production setup, durability would come from **managed databases** (e.g., Azure Database for MySQL, Azure Cosmos DB) or **PersistentVolumes / StatefulSets** backed by Azure Disks, so data would survive restarts. That's deliberately left out here to keep the project free to host while still demonstrating the full CI/CD → AKS pipeline.

## 🏗️ Architecture Overview

This Users Microservice is one of three services in a distributed eCommerce system:

![eCommerce microservices architecture](users_microservice_architecture_v4.png)

## Learning Project

Built while working through ".NET Microservices with Azure DevOps & AKS | Basic to Master"(https://www.udemy.com/course/dot-net-microservices-ecommerce-project-azure-devops-kubernetes-aks/learn/lecture/45853823?start=1#overview) by Harsha Vardhan on Udemy.

## 👨‍💻 Author

**Akshat Parasher** — Software Engineer | C#/.NET Developer | Germany 🇩🇪

- 🔗 [Portfolio](https://akshat95-portfolio.netlify.app)
- 🔗 [GitHub](https://github.com/AkshatAspNetCore)
- 🔗 [GitLab](https://gitlab.com/arkhamknight95-group)
