# openapi_client.SensorApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**delete_sensor**](SensorApi.md#delete_sensor) | **DELETE** /sensor | deletes a sensor
[**get_sensor**](SensorApi.md#get_sensor) | **GET** /sensor | gets a sensor
[**post_sensor**](SensorApi.md#post_sensor) | **POST** /sensor | post a sensor
[**put_sensor**](SensorApi.md#put_sensor) | **PUT** /sensor | puts a sensor


# **delete_sensor**
> InlineResponse201 delete_sensor(sensor_name=sensor_name)

deletes a sensor

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.SensorApi()
sensor_name = 'sensor_name_example' # str | Unique sensorName (optional)

try:
    # deletes a sensor
    api_response = api_instance.delete_sensor(sensor_name=sensor_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling SensorApi->delete_sensor: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sensor_name** | **str**| Unique sensorName | [optional] 

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

# **get_sensor**
> Sensor get_sensor(sensor_name=sensor_name)

gets a sensor

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.SensorApi()
sensor_name = 'sensor_name_example' # str | Unique sensorName (optional)

try:
    # gets a sensor
    api_response = api_instance.get_sensor(sensor_name=sensor_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling SensorApi->get_sensor: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sensor_name** | **str**| Unique sensorName | [optional] 

### Return type

[**Sensor**](Sensor.md)

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

# **post_sensor**
> InlineResponse201 post_sensor(sensor)

post a sensor

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.SensorApi()
sensor = openapi_client.Sensor() # Sensor | 

try:
    # post a sensor
    api_response = api_instance.post_sensor(sensor)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling SensorApi->post_sensor: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sensor** | [**Sensor**](Sensor.md)|  | 

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

# **put_sensor**
> InlineResponse201 put_sensor(sensor, sensor_name=sensor_name)

puts a sensor

### Example

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint

# Create an instance of the API class
api_instance = openapi_client.SensorApi()
sensor = openapi_client.Sensor() # Sensor | 
sensor_name = 'sensor_name_example' # str | Unique sensorName (optional)

try:
    # puts a sensor
    api_response = api_instance.put_sensor(sensor, sensor_name=sensor_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling SensorApi->put_sensor: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sensor** | [**Sensor**](Sensor.md)|  | 
 **sensor_name** | **str**| Unique sensorName | [optional] 

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

