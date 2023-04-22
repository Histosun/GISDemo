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

The front end uses React, TypeScript and [OpenLayers](https://openlayers.org/).

The backend uses ASP.NET core, Web Api, C#, ef core.