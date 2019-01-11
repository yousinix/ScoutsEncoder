/*
 * Get the latest release's assets download url
 */

// OAuth2 key/secret
const client_id = "9949ebcbd8fb413c48ec";
const client_secret = "09cc4d3a04d2fdbdeb00a6c244728b8292000cbd";

const getUrl = async () =>
{
    const api_call = await fetch('https://api.github.com/repos/YoussefRaafatNasry/ScoutsEncoder/releases/latest?client_id=${client_id}&client_secret=${client_secret}');
    const data = await api_call.json();
    return { data };
}

$(function() {
    getUrl().then((response) => {
        document.getElementById("latest-version-download-link").href = response.data.assets[0].browser_download_url;
    })
});