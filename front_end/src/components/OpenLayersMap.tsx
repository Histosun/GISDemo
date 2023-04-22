import React, { useRef, useEffect, useState } from 'react';
import axios from 'axios'
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

class TrafficCollision {
    id: number;
    location: string;
    totalCollisions: number;
    f2015Total: number;
    f2016Total: number;
    f2017Total: number;
    f2018Total: number;
    f2019Total: number;
    geometry: Point;
}

const styleCache = {};

const featureStyle = function (feature) {
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
}

const OpenLayersMap: React.FC<MapProps> = (mapProps: MapProps) => {
    const mapRef = useRef<HTMLDivElement>(null);
    const [clickedFeatures, setClickedFeatures] = useState([]);

    useEffect(() => {
        if (!mapRef.current)
            return;

        // Create map
        const mapObject = new Map({
            target: mapRef.current,
            layers: [
                new TileLayer({
                    source: new OSM(),
                })
            ],
            view: new View({
                ...mapProps,
                projection: 'EPSG:4326'
            }),
        });

        axios.get('http://localhost:8080/TrafficCollisions/GetTrafficCollisions')
            .then(response => {
                var collisions = response.data;

                if (collisions.length < 0)
                    return;

                const features: Feature[] = [];

                for (var i = 0; i < collisions.length; ++i) {
                    var newFeature = new Feature(new Point(collisions[i].geometry.coordinates));
                    newFeature.setProperties(collisions[i].properties)
                    features.push(newFeature);
                }

                const source = new VectorSource({
                    features: features
                });

                const clusterSource = new Cluster({
                    distance: 30,
                    source: source,
                });

                const clusterLayer = new VectorLayer({
                    source: clusterSource,
                    style: featureStyle,
                });

                mapObject.addLayer(clusterLayer);


                mapObject.on('click', (e) => {
                    clusterLayer.getFeatures(e.pixel).then((clickedFeatures) => {
                        if (!clickedFeatures.length)
                            return;
                        var feature = clickedFeatures[0];
                        var properties = feature.getProperties();
                        console.log(properties.features);
                        setClickedFeatures(properties.features);
                    });
                });
            })
            .catch(error => {
                console.error(error);
            })

        return () => {
            // destroy map object
            mapObject.dispose();
        };


    }, []);

    return (
        <div>
            <div ref={mapRef} className="map" />
            <div>Collision Statistics: </div>
            {
                clickedFeatures.map(it => {
                    return (
                        <div key={it.ol_uid}>
                            <div>
                                Total Collisions: {it.getProperties()['total']}, Location: {it.getProperties()['Location']}
                            </div>
                        </div>
                    );
                })
            }
        </div>
    );
};

export default OpenLayersMap;