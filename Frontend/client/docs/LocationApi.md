# openapi_client.LocationApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**delete_location**](LocationApi.md#delete_location) | **DELETE** /Location | deletes a sensor
[**get_location**](LocationApi.md#get_location) | **GET** /Location | gets a location
[**postlocation**](LocationApi.md#postlocation) | **POST** /Location | posting a new location
[**put_location**](LocationApi.md#put_location) | **PUT** /Location | updates a location


# **delete_location**
> InlineResponse201 delete_location(location_name=location_name)

deletes a sensor

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.LocationApi()
location_name = 'location_name_example' # str | Unique locationName (optional)

try:
    # deletes a sensor
    api_response = api_instance.delete_location(location_name=location_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling LocationApi->delete_location: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **location_name** | **str**| Unique locationName | [optional] 

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

# **get_location**
> Location get_location(location_name=location_name)

gets a location

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.LocationApi()
location_name = 'location_name_example' # str | Unique locationName (optional)

try:
    # gets a location
    api_response = api_instance.get_location(location_name=location_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling LocationApi->get_location: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **location_name** | **str**| Unique locationName | [optional] 

### Return type

[**Location**](Location.md)

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

# **postlocation**
> InlineResponse201 postlocation(location)

posting a new location

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.LocationApi()
location = openapi_client.Location() # Location | 

try:
    # posting a new location
    api_response = api_instance.postlocation(location)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling LocationApi->postlocation: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **location** | [**Location**](Location.md)|  | 

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

# **put_location**
> InlineResponse201 put_location(location)

updates a location

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.LocationApi()
location = openapi_client.Location() # Location | 

try:
    # updates a location
    api_response = api_instance.put_location(location)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling LocationApi->put_location: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **location** | [**Location**](Location.md)|  | 

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
**200** | Successful response |  -  |
**404** | Not created response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

