# Product-Rating-System

# Softwares and Installations
 Visual Studio version: 2015 or above 
 
 MySql
 
 .Net Framework 4.7
 
 Entity Framework
 
 # Execution Steps
 Do Nuget Retore at Visual Studio
 
 Run the project
 
 
 # Test Cases
 # 1. GET api/Products 
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
  
  # 2. GET api/users
  <https://localhost:44317/api/Users/>
  
  {
    "Id": 5,
    "Name": "user"
}

# 3. GET api/productsRating/{id}
<https://localhost:44317/api/ProductRatings>

{
        "RatingId": 1,
        "User": null,
        "UserId": 6,
        "Product": null,
        "ProductId": 1,
        "RatingGiven": 0
    }

# 4. GET api/AverageRating/id
<https://localhost:44317/api/AverageRating/1>

2.6666666666666665

# 5. GET api/ProductRatingByCustomer/{productId}/{userId}
<https://localhost:44317/api/ProductRatingByCustomer/1/6>

{
    "RatingId": 1,
    "User": null,
    "UserId": 6,
    "Product": null,
    "ProductId": 1,
    "RatingGiven": 0
}

# 6. PUT api/ProductRating/{ProductId}/{UserID}
<https://localhost:44317/api/ProductRatings/1/6>

{
  "RatingId": 1,
  "UserId": 6,
  "ProductId": 1,
  "RatingGiven": 2
}

# 7. POST api/ProductRatings
<https://localhost:44317/api/ProductRatings>

// if the rating for particular combination of User and Product Id exist; update the value else post new row

{
	"UserId": 3,
	"ProductId": 5,
	"RatingGiven": 1
}
