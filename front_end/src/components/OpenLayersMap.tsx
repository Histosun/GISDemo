import React, { useRef, useEffect, useState } from 'react';
import Map from 'ol/Map';
import View from 'ol/View';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import './OpenLayersMap.css';

export interface MapProps {
    center: [number, number];
    zoom: number;
    minZoom: number | undefined;
    maxZoom: number | undefined;
}

const OpenLayersMap: React.FC<MapProps> = (mapProps : MapProps) => {
    const mapRef = useRef<HTMLDivElement>(null);

    useEffect(() => {
        if (!mapRef.current)
            return;

        // Create map
        const mapObject = new Map({
            target: mapRef.current,
            layers: [
                new TileLayer({
                    source: new OSM(),
                }),
            ],
            view: new View({
                ...mapProps,
                projection: 'EPSG:4326'
            }),
        });

        return () => {
            // destroy map object
            mapObject.dispose();
        };
    }, []);

    return <div ref={mapRef} className="map" />;
};

export default OpenLayersMap;