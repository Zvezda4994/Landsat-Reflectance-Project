from flask import Flask, request, jsonify, render_template
import requests
import datetime

app = Flask(__name__)

# USGS M2M API credentials
USERNAME = 'silvio2232'  # Replace with your USGS username
TOKEN = 'eyJjaWQiOjI3Mjk2OTU1LCJzIjoiMTcyODIxOTY2MSIsInIiOjQ4MSwicCI6WyJ1c2VyIl19'  # Replace with your application token
APIENDPOINT = 'https://m2m.cr.usgs.gov/api/api/json/stable/'
LEVEL2 = "landsat_ot_c2_l2"

def landsatSceneLEVEL2(api_key, lat, lng, cloudmin, cloudmax, datebegin, dateend):
    headers = {"X-Auth-Token": api_key, "Content-Type": "application/json"}
    payload = {
        "datasetName": LEVEL2,
        "sceneFilter" : {
            "spatialFilter": {
                "filterType": "mbr",
                "lowerLeft": {"latitude": lat - 0.5, "longitude": lng - 0.5},
                "upperRight": {"latitude": lat + 0.5, "longitude": lng + 0.5}
            },
            'acquisitionFilter': {'start': datebegin, 'end': dateend},
            'cloudCoverFilter': {'min':  cloudmin, 'max': cloudmax}
        },
        "maxResults": 15,
        "sortField": "acquisitionDate",
        "sortOrder": "DESC"
    }
    response = requests.post(f"{APIENDPOINT}scene-search", json=payload, headers=headers)
    return response.json()

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/get_landsat_data', methods=['POST'])
def get_landsat_data():
    data = request.get_json()
    lat = float(data['latitude'])
    lng = float(data['longitude'])
    cloudmin = int(data['cloudmin'])
    cloudmax = int(data['cloudmax'])
    datebegin = data['datebegin']
    dateend = data['dateend']
    api_key = TOKEN  # Use TOKEN as the api_key directly

    result = landsatSceneLEVEL2(api_key, lat, lng, cloudmin, cloudmax, datebegin, dateend)

    if 'data' in result and 'results' in result['data'] and result['data']['results']:
        scene = result['data']['results'][0]
        browse_path = scene['browse'][0]['browsePath']
        dateString = scene['temporalCoverage']['startDate']
        date1 = datetime.datetime.strptime(dateString, '%Y-%m-%d %H:%M:%S').date()
        currentDate = datetime.datetime.now().date()
        days_since_acquisition = (currentDate - date1).days % 8
        days_until_next_overpass = (8 - days_since_acquisition) % 8
        if days_until_next_overpass == 0:
            next_overpass_date = currentDate
        else:
            next_overpass_date = currentDate + datetime.timedelta(days=days_until_next_overpass)
        next_overpass_date_str = next_overpass_date.strftime('%m/%d/%Y')

        # Extract additional information
        pathRow = scene['entityId']
        satellite = "Landsat-" + str(pathRow[2])
        path = pathRow[3:6]
        row = pathRow[6:9]
        cloud_cover = scene.get('cloudCover', 'N/A')
        print(dateString)

        response_data = {
            'browse_path': browse_path,
            'next_overpass_date': next_overpass_date_str,
            'satellite': satellite,
            'scene_date_taken' : dateString.split()[0],
            'path': path,
            'row': row,
            'cloud_cover': cloud_cover
        }
        return jsonify(response_data)
    else:
        return jsonify({'error': 'No results found or error in response.'})

if __name__ == "__main__":
    app.run(debug=True)
