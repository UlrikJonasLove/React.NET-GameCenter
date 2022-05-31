import { ErrorMessage, Field } from "formik";

export const TextField = (props: textFieldProps) => {
  return (
    <div className="mb-3">
      <label htmlFor={props.field}>{props.displayName}</label>
      <Field name={props.field} id={props.field} className="form-control" />
      <ErrorMessage name={props.field}>
        {(msg) => <div className="text-danger">{msg}</div>}
      </ErrorMessage>
    </div>
  );
}

interface textFieldProps {
    field: string;
    displayName: string;
}
