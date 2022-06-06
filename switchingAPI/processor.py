import requests
import http.client
import json

from config import *

def get_answer_v1():

    base_uri = get_base_uri()
    question1_uri = get_question1_uri()

    conn = http.client.HTTPSConnection(base_uri)
    payload = ''
    headers = {}
    conn.request("GET", question1_uri, payload, headers)
    res = conn.getresponse()
    data = res.read().decode("utf-8")
    return data


def get_answer_v2():

    base_uri = get_base_uri()
    question1_uri = get_question2_uri()
    search_key1 = "Ergonomic"
    search_key2 = "Sport"
    max_data = 3

    conn = http.client.HTTPSConnection(base_uri)
    payload = ''
    headers = {}
    conn.request("GET", question1_uri, payload, headers)
    res = conn.getresponse()
    resp_data = res.read().decode("utf-8")
    json_data = json.loads(resp_data)

    res_data = {}
    for data in json_data:
        id = int(data.get('id'))
        desc_data = data.get('description')
        title_data = data.get('title')
        tags = data.get('tags')


        if (search_key1 in desc_data or search_key1 in title_data) or (tags and any(search_key2 in tag for tag in tags)):
            res_data.update({id : data})

    sorted_desc_ids = sorted(res_data, reverse=True)

    final_data = []
    total_data = 0
    for desc_id in sorted_desc_ids:
        if total_data >= max_data:
            break

        final_data.append(res_data.get(desc_id))
        total_data += 1

    return final_data


def get_answer_v3():

    base_uri = get_base_uri()
    question3_uri = get_question3_uri()
    flatten_key = "items"

    conn = http.client.HTTPSConnection(base_uri)
    payload = ''
    headers = {}
    conn.request("GET", question3_uri, payload, headers)
    res = conn.getresponse()
    resp_data = res.read().decode("utf-8")
    json_data = json.loads(resp_data)

    data_final = []
    for data in json_data:
        if not data.get(flatten_key):
            data_final.append(data)
        else:
            data_update = {}
            for data_item in data:
                if data_item != flatten_key:
                    data_update.update({data_item : data.get(data_item)})

            if data.get(flatten_key):
                for flatten_item in data.get(flatten_key):
                    flatten_item.update(data_update)
                    data_final.append(flatten_item)
    return data_final
