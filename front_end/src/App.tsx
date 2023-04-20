import React from "react";
import OpenLayersMap, { MapProps } from "./components/OpenLayersMap";


const App: React.FC = () => {
  const mapProps: MapProps = {
    center: [-75.6972, 45.4215],
    zoom: 12,
    maxZoom: 20,
    minZoom: 12
  }

  return (
    <OpenLayersMap {...mapProps} />
  );
};

export default App;
