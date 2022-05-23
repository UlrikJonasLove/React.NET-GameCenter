import { useFormikContext } from 'formik';
import { coordinateDto } from '../utils/models/utils.models';
import Map from '../utils/Map';

export const MapField = (props: mapFieldProps) => {
    const {values} = useFormikContext<any>();

    const handleMapClick = (coordinates: coordinateDto) => {
        values[props.latField] = coordinates.lat;
        values[props.lngField] = coordinates.lng;
    }
    return <Map coordinates={props.coordinates} handleMapClick={handleMapClick}/>
}

interface mapFieldProps {
    coordinates: coordinateDto[];
    latField: string;
    lngField: string;
}

MapField.defaultProps = {
    coordinates: []
}