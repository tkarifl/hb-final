# Summary  
The Api basically takes REST requests, and process the requests to db.  
The api/report, reports the most 10 added items, the request can be done for specified user,  
which will report most 10 added items by the user.  
There are 2 databases, mongo and postgresql  
There are 4 tables(on postgresql); Users, Items, ListItems and Lists
Api process the requests to postresql, and for every 1 hour, a background job(hangfire) fetches the current List items  
From postgresql, and updates the mongo database (adds new items from postresql, delete  
items from mongo which is not in postresql, and updates the remaining items in mongo)  

# Notes  
- The api doesn't allow adding <strong>same items to same list</strong>, if requested, it will simply return Badrequest response  
- The delete requests are <strong>chained</strong>, this means if someone sends delete request to specified user, the user and  
all the related entities to the user will be deleted (etc. lists and list items which points to deleted user)  
- Swagger dashboard is enabled in production environment (if the api is running in container, swagger  
page still can be accessed from the container)
- Hangfire dashboard is enabled in production environment (if the api is running in container, hangfire  
page still can be accessed from the container)
- The reports (user favourite items and general favourite items) will fetch the items from mongodb
- The tables have foreign keys, when sending request make sure (if any) foreign keys points  
to real entities, if not, api will not allow this request and returns Badrequest response