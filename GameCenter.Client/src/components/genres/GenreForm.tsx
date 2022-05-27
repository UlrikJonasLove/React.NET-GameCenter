import { Form, Formik, FormikHelpers } from "formik";
import { Link } from "react-router-dom";
import { Button } from "../utils/Button";
import { TextField } from '../forms/TextField';
import * as Yup from 'yup';
import { genreCreationDTO } from "./models/Genres.model";

export const GenreForm = (props: genreFormProps) =>{
    return (
        <Formik initialValues={props.model}
        onSubmit={props.onSubmit}
        validationSchema={Yup.object({
            name: Yup.string().required("This field is required").max(50, 'max length is 50 characters').firstLetterUpperCase()
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

interface genreFormProps{
    model: genreCreationDTO;
    onSubmit(values: genreCreationDTO, action: FormikHelpers<genreCreationDTO>): void;
}