import { Form, Formik } from "formik";
import { Link } from "react-router-dom";
import { genreFormProps } from "./Interface/GenreProps.model";
import Button from "../Utils/Button";
import TextField from '../forms/TextField';
import * as Yup from 'yup';

export default function GenreForm(props: genreFormProps) {
    return (
        <Formik initialValues={props.model}
        onSubmit={props.onSubmit}
        validationSchema={Yup.object({
            name: Yup.string().required("This field is required").firstLetterUpperCase()
        })}
        >
            {(FormikProps) => (
                <Form>
                    <TextField field="name" displayName="Name"/>

                    <Button disabled={FormikProps.isSubmitting} type="submit">Save</Button>
                    <Link className="btn btn-secondary" to="/genres">Cancel</Link>
                </Form>
            )}
        </Formik>
    )
}