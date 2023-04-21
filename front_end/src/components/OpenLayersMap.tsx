import React, { useRef, useEffect } from 'react';
import Point from 'ol/geom/Point';
import Map from 'ol/Map';
import View from 'ol/View';
import {
    Circle as CircleStyle,
    Fill,
    Stroke,
    Style,
    Text,
} from 'ol/style';
import TileLayer from 'ol/layer/Tile';
import VectorLayer from 'ol/layer/Vector';
import OSM from 'ol/source/OSM';
import { Cluster, Vector as VectorSource } from 'ol/source';
import './OpenLayersMap.css';
import Feature from 'ol/Feature';

export interface MapProps {
    center: [number, number];
    zoom: number;
    minZoom: number | undefined;
    maxZoom: number | undefined;
}

const styleCache = {};

function initClusterLayer(): VectorLayer<VectorSource> {
    const features: Array<Feature> = [new Feature(new Point([ -76.063162442964796, 45.217294008430798 ]))];
    const source = new VectorSource({
        features: features,
    });

    const clusterSource = new Cluster({
        distance: 30,
        source: source,
    });
    
    return new VectorLayer({
        source: clusterSource,
        style: function (feature) {
            const size = feature.get('features').length;
            let style = styleCache[size];
            if (!style) {
                style = new Style({
                    image: new CircleStyle({
                        radius: 10,
                        stroke: new Stroke({
                            color: '#fff',
                        }),
                        fill: new Fill({
                            color: '#3399CC',
                        }),
                    }),
                    text: new Text({
                        text: size.toString(),
                        fill: new Fill({
                            color: '#fff',
                        }),
                    }),
                });
                styleCache[size] = style;
            }
            return style;
        },
    });
}

const OpenLayersMap: React.FC<MapProps> = (mapProps: MapProps) => {
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
                initClusterLayer()
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