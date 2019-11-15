# Data access layer
import openapi_client

def get_thing(id):
    mockLoc = (1,2) # X Y
    mockPh = [5.3, 6.5, 7.2, 5.7, 6.1, 8.1, 6.8, 6.9]
    mockTemp = [20.3, 19.7, 21.1, 20.1, 19.8, 20.0, 20.6, 22.5]
    mockTime = [0, 1, 2, 3, 4, 5, 6, 7, 8]
    mockBat = [10, 20, 30, 15, 12, 10, 7, 18]
    data_dict = {"ph" : mockPh,
                 "temp" : mockTemp,
                 "time" : mockTime,
                 "loc" : mockLoc,
                 "bat": mockBat}
    return data_dict

def get_id_of_things():
    # Create an instance of the API class

    api_instance = openapi_client.ThingApi()
    api_instance.api_client.configuration.host = '130.225.57.56:51099'

    #result = api_instance.get_things()
    result1 = api_instance.api_client.call_api('/Things', 'GET', response_type='list[Thing]')
    return result1


if __name__ == "__main__":
    result = get_id_of_things()
    i = 0

