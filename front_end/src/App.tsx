import React from "react";
import OpenLayersMap from "./components/OpenLayersMap";


const App: React.FC = () => {
  return (
    <OpenLayersMap initialCenter={[-12080385, 7567433]} initialZoom={4}/>
  );
};

export default App;
