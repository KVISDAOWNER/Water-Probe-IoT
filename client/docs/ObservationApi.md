# openapi_client.ObservationApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**get_observation**](ObservationApi.md#get_observation) | **GET** /Observation | Call to get observation from database
[**get_observations**](ObservationApi.md#get_observations) | **GET** /Observations | Get all observations associated to datastream
[**post_observation**](ObservationApi.md#post_observation) | **POST** /Observation | Call to write observation to database


# **get_observation**
> Observation get_observation(observation_name=observation_name)

Call to get observation from database

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.ObservationApi()
observation_name = 'observation_name_example' # str | Unique observationName (optional)

try:
    # Call to get observation from database
    api_response = api_instance.get_observation(observation_name=observation_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling ObservationApi->get_observation: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **observation_name** | **str**| Unique observationName | [optional] 

### Return type

[**Observation**](Observation.md)

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

# **get_observations**
> list[Observation] get_observations(datastream_ref=datastream_ref)

Get all observations associated to datastream

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.ObservationApi()
datastream_ref = 'datastream_ref_example' # str | Ref to unique datastream (optional)

try:
    # Get all observations associated to datastream
    api_response = api_instance.get_observations(datastream_ref=datastream_ref)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling ObservationApi->get_observations: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **datastream_ref** | **str**| Ref to unique datastream | [optional] 

### Return type

[**list[Observation]**](Observation.md)

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

# **post_observation**
> InlineResponse201 post_observation(observation)

Call to write observation to database

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.ObservationApi()
observation = openapi_client.Observation() # Observation | Optional properties represented as json for the Thing

try:
    # Call to write observation to database
    api_response = api_instance.post_observation(observation)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling ObservationApi->post_observation: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **observation** | [**Observation**](Observation.md)| Optional properties represented as json for the Thing | 

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

