'use strict';

let openFolder = document.getElementById('openFolder');
let download = document.getElementById('download');
let spinnerDiv = document.getElementById('spinner');
// let config = chrome.extension.getBackgroundPage().config;

let localConfig = {
    baseUrl: 'https://localhost:5001/',
    apiUrl: 'https://localhost:5001/MamaDownload/',
    downloadUrl: function() {
        return this.apiUrl + 'Download';
    }
}

let app = {
    init: function() {
    },

    openFolder : function() {
    },

    download : function() {
        let currentUrl = '';

        chrome.tabs.query({'active': true, 'windowId': chrome.windows.WINDOW_ID_CURRENT},
            function(tabs){
                currentUrl = tabs[0].url;

                if(currentUrl && currentUrl.includes('youtube') && currentUrl.includes('watch')) {
                    spinnerDiv.classList.toggle('loader');
                    let url = localConfig.downloadUrl();
                    fetch(url, {
                        method: 'POST',
                        body: JSON.stringify({ YoutubeLink: currentUrl }),
                        mode: 'cors',
                        headers:{
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        }
                    })
                    .then(response => {
                        alert(response);
                        spinnerDiv.classList.toggle('loader');
                    })
                    .catch(err => {
                        spinnerDiv.classList.toggle('loader');
                    });
                }
            }
        );

    }
}

document.addEventListener("DOMContentLoaded", function() {
    app.init();
    openFolder.onclick = app.openFolder;
    download.onclick = app.download;
});
