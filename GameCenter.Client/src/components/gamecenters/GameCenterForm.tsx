import { Form, Formik } from "formik";
import { Link } from "react-router-dom";
import { TextField } from "../forms/TextField";
import { Button } from "../Utils/Button";
import { gameCenterForm } from "./interface/GameCenters.interface";
import * as Yup from "yup";

export default function GameCenterForm(props: gameCenterForm) {
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
                    <Button disabled={formikProps.isSubmitting} type="submit" >Save</Button>
                    <Link className="btn btn-secondary" to="/gamecenters">Cancel</Link>
                </Form>
            )}
        </Formik>
    )
}