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

