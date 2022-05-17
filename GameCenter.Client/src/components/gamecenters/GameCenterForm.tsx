import { Form, Formik } from "formik";
import { Link } from "react-router-dom";
import { TextField } from "../forms/TextField";
import { Button } from "../Utils/Button";
import { gameCenterForm } from "./interface/GameCenters.interface";
import * as Yup from "yup";
import { MapField } from "../forms/MapField";
import coordinateDto from "../Utils/interface/utils.models";

export default function GameCenterForm(props: gameCenterForm) {
    const transformCoordinates = () : coordinateDto[] | undefined => {
        if(props.model.latitude && props.model.longitude){
            const response: coordinateDto = {lat: props.model.latitude,
                lng: props.model.longitude};
                return [response];
            }
            return undefined;
        }

    return (
        <Formik 
        initialValues={props.model} 
        onSubmit={props.onSubmit} 
        validationSchema={Yup.object({
            name: Yup.string().required("This field is required").firstLetterUpperCase()
        })}>
            {(formikProps) => (
                <Form>
                    <TextField displayName="Name" field="name" />

                    <div style={{marginBottom: '1rem'}}>
                        <MapField latField="latitude" lngField="longitude"
                        coordinates={transformCoordinates()}/>
                    </div>
                    <Button disabled={formikProps.isSubmitting} type="submit" >Save</Button>
                    <Link className="btn btn-secondary" to="/gamecenters">Cancel</Link>
                </Form>
            )}
        </Formik>
    )
}