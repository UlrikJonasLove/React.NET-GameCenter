import { Form, Formik, FormikHelpers } from "formik";
import { Link } from "react-router-dom";
import { TextField } from "../forms/TextField";
import { Button } from "../utils/Button";
import * as Yup from "yup";
import { MapField } from "../forms/MapField";
import { coordinateDto } from "../utils/models/utils.models";
import { gameCenterCreationDTO } from "./models/GameCenterDTO.model";

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

interface gameCenterForm {
    model: gameCenterCreationDTO;
    onSubmit(values: gameCenterCreationDTO, action: FormikHelpers<gameCenterCreationDTO>) : void;
}