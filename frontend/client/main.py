import openapi_client
# Create an instance of the API class

api_instance = openapi_client.ThingApi()
api_instance.api_client.configuration.host = '130.225.57.56:51099'

result = api_instance.get_things()
#result1 = api_instance.api_client.call_api('/Things', 'GET', response_type='list[Thing]')

print(result)
#print(result1)
