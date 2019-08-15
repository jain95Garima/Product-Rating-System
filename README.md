## Softwares and Installations
 Visual Studio version: 2015 or above 
 
 MySql
 
 .Net Framework 4.7
 
 Entity Framework
 
 ## Execution Steps
 Do restore Nugget Packages at Visual Studio
 
 Run the project
 
 
 ## Use Cases
 ### 1. GET api/Products/{productId}
 url: <https://localhost:44317/api/Products>
 
 [Response]
 ```json
  [
    {
      "Id": 1,
      "Name": "sample string 2",
      "Description": "sample string 3"
    },
    {
      "Id": 1,
      "Name": "sample string 2",
      "Description": "sample string 3"
    }
  ]
  ```
  
  ### 2. GET api/users
  url: <https://localhost:44317/api/Users/>
  
  [Response]
  ```json
  {
    "Id": 5,
    "Name": "user"
}
```

### 3. GET api/productsRating/{id}
url: <https://localhost:44317/api/ProductRatings>

[Response]
```json
{
        "RatingId": 1,
        "User": null,
        "UserId": 6,
        "Product": null,
        "ProductId": 1,
        "RatingGiven": 0
    }
```
### 4. GET api/AverageRating/id
url: <https://localhost:44317/api/AverageRating/1>

[Response]
```json
2.6666666666666665
```
### 5. GET api/ProductRatingByCustomer/{productId}/{userId}
url: <https://localhost:44317/api/ProductRatingByCustomer/1/6>
[Response]
```json
{
    "RatingId": 1,
    "User": null,
    "UserId": 6,
    "Product": null,
    "ProductId": 1,
    "RatingGiven": 0
}
```
### 6. PUT api/ProductRating/{ProductId}/{UserID}
url: <https://localhost:44317/api/ProductRatings/1/6>

[Body]
```json
{
  "RatingId": 1,
  "UserId": 6,
  "ProductId": 1,
  "RatingGiven": 2
}
```
[Response]

204 No Content
### 7. POST api/ProductRatings
url: <https://localhost:44317/api/ProductRatings>

// if the rating for particular combination of User and Product Id exist; update the value else post new row

[Body]
```json
{
	"UserId": 3,
	"ProductId": 5,
	"RatingGiven": 1
}
```
[Response]

204 NO Content
