import { Form, Formik } from "formik";
import { actorFormProps } from "./interface/actor.model";
import { TextField } from "../forms/TextField";
import { DateField } from "../forms/DateField";
import { ImageField } from "../forms/ImageField";
import { MarkdownField } from "../forms/MarkdownField";
import { Button } from "../utils/Button";
import { Link } from "react-router-dom";
import * as Yup from "yup"

export const ActorForm = (props: actorFormProps) => {
    return(
        <Formik 
        initialValues={props.model}
        onSubmit={props.onSubmit}
        validationSchema={Yup.object({
            name: Yup.string().required("This field is required").firstLetterUpperCase(),
            dateOfBirth: Yup.date().nullable().required("This field is required")
        })}>
            {(formikProps) => (
                <Form>
                    <TextField displayName="Name" field="name"/>
                    <DateField displayName="Date of Birth" field="dateOfBirth"/>
                    <ImageField displayName="Picture" field="picture" imageURL={props.model.pictureURL} />
                    <MarkdownField displayName="Biography" field="biography" />
                    <Button disabled={formikProps.isSubmitting} type="submit">Save</Button>
                    <Link to="/actors" className="btn btn-secondary">Cancel</Link>
                </Form>
            )}
        </Formik>
    )
}