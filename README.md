
In absense of Jira, story + sub tasks are captured below.

## Project prerequsities

- .NET Core 2.2
- xUnit
- Moq
- [Modulus weight table](https://protect-eu.mimecast.com/s/YPTGCgLqoIm973QToGfo_?domain=vocalink.com)

## Solution notes for developer

The solutions has been arranged so that an Web API (modulus.web) is accessible via HTTP call.  This acts as a very thin http client.  This calls out to an api (modulus.api) and this is where the main business logic resides.  There are some types (models) that are shared between the projects and these are found in the modulus.shared project.

There are two test projects.  These are modulus.tests and modulus.web.tests.  These projects concentrate their unit tests on modulus.api and modulus.web respectively.

To help with the understanding of the business domain, I have included a DSL section below.

## Domain specific language

- `Modulus Checking` - is used to check the validity of account numbers for a sorting code
- `Standard` - A process by which the modulus check is performed (notation weights are added together then) then based on what Standard (10 or 11), the remainder will judge whether valid or not. 0 is valid
- `Double Alternative` - A process by which the modulus check is performed (notation weight individual digits are added together) then modulus 10 is used to determine the remainder. If 0, then valid, otherwise invalid
- `Standard 10` - The modulus to use [10] to obtain the remainder
- `Standard 11` - The modulus to use [11] to obtain the remainder
- `Exception 4` - If the weight table last column contains a number 4, then the specific logic must be followed
- `Exception 7` - If the weight table last column contains a number 7, then the specific logic must be followed
- `Notation` - Term to describe the separation of the sort and account codes


## Story (mod-1):

- To implement Modulus checking in order to validate account numbers for a sorting code.

- Must create a HTTP API (content-type: application/json) to accept sort and account code and return the appropriate response based on whether or not combination is valid or not.

- There are 2 types of modulus checking that can be performed - standard and double alternative.  The appropriate check (see the (Alg column) is stipulated in the `weight table`, based on sort code lookup (range).  If two entries are matched, then another check must be performed.  If one entry is matched, then one check is performed.  If no entries, then no checks must be performed (assumed valid).

- Must assume all combinations are valid unless determined otherwise

## Tasks:

### mod-2

- Intepret spec (and identify incomplete or missing information) - done
 - No exception table (I don't know how important/critical this is, have decided to continue without this info as it's the weekend and no means to get this information)
- Create repo - done
- Create branch (dev/mod-1) - done

### mod-3

- Create solution structure: - done
  - Web (align status codes to success & failed requests)
  - Api
  - Shared
  - Tests (xUnit)
- Source data for tests - done
  - Test data in spec document
- Obtain and load Modulus Weight Table into object - done

### mod-4

- Create tests for standard check 
- Implement logic for standard check (ignore exceptions that are not 4 or 7)

### mod-5

- Create tests for double alternative check
- Implement logic for double alternative check (ignore exceptions that are not 4 or 7)

### mod-6

- Create HTTP API - done
- Create routes - done
- Create success responses - done
- Create failure responses - done
- Create tests - done

- statusCode: 200 (valid)

POST https://localhost:5001/api/validate
```
{
    "sortCode" : "089999",
    "accountNumber": "66374958"
}
```

- statusCode: 404 (invalid)

POST https://localhost:5001/api/validate
```
{
    "sortCode" : "089999",
    "accountNumber": "66374959"
}
```

- statusCode: 400 (other)

### mod-7 

- Finalise documentation

### TODOs

- WeightTable is a hack, needs improving - done
- Failing tests
- Create custom Exceptions - done

### Notes

- Not clear where the Exceptions checks are to be run; e.g. before, after or in place of the existing check. 
- Test Case Data is confusing, in order for mutliple check algorithms be used (e.g. Standard Mod 11 then dobule Alternative) the sort and account codes must return those from Modulus Weight table. This is not the case (see No 2, returns mod 10 and not mod 11 algoritm)
- Haven't added logging (or any other observability)
- I don't know the intended client (public or internal) so redacting error message bubbling up from HTTP API
- Will need to make POST validate async (the assumption here is that the demand will be high for this endpoint)
- Not all the tests worked.  My assumption is that I have misinterpretted the specification.
- The ModulusProcessor.IsValid() method is a bit smelly and will work on this in the short term to improve for own satisfaction.




