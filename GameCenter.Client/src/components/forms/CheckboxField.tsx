import { Field } from "formik"

// Component for checkbox inputs, using props to get the field name and display name
export const CheckboxField = (props: checkboxFieldProps) => {
    return (
        <div className="mb-3 form-check">
            <Field className="form-check-input" id={props.field} name={props.field} type="checkbox" />
            <label htmlFor={props.field}>{props.displayName}</label>
        </div>
    )
}

interface checkboxFieldProps {
    displayName: string;
    field: string;
}
