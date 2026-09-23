// wwwroot/js/geo.js
// Call from Blazor: await JS.InvokeAsync<GeoCoords>("getLocation")

window.getLocation = () => new Promise((resolve, reject) => {
    if (!navigator.geolocation) {
        reject("Geolocation is not supported by this browser.");
        return;
    }
    navigator.geolocation.getCurrentPosition(
        pos => resolve({
            lat: pos.coords.latitude,
            lng: pos.coords.longitude
        }),
        err => reject(err.message),
        { enableHighAccuracy: true, timeout: 10000 }
    );
});
