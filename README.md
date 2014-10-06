Durango serves as an unofficial read-only API client for Xbox LIVE®. 

The solution is comprised of both a web service and a standalone class library that can be used independently of the web service to interface with Xbox Live.

### Status

Unfortunately this library has been rendered dysfunctional by the latest changes to the Xbox website from where the data is parsed.

Endpoint                       | Result
------------------------------ | -------------
*/search/{query}*              | Correct response
*/profile/{gamertag}*          | Exception
*/profile/{gamertag}/friends*  | Bugged
*/profile/{gamertag}/games*    | Exception
*/profile/{gamertag}/games*    | Bugged


