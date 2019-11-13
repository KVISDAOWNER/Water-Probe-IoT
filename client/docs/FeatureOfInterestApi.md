# openapi_client.FeatureOfInterestApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**delete_feature_of_interest**](FeatureOfInterestApi.md#delete_feature_of_interest) | **DELETE** /FeatureOfInterest | deletes a FeatureOfInterest
[**get_feature_of_interest**](FeatureOfInterestApi.md#get_feature_of_interest) | **GET** /FeatureOfInterest | gets a FeatureOfInterest
[**post_feature_of_interest**](FeatureOfInterestApi.md#post_feature_of_interest) | **POST** /FeatureOfInterest | posting a new FeatureOfInterest
[**put_feature_of_interest**](FeatureOfInterestApi.md#put_feature_of_interest) | **PUT** /FeatureOfInterest | updates a FeatureOfInterest


# **delete_feature_of_interest**
> InlineResponse201 delete_feature_of_interest(feature_of_interest_name=feature_of_interest_name)

deletes a FeatureOfInterest

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.FeatureOfInterestApi()
feature_of_interest_name = 'feature_of_interest_name_example' # str | Unique FeatureOfInterest name (optional)

try:
    # deletes a FeatureOfInterest
    api_response = api_instance.delete_feature_of_interest(feature_of_interest_name=feature_of_interest_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling FeatureOfInterestApi->delete_feature_of_interest: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **feature_of_interest_name** | **str**| Unique FeatureOfInterest name | [optional] 

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

# **get_feature_of_interest**
> FeatureOfInterest get_feature_of_interest(feature_of_interest_name=feature_of_interest_name)

gets a FeatureOfInterest

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.FeatureOfInterestApi()
feature_of_interest_name = 'feature_of_interest_name_example' # str | Unique FeatureOfInterest name (optional)

try:
    # gets a FeatureOfInterest
    api_response = api_instance.get_feature_of_interest(feature_of_interest_name=feature_of_interest_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling FeatureOfInterestApi->get_feature_of_interest: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **feature_of_interest_name** | **str**| Unique FeatureOfInterest name | [optional] 

### Return type

[**FeatureOfInterest**](FeatureOfInterest.md)

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

# **post_feature_of_interest**
> InlineResponse201 post_feature_of_interest(feature_of_interest)

posting a new FeatureOfInterest

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.FeatureOfInterestApi()
feature_of_interest = openapi_client.FeatureOfInterest() # FeatureOfInterest | 

try:
    # posting a new FeatureOfInterest
    api_response = api_instance.post_feature_of_interest(feature_of_interest)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling FeatureOfInterestApi->post_feature_of_interest: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **feature_of_interest** | [**FeatureOfInterest**](FeatureOfInterest.md)|  | 

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

# **put_feature_of_interest**
> InlineResponse201 put_feature_of_interest(feature_of_interest)

updates a FeatureOfInterest

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.FeatureOfInterestApi()
feature_of_interest = openapi_client.FeatureOfInterest() # FeatureOfInterest | 

try:
    # updates a FeatureOfInterest
    api_response = api_instance.put_feature_of_interest(feature_of_interest)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling FeatureOfInterestApi->put_feature_of_interest: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **feature_of_interest** | [**FeatureOfInterest**](FeatureOfInterest.md)|  | 

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

