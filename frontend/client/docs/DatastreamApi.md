# openapi_client.DatastreamApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**delete_datastream**](DatastreamApi.md#delete_datastream) | **DELETE** /dataStream | deletes a datastream
[**get_datastream**](DatastreamApi.md#get_datastream) | **GET** /dataStream | Gets a datastream
[**get_datastreams**](DatastreamApi.md#get_datastreams) | **GET** /dataStreams | Get all datastreams from thing
[**post_datastream**](DatastreamApi.md#post_datastream) | **POST** /dataStream | posts a datastream
[**put_datastream**](DatastreamApi.md#put_datastream) | **PUT** /dataStream | put to a datastream


# **delete_datastream**
> InlineResponse201 delete_datastream(data_stream_name=data_stream_name)

deletes a datastream

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.DatastreamApi()
data_stream_name = 'data_stream_name_example' # str | Unique dataStreamName (optional)

try:
    # deletes a datastream
    api_response = api_instance.delete_datastream(data_stream_name=data_stream_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling DatastreamApi->delete_datastream: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data_stream_name** | **str**| Unique dataStreamName | [optional] 

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

# **get_datastream**
> DataStream get_datastream(data_stream_name=data_stream_name)

Gets a datastream

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.DatastreamApi()
data_stream_name = 'data_stream_name_example' # str | Unique dataStreamName (optional)

try:
    # Gets a datastream
    api_response = api_instance.get_datastream(data_stream_name=data_stream_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling DatastreamApi->get_datastream: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data_stream_name** | **str**| Unique dataStreamName | [optional] 

### Return type

[**DataStream**](DataStream.md)

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

# **get_datastreams**
> list[DataStream] get_datastreams(thing_ref=thing_ref)

Get all datastreams from thing

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.DatastreamApi()
thing_ref = 'thing_ref_example' # str | Ref to unique thing (optional)

try:
    # Get all datastreams from thing
    api_response = api_instance.get_datastreams(thing_ref=thing_ref)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling DatastreamApi->get_datastreams: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **thing_ref** | **str**| Ref to unique thing | [optional] 

### Return type

[**list[DataStream]**](DataStream.md)

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

# **post_datastream**
> InlineResponse201 post_datastream(data_stream)

posts a datastream

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.DatastreamApi()
data_stream = openapi_client.DataStream() # DataStream | Optional properties represented as json for the dataStream

try:
    # posts a datastream
    api_response = api_instance.post_datastream(data_stream)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling DatastreamApi->post_datastream: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data_stream** | [**DataStream**](DataStream.md)| Optional properties represented as json for the dataStream | 

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

# **put_datastream**
> InlineResponse201 put_datastream(data_stream, data_stream_name=data_stream_name)

put to a datastream

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.DatastreamApi()
data_stream = openapi_client.DataStream() # DataStream | Optional properties represented as json for the dataStream
data_stream_name = 'data_stream_name_example' # str | Unique dataStreamName (optional)

try:
    # put to a datastream
    api_response = api_instance.put_datastream(data_stream, data_stream_name=data_stream_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling DatastreamApi->put_datastream: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data_stream** | [**DataStream**](DataStream.md)| Optional properties represented as json for the dataStream | 
 **data_stream_name** | **str**| Unique dataStreamName | [optional] 

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

