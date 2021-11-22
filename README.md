# What is this project about
This project was final homework for a software bootcamp.  
Basically, the project performs some basic processes for an e-commerce application, which does crud operations on users, products, lists and list items.  
The project consist of 3 docker containers (1 of them is this application, and the other two are mongodb and postresql).  
The api takes rest requests, process crud operations to db(postgresql), report the most added items to lists (can be done for specific user too if wanted), and update mongodb from postresql.  
The mongodb's purpose is storing logs from postgresql (list item logs) and the api will fetch these logs from the mongodb to report the most added items to lists.  
A hangfire job (for every 1 hour), will sync the mongodb from postgresql.

# Notes  
- The project's architecture is clean architecture(onion architecture)
- Solid principles are applied
- The api doesn't allow adding <strong>same items to same list</strong>, if requested, it will simply return Badrequest response  
- The delete requests are <strong>chained</strong>, for example if someone wants to delete specified user, the user and  
all the related entities to the user will be deleted (etc. lists and list items which belongs to deleted user)  
- The tables have foreign keys, when sending request make sure (if any) foreign keys points  
to real entities, if not, api will not allow this request and returns Badrequest response
