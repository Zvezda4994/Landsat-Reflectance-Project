import requests

USERNAME = 'goosewalk'
TOKEN = 'eyJjaWQiOjI3Mjk2OTgzLCJzIjoiMTcyODE1MjE4NCIsInIiOjczNiwicCI6WyJ1c2VyIl19'
APIENDPOINT = 'https://m2m.cr.usgs.gov/api/api/json/stable/'
LEVEL1 = "landsat_ot_c2_l1"
LEVEL2 = "landsat_ot_c2_l2"

def landsatSceneLEVEL2(api_key, lat, lng):
    headers = {"X-Auth-Token": api_key, "Content-Type": "application/json"}
    payload = {
        "datasetName": LEVEL2,
        "sceneFilter" : {
            "spatialFilter": {
            "filterType": "mbr",
            "lowerLeft": {"latitude": lat - 0.5, "longitude": lng - 0.5},
            "upperRight": {"latitude": lat + 0.5, "longitude": lng + 0.5}
        },
        },
        "maxResults": 2,
        "sortField": "acquisitionDate",
        "sortDirection": "DESC"
    }
    response = requests.post(f"{APIENDPOINT}scene-search", json=payload, headers=headers)
    return response.json()

def main():
    lat, lng = 44.60813, -64.18034  # Example coordinates (Halifax)
    result = landsatSceneLEVEL2(TOKEN, lat, lng)
    print(result)

if __name__ == "__main__":
    main()
