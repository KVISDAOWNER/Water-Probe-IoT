# openapi_client.ThingApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**delete_thing**](ThingApi.md#delete_thing) | **DELETE** /Thing | Delete an existing probe
[**get_thing**](ThingApi.md#get_thing) | **GET** /Thing | Get an existing probe
[**get_things**](ThingApi.md#get_things) | **GET** /Things | Gets all things (probes)
[**new_thing**](ThingApi.md#new_thing) | **POST** /Thing | Creates a new probe


# **delete_thing**
> InlineResponse201 delete_thing(thingname=thingname)

Delete an existing probe

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.ThingApi()
thingname = 'thingname_example' # str | Unique thingName (optional)

try:
    # Delete an existing probe
    api_response = api_instance.delete_thing(thingname=thingname)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling ThingApi->delete_thing: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **thingname** | **str**| Unique thingName | [optional] 

### Return type

[**InlineResponse201**](InlineResponse201.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/plain

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
**200** | Successful response |  -  |
**404** | Not created response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **get_thing**
> Thing get_thing(thingname=thingname)

Get an existing probe

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.ThingApi()
thingname = 'thingname_example' # str | Unique thingName (optional)

try:
    # Get an existing probe
    api_response = api_instance.get_thing(thingname=thingname)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling ThingApi->get_thing: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **thingname** | **str**| Unique thingName | [optional] 

### Return type

[**Thing**](Thing.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/plain

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
**200** | OK |  -  |
**404** | Not created response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **get_things**
> list[Thing] get_things()

Gets all things (probes)

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.ThingApi()

try:
    # Gets all things (probes)
    api_response = api_instance.get_things()
    pprint(api_response)
except ApiException as e:
    print("Exception when calling ThingApi->get_things: %s\n" % e)
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**list[Thing]**](Thing.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/plain

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
**200** | OK |  -  |
**404** | Not created response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **new_thing**
> InlineResponse201 new_thing(thing)

Creates a new probe

Creates new thing

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.ThingApi()
thing = openapi_client.Thing() # Thing | Optional properties represented as json for the Thing

try:
    # Creates a new probe
    api_response = api_instance.new_thing(thing)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling ThingApi->new_thing: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **thing** | [**Thing**](Thing.md)| Optional properties represented as json for the Thing | 

### Return type

[**InlineResponse201**](InlineResponse201.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, text/plain

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
**201** | Successful response |  -  |
**404** | Not created response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

