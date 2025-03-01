# coding: utf-8

"""
    WaterProbe API

    API for waterprobing  # noqa: E501

    The version of the OpenAPI document: 1
    Generated by: https://openapi-generator.tech
"""


from __future__ import absolute_import

import unittest

import openapi_client
from openapi_client.api.observation_api import ObservationApi  # noqa: E501
from openapi_client.rest import ApiException


class TestObservationApi(unittest.TestCase):
    """ObservationApi unit test stubs"""

    def setUp(self):
        self.api = openapi_client.api.observation_api.ObservationApi()  # noqa: E501

    def tearDown(self):
        pass

    def test_get_observation(self):
        """Test case for get_observation

        Call to get observation from database  # noqa: E501
        """
        pass

    def test_get_observations(self):
        """Test case for get_observations

        Get all observations associated to datastream  # noqa: E501
        """
        pass

    def test_post_observation(self):
        """Test case for post_observation

        Call to write observation to database  # noqa: E501
        """
        pass


if __name__ == '__main__':
    unittest.main()
