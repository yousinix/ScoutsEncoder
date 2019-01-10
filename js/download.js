/*
 * Get the latest release's assets download url
 */

const getUrl = async () =>
{
    const api_call = await fetch('https://api.github.com/repos/YoussefRaafatNasry/ScoutsEncoder/releases/latest');
    const data = await api_call.json();
    return { data };
}

$(function() {
    getUrl().then((response) => {
        document.getElementById("latest-version-download-link").href = response.data.assets[0].browser_download_url;
    })
});