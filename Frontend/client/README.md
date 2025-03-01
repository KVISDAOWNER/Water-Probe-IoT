# openapi-client
API for waterprobing

This Python package is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 1
- Package version: 1.0.0
- Build package: org.openapitools.codegen.languages.PythonClientCodegen

## Requirements.

Python 2.7 and 3.4+

## Installation & Usage
### pip install

If the python package is hosted on a repository, you can install directly using:

```sh
pip install git+https://github.com/GIT_USER_ID/GIT_REPO_ID.git
```
(you may need to run `pip` with root permission: `sudo pip install git+https://github.com/GIT_USER_ID/GIT_REPO_ID.git`)

Then import the package:
```python
import openapi_client 
```

### Setuptools

Install via [Setuptools](http://pypi.python.org/pypi/setuptools).

```sh
python setup.py install --user
```
(or `sudo python setup.py install` to install the package for all users)

Then import the package:
```python
import openapi_client
```

## Getting Started

Please follow the [installation procedure](#installation--usage) and then run the following:

```python
from __future__ import print_function
import time
import openapi_client
from openapi_client.rest import ApiException
from pprint import pprint


# Defining host is optional and default to http://localhost
configuration.host = "http://localhost"
# Create an instance of the API class
api_instance = openapi_client.DatastreamApi(openapi_client.ApiClient(configuration))
data_stream_name = 'data_stream_name_example' # str | Unique dataStreamName (optional)

try:
    # deletes a datastream
    api_response = api_instance.delete_datastream(data_stream_name=data_stream_name)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling DatastreamApi->delete_datastream: %s\n" % e)

```

## Documentation for API Endpoints

All URIs are relative to *http://localhost*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*DatastreamApi* | [**delete_datastream**](docs/DatastreamApi.md#delete_datastream) | **DELETE** /dataStream | deletes a datastream
*DatastreamApi* | [**get_datastream**](docs/DatastreamApi.md#get_datastream) | **GET** /dataStream | Gets a datastream
*DatastreamApi* | [**get_datastreams**](docs/DatastreamApi.md#get_datastreams) | **GET** /dataStreams | Get all datastreams from thing
*DatastreamApi* | [**post_datastream**](docs/DatastreamApi.md#post_datastream) | **POST** /dataStream | posts a datastream
*DatastreamApi* | [**put_datastream**](docs/DatastreamApi.md#put_datastream) | **PUT** /dataStream | put to a datastream
*FeatureOfInterestApi* | [**delete_feature_of_interest**](docs/FeatureOfInterestApi.md#delete_feature_of_interest) | **DELETE** /FeatureOfInterest | deletes a FeatureOfInterest
*FeatureOfInterestApi* | [**get_feature_of_interest**](docs/FeatureOfInterestApi.md#get_feature_of_interest) | **GET** /FeatureOfInterest | gets a FeatureOfInterest
*FeatureOfInterestApi* | [**post_feature_of_interest**](docs/FeatureOfInterestApi.md#post_feature_of_interest) | **POST** /FeatureOfInterest | posting a new FeatureOfInterest
*FeatureOfInterestApi* | [**put_feature_of_interest**](docs/FeatureOfInterestApi.md#put_feature_of_interest) | **PUT** /FeatureOfInterest | updates a FeatureOfInterest
*LocationApi* | [**delete_location**](docs/LocationApi.md#delete_location) | **DELETE** /Location | deletes a sensor
*LocationApi* | [**get_location**](docs/LocationApi.md#get_location) | **GET** /Location | gets a location
*LocationApi* | [**postlocation**](docs/LocationApi.md#postlocation) | **POST** /Location | posting a new location
*LocationApi* | [**put_location**](docs/LocationApi.md#put_location) | **PUT** /Location | updates a location
*ObservationApi* | [**get_observation**](docs/ObservationApi.md#get_observation) | **GET** /Observation | Call to get observation from database
*ObservationApi* | [**get_observations**](docs/ObservationApi.md#get_observations) | **GET** /Observations | Get all observations associated to datastream
*ObservationApi* | [**post_observation**](docs/ObservationApi.md#post_observation) | **POST** /Observation | Call to write observation to database
*ObservedPropertyApi* | [**delete_observed_property**](docs/ObservedPropertyApi.md#delete_observed_property) | **DELETE** /ObservedProperty | Deletes an ObservedProperty
*ObservedPropertyApi* | [**get_observed_property**](docs/ObservedPropertyApi.md#get_observed_property) | **GET** /ObservedProperty | gets an ObservedProperty
*ObservedPropertyApi* | [**post_observed_property**](docs/ObservedPropertyApi.md#post_observed_property) | **POST** /ObservedProperty | Creates a new ObservedProperty
*ObservedPropertyApi* | [**put_observed_property**](docs/ObservedPropertyApi.md#put_observed_property) | **PUT** /ObservedProperty | updates an ObservedProperty
*SensorApi* | [**delete_sensor**](docs/SensorApi.md#delete_sensor) | **DELETE** /sensor | deletes a sensor
*SensorApi* | [**get_sensor**](docs/SensorApi.md#get_sensor) | **GET** /sensor | gets a sensor
*SensorApi* | [**post_sensor**](docs/SensorApi.md#post_sensor) | **POST** /sensor | post a sensor
*SensorApi* | [**put_sensor**](docs/SensorApi.md#put_sensor) | **PUT** /sensor | puts a sensor
*ThingApi* | [**delete_thing**](docs/ThingApi.md#delete_thing) | **DELETE** /Thing | Delete an existing probe
*ThingApi* | [**get_thing**](docs/ThingApi.md#get_thing) | **GET** /Thing | Get an existing probe
*ThingApi* | [**get_things**](docs/ThingApi.md#get_things) | **GET** /Things | Gets all things (probes)
*ThingApi* | [**new_thing**](docs/ThingApi.md#new_thing) | **POST** /Thing | Creates a new probe


## Documentation For Models

 - [DataStream](docs/DataStream.md)
 - [FeatureOfInterest](docs/FeatureOfInterest.md)
 - [InlineResponse201](docs/InlineResponse201.md)
 - [Location](docs/Location.md)
 - [Observation](docs/Observation.md)
 - [ObservedProperty](docs/ObservedProperty.md)
 - [Sensor](docs/Sensor.md)
 - [Thing](docs/Thing.md)
 - [TmInstant](docs/TmInstant.md)
 - [TmObject](docs/TmObject.md)


## Documentation For Authorization

 All endpoints do not require authorization.

## Author




