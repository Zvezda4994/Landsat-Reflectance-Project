using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandsatReflectance.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}


//import requests

//USERNAME = 'goosewalk'
//TOKEN = 'eyJjaWQiOjI3Mjk2OTgzLCJzIjoiMTcyODE1MjE4NCIsInIiOjczNiwicCI6WyJ1c2VyIl19'
//APIENDPOINT = 'https://m2m.cr.usgs.gov/api/api/json/stable/'
//LEVEL1 = "landsat_ot_c2_l1"
//LEVEL2 = "landsat_ot_c2_l2"

//def landsatSceneLEVEL2(api_key, lat, lng):
//    headers = {"X-Auth-Token": api_key, "Content-Type": "application/json"}
//    payload = {
//        "datasetName": LEVEL2,
//        "sceneFilter" : {
//            "spatialFilter": {
//            "filterType": "mbr",
//            "lowerLeft": {"latitude": lat - 0.5, "longitude": lng - 0.5},
//            "upperRight": {"latitude": lat + 0.5, "longitude": lng + 0.5}
//        },
//        },
//        "maxResults": 10,
//        "sortField": "acquisitionDate",
//        "sortDirection": "DESC"
//    }
//    response = requests.post(f"{APIENDPOINT}scene-search", json=payload, headers=headers)
//    return response.json()

//def main():
//    lat, lng = 44.60813, -64.18034  # Example coordinates (Halifax)
//    acceptable_cloud_cover = 20  # Set your acceptable cloud cover threshold (in percentage)

//    result = landsatSceneLEVEL2(TOKEN, lat, lng)

//    if 'data' in result and 'results' in result['data']:
//        scenes = result['data']['results']
//        suitable_scene = None

//        for scene in scenes:
//            cloud_cover = scene.get('cloudCover', 100)  # Default to 100 if cloudCover not present
//            if cloud_cover <= acceptable_cloud_cover:
//                suitable_scene = scene
//                break  # Stop after finding the first suitable scene

//        if suitable_scene:
//            # Access the 'browse path' URL
//            browse_info = suitable_scene.get('browse', [{}])[0]
//            browse_path = browse_info.get('browsePath', 'N/A')
//            print(f"Found a scene with cloud cover {cloud_cover}%:")
//            print(f"Browse Image URL: {browse_path}")
//        else:
//            print(f"No scenes found with cloud cover less than or equal to {acceptable_cloud_cover}%.")

//    else:
//        print("No results found or error in response.")

//if __name__ == "__main__":
//    main()
//import requests

//USERNAME = 'goosewalk'
//TOKEN = 'eyJjaWQiOjI3Mjk2OTgzLCJzIjoiMTcyODE1MjE4NCIsInIiOjczNiwicCI6WyJ1c2VyIl19'
//APIENDPOINT = 'https://m2m.cr.usgs.gov/api/api/json/stable/'
//LEVEL1 = "landsat_ot_c2_l1"
//LEVEL2 = "landsat_ot_c2_l2"

//def landsatSceneLEVEL2(api_key, lat, lng):
//    headers = {"X-Auth-Token": api_key, "Content-Type": "application/json"}
//    payload = {
//        "datasetName": LEVEL2,
//        "sceneFilter" : {
//            "spatialFilter": {
//            "filterType": "mbr",
//            "lowerLeft": {"latitude": lat - 0.5, "longitude": lng - 0.5},
//            "upperRight": {"latitude": lat + 0.5, "longitude": lng + 0.5}
//        },
//        },
//        "maxResults": 10,
//        "sortField": "acquisitionDate",
//        "sortDirection": "DESC"
//    }
//    response = requests.post(f"{APIENDPOINT}scene-search", json=payload, headers=headers)
//    return response.json()

//def main():
//    lat, lng = 44.60813, -64.18034  # Example coordinates (Halifax)
//    acceptable_cloud_cover = 20  # Set your acceptable cloud cover threshold (in percentage)

//    result = landsatSceneLEVEL2(TOKEN, lat, lng)

//    if 'data' in result and 'results' in result['data']:
//        scenes = result['data']['results']
//        suitable_scene = None

//        for scene in scenes:
//            cloud_cover = scene.get('cloudCover', 100)  # Default to 100 if cloudCover not present
//            if cloud_cover <= acceptable_cloud_cover:
//                suitable_scene = scene
//                break  # Stop after finding the first suitable scene

//        if suitable_scene:
//            # Access the 'browse path' URL
//            browse_info = suitable_scene.get('browse', [{}])[0]
//            browse_path = browse_info.get('browsePath', 'N/A')
//            print(f"Found a scene with cloud cover {cloud_cover}%:")
//            print(f"Browse Image URL: {browse_path}")
//        else:
//            print(f"No scenes found with cloud cover less than or equal to {acceptable_cloud_cover}%.")

//    else:
//        print("No results found or error in response.")

//if __name__ == "__main__":
//    main()
