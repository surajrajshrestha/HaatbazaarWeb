const CACHE_NAME = "haatbazaar-cache-v1";
const urlsToCache = [
  "/",
  "/index.html",
  "/css/styles.css",
  "/js/main.js",
  "/android-chrome-192x192.png",
  "/android-chrome-512x512.png",
  "/favicon.ico",
];

// Install event - cache files
self.addEventListener("install", (event) => {
  event.waitUntil(
    caches.open(CACHE_NAME).then((cache) => {
      //return cache.addAll(urlsToCache);
    })
  );
});

// Fetch event - serve cached content when offline
self.addEventListener("fetch", (event) => {
  event.respondWith(
    caches.match(event.request).then((response) => {
      if (response) {
        //return response;
      }
      //return fetch(event.request);
    })
  );
});

// Activate event - clean up old caches
self.addEventListener("activate", (event) => {
  const cacheWhitelist = [CACHE_NAME];
  event.waitUntil(
    caches.keys().then((cacheNames) => {
      return Promise
        .all
        /*cacheNames.map((cacheName) => {
          if (!cacheWhitelist.includes(cacheName)) {
            // return caches.delete(cacheName);
          }
        })*/
        ();
    })
  );
});
