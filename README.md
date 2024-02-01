# Project Description

This project aims to create a basic RESTful API supporting CRUD operations for a mobile e-commerce platform. It also includes a JWT (JSON Web Token) based authentication system for user login.

# Used Technologies
- ASP.NET API
- N Layer Architecture
- Generic Repository Pattern 
- Unit Of Work
- Entity Framework Core
- SQL Server
- Fluent Validation
- AutoMapper

# Key Aspects

- Authentication and Authorization (JWT)
- Global Exception Handling
- Custom Response
- Filters

# API Endpoint Definitions

**Brands**

| **HTTP Methods** | **Endpoints** | **Explanation** |
| --- | --- | --- |
| `GET`| `/brands` | List all brands. |
| `GET`| `/brands/{brandId}` | Get a specific brand. |
| `POST`| `/brands` | Add a new brand. |
| `PUT`| `/brands/{brandId}` | Update a specific brand. | 
| `DELETE`| `/brands/{brandId}` | Delete a specific brand. | 


**Models**

| **HTTP Methods** | **Endpoints** | **Explanation** |
| --- | --- | --- |
| `GET`| `/brands/{brandId}/models` | List all models for a brand. | 
| `GET`| `/models/{modelId}` | Get a specific model. | 
| `POST`| `/brands/{brandId}/models` | Add a new model for a brand. | 
| `PUT`| `/models/{modelId}` | Update a specific model. | 
| `DELETE`| `/models/{modelId}` | Delete a specific model. | 


**Versions** 

| **HTTP Methods** | **Endpoints** | **Explanation** |
| --- | --- | --- |
| `GET`| `/models/{modelId}/versions` | List all versions for a model. | 
| `GET`| `/versions/{versionId}` | Get a specific version. | 
| `POST`| `/models/{modelId}/versions` | Add a new version for a model. | 
| `PUT`| `/versions/{versionId}` | Update a specific version. | 
| `DELETE`| `/versions/{versionId}` | Delete a specific version. | 


**Orders** 

| **HTTP Methods** | **Endpoints** | **Explanation** |
| --- | --- | --- |
| `POST`| `/orders` | Create a new order. | 
| `GET`| `/orders` | List all orders. | 
| `GET`| `customers/{customerId}/orders` | List orders for a specific customer. | 
| `GET`| `/orders/{orderId}` | View details of a specific order. | 
| `PUT`| `/orders/{orderId}` | Update details of a specific order. | 
| `DELETE`| `/orders/{orderId}` | Delete a specific order. | 

**Auth** 

| **HTTP Methods** | **Endpoints** | **Explanation** |
| --- | --- | --- |
| `POST`| `/auth/login` | User login. | 
| `POST`| `/auth/register` | Register a new user. | 
| `GET`| `/auth/user` | Get information of the logged-in user. | 
| `PUT`| `/auth/user` | Update information of the logged-in user. | 

# Database Diagrams

![DatabaseDiagram](https://www.serkanisik.com/wp-content/uploads/2024/02/phoneEcommerce.png)