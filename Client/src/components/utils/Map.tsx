import { MapContainer, TileLayer, Marker, useMapEvent, Popup } from "react-leaflet";
import L from "leaflet";
import icon from 'leaflet/dist/images/marker-icon.png';
import iconShadow from 'leaflet/dist/images/marker-shadow.png';
import 'leaflet/dist/leaflet.css';
import  { coordinateDto }  from "./models/utils.models";
import { useState } from "react";

let defaultIcon = L.icon({
    iconUrl: icon,
    shadowUrl: iconShadow,
    iconAnchor: [16, 37]
});

L.Marker.prototype.options.icon = defaultIcon;

export default function Map(props: mapProps){
    const [coordinates, setCoordinates] = useState<coordinateDto[]>(props.coordinates);

    return (
        <MapContainer center={[57.78443337441883, 14.164452170239498]} zoom={14} style={{height: props.height}}>
            <TileLayer attribution="Game Center" 
            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"/>
            {props.readOnly ? null : <MapClick setCoordinates={coordinates => {
                setCoordinates([coordinates]);
                props.handleMapClick(coordinates);
            }} />}
            
            {coordinates.map((coordinate, index) => 
                <Marker key={index} position={[coordinate.lat, coordinate.lng]}>{coordinate.name ? 
                <Popup>{coordinate.name}</Popup> : null}</Marker> )}
        </MapContainer>
    )
}

interface mapProps {
    height: string;
    coordinates: coordinateDto[];
    handleMapClick(coordinates: coordinateDto): void;
    readOnly: boolean;

}

Map.defaultProps = {
    height: '500px',
    handleMapClick: () => {},
    readOnly: false
}

const MapClick = (props: mapClickProps) => {
    useMapEvent('click', eventArgs => {
        props.setCoordinates({lat: eventArgs.latlng.lat, lng: eventArgs.latlng.lng});
    })
    return null
}

interface mapClickProps {
    setCoordinates(coordinates: coordinateDto): void;
}