import React, { useRef, useEffect, useState } from 'react';
import Map from 'ol/Map';
import View from 'ol/View';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import './OpenLayersMap.css'

interface MapProps {
    initialCenter: [number, number];
    initialZoom: number;
}

const OpenLayersMap: React.FC<MapProps> = ({initialCenter, initialZoom}) => {
    const mapRef = useRef<HTMLDivElement>(null);
    const [map, setMap] = useState<Map | null>(null);

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
                center: initialCenter,
                zoom: initialZoom,
            }),
        });

        setMap(mapObject);

        return () => {
            // destroy map object
            mapObject.dispose();
        };
    }, []);

    return <div ref={mapRef} className="map" />; // 使用 mapRef
};

export default OpenLayersMap;