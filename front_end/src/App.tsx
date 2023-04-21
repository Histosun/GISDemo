import React from "react";
import OpenLayersMap, { MapProps } from "./components/OpenLayersMap";


const App: React.FC = () => {
  const mapProps: MapProps = {
    center: [-75.6972, 45.4215],
    zoom: 10,
    maxZoom: 20,
    minZoom: 10
  }

  return (
    <OpenLayersMap {...mapProps} />
  );
};

export default App;
