# SunnyBlog

## Introduction

This is a simple statistical GIS project on Ottawa traffic collisions from 2015 to 2019. The data is sourced from https://open.ottawa.ca/datasets/ottawa::traffic-collisions-by-location-2015-to-2019/explore?location=45.245030%2C-75.800230%2C2.54.

This project utilizes OpenLayers to display collision features as points and provides clustering functionality. Clicking on a feature displays a list of statistical information about the collision.



## Demo

### Feature Cluster

![Feature Point Cluster](./demo/cluster.gif)

### Display Feature Infomation

![Display feature info](./demo/detail.gif)

## Tech stack

The front end is using React, TypeScript and [OpenLayers](https://openlayers.org/).

The backend is using ASP.NET core, Web Api, C#, ef core.

The database is using PostgreSQL. uses PosgresSQL and Postgres GIS.

## Backend API

The backend includes only two simple APIs. One is a POST API for storing data, and the other is a GET API for retrieving data to be displayed on the frontend. Both APIs use JSON format for data exchange. The POST request accepts data in GeoJSON format, which is then converted into EF Core entity class for storage.

### POST

https://localhost:7102/TrafficCollisions/CreateTrafficCollisions

Sample request body:
```JSON
{
    "type": "FeatureCollection",
    "name": "Traffic_Collisions_by_Location_2015_to_2019",
    "crs": { "type": "name", "properties": { "name": "urn:ogc:def:crs:OGC:1.3:CRS84" } },
    "features": [
        { 
            "type": "Feature", 
            "properties": { 
                "Location": "UPPER DWYER HILL RD btwn HAMILTON SIDE RD & MCARTON RD (__3ZA4E9)", 
                "Total_Collisions": 10, 
                "F2015_Total": 2, 
                "F2016_Total": 3, 
                "F2017_Total": 3, 
                "F2018_Total": 1, 
                "F2019_Total": 1
            }, 
            "geometry": { 
                "type": "Point", 
                "coordinates": [ -76.063162442964796, 45.217294008430798 ] 
            } 
        }
    ]
}
```

Full Data can be downloaded [here](https://open.ottawa.ca/datasets/ottawa::traffic-collisions-by-location-2015-to-2019/explore?location=45.245030%2C-75.800230%2C2.54).