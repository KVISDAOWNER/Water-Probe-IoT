import openapi_client
import json


thingapi = openapi_client.ThingApi()
datastreamapi = openapi_client.DatastreamApi()
observationapi = openapi_client.ObservationApi()

ip_of_server_api = '130.225.57.56:51099'


def patch_location_of_thing(probe_id, lat, lon, desc):
    location = {"lat": float(lat), "long": float(lon)}
    body = {"description": desc, "encodingType": "string", "_Location": location}
    res = thingapi.api_client.request('PATCH', ip_of_server_api+'/Thing',
                                      query_params=[('thingRef', probe_id)],
                                      body=body)

    return res.status == 200


def get_names_of_things():
    thingapi.api_client.configuration.host = ip_of_server_api
    result = thingapi.api_client.call_api('/Things', 'GET', response_type='list[Thing]')
    probes = result[0]
    names = []
    for probe in probes:
        names.append(probe.name)

    return names


def get_latitudes(probes):
    lat = []
    for probe in probes:
        if probe.location is None:
            lat.append("0.0000")
        else:
            lat.append(probe.location.location["lat"])
    return lat


def get_things_objects():
    api_instance = openapi_client.ThingApi()
    api_instance.api_client.configuration.host = ip_of_server_api
    result = api_instance.api_client.call_api('/Things', 'GET', response_type='list[Thing]')
    probes = result[0]
    return probes


def get_longitudes(probes):
    long = []
    for probe in probes:
        if probe.location is None:
            long.append("0.0000")
        else:
            long.append(probe.location.location["long"])
    return long


def get_descriptions(probes):
    desc = []
    for probe in probes:
        if probe.description is None:
            desc.append("No Description")
        else:
            desc.append(probe.description)
    return desc


def get_observations_of_datastreams(datastreams):
    # datastreams is a list of names
    observations = []
    for datastream in datastreams:
        obs = observationapi.api_client.request('GET', ip_of_server_api+'/Observations',
                                                query_params=[('dataStreamRef', datastream)])
        observations.append(json.loads(obs.data))
    return observations


def get_datastreams_of_things(thingnames):
    datastreams = []
    for thingname in thingnames:
        datastreams.append(json.loads(datastreamapi.api_client.request('GET', ip_of_server_api+'/dataStreams',
                                                                       query_params=[('thingRef', thingname)]).data))

    return datastreams
