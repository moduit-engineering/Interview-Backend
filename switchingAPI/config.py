from jproperties import Properties

configs = Properties()

with open('app.properties', 'rb') as config_file:
    configs.load(config_file)


def get_base_uri():
    return configs.get("base_uri").data

def get_question1_uri():
    return configs.get("question1_uri").data

def get_question2_uri():
    return configs.get("question2_uri").data

def get_question3_uri():
    return configs.get("question3_uri").data

