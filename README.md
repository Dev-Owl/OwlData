# OwlData
Little data experiment with NetCore and CouchDB

# InsertTestData - CMD application
Can be used to import json data from a folder into CouchDB. The JSON data has to be in array from like: [{obj1},{obj2}]
Command line arguments are:




| Command | Description | Required |
| ---|---| :---: |
| -data | Path to the folder | YES |
| -server | URL to couchDB | YES |
| -usr | User used to login  | YES |
| -pwd | Password for this user | YES |
| -db  | Name of the db to use,if empty import will be used, if db not exists it will be created | NO |


# OwlDataModel - Library with core functions
Offers the base idea of Entity and Validation Model. Folder also contains Unit tests and a make file for Windows and Linux.
The image below shows the major system components:
![alt text][dataModelOverview]

## Entity
Entity can be any data that is key value based (for example a JSON object). This part is the raw unrated data from an external source without description.
As an example:
```javascript
{
	"Name": "Glenn",
	"FirstName": "Arden",
	"Street": "P.O. Box 999, 7555 In St.",
	"City": "Dindigul",
	"PostCode": "KP6 8RB",
	"Phone": "(914) 636-5716",
	"EMail": "Cras.lorem.lorem@purussapien.edu",
	"Country": "French Southern Territories",
	"Fax": "(595) 704-5546",
	"Company": "Imperdiet Nec LLP"
}
```

## Model
The Model describes and rates data coming from an Entity. A Model can also be seen as a collection of properties that describe single key value pairs in an Entity.

A Model has a Score that is build out of the Avg. of all Property scores and will range from 0 to 1 where 0 means a bad data quality and 1 a perfect quality.


## Model - Property
A Property is a description for a single key value pair in an Entity. A Property always has the following information:
* Name
* Score
* Validation Functions
* Required Flag

There are two major types of Properties, optional ( Required flag is false) and required Properties. If any required Property is missing or null no score will be calculated for the complete Entity.

Properties do have a Score in the range of 0 to 1 where 0 means a bad data quality and 1 a perfect quality (according to the defined rules).

## Model - Validation Functions
A validation function can be used by any Property and will always return a boolean value. All Validation Functions have the following information:

* Function name
* Score
* Optional Parameter

Validation functions always receive the following information during execution:

* Complete Entity
* Name of current Property 
* Additional Parameter (Key Value)

If the function returns true, the related Score will be used in the calculation otherwise the result is always 0















[dataModelOverview]: https://github.com/Dev-Owl/OwlData/blob/master/OwlDataModel/Documents/Overview.png "System component overview"
