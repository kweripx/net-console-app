
# .NET console application

console application to retrieve information regarding nobel prize laureates

### TODO

- [x] 15 seconds Interval
- [x] Store in a object
- [x] Retrieve from the nobel prize api information for each category and year
- [x] Log the response from the API to a log file in the same folder as the executable
- [x] Receive a mandatory parameter with a full path to a file
- [ ] If we run the application multiple times, it should not make requests to the API if the application was ran for the last time less than 60 seconds before.
- [ ] URL being used and the output of the request.


# Running 
dotnet run program.cs

# Difficulties 
I wasn't able to implement the verification to not make a request if the application was ran for the last time less than 60 seconds before, because the process to make a request using a file took more time than i thought, this and show url request wasn't implemented.  
