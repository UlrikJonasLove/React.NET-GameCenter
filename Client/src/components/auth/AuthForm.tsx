import { Form, Formik, FormikHelpers } from "formik";
import { authCredentials } from "../../models/auth/auth.models";
import * as yup from 'yup';
import { TextField } from "../forms/TextField";
import { Button } from "../utils/Button";
import { Link } from "react-router-dom";

export const AuthForm = (props: authFormProps) => {
    return (
        <Formik
            initialValues={props.model}
            onSubmit={props.onSubmit}
            validationSchema={yup.object({
                email: yup.string().required("Email is required").email("You have to enter a valid email"),
                password: yup.string().required("Password is required")
            })}>
                {formikProps => (
                    <Form>
                        <TextField displayName="Email" field="email" />
                        <TextField displayName="Password" field="password" type="password" />

                        <Button disabled={formikProps.isSubmitting} type="submit">{props.btnText}</Button>
                        <Link to="/" className="btn btn-secondary">Cancel</Link>
                    </Form>
                )}
        </Formik>
    )
}

interface authFormProps {
    btnText: string;
    model: authCredentials;
    onSubmit(values: authCredentials, actions: FormikHelpers<authCredentials>): void;
}