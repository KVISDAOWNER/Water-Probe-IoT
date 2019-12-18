# openapi_client.ObservedPropertyApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**delete_observed_property**](ObservedPropertyApi.md#delete_observed_property) | **DELETE** /ObservedProperty | Deletes an ObservedProperty
[**get_observed_property**](ObservedPropertyApi.md#get_observed_property) | **GET** /ObservedProperty | gets an ObservedProperty
[**post_observed_property**](ObservedPropertyApi.md#post_observed_property) | **POST** /ObservedProperty | Creates a new ObservedProperty
[**put_observed_property**](ObservedPropertyApi.md#put_observed_property) | **PUT** /ObservedProperty | updates an ObservedProperty


# **delete_observed_property**
> InlineResponse201 delete_observed_property(observed_property_name=observed_property_name)

Deletes an ObservedProperty

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.ObservedPropertyApi()
observed_property_name = 'observed_property_name_example' # str | Unique ObservedProperty name (optional)

try:
    # Deletes an ObservedProperty
    api_response = api_instance.delete_observed_property(observed_property_name=observed_property_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling ObservedPropertyApi->delete_observed_property: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **observed_property_name** | **str**| Unique ObservedProperty name | [optional] 

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

# **get_observed_property**
> ObservedProperty get_observed_property(observed_property_name=observed_property_name)

gets an ObservedProperty

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.ObservedPropertyApi()
observed_property_name = 'observed_property_name_example' # str | Unique ObservedProperty name (optional)

try:
    # gets an ObservedProperty
    api_response = api_instance.get_observed_property(observed_property_name=observed_property_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling ObservedPropertyApi->get_observed_property: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **observed_property_name** | **str**| Unique ObservedProperty name | [optional] 

### Return type

[**ObservedProperty**](ObservedProperty.md)

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

# **post_observed_property**
> InlineResponse201 post_observed_property(observed_property)

Creates a new ObservedProperty

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.ObservedPropertyApi()
observed_property = openapi_client.ObservedProperty() # ObservedProperty | 

try:
    # Creates a new ObservedProperty
    api_response = api_instance.post_observed_property(observed_property)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling ObservedPropertyApi->post_observed_property: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **observed_property** | [**ObservedProperty**](ObservedProperty.md)|  | 

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

# **put_observed_property**
> InlineResponse201 put_observed_property(observed_property)

updates an ObservedProperty

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.ObservedPropertyApi()
observed_property = openapi_client.ObservedProperty() # ObservedProperty | 

try:
    # updates an ObservedProperty
    api_response = api_instance.put_observed_property(observed_property)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling ObservedPropertyApi->put_observed_property: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **observed_property** | [**ObservedProperty**](ObservedProperty.md)|  | 

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

